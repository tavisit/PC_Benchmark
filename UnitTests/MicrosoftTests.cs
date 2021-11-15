using NUnit.Framework;
using System.Collections.Generic;
using Benchmark.Backend.Entities;
using Benchmark.Backend.Utilities;
namespace UnitTests
{
    class MicrosoftTests
    {
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CpuDataTest()
        {
            CpuInformation cpuInformation;
            cpuInformation = Benchmark.Backend.MicrosoftBenchmark.CpuData();

            Assert.True(cpuInformation != null);
            Assert.True(cpuInformation.Manufacturer.ContainsLower("Intel"));
            Assert.True(cpuInformation.NrCores.EqualsLower("4"));
            Assert.True(cpuInformation.NrLogicalProcessors.EqualsLower("8"));
        }

        [Test]
        public void RamDataTest()
        {
            List<RamInformation> ramInformation;
            ramInformation = Benchmark.Backend.MicrosoftBenchmark.RamData();
            Assert.True(ramInformation != null);
            Assert.True(ramInformation[0] != null);
            Assert.True(ramInformation[0].Capacity.EqualsLower("17179869184"));
            Assert.True(ramInformation[0].MinVoltage.EqualsLower("1200"));
            Assert.True(ramInformation[0].MinVoltage.EqualsLower("1200"));
            Assert.True(ramInformation[0].Speed.EqualsLower("2400"));
        }

        [Test]
        public void BatteryDataTest()
        {
            BatteryInformation batteryInformation;
            batteryInformation = Benchmark.Backend.MicrosoftBenchmark.BatteryData();
            Assert.True(batteryInformation != null);
            Assert.True(batteryInformation.Name != null);
            Assert.True(batteryInformation.Status.EqualsLower("OK"));
        }

        [Test]
        public void StorageDataTest()
        {
            List<StorageInformation> storageInformation;
            storageInformation = Benchmark.Backend.MicrosoftBenchmark.StorageData();
            Assert.True(storageInformation != null);
            Assert.True(storageInformation[0] != null);
            Assert.True(storageInformation[1] != null);
            Assert.True(storageInformation[0].BytesPerSector.EqualsLower("512"));
            Assert.True(storageInformation[1].BytesPerSector.EqualsLower("512"));
            Assert.True(storageInformation[0].Model.EqualsLower("NVMe KINGSTON SA2000M"));
            Assert.True(storageInformation[1].Model.EqualsLower("ST1000LM035-1RK172"));
        }

        [Test]
        public void GpuDataTest()
        {
            List<GpuInformation> gpuInformation;
            gpuInformation = Benchmark.Backend.MicrosoftBenchmark.GpuData();
            Assert.True(gpuInformation != null);
            Assert.True(gpuInformation[0] != null);
            Assert.True(gpuInformation[1] != null);

            Assert.True(gpuInformation[0].Name.EqualsLower("NVIDIA GeForce GTX 1050 Ti"));
            Assert.True(gpuInformation[1].Name.EqualsLower("Intel(R) HD Graphics 630"));

            Assert.True(gpuInformation[0].VideoProcessor.EqualsLower("4293918720"));
            Assert.True(gpuInformation[1].VideoProcessor.EqualsLower("1073741824"));

            Assert.True(gpuInformation[0].VideoArchitecture.EqualsLower("VGA"));
            Assert.True(gpuInformation[1].VideoArchitecture.EqualsLower("VGA"));
        }
    }
}
