using NUnit.Framework;

namespace UnitTests
{
    class StorageTests
    {
        private int _storageSpaceAllocated = 8096 * 16;

        Benchmark.Backend.Storage storage;
        [SetUp]
        public void Setup()
        {
            storage = new Benchmark.Backend.Storage();
        }

        [Test]
        public void LightSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", _storageSpaceAllocated, 1);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void LightSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", _storageSpaceAllocated, 1);

            Assert.IsTrue(storageTest == 100);

            storageTest = storage.FileAccess(@"E:\\", _storageSpaceAllocated, 1);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void MediumSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", _storageSpaceAllocated, 6);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void MediumSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", _storageSpaceAllocated, 5);

            Assert.IsTrue(storageTest == 100);

            storageTest = storage.FileAccess(@"E:\\", _storageSpaceAllocated, 5);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void StressSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", _storageSpaceAllocated, 32);

            TestContext.Progress.WriteLine("FileAccess: " + storageTest.ToString());

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void StressSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", _storageSpaceAllocated, 32);

            TestContext.Progress.WriteLine("FileAccess: " + storageTest.ToString());
            Assert.IsTrue(storageTest == 100);

            storageTest = storage.FileAccess(@"E:\\", _storageSpaceAllocated, 32);
            TestContext.Progress.WriteLine("FileAccess: " + storageTest.ToString());

            Assert.IsTrue(storageTest == 100);
        }
    }
}
