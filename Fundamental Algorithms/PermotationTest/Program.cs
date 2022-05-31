using System;

namespace PermotationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            GenerateAllPermutations(input,0);

        }

        private static void GenerateAllPermutations(char[] array, int index)
        {
            Console.WriteLine("Generate with "+index);
            var nextIndex = index + 1;
            if (index>=array.Length)
            {
                Console.WriteLine(string.Join(' ', array));
                return;
            }
            GenerateAllPermutations(array,nextIndex);

            for (int i = nextIndex; i < array.Length; i++)
            {
                Console.WriteLine("Swap "+index +" with " + i);
                Swap(array,index, i);
                GenerateAllPermutations(array,nextIndex);
                Swap(array, index, i);
            }
        }

        private static void Swap(char[] array,int index, int nextIndex)
        {
            var temp = array[nextIndex];
            array[nextIndex]= array[index];
            array[index]=temp;
        }
    }
}
