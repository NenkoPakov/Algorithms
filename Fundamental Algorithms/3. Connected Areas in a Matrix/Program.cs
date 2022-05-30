using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Connected_Areas_in_a_Matrix
{
    public static class Program
    {
        private const char WALL_FIELD_SYMBOL = '*';
        private const char VISITED_FIELD_SYMBOL = 'v';

        private static char[,] matrix;
        private static int areaSize = 0;
        private static ICollection<Area> areas = new List<Area>();

        static void Main()
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int matrixCols = int.Parse(Console.ReadLine());
            matrix = new char[matrixRows, matrixCols];

            PopulateMatrix(matrixRows, matrixCols);

            FindAreas();
            PrintAreas();
        }

        private static void PrintAreas()
        {
            var currentIndex = 1;

            Console.WriteLine($"Total areas found: {areas.Count()}");

            areas.OrderByDescending(area => area.Size)
                        .ThenBy(area => area.StartingRow)
                        .ThenBy(area => area.StartingCol)
                        .ToList()
                        .ForEach((area=>Console.WriteLine($"Area #{currentIndex++} at ({area.StartingRow}, {area.StartingCol}), size: {area.Size}")));
        }

        private static void FindAreas()
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    areaSize = 0;

                    Area area = new Area();
                    area.StartingRow = row;
                    area.StartingCol = col;

                    ExploreAreaSize(row, col);


                    if (areaSize > 0)
                    {
                        area.Size = areaSize;
                        areas.Add(area);
                    }
                }
            }
        }

        private static void ExploreAreaSize(int currentRow, int currentCol)
        {

            if (currentRow < 0 || currentCol < 0 || currentRow >= matrix.GetLength(0) || currentCol >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[currentRow, currentCol] == WALL_FIELD_SYMBOL || matrix[currentRow, currentCol] == VISITED_FIELD_SYMBOL)
            {
                return;
            }

            matrix[currentRow, currentCol] = VISITED_FIELD_SYMBOL;
            areaSize++;

            ExploreAreaSize(currentRow - 1, currentCol);
            ExploreAreaSize(currentRow + 1, currentCol);
            ExploreAreaSize(currentRow, currentCol - 1);
            ExploreAreaSize(currentRow, currentCol + 1);
        }

        private static void PopulateMatrix(int matrixRows, int matrixCols)
        {
            for (int row = 0; row < matrixRows; row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
        }
    }
}
