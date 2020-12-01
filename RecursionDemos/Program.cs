using System;

namespace NQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] queens = new int[n, n];

            Console.WriteLine(GetQueens(queens, 0));
        }

        static void Print(int[,] queens)
        {
            for (int row = 0; row < queens.GetLength(0); row++)
            {
                for (int col = 0; col < queens.GetLength(1); col++)
                {
                    if (queens[row, col] == 1)
                    {
                        Console.Write("Q" + " ");
                    }
                    if(queens[row, col] == 0)
                    {
                        Console.Write("_" + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        private static int GetQueens(int[,] queens, int row)
        {
            if (row == queens.GetLength(0))
            {
                Print(queens);
                return 1;
            }
            int found = 0;
            for (int col = 0; col < queens.GetLength(1); col++)
            {
                if (IsItSafe(queens, row, col))
                {
                    queens[row, col] = 1;
                    found += GetQueens(queens, row + 1);
                    queens[row, col] = 0;
                }
            }
            return found;
        }

        private static bool IsItSafe(int[,] queens, int row, int col)
        {
            for (int i = 1; i < queens.GetLength(0); i++)
            {
                if (row - i >= 0 && queens[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && queens[row, col - 1] == 1)
                {
                    return false;
                }
                if (row + i < queens.GetLength(0) && queens[row + i, col] == 1)
                {
                    return false;
                }
                if (col + i < queens.GetLength(0) && queens[row, col + i] == 1)
                {
                    return false;
                }

                if(col + i < queens.GetLength(0) && row + i < queens.GetLength(0) && queens[row + i, col + i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && row + i < queens.GetLength(0) && queens[row + i, col - i] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && row - i >= 0 && queens[row - i, col - i] == 1)
                {
                    return false;
                }
                if(col + i < queens.GetLength(0) && row - i >= 0 && queens[row - i, col + i] == 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
