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
            float cpuFrequencyValue = cpu.RunFrequencyTests();
            Assert.IsTrue(cpuFrequencyValue > 2.4);
            cpuFrequencyValue = cpu.RunFrequencyTests();
            Assert.IsTrue(cpuFrequencyValue > 2.4);
            cpuFrequencyValue = cpu.RunFrequencyTests();
            Assert.IsTrue(cpuFrequencyValue > 2.4);
            cpuFrequencyValue = cpu.RunFrequencyTests();
            Assert.IsTrue(cpuFrequencyValue > 2.4);
            cpuFrequencyValue = cpu.RunFrequencyTests();
            Assert.IsTrue(cpuFrequencyValue > 2.4);
        }

        [Test]
        public void SimpleOperationsTest()
        {
            float cpuSimpleOperationsValue = cpu.RunSimpleOperationsTests();
            Assert.IsTrue(cpuSimpleOperationsValue < 5);
            cpuSimpleOperationsValue = cpu.RunSimpleOperationsTests();
            Assert.IsTrue(cpuSimpleOperationsValue < 5);
            cpuSimpleOperationsValue = cpu.RunSimpleOperationsTests();
            Assert.IsTrue(cpuSimpleOperationsValue < 5);
            cpuSimpleOperationsValue = cpu.RunSimpleOperationsTests();
            Assert.IsTrue(cpuSimpleOperationsValue < 5);
            cpuSimpleOperationsValue = cpu.RunSimpleOperationsTests();
            Assert.IsTrue(cpuSimpleOperationsValue < 5);
        }
    }
}
