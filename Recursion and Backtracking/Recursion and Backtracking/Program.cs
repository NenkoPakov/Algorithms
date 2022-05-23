using System;
using System.Linq;

namespace Recursion_and_Backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(x=>int.Parse(x))
                                .ToArray();

            Console.WriteLine(GetSum(input, 0));

        }

        private static int GetSum(int[] input, int startIndex)
        {
            if (startIndex >= input.Length-1)
            {
                return input[startIndex];
            }

            return input[startIndex] + GetSum(input, startIndex + 1);
        }
    }
}
