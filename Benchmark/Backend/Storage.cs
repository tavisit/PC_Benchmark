using System.IO;

namespace Benchmark.Backend
{
    public class Storage
    {
        private uint _firstValue = 0x5555;
        private uint _secondValue = 0xAAAA;

        public float FileAccess(string path,int size, int repeating)
        {
            path += "BenchmarkStorage.txt";
            int errorCount = 0;

            for (int repeat = 0; repeat < repeating; repeat++)
            {
                if(File.Exists(path))
                {
                    File.Delete(path);
                }

                for (int i = 0; i < size; i++)
                {
                    File.AppendAllText(path, _firstValue.ToString()+"\n");
                }

                foreach (string line in File.ReadLines(path))
                {
                    if(_firstValue.ToString() != line)
                    {
                        errorCount++;
                    }
                }
                File.Delete(path);
                for (int i = 0; i < size; i++)
                {

                    File.AppendAllText(path, _secondValue.ToString() + "\n");
                }

                foreach (string line in File.ReadLines(path))
                {
                    if (_secondValue.ToString() != line)
                    {
                        errorCount++;
                    }
                }
                File.Delete(path);
            }

            return 100 * ((float)errorCount / (float)size);
        }
    }
}
