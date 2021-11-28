namespace Benchmark.Backend.Entities
{
    public class RamInformation
    {
        private string name;
        private string speed;
        private string minVoltage;
        private string maxVoltage;
        private string status;
        private string capacity;
        private string dataWidth;
        private string totalWidth;

        public string Name { get => name; set => name = value; }
        public string Speed { get => speed; set => speed = value; }
        public string MinVoltage { get => minVoltage; set => minVoltage = value; }
        public string MaxVoltage { get => maxVoltage; set => maxVoltage = value; }
        public string Status { get => status; set => status = value; }
        public string Capacity { get => capacity; set => capacity = value; }
        public string DataWidth { get => dataWidth; set => dataWidth = value; }
        public string TotalWidth { get => totalWidth; set => totalWidth = value; }
    }
}
