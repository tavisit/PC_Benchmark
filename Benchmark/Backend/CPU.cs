using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Numerics;

namespace Benchmark.Backend
{
    public class CPU
    {
        public CPU()
        {

        }
        /// <summary>
        /// Run all the frequency tests and measure their execution time
        /// </summary>
        /// <returns></returns>
        public float RunFrequencyTests()
        {
            int nrTests = 3;
            float averageCPU = 0;
            int processorCount = Environment.ProcessorCount;
            // For every physical processor
            for (int i=0;i< processorCount; i++)
            {
                // Enable the current processor and set the affinity to it
                foreach (ProcessThread pt in Process.GetCurrentProcess().Threads)
                {
                    pt.IdealProcessor = i;
                    pt.ProcessorAffinity = (IntPtr)(1 << i);
                }
                // measure the time passed for each of the available algorithms
                float currentCPUFrequency = BenchmarkSHA256(10000) + BenchmarkPower(10000) + BenchmarkForLoops(1000);
                averageCPU += currentCPUFrequency;
            }
            averageCPU /= (processorCount * nrTests);
            return averageCPU;
        }

        /// <summary>
        /// Run all the simple operation tests and measure their execution time
        /// </summary>
        /// <returns></returns>
        public float RunSimpleOperationsTests()
        {
            float averageCPU = 0;
            int processorCount = Environment.ProcessorCount;
            // For every physical processor
            int nrTests = 100;
            for (int i = 0; i < processorCount; i++)
            {
                // Enable the current processor and set the affinity to it
                foreach (ProcessThread pt in Process.GetCurrentProcess().Threads)
                {
                    pt.IdealProcessor = i;
                    pt.ProcessorAffinity = (IntPtr)(1 << i);
                }
                // measure the time passed for each of the available algorithms
                averageCPU += BenchmarkSimpleOperations(nrTests);
            }
            averageCPU /= (nrTests * nrTests * 2);
            averageCPU /= processorCount;
            return averageCPU;
        }

        /// <summary>
        /// Run a benchmark which runs a simple string to sha256 algorithm and measure its execution time
        /// </summary>
        /// <param name="nrTests"></param>
        /// <returns></returns>
        private float BenchmarkSHA256(int nrTests)
        {
            Stopwatch swTotal = new Stopwatch();
            BigInteger averageTimeSha256 = new BigInteger(0);
            for(int i=0;i< nrTests; i++)
            {
                Stopwatch sw = new Stopwatch();
                string data = RandomString(256);
                sw.Start();
                swTotal.Start();
                string returnSha256 = ComputeSha256Hash(data);
                sw.Stop();
                swTotal.Stop();
                // add to the average the partial execution time
                averageTimeSha256 = BigInteger.Add(averageTimeSha256, new BigInteger(sw.Elapsed.Ticks));
            }
            averageTimeSha256 = BigInteger.Divide(averageTimeSha256, new BigInteger(nrTests));
            return ((float)((float)averageTimeSha256 / (swTotal.Elapsed.TotalMilliseconds)));
        }
        /// <summary>
        /// Run a benchmark which runs the power function and measure its execution time
        /// </summary>
        /// <param name="nrTests"></param>
        /// <returns></returns>
        private float BenchmarkPower(int nrTests)
        {
            Stopwatch swTotal = new Stopwatch();
            BigInteger averageTimePower = new BigInteger(0);
            for (int i = 0; i < nrTests; i++)
            {
                Stopwatch sw = new Stopwatch();
                BigInteger result = new BigInteger(0);
                BigInteger a = new BigInteger(2);
                int b = 128;
                sw.Start();
                swTotal.Start();
                result = BigInteger.Pow(a, b);
                sw.Stop();
                swTotal.Stop();
                // add to the average the partial execution time
                averageTimePower = BigInteger.Add(averageTimePower, new BigInteger(sw.Elapsed.Ticks));
                sw.Reset();
            }

            averageTimePower = BigInteger.Divide(averageTimePower, new BigInteger(nrTests));
            return ((float)((float)averageTimePower / (swTotal.Elapsed.TotalMilliseconds)));
        }
        /// <summary>
        /// Run a benchmark which runs a big loop and measure its execution time
        /// </summary>
        /// <param name="nrTests"></param>
        /// <returns></returns>
        private float BenchmarkForLoops(int nrTests)
        {
            Stopwatch swTotal = new Stopwatch();
            BigInteger averageTimeForLoops = new BigInteger(0);
            for (int i = 0; i < nrTests; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                swTotal.Start();
                bool a = true;
                for(int j=0;j< nrTests; j++)
                {
                    for(int k=0;k< nrTests; k++)
                    {
                        a = !a;
                    }
                }
                swTotal.Stop();
                sw.Stop();
                // add to the average the partial execution time
                averageTimeForLoops = BigInteger.Add(averageTimeForLoops, new BigInteger(sw.Elapsed.Ticks));
                sw.Reset();
            }

            averageTimeForLoops = BigInteger.Divide(averageTimeForLoops, new BigInteger(nrTests));
            return ((float)((float)averageTimeForLoops / (swTotal.Elapsed.TotalMilliseconds)));
        }

        private int BenchmarkSimpleOperations(int nrTests)
        {
            long averageSimpleOperations = 0;
            do
            {
                averageSimpleOperations = 0;
                for (int times = 0; times < nrTests; times++)
                {
                    long a = 0;
                    for (int i = 0; i < nrTests; i++)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        a = a + 1;
                        sw.Stop();
                        averageSimpleOperations += sw.ElapsedTicks;
                    }
                    for (int i = 0; i < nrTests; i++)
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        a = a - 1;
                        sw.Stop();
                        averageSimpleOperations += sw.ElapsedTicks;
                    }
                }

            } while (averageSimpleOperations <= (nrTests * nrTests * 2));
            
            
            return (int)averageSimpleOperations; ;
        }

        /// <summary>
        /// Creates a random string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Computes the SHA256 hash of a string
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        private string ComputeSha256Hash(string rawData)
        { 
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
