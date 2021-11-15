using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Backend
{
    public class RAM
    {
        private uint _firstValue = 0x5555;
        private uint _secondValue = 0xAAAA;

        public float DimensionRAM()
        {
            return RandomAccess(32000);
        }

        public float SequentialAccess(int size)
        {
            uint[] setOfNumbers = new uint[size];

            for(int i=0;i<size;i++)
            {
                setOfNumbers[i] = _firstValue;
            }

            int errorCount = 0;
            for(int i=0;i<size;i++)
            {
                if(setOfNumbers[i]!=_firstValue)
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
            return 100*((float)errorCount/(float)size);
        }

        public float RandomAccess(int size)
        {
            List<uint> setOfNumbers = new List<uint>();

            for (int i = 0; i < size; i++)
            {
                setOfNumbers.Add(_firstValue);
            }

            int errorCount = 0;
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
            return 100 * ((float)errorCount / (float)size);
        }

    }
}
