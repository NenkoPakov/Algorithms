using System;
using System.Linq;

namespace _3._Bubble_Sort
{
    public static class Program
    {
        private static int[] input;

        public static void Main()
        {
            input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            BubbleSort();
            Console.WriteLine(string.Join(' ', input));
        }

        private static void BubbleSort()
        {
            int leftIndex = 0;
            int rightIndex = input.Length - 1;

            for (int i = leftIndex; i <= rightIndex; i++)
            {

                for (int j = leftIndex + 1; j <= rightIndex; j++)
                {
                    int firstNumberForComparisonIndex = j - 1;
                    int secondNumberForComparisonIndex = j;

                    if (input[firstNumberForComparisonIndex] > input[secondNumberForComparisonIndex])
                    {
                        SwapNumbers(firstNumberForComparisonIndex, secondNumberForComparisonIndex);
                    }
                }

                rightIndex--;
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
