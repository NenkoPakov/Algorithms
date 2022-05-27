using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.__Queens_Puzzle
{
    public static class Program
    {
        private const int CHESS_TABLE_SIZE = 8;
        private const int FIRST_QUEEN_ROW = 0;
        private const int FIRST_QUEEN_COL = 0;

        private const char QUEEN_SPOT_SYMBOL = '*';
        private const char FREE_SPOT_SYMBOL = '-';

        static private readonly ICollection<int> LeftDiagonal = new HashSet<int>();
        static private readonly ICollection<int> RightDiagonal = new HashSet<int>();
        static private readonly SortedDictionary<int, int> Queens = new SortedDictionary<int, int>();

        static private  int PlacedQueens = 0;
        static private  int FoundSolutions = 0;

        static void Main()
        {
            char[,] chessBoard = new char[CHESS_TABLE_SIZE, CHESS_TABLE_SIZE];
            PopulateTheBoard(chessBoard);

            PutAllQueens(chessBoard);
        }

        private static void PopulateTheBoard(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = FREE_SPOT_SYMBOL;
                }
            }
        }

        private static void PutAllQueens(char[,] chessBoard)
        {
            FindNextQueenPlace(chessBoard, FIRST_QUEEN_ROW, FIRST_QUEEN_COL);
        }

        private static void FindNextQueenPlace(char[,] chessBoard, int queenRow, int queenCol)
        {
            if (IsOutsideTheBoard(chessBoard, queenRow, queenCol))
            {
                return;
            }

            int leftDiagonalIndex = queenCol - queenRow;
            int rightDiagonalIndex = queenCol + queenRow;

            if (!CheckIfCanPlaceAQueen(queenRow, queenCol, leftDiagonalIndex, rightDiagonalIndex))
            {
                FindNextQueenPlace(chessBoard, queenRow, queenCol + 1);
            }

            SetQueen(chessBoard, queenRow, queenCol, leftDiagonalIndex, rightDiagonalIndex);

            FindNextQueenPlace(chessBoard, queenRow + 1, FIRST_QUEEN_COL);

            if (PlacedQueens == 8)
            {
                PrintChessBoard(chessBoard);
                Console.WriteLine(++FoundSolutions);
            }

            int lastAddedQueenRow, lastAddedQueenCol;
            RemoveQueen(chessBoard, out lastAddedQueenRow, out lastAddedQueenCol);

            FindNextQueenPlace(chessBoard, lastAddedQueenRow, lastAddedQueenCol + 1);
        }

        private static bool IsOutsideTheBoard(char[,] chessBoard, int queenRow, int queenCol)
        {
            return queenRow < 0
                            || queenCol < 0
                            || queenRow >= chessBoard.GetLength(0)
                            || queenCol >= chessBoard.GetLength(1)
                            || queenCol >= chessBoard.GetLength(1);
        }

        private static void RemoveQueen(char[,] chessBoard, out int lastAddedQueenRow, out int lastAddedQueenCol)
        {
            lastAddedQueenRow = Queens.Keys.Last();
            lastAddedQueenCol = Queens[lastAddedQueenRow];
            Queens.Remove(lastAddedQueenRow);

            PlacedQueens--;

            LeftDiagonal.Remove(lastAddedQueenCol - lastAddedQueenRow);
            RightDiagonal.Remove(lastAddedQueenRow + lastAddedQueenCol);
            chessBoard[lastAddedQueenRow, lastAddedQueenCol] = FREE_SPOT_SYMBOL;
        }

        private static void SetQueen(char[,] chessBoard, int queenRow, int queenCol, int leftDiagonalIndex, int rightDiagonalIndex)
        {
            Queens[queenRow] = queenCol;
            PlacedQueens++;

            LeftDiagonal.Add(leftDiagonalIndex);
            RightDiagonal.Add(rightDiagonalIndex);
            chessBoard[queenRow, queenCol] = QUEEN_SPOT_SYMBOL;
        }

        private static bool CheckIfCanPlaceAQueen(int queenRow, int queenCol, int leftDiagonalIndex, int rightDiagonalIndex)
        {
            return !Queens.ContainsKey(queenRow)
                            && !Queens.ContainsValue(queenCol)
                            && !LeftDiagonal.Contains(leftDiagonalIndex)
                            && !RightDiagonal.Contains(rightDiagonalIndex);
        }

        private static void PrintChessBoard(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    Console.Write($"{chessBoard[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
