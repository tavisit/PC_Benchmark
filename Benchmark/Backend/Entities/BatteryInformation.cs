using System;

namespace Benchmark.Backend.Entities
{
    public class BatteryInformation
    {
        private string name;
        private string status;
        private string estimatedChargeRemaining;
        private string designVoltage;
        private string designCapacity;
        private string fullChargeCapacity;
        private string maxRechargeTime;
        private string estimatedRunTime;

        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public string EstimatedChargeRemaining { get => estimatedChargeRemaining; set => estimatedChargeRemaining = value; }
        public string EstimatedRunTime { get => estimatedRunTime; set => estimatedRunTime = value; }
        public string DesignVoltage { get => designVoltage; set => designVoltage = value; }
        public string DesignCapacity { get => designCapacity; set => designCapacity = value; }
        public string FullChargeCapacity { get => fullChargeCapacity; set => fullChargeCapacity = value; }
        public string MaxRechargeTime { get => maxRechargeTime; set => maxRechargeTime = value; }

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
                    if (prop.Name == "EstimatedRunTime")
                    {
                        if (int.Parse(actualValue )> 1000)
                        {
                            actualValue = "Charging";
                        }
                        else
                        {
                            actualValue += " minutes";

                        }
                    }
                    else if (prop.Name == "EstimatedChargeRemaining")
                    {
                        actualValue += "%";
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
