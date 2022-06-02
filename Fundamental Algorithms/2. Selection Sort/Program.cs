using System;
using System.Linq;

namespace _2._Selection_Sort
{
    public static class Program
    {
        private static int[] input;

        public static void Main()
        {
            input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            SelectionSort();
            Console.WriteLine(string.Join(' ', input));
        }

        private static void SelectionSort()
        {
            int leftIndex = 0;
            int rightIndex = input.Length - 1;

            for (int currentNumberForComparison = 0; currentNumberForComparison <= rightIndex; currentNumberForComparison++)
            {
                int minNumber = input[currentNumberForComparison];
                int minNumberIndex = currentNumberForComparison;

                for (int secondNumberForComparison = leftIndex+1; secondNumberForComparison <= rightIndex; secondNumberForComparison++)
                {
                    int currentNumber = input[secondNumberForComparison];

                    if (currentNumber < minNumber)
                    {
                        minNumber = currentNumber;
                        minNumberIndex = secondNumberForComparison;
                    }
                }

                SwapNumbers(leftIndex, minNumberIndex);

                leftIndex++;
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
