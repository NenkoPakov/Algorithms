using System;

namespace _4._Recursive_Factorial
{
    public static class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateFactorial(number)); 
        }

        private static int CalculateFactorial(int number)
        {
            if (number<=1)
            {
                return 1;
            }

            return number * CalculateFactorial(number - 1);
        }
    }
}
