using System;
using System.IO;
using System.Windows.Forms;

namespace Benchmark.Frontend
{
    public partial class ComputedBenchmark : Form
    {

        string ramChoice = "Light";
        string storageChoice = "Light";
        string pathSelected = "";


        public ComputedBenchmark()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectionFileTextBox.Text = "Folder Selected:\n"+fbd.SelectedPath;
                    pathSelected = fbd.SelectedPath;

                    if (fbd.SelectedPath.Contains("C:\\"))
                    {
                        MessageBox.Show("The Benchmark will fail if not started in admin mode", "Message");
                    }
                }
            }
        }

        private void runButtonCPU_Click(object sender, EventArgs e)
        {
            runButtonRAM.Enabled = false;
            runButtonStorage.Enabled = false;
            runButtonCPU.Enabled = false;
            MessageBox.Show("The CPU Benchmark is running!", "Message");

            Benchmark.Backend.CPU cpu = new Backend.CPU();
            float mipsHard = cpu.RunMIPSTests();
            cpuTextBox.Text = "MIPS: " + mipsHard + "\n";
            float simpleOperations = cpu.RunSimpleOperationsTests();
            cpuTextBox.Text += "Cycles for simple operations: " + simpleOperations;

            MessageBox.Show("The CPU Benchmark has finished!", "Message");
            runButtonRAM.Enabled = true;
            runButtonStorage.Enabled = true;
            runButtonCPU.Enabled = true;
        }

        private void runButtonRAM_Click(object sender, EventArgs e)
        {

            runButtonRAM.Enabled = false;
            runButtonStorage.Enabled = false;
            runButtonCPU.Enabled = false;
            MessageBox.Show("The RAM Benchmark is running!", "Message");
            ramTextBox.Text = ramTypeTest();
            MessageBox.Show("The RAM Benchmark has finished!", "Message");
            runButtonRAM.Enabled = true;
            runButtonStorage.Enabled = true;
            runButtonCPU.Enabled = true;
        }

        private void runButtonStorage_Click(object sender, EventArgs e)
        {
            if(pathSelected == "")
            {
                MessageBox.Show("You have to select a place to run the test!", "Message");
                return;
            }

            runButtonRAM.Enabled = false;
            runButtonStorage.Enabled = false;
            runButtonCPU.Enabled = false;
            MessageBox.Show("The Storage Benchmark is running!", "Message");
            storageTextBox.Text = storageTypeTest(pathSelected);
            MessageBox.Show("The Storage Benchmark has finished!", "Message");
            runButtonRAM.Enabled = true;
            runButtonStorage.Enabled = true;
            runButtonCPU.Enabled = true;

        }

        private void ramComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string selectedValue = cmb.SelectedItem.ToString();
            selectedValue = selectedValue.Substring(0, selectedValue.IndexOf(" "));
            ramChoice = selectedValue;
        }

        private void storageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string selectedValue = cmb.SelectedItem.ToString();
            selectedValue = selectedValue.Substring(0, selectedValue.IndexOf(" "));
            storageChoice = selectedValue;
        }

        private string ramTypeTest()
        {

            Backend.RAM ram = new Backend.RAM();
            float sequentialReturn = 0.0f;
            float randomReturn = 0.0f;
            switch (ramChoice)
            {
                case "Light":
                    sequentialReturn = ram.SequentialAccess(67108864, 16);
                    randomReturn = ram.RandomAccess(67108864, 16);
                    break;
                case "Medium":
                    sequentialReturn = ram.SequentialAccess(67108864, 32*8);
                    randomReturn = ram.RandomAccess(67108864, 32 * 16);
                    break;
                case "Stress":
                    sequentialReturn = ram.SequentialAccess(67108864, 128 * 8);
                    randomReturn = ram.RandomAccess(67108864, 128 * 16);
                    break;
                case "Extreme":
                    sequentialReturn = ram.SequentialAccess(67108864, 128 * 16);
                    randomReturn = ram.RandomAccess(67108864, 1024 * 16);
                    break;
            }

            return "RAM health is\n" + 
                    "Sequential read/write at " + sequentialReturn.ToString() + "\n" + 
                    "Random read/write at " + randomReturn.ToString();

        }

        private string storageTypeTest(string path)
        {
            Backend.Storage storage = new Backend.Storage();
            float returnValue = 0.0f;
            switch (storageChoice)
            {
                case "Light":
                    returnValue = storage.FileAccess(path, 8096*16, 1);
                    break;
                case "Medium":
                    returnValue = storage.FileAccess(path, 8096* 16, 5);
                    break;
                case "Stress":
                    returnValue = storage.FileAccess(path, 8096* 16, 16);
                    break;
                case "Extreme":
                    returnValue = storage.FileAccess(path, 8096* 16, 64);
                    break;
            }

            return "The health of the storage at " + path + " is \n" +
                returnValue.ToString();
        }

        private void ComputedBenchmark_Load(object sender, EventArgs e)
        {

        }
    }
}
