using NUnit.Framework;

namespace UnitTests
{
    class CpuUnitTests
    {
        Benchmark.Backend.CPU cpu;
        [SetUp]
        public void Setup()
        {
            cpu = new Benchmark.Backend.CPU();
        }

        [Test]
        public void FrequencyTest()
        {
            OneFrequencyTest();
            OneFrequencyTest();
            OneFrequencyTest();
            OneFrequencyTest();
        }

        [Test]
        public void OneFrequencyTest()
        {

            float cpuFrequencyValue = cpu.RunFrequencyTests();
            Assert.IsTrue(cpuFrequencyValue > 3);
        }

        [Test]
        public void SimpleOperationsTest()
        {
            OneSimpleOperationsTest();
            OneSimpleOperationsTest();
            OneSimpleOperationsTest();
            OneSimpleOperationsTest();
        }

        [Test]
        public void OneSimpleOperationsTest()
        {
            float cpuSimpleOperationsValue = cpu.RunSimpleOperationsTests();
            Assert.IsTrue(cpuSimpleOperationsValue < 5);
        }
    }
}
