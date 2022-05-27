using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Find_All_Paths_in_a_Labyrinth
{
    class Program
    {
        private const int STARTING_ROW_INDEX = 0;
        private const int STARTING_COL_INDEX = 0;

        private const char FINISH_FIELD_SYMBOL = 'e';
        private const char VISITED_FIELD_SYMBOL = 'v';
        private const char FORBIDDEN_FIELD_SYMBOL = '*';
        private const char PERMITED_FIELD_SYMBOL = '-';

        private const char UP_DIRECTION_SYMBOL = 'U';
        private const char DOWN_DIRECTION_SYMBOL = 'D';
        private const char RIGHT_DIRECTION_SYMBOL = 'R';
        private const char LEFT_DIRECTION_SYMBOL = 'L';
        public static List<char?> Paths = new List<char?>();

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, cols];
            PopulateMatrix(rows, cols, matrix);

            FindAllPaths(matrix, STARTING_ROW_INDEX, STARTING_COL_INDEX);
        }



        private static void FindAllPaths(char[,] matrix, int rowIndex, int colIndex, char? direction = null)
        {
            if (rowIndex >= matrix.GetLength(0)
                || rowIndex < 0
                || colIndex >= matrix.GetLength(1)
                || colIndex < 0
                || matrix[rowIndex, colIndex] == FORBIDDEN_FIELD_SYMBOL
                || matrix[rowIndex, colIndex] == VISITED_FIELD_SYMBOL)
            {
                return;
            }

            Paths.Add(direction);

            if (matrix[rowIndex, colIndex] == FINISH_FIELD_SYMBOL)
            {
                Console.WriteLine(string.Join(string.Empty, Paths));
                Paths.RemoveAt(Paths.Count - 1);
                return;
            }

            matrix[rowIndex, colIndex] = VISITED_FIELD_SYMBOL;

            FindAllPaths(matrix, rowIndex - 1, colIndex, UP_DIRECTION_SYMBOL);
            FindAllPaths(matrix, rowIndex + 1, colIndex, DOWN_DIRECTION_SYMBOL);
            FindAllPaths(matrix, rowIndex, colIndex + 1, RIGHT_DIRECTION_SYMBOL);
            FindAllPaths(matrix, rowIndex, colIndex - 1, LEFT_DIRECTION_SYMBOL);

            Paths.RemoveAt(Paths.Count - 1);
            matrix[rowIndex, colIndex] = PERMITED_FIELD_SYMBOL;
        }

        private static void PopulateMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] matrixRow = Console.ReadLine().ToCharArray();

                for (int index = 0; index < cols; index++)
                {
                    matrix[row, index] = matrixRow[index];
                }
            }
        }
    }
}
