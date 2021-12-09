using NUnit.Framework;

namespace UnitTests
{
    class RamTests
    {
        Benchmark.Backend.RAM ram;
        [SetUp]
        public void Setup()
        {
            ram = new Benchmark.Backend.RAM();
        }

        [Test]
        public void LightRAMTest()
        {
            float sequentialRAM = ram.SequentialAccess(1073741824, 1);
            float randomRAM = ram.RandomAccess(1073741824, 1);

            Assert.IsTrue(sequentialRAM == 100);
            Assert.IsTrue(randomRAM == 100);
        }

        [Test]
        public void MediumRAMTest()
        {
            float sequentialRAM = ram.SequentialAccess(1073741824, 32);
            float randomRAM = ram.RandomAccess(1073741824, 32);

            Assert.IsTrue(sequentialRAM == 100);
            Assert.IsTrue(randomRAM == 100);
        }

        [Test]
        public void StressRAMTest()
        {
            float sequentialRAM = ram.SequentialAccess(1073741824, 1024);
            float randomRAM = ram.RandomAccess(1073741824, 1024);

            Assert.IsTrue(sequentialRAM >= 0);
            Assert.IsTrue(randomRAM >= 0);
        }
    }
}
