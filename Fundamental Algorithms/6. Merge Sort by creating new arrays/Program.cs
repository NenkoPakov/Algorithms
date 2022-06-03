using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Merge_Sort
{
    public static class Program
    {
        private static int[] input;

        public static void Main()
        {
            input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Console.WriteLine(string.Join(' ', MergeSort(input)));
        }

        private static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int pivotIndex = array.Length / 2;

            return MergeArrays(MergeSort(array.Take(pivotIndex).ToArray()), MergeSort(array.Skip(pivotIndex).ToArray()));
        }

        private static int[] MergeArrays(int[] leftHalf, int[] rightHalf)
        {
            int[] sortedElements = new int[leftHalf.Length + rightHalf.Length];

            int sortedIdx = 0, leftIdx = 0, rightIdx = 0;

            while (leftIdx < leftHalf.Length && rightIdx < rightHalf.Length)
            {
                int leftNumber = leftHalf[leftIdx];
                int rightNumber = rightHalf[rightIdx];

                bool isLeftNumberSmaller = leftNumber < rightNumber;

                sortedElements[sortedIdx++] = isLeftNumberSmaller ? leftNumber:rightNumber;

                if (isLeftNumberSmaller)
                {
                    leftIdx++;
                }
                else
                {
                    rightIdx++;
                }
            }

            if (leftIdx < leftHalf.Length)
            {
                for (int nextElementIndex = leftIdx; nextElementIndex < leftHalf.Length; nextElementIndex++)
                {
                    sortedElements[sortedIdx++] = leftHalf[nextElementIndex];
                }
            }

            if (rightIdx < rightHalf.Length)
            {
                for (int nextElementIndex = rightIdx; nextElementIndex < rightHalf.Length; nextElementIndex++)
                {
                    sortedElements[sortedIdx++] = rightHalf[nextElementIndex];
                }
            }

            return sortedElements;
        }

        private static void SwapNumbers(int firstNumberIndex, int secondNumberIndex)
        {
            int tempNumberHolder = input[secondNumberIndex];
            input[secondNumberIndex] = input[firstNumberIndex];
            input[firstNumberIndex] = tempNumberHolder;
        }
    }
}
