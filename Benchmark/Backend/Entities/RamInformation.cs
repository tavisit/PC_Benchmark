using System;

namespace Benchmark.Backend.Entities
{
    public class RamInformation
    {
        private string name;
        private string status;
        private string speed;
        private string capacity;
        private string minVoltage;
        private string maxVoltage;
        private string dataWidth;
        private string totalWidth;

        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public string Speed { get => speed; set => speed = value; }
        public string Capacity { get => capacity; set => capacity = value; }
        public string MinVoltage { get => minVoltage; set => minVoltage = value; }
        public string MaxVoltage { get => maxVoltage; set => maxVoltage = value; }
        public string DataWidth { get => dataWidth; set => dataWidth = value; }
        public string TotalWidth { get => totalWidth; set => totalWidth = value; }

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
                    if (prop.Name == "Capacity")
                    {
                        long sizeInt = long.Parse(actualValue);
                        sizeInt /= 1024;
                        sizeInt /= 1024;
                        sizeInt /= 1024;
                        actualValue = sizeInt.ToString();
                        actualValue += " Gb";
                    }
                    else if (prop.Name == "Speed")
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
