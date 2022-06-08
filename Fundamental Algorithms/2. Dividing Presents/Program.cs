using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Dividing_Presents
{
    class Program
    {
        private static int[] presents;

        static void Main(string[] args)
        {
            presents = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .OrderBy(x => x)
                .ToArray();

            int presentsSum = presents.Sum(x => x);
            int halfPrice = presentsSum / 2;

            HashSet< KeyValuePair<int, int> > sums = GetAllPossibleSums(presents, halfPrice);

            PrintOutput(sums.OrderBy(sum=>sum.Key).ToList(), halfPrice, presentsSum);
        }

        private static void PrintOutput(ICollection<KeyValuePair<int, int>> sums, int halfPrice, int totalPrice)
        {
            KeyValuePair<int, int> theClosestSmallerSum = sums.LastOrDefault();

            while (theClosestSmallerSum.Key > halfPrice)
            {
                sums.Remove(theClosestSmallerSum);
                theClosestSmallerSum = sums.LastOrDefault();
            }

            int biggerHalf = totalPrice - theClosestSmallerSum.Key;
            int difference = biggerHalf - theClosestSmallerSum.Key;

            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Alan:{theClosestSmallerSum.Key} Bob:{biggerHalf}");

            var takenPresents = new List<int>();
            var presentToTake = theClosestSmallerSum;

            while (presentToTake.Key > 0)
            {
                takenPresents.Add(presentToTake.Value);

                int previousSum = presentToTake.Key - presentToTake.Value;
                presentToTake = sums.FirstOrDefault(sum => sum.Key == previousSum);
            }

            Console.WriteLine($"Alan takes: {string.Join(' ', takenPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static HashSet<KeyValuePair<int, int>> GetAllPossibleSums(int[] presents, int targetSum)
        {
            HashSet < KeyValuePair < int,int>> sumsHistory = new HashSet<KeyValuePair<int, int>>();
            sumsHistory.Add(new KeyValuePair<int, int>(0, 0));

            bool isFound = false;

            foreach (int present in presents)
            {
                var sumsCopy = sumsHistory.Select(sum => sum.Key).ToArray();
                foreach (var sum in sumsCopy)
                {
                    int currentSum = sum + present;

                    sumsHistory.Add(new  KeyValuePair<int, int>(currentSum, present));

                    if (currentSum >= targetSum)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            return sumsHistory;
        }
    }
}
