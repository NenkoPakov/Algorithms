using System;
using System.Linq;

namespace _5._Quicksort
{
    public static class Program
    {
        private static int[] input;

        public static void Main()
        {
            input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            QuickSort(0, input.Length - 1);

            Console.WriteLine(string.Join(' ', input));
        }

        private static void QuickSort(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivotIndex = startIndex;
            int pivotNumber = input[pivotIndex];

            int initialLeftIndex = pivotIndex + 1;
            int leftIndex = initialLeftIndex;
            int rightIndex = endIndex;

            while (leftIndex <= rightIndex)
            {
                int leftNumber = input[leftIndex];
                int rightNumber = input[rightIndex];

                if (leftNumber > pivotNumber && rightNumber < pivotNumber)
                {
                    SwapNumbers(leftIndex, rightIndex);
                }

                if (leftNumber <= pivotNumber)
                {
                    leftIndex++;
                }

                if (rightNumber >= pivotNumber)
                {
                    rightIndex--;
                }
            }

            if (pivotIndex != rightIndex)
            {
                SwapNumbers(pivotIndex, rightIndex);
            }

            if (rightIndex - 1 - startIndex < endIndex - (rightIndex + 1))
            {
                QuickSort(startIndex, rightIndex - 1);
                QuickSort(rightIndex + 1, endIndex);
            }
            else
            {
                QuickSort(rightIndex + 1, endIndex);
                QuickSort(startIndex, rightIndex - 1);
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
