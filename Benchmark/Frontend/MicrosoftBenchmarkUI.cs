using Benchmark.Backend.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benchmark.Frontend
{
    public partial class MicrosoftBenchmarkUI : Form
    {
        private CpuInformation cpuData;
        private List<GpuInformation> gpuData;
        private List<RamInformation> ramData;
        private List<StorageInformation> storageData;
        private BatteryInformation batteryData;

        public MicrosoftBenchmarkUI()
        {
            InitializeComponent();

            Parallel.Invoke(
                    () => {
                        cpuData = Backend.MicrosoftBenchmark.CpuData();
                        cpuTextBox.Text = cpuData.ToString();
                    },
                    () => {
                        gpuData = Backend.MicrosoftBenchmark.GpuData();
                        gpuTextBox.Text = "";
                        gpuData.ForEach(gpu => gpuTextBox.Text += gpu.ToString() + "\n");
                    },
                    () => {
                        ramData = Backend.MicrosoftBenchmark.RamData();
                        ramTextBox.Text = "";
                        ramData.ForEach(ram => ramTextBox.Text += ram.ToString() + "\n");
                    },
                    () => {
                        storageData = Backend.MicrosoftBenchmark.StorageData();
                        storageTextBox.Text = "";
                        storageData.ForEach(storageSolution => storageTextBox.Text += storageSolution.ToString() + "\n");
                    },
                    () => {
                        batteryData = Backend.MicrosoftBenchmark.BatteryData();
                        batteryTextBox.Text = batteryData.ToString();
                    }
                );            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
