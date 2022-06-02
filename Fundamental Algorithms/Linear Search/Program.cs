using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Binary_Search
{
    public static class Program
    {
        private static int[] input;

        public static void Main()
        {
            input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            InsertationSort();
            Console.WriteLine(string.Join(' ', input));
        }

        private static void InsertationSort()
        {
            int rightIndex = input.Length - 1;

            for (int leftIndex = 0; leftIndex <= rightIndex; leftIndex++)
            {
                for (int j = leftIndex + 1; j <= rightIndex; j++)
                {
                    int initialFirstNumberForComparisonIndex = j - 1;
                    int firstNumberForComparisonIndex = initialFirstNumberForComparisonIndex;
                    int secondNumberForComparisonIndex = j;

                    while (firstNumberForComparisonIndex >= 0 && input[secondNumberForComparisonIndex] < input[firstNumberForComparisonIndex])
                    {
                        SwapNumbers(firstNumberForComparisonIndex--, secondNumberForComparisonIndex--);
                    }
                }
            }
        }

        private static void SwapNumbers(int firstNumberIndex, int secondNumberIndex)
        {
            int tempNumberHolder = input[secondNumberIndex];
            input[secondNumberIndex] = input[firstNumberIndex];
            input[firstNumberIndex] = tempNumberHolder;
        }
    }
}
