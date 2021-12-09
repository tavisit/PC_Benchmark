namespace Benchmark.Backend.Entities
{
    public class GpuInformation
    {
        private string name;
        private string driverVersion;
        private string status;
        private string minRefreshRate;
        private string maxRefreshRate;
        private string videoArchitecture;
        private string videoMemoryType;
        private string videoProcessor;
        private string adapterRAM;

        public string Name { get => name; set => name = value; }
        public string DriverVersion { get => driverVersion; set => driverVersion = value; }
        public string Status { get => status; set => status = value; }
        public string MinRefreshRate { get => minRefreshRate; set => minRefreshRate = value; }
        public string MaxRefreshRate { get => maxRefreshRate; set => maxRefreshRate = value; }
        public string VideoArchitecture { get => videoArchitecture; set => videoArchitecture = value; }
        public string VideoMemoryType { get => videoMemoryType; set =>  videoMemoryType = value;}
        public string VideoProcessor { get => videoProcessor; set => videoProcessor = value; }
        public string AdapterRAM { get => adapterRAM; set => adapterRAM = value; }

        public override string ToString()
        {
            string toStringReturn = "";
            var properties = GetType().GetProperties();

            foreach (var prop in properties)
            {
                string actualValue = (string)prop.GetValue(this, null);
                if (actualValue == null)
                {
                    continue;
                }
                else
                {
                    if (prop.Name == "MinRefreshRate" || prop.Name == "MaxRefreshRate")
                    {
                        actualValue += " Hz";
                    }

                    toStringReturn += prop.Name + " : ";
                    toStringReturn += actualValue;
                    toStringReturn += "\n";
                }
            }

            return toStringReturn;
        }
    }
}
