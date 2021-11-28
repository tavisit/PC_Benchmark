namespace Benchmark.Backend.Entities
{
    public class BatteryInformation
    {
        private string name;
        private string status;
        private string estimatedChargeRemaining;
        private string fullChargeCapacity;
        private string designCapacity;
        private string maxRechargeTime;
        private string designVoltage;

        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public string EstimatedChargeRemaining { get => estimatedChargeRemaining; set => estimatedChargeRemaining = value; }
        public string FullChargeCapacity { get => fullChargeCapacity; set => fullChargeCapacity = value; }
        public string DesignCapacity { get => designCapacity; set => designCapacity = value; }
        public string MaxRechargeTime { get => maxRechargeTime; set => maxRechargeTime = value; }
        public string DesignVoltage { get => designVoltage; set => designVoltage = value; }
    }
}
