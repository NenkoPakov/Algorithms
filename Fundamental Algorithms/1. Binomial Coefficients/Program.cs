using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Binomial_Coefficients
{
    public static class Program
    {
        private static Dictionary<string, long> binoms = new Dictionary<string, long>();

        public static void Main()
        {
            int rowIndex = int.Parse(Console.ReadLine());
            int colIndex = int.Parse(Console.ReadLine());

            long binomCoef = CalcBinomCoef(rowIndex, colIndex);
            Console.WriteLine(binomCoef);
        }

        private static long CalcBinomCoef(int rowIndex, int colIndex)
        {
            if (colIndex==0 || colIndex==rowIndex)
            {
                return 1;
            }

            string compositeKey = $"{rowIndex}-{colIndex}";
            string twinCompositeKey = $"{rowIndex}-{rowIndex-colIndex}";


            if (binoms.ContainsKey(compositeKey))
            {
                return binoms[compositeKey];
            }

            if (binoms.ContainsKey(twinCompositeKey))
            {
                return binoms[compositeKey];
            }

            long currentBinom = CalcBinomCoef(rowIndex - 1, colIndex - 1) + CalcBinomCoef(rowIndex - 1, colIndex);

            binoms.TryAdd(compositeKey, currentBinom);
            binoms.TryAdd(twinCompositeKey, currentBinom);

            return currentBinom;
        }
    }
}
