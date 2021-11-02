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
        public void MIPSTest()
        {
            OneMIPSTest();
            OneMIPSTest();
            OneMIPSTest();
            OneMIPSTest();
        }

        [Test]
        public void OneMIPSTest()
        {

            float cpuMIPSValue = cpu.RunMIPSTests();
            Assert.IsTrue(cpuMIPSValue > 3.5);
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
