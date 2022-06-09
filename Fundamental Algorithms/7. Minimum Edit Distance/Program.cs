using System;

namespace _7._Minimum_Edit_Distance
{
    class Program
    {
        private static int replacementCost;
        private static int insertCost;
        private static int deleteCost;
        static void Main(string[] args)
        {
            replacementCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            int minDistance = GetMinDistance(firstString, secondString);
            Console.WriteLine($"Minimum edit distance: {minDistance}");
        }

        private static int GetMinDistance(string firstString, string secondString)
        {
            int[,] distances = new int[firstString.Length+1, secondString.Length+1 ];

            for (int row = 1; row < distances.GetLength(0); row++)
            {
                distances[row, 0] = distances[row - 1, 0] + deleteCost;
            }

            for (int col = 1; col < distances.GetLength(1); col++)
            {
                distances[0, col] = distances[0, col-1]+ insertCost;
            }

            for (int firstIdx = 1; firstIdx < distances.GetLength(0); firstIdx++)
            {
                for (int secondIdx = 1; secondIdx < distances.GetLength(1); secondIdx++)
                {
                    if (firstString[firstIdx - 1] == secondString[secondIdx - 1])
                    {
                        distances[firstIdx, secondIdx] = distances[firstIdx - 1, secondIdx - 1];
                    }
                    else
                    {
                        int replace = distances[firstIdx - 1, secondIdx - 1] + replacementCost;
                        int insert = distances[firstIdx , secondIdx - 1] + insertCost;
                        int delete = distances[firstIdx-1 , secondIdx ] + deleteCost;

                        int minCost = Math.Min(Math.Min(insert, delete), replace);

                        distances[firstIdx, secondIdx] = minCost;
                    }
                }
            }

            return distances[firstString.Length, secondString.Length];
        }
    }
}
