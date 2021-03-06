using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Sum_with_Unlimited_Amount_of_Coins
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
            int[] sums = new int[targetSum + 1];
            sums[0] = 1;

            foreach (int coin in coins)
            {
                for (int sum = coin; sum <= targetSum; sum++)
                {
                    sums[sum] += sums[sum - coin];
                }
            }

            return sums[targetSum];
        }
    }
}
