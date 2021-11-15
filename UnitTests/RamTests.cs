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

        //[Test]
        //public void MIPSTest()
        //{
        //    float sequentialRAM = ram.SequentialAccess(32000000);
        //    float randomRAM = ram.RandomAccess(32000000);

        //    Assert.IsTrue(sequentialRAM > 0);
        //    Assert.IsTrue(randomRAM > 0);
        //}
    }
}
