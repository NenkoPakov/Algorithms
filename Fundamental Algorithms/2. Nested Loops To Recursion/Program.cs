using System;
using System.Collections.Generic;

namespace _2._Nested_Loops_To_Recursion
{
    public static class Program
    {
        private static int NestedLoopsCount;
        private static int[] result;
        static void Main()
        {
            NestedLoopsCount = int.Parse(Console.ReadLine());
            result = new int[NestedLoopsCount];
            GenerateNestedLoopPermotation(0);
        }

        private static void GenerateNestedLoopPermotation(int currentIndex)
        {
            if (currentIndex >= NestedLoopsCount)
            {
                Console.WriteLine(string.Join(' ', result));
                return;
            }

            for (int i = 1; i <= NestedLoopsCount; i++)
            {
                result[currentIndex] = i;
                GenerateNestedLoopPermotation(currentIndex + 1);
            }
        }
    }
}
