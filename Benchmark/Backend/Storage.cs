using NUnit.Framework;
using System.IO;

namespace Benchmark.Backend
{
    public class Storage
    {
        private readonly uint _firstValue = 0x5555;
        private readonly uint _secondValue = 0xAAAA;

        public float FileAccess(string path,int size, int repeating)
        {
            path += "BenchmarkStorage.txt";
            int errorCount = 0;

            for (int repeat = 0; repeat < repeating; repeat++)
            {
                if (repeat % 32 == 0)
                {
                    TestContext.Progress.WriteLine("FileAccess: " + repeat.ToString());
                }

                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }catch(IOException)
                {
                    return -1f;
                }

                string writingValue = "";
                for (int i = 0; i < size; i++)
                {
                    writingValue += _firstValue.ToString() + "\n";
                }
                File.AppendAllText(path, writingValue);

                foreach (string line in File.ReadLines(path))
                {
                    if(_firstValue.ToString() != line)
                    {
                        errorCount++;
                    }
                }

                try
                {
                    File.Delete(path);
                }
                catch (IOException)
                {
                    return -1f;
                }

                writingValue = "";
                for (int i = 0; i < size; i++)
                {
                    writingValue += _secondValue.ToString() + "\n";
                }
                File.AppendAllText(path, writingValue);

                foreach (string line in File.ReadLines(path))
                {
                    if (_secondValue.ToString() != line)
                    {
                        errorCount++;
                    }
                }
                File.Delete(path);
            }

            return 100-100 * ((float)errorCount / (float)size);
        }
    }
}
