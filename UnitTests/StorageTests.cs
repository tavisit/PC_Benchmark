using NUnit.Framework;

namespace UnitTests
{
    class StorageTests
    {
        Benchmark.Backend.Storage storage;
        [SetUp]
        public void Setup()
        {
            storage = new Benchmark.Backend.Storage();
        }

        [Test]
        public void LightSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", 32000, 1);

            Assert.IsTrue(storageTest == 0);
        }

        [Test]
        public void LightSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", 32000, 1);

            Assert.IsTrue(storageTest == 0);

            storageTest = storage.FileAccess(@"E:\\", 32000, 1);

            Assert.IsTrue(storageTest == 0);
        }

        [Test]
        public void MediumSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", 32000, 32);

            Assert.IsTrue(storageTest == 0);
        }

        [Test]
        public void MediumSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", 32000, 32);

            Assert.IsTrue(storageTest == 0);

            storageTest = storage.FileAccess(@"E:\\", 32000, 32);

            Assert.IsTrue(storageTest == 0);
        }

        [Test]
        public void StressSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", 32000, 10240);

            Assert.IsTrue(storageTest == 0);
        }

        [Test]
        public void StressSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", 32000, 10240);

            Assert.IsTrue(storageTest == 0);

            storageTest = storage.FileAccess(@"E:\\", 32000, 10240);

            Assert.IsTrue(storageTest == 0);
        }
    }
}
