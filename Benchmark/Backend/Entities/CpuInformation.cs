namespace Benchmark.Backend.Entities
{
    public class CpuInformation
    {
        private string procName;
        private string manufacturer;
        private string version;
        private string nrCores;
        private string nrLogicalProcessors;
        private string nrThreads;
        private string maximumClockSpeed;
        private string currentClockSpeed;

        public string ProcName { get => procName; set => procName = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Version { get => version; set => version = value; }
        public string NrCores { get => nrCores; set => nrCores = value; }
        public string NrLogicalProcessors { get => nrLogicalProcessors; set => nrLogicalProcessors = value; }
        public string NrThreads { get => nrThreads; set => nrThreads = value; }
        public string MaximumClockSpeed { get => maximumClockSpeed; set => maximumClockSpeed = value; }
        public string CurrentClockSpeed { get => currentClockSpeed; set => currentClockSpeed = value; }

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
                    if (prop.Name == "MaximumClockSpeed" || prop.Name == "CurrentClockSpeed")
                    {
                        actualValue += " MHz";
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
