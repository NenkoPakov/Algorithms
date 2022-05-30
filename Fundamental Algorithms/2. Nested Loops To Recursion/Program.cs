using System;
using System.Collections.Generic;

namespace _2._Nested_Loops_To_Recursion
{
    public static class Program
    {
        private static int nestedLoopsCount;
        private static int[] result;
        static void Main()
        {
            nestedLoopsCount = int.Parse(Console.ReadLine());
            result = new int[nestedLoopsCount];
            GenerateNestedLoopPermotation(0);
        }

        private static void GenerateNestedLoopPermotation(int currentIndex)
        {
            if (currentIndex >= nestedLoopsCount)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int i = 1; i <= nestedLoopsCount; i++)
            {
                result[currentIndex] = i;
                GenerateNestedLoopPermotation(currentIndex + 1);
            }
        }
    }
}
