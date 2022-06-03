using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7._Sum_of_Coins
{
    public static class Program
    {
        public static void Main()
        {
            IEnumerable<int> coins = Console.ReadLine().Split(", ").Select(x => int.Parse(x));

            int targetValue = int.Parse(Console.ReadLine());

            Console.WriteLine(GetCoinsSum(coins.OrderByDescending(x => x), targetValue));
        }

        private static string GetCoinsSum(IEnumerable<int> orderedCoins, int targetValue)
        {
            int coinIndex = default;

            IDictionary<int, int> takenCoins = new Dictionary<int, int>();

            while (targetValue > 0 && coinIndex < orderedCoins.Count())
            {
                int currentCoin = orderedCoins.Skip(coinIndex).FirstOrDefault();

                int coinCount = targetValue / currentCoin;

                if (coinCount == 0)
                {
                    coinIndex++;
                    continue;
                }

                targetValue %= currentCoin;

                takenCoins.Add(currentCoin, coinCount);
                coinIndex++;
            }

            if (targetValue > 0)
            {
                return "Error";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Number of coins to take: {takenCoins.Sum(x => x.Value)}");

                foreach (var key in takenCoins.Keys)
                {
                    sb.AppendLine($"{takenCoins[key]} coin(s) with value {key}");
                }

                return sb.ToString();
            }
        }
    }
}
