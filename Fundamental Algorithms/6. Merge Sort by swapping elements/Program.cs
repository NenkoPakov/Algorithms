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

            MergeSort(0, input.Length - 1);

            Console.WriteLine(string.Join(' ', input));
        }

        private static void MergeSort(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivotIndex = (startIndex+endIndex) / 2;

            MergeSort(startIndex, pivotIndex);
            MergeSortedSubsets(startIndex, pivotIndex);

            MergeSort(pivotIndex + 1, endIndex);

            MergeSortedSubsets(startIndex, endIndex);
        }

        private static void MergeSortedSubsets(int startIndex, int endIndex)
        {
            int pivotIndex = (startIndex + endIndex) / 2;
            int leftHalfFirstIndex = startIndex;
            int rightHalfFirstIndex = pivotIndex+1;

            int leftHalfFirstNumber;
            int rightHalfFirstNumber;

            while (leftHalfFirstIndex < rightHalfFirstIndex)
            {
                leftHalfFirstNumber = input[leftHalfFirstIndex];
                rightHalfFirstNumber = input[rightHalfFirstIndex];

                if (leftHalfFirstNumber > rightHalfFirstNumber)
                {
                    SwapNumbers(leftHalfFirstIndex, rightHalfFirstIndex);

                    CheckIfRightHalfIsOrderedCorrectly(rightHalfFirstIndex, endIndex);
                }

                leftHalfFirstIndex++;

            }

            rightHalfFirstIndex++; 

            if (rightHalfFirstIndex > endIndex)
            {
                return;
            }

            leftHalfFirstNumber = input[leftHalfFirstIndex];
            rightHalfFirstNumber = input[rightHalfFirstIndex];

            while (leftHalfFirstNumber > rightHalfFirstNumber && rightHalfFirstIndex <= endIndex)
            {
                SwapNumbers(leftHalfFirstIndex++, rightHalfFirstIndex++);

                leftHalfFirstNumber = input[leftHalfFirstIndex];
                rightHalfFirstNumber = input[rightHalfFirstIndex];
            }
        }

        private static void CheckIfRightHalfIsOrderedCorrectly(int firstIndex, int lastIndex)
        {
            int firstNumber = input[firstIndex];
            int secondNumber = input[firstIndex + 1];

            while (firstNumber>secondNumber && firstIndex < lastIndex)
            {
                SwapNumbers(firstIndex, firstIndex + 1);

                firstNumber = input[firstIndex++];
                secondNumber = input[firstIndex + 1];
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
