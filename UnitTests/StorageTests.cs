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
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", 8096, 1);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void LightSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", 8096, 1);

            Assert.IsTrue(storageTest == 100);

            storageTest = storage.FileAccess(@"E:\\", 8096, 1);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void MediumSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", 8096, 32);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void MediumSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", 8096, 32);

            Assert.IsTrue(storageTest == 100);

            storageTest = storage.FileAccess(@"E:\\", 8096, 32);

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void StressSystemDriveTest()
        {
            float storageTest = storage.FileAccess(@"C:\\Program Files\\BenchmarkPC\\", 8096, 1024);

            TestContext.Progress.WriteLine("FileAccess: " + storageTest.ToString());

            Assert.IsTrue(storageTest == 100);
        }

        [Test]
        public void StressSsdDriveTest()
        {
            float storageTest = storage.FileAccess(@"D:\\", 8096, 1024);

            TestContext.Progress.WriteLine("FileAccess: " + storageTest.ToString());
            Assert.IsTrue(storageTest == 100);

            storageTest = storage.FileAccess(@"E:\\", 8096, 1024);
            TestContext.Progress.WriteLine("FileAccess: " + storageTest.ToString());

            Assert.IsTrue(storageTest == 100);
        }
    }
}
