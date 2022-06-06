using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Areas_in_Matrix
{
    public static class Program
    {
        private const char VISTITED_FIELD = 'V';
        private static char[,] matrix;
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            IDictionary<char, int> areas = new SortedDictionary<char, int>();

            matrix = new char[rows, cols];
            ReadMatrix(rows, cols);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char symbol = matrix[row, col];
                    int areaSize = DFS(row, col, symbol);

                    if (areaSize<=0)
                    {
                        continue;
                    }

                    if (!areas.ContainsKey(symbol))
                    {
                        areas.Add(symbol, default);
                    }

                    areas[symbol] += 1;
                }
            }

            Console.WriteLine($"Areas: {areas.Values.Sum(x=>x)}");
            foreach (KeyValuePair<char, int> area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value} ");
            }
        }

        private static int DFS(int row, int col, char symbol)
        {
            if (row < 0 ||
                col < 0 ||
                row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1))
            {
                return 0;
            }

            if (matrix[row, col] != symbol || symbol==VISTITED_FIELD)
            {
                return 0;
            }

            matrix[row, col] = VISTITED_FIELD;

            int areaSize = 1;

            areaSize += DFS(row - 1, col, symbol);
            areaSize += DFS(row, col + 1, symbol);
            areaSize += DFS(row + 1, col, symbol);
            areaSize += DFS(row, col - 1, symbol);

            return areaSize;
        }

        private static void ReadMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                string colElements = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }
    }
}
