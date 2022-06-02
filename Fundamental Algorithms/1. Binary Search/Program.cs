using System;
using System.Linq;

namespace _1._Binary_Search
{
    public static class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int key = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(input, key));
        }

        private static int BinarySearch(int[] input, int key)
        {
            int length = input.Length;
            int midleIndex = length / 2;

            if (input.Length ==0 || (input.Length == 1 && input[0]!=key))
            {
                return -1;
            }

            if ( input[midleIndex] == key )
            {
                return midleIndex;
            }

            if (input[midleIndex] > key)
            {
                return BinarySearch(input.Take(midleIndex).ToArray(), key);
            }

            if (input[midleIndex] < key)
            {
                int foundAtIndex = BinarySearch(input.Skip(midleIndex).ToArray(), key);

                if (foundAtIndex==-1)
                {
                    return -1;
                }

                return midleIndex + foundAtIndex;
            }

            return -1;
        }
    }
}
