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

                if (leftNumber >= pivotNumber)
                {
                    rightIndex--;
                }
            }

            if (leftIndex != initialLeftIndex)
            {
                SwapNumbers(pivotIndex, rightIndex);
            }

            QuickSort(startIndex, rightIndex - 1);
            QuickSort(rightIndex + 1, endIndex);
        }

        private static void SwapNumbers(int firstNumberIndex, int secondNumberIndex)
        {
            int tempNumberHolder = input[secondNumberIndex];
            input[secondNumberIndex] = input[firstNumberIndex];
            input[firstNumberIndex] = tempNumberHolder;
        }
    }
}
