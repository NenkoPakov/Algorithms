using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Sum_with_Limited_Amount_of_Coins
{
    public static class Program
    {
        public static void Main()
        {
            int[] coins = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            int combinations = GenerateAllCombinations(coins, targetSum);
            Console.WriteLine(combinations);
        }

        private static int GenerateAllCombinations(int[] coins, int targetSum)
        {
            int combinations = 0;
            HashSet<int> sums = new HashSet<int>() { 0 };

            foreach (int coin in coins)
            {
                IEnumerable<int> currentSums = sums.ToArray();

                foreach (int sum in currentSums)
                {
                    int currentSum = coin + sum;

                    sums.Add(currentSum);

                    if (currentSum == targetSum)
                    {
                        combinations++;
                    }
                }
            }

            return combinations;
        }
    }
}