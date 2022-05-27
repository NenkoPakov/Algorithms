using System;

namespace _3._Generating_bit_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int startIndex = 0;
            int[] vectors = new int[input];

            GenerateVector(vectors, startIndex);
        }

        private static void GenerateVector(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int j = 0; j <= 1; j++)
            {
                arr[index] = j;
                GenerateVector(arr, index+1);
            }
        }
    }
}
