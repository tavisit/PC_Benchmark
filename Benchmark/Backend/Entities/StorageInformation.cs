namespace Benchmark.Backend.Entities
{
    public class StorageInformation
    {
        private string name;
        private string model;
        private string bytesPerSector;
        private string size;
        private string status;
        private string totalSectors;
        private string partitions;
        private string manufacturer;

        public string Name { get => name; set => name = value; }
        public string Model { get => model; set => model = value; }
        public string BytesPerSector { get => bytesPerSector; set => bytesPerSector = value; }
        public string Size { get => size; set => size = value; }
        public string Status { get => status; set => status = value; }
        public string TotalSectors { get => totalSectors; set => totalSectors = value; }
        public string Partitions { get => partitions; set => partitions = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
    }
}
