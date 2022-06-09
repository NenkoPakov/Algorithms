using System;

namespace _5._Word_Differences
{
    public static class Program
    {
        public static void Main()
        {
            string firstString = Console.ReadLine();  
            string secondString = Console.ReadLine();

            int count = CalculateDifference(firstString, secondString);
            Console.WriteLine($"Deletions and Insertions: {count}");
        }

        private static int CalculateDifference(string firstString, string secondString)
        {
            int[,] differences = new int[firstString.Length + 1, secondString.Length + 1];

            for (int i = 0; i < firstString.Length +1; i++)
            {
                differences[0, i] = i;
            }

            for (int i = 0; i < secondString.Length + 1; i++)
            {
                differences[i, 0] = i;
            }

            for (int firstIdx = 1; firstIdx <= firstString.Length; firstIdx++)
            {
                for (int secondIdx = 1; secondIdx <= secondString.Length; secondIdx++)
                {
                    differences[firstIdx, secondIdx] = firstString[firstIdx-1]==secondString[secondIdx-1] 
                                                        ? differences[firstIdx - 1, secondIdx - 1] 
                                                        : Math.Min(differences[firstIdx - 1, secondIdx], differences[firstIdx, secondIdx - 1])+1;
                }
            }

            return differences[firstString.Length, secondString.Length];
        }
    }
}
