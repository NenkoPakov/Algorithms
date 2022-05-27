using System;

namespace _7._Recursive_Fibonacci
{
    public static class Program
    {
        private static int FibonacciNumber;

        static void Main()
        {
            FibonacciNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(FibonacciNumber));
        }

        private static int GetFibonacci(int number)
        {
            if (number == 0 || number == 1)
            {
                return 1;

            }

            return GetFibonacci(number - 1) + GetFibonacci(number - 2);
        }
    }
}