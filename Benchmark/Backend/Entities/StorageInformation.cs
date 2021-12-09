using System;

namespace Benchmark.Backend.Entities
{
    public class StorageInformation
    {
        private string name;
        private string model;
        private string manufacturer;
        private string status;
        private string size;
        private string partitions;
        private string totalSectors;
        private string bytesPerSector;

        public string Name { get => name; set => name = value; }
        public string Model { get => model; set => model = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Status { get => status; set => status = value; }
        public string Partitions { get => partitions; set => partitions = value; }
        public string Size { get => size; set => size = value; }
        public string TotalSectors { get => totalSectors; set => totalSectors = value; }
        public string BytesPerSector { get => bytesPerSector; set => bytesPerSector = value; }

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
                    if (prop.Name == "Size")
                    {
                        long sizeInt = long.Parse(actualValue);
                        sizeInt /= 1000;
                        sizeInt /= 1000;
                        sizeInt /= 1000;
                        actualValue = sizeInt.ToString();
                        actualValue += " Gb";
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
