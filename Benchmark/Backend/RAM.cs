using System.Collections.Generic;
using NUnit.Framework;

namespace Benchmark.Backend
{
    public class RAM
    {
        private readonly uint _firstValue = 0x5555;
        private readonly uint _secondValue = 0xAAAA;

        public float SequentialAccess(int size, int repeating)
        {
            uint[] setOfNumbers = new uint[size];
            int errorCount = 0;

            for (int repeat = 0;repeat<repeating;repeat++)
            {
                if(repeat % 32 == 0)
                {
                    TestContext.Progress.WriteLine("SequentialAccess: "+repeat.ToString());
                }

                for (int i = 0; i < size; i++)
                {
                    setOfNumbers[i] = _firstValue;
                }

                for (int i = 0; i < size; i++)
                {
                    if (setOfNumbers[i] != _firstValue)
                    {
                        errorCount++;
                    }
                }

                for (int i = 0; i < size; i++)
                {
                    setOfNumbers[i] = _secondValue;
                }

                for (int i = 0; i < size; i++)
                {
                    if (setOfNumbers[i] != _secondValue)
                    {
                        errorCount++;
                    }
                }
            }
            
            return 100 - 100*((float)errorCount/(float)size);
        }

        public float RandomAccess(int size, int repeating)
        {
            List<uint> setOfNumbers = new List<uint>();
            int errorCount = 0;

            for (int repeat = 0; repeat < repeating; repeat++)
            {
                if (repeat % 32 == 0)
                {
                    TestContext.Progress.WriteLine("RandomAccess: " + repeat.ToString());
                }

                setOfNumbers.Clear();
                for (int i = 0; i < size; i++)
                {
                    setOfNumbers.Add(_firstValue);
                }

                for (int i = 0; i < size; i++)
                {
                    if (setOfNumbers[i] != _firstValue)
                    {
                        errorCount++;
                    }
                }

                setOfNumbers.Clear();
                for (int i = 0; i < size; i++)
                {
                    setOfNumbers.Add(_secondValue);
                }

                for (int i = 0; i < size; i++)
                {
                    if (setOfNumbers[i] != _secondValue)
                    {
                        errorCount++;
                    }
                }
            }
            return 100 - 100 * ((float)errorCount / (float)size);
        }

    }
}
