using System;

namespace _1._Reverse_Array
{
    public static class Program
    {
        static void Main()
        {
            // Using string[] we can reverse even sentences, not just numbers
            string[] input = Console.ReadLine().Split();
            int startingIndex = 0;
            ReverseArray(input, startingIndex);
            Console.WriteLine(string.Join(' ', input));
        }

        private static void ReverseArray(string[] input, int startIndex)
        {
            int inputLength = input.Length;

            if (startIndex != inputLength / 2)
            {
                string temporaryElement = input[inputLength - 1 - startIndex];
                input[inputLength - 1 - startIndex] = input[startIndex];
                input[startIndex] = temporaryElement;

                ReverseArray(input, startIndex + 1);
            }
        }
    }
}
