using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Connecting_Cables
{
    public static class Program
    {
        public static void Main()
        {
            int[] cables = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int pairs = FindAllPairs(cables);
            Console.WriteLine($"Maximum pairs connected: {pairs}");
        }

        private static int FindAllPairs(int[] cables)
        {
            int cablesCount = cables.Length;
            int[,] pairs = new int[cablesCount + 1, cablesCount + 1];

            for (int i = 0; i <= cablesCount; i++)
            {
                pairs[0, i] = pairs[i, 0] = 0;
            }

            for (int idx = 1; idx <= cablesCount; idx++)
            {
                for (int cableIdx = 1; cableIdx <= cablesCount; cableIdx++)
                {
                    int currentPairsCount = Math.Max(pairs[idx - 1, cableIdx], pairs[idx, cableIdx - 1]);
                    pairs[idx, cableIdx] = idx != cables[cableIdx-1] ? currentPairsCount : currentPairsCount + 1;
                }
            }

            return pairs[cablesCount, cablesCount];
        }
    }
}
