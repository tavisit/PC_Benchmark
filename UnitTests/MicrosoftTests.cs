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
            Assert.True(cpuInformation.Manufacturer.ContainsLower("AuthenticAMD"));
            Assert.True(cpuInformation.NrCores.EqualsLower("8"));
            Assert.True(cpuInformation.NrLogicalProcessors.EqualsLower("16"));
            Assert.True(cpuInformation.MaximumClockSpeed.EqualsLower("2901"));
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
            Assert.True(ramInformation[0].Speed.EqualsLower("3200"));
            Assert.True(ramInformation[0].DataWidth.EqualsLower("64"));
            Assert.True(ramInformation[0].TotalWidth.EqualsLower("64"));

            Assert.True(ramInformation[1] != null);
            Assert.True(ramInformation[1].Capacity.EqualsLower("17179869184"));
            Assert.True(ramInformation[1].MinVoltage.EqualsLower("1200"));
            Assert.True(ramInformation[1].MinVoltage.EqualsLower("1200"));
            Assert.True(ramInformation[1].Speed.EqualsLower("3200"));
            Assert.True(ramInformation[1].DataWidth.EqualsLower("64"));
            Assert.True(ramInformation[1].TotalWidth.EqualsLower("64"));
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

            Assert.True(storageInformation[0].Model.EqualsLower("SAMSUNG MZVLQ1T0HBLB-00B00"));
            Assert.True(storageInformation[1].Model.EqualsLower("KINGSTON SA2000M8500G"));

            Assert.True(storageInformation[0].Size.EqualsLower("1024203640320"));
            Assert.True(storageInformation[1].Size.EqualsLower("500105249280"));
        }

        [Test]
        public void GpuDataTest()
        {
            List<GpuInformation> gpuInformation;
            gpuInformation = Benchmark.Backend.MicrosoftBenchmark.GpuData();
            Assert.True(gpuInformation != null);
            Assert.True(gpuInformation[0] != null);
            Assert.True(gpuInformation[1] != null);

            Assert.True(gpuInformation[0].Name.EqualsLower("AMD Radeon(TM) Graphics"));
            Assert.True(gpuInformation[1].Name.EqualsLower("NVIDIA GeForce RTX 3060 Laptop GPU"));

            Assert.True(gpuInformation[0].VideoProcessor.EqualsLower("536870912"));
            Assert.True(gpuInformation[1].VideoProcessor.EqualsLower("4293918720"));

            Assert.True(gpuInformation[0].VideoArchitecture.EqualsLower("VGA"));
            Assert.True(gpuInformation[1].VideoArchitecture.EqualsLower("VGA"));
        }
    }
}
