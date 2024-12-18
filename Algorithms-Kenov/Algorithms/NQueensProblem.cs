using Algorithms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal static class NQueensProblem
    {
        public static void Solve(int n)
        {
            HashSet<int> attackedRows = new ();
            HashSet<int> attackedCols = new ();
            char[,] board = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    board[row, col] = '-';
            }
            Func<int, int, int> upRow = (r,i) => r - i;
            Func<int, int, int> downRow = (r,i) => r + i;
            Func<int, int, int> leftCol = (c, i) => c - i;
            Func<int, int, int> rightCol = (c, i) => c + i;
            Func<int, int, Func<int, int, int>, Func<int, int, int>, bool> CheckDiagonal = (row, col, rowFunc, colFunc) =>
            {
                for (int i = 1; i < n; i++)
                {
                    var r = rowFunc(row, i);
                    var c = colFunc(col, i);

                    if (r < 0 || c < 0 || r >= n || c >= n) break;
                    if (board[r, c] == 'q') return false;
                }
                return true;
            };
            int count = 0;
            Solve(board, 0);
            Console.WriteLine(count);

            void Solve(char[,] board, int row)
            {
                if (row == n)
                {
                    count++;
                    return;
                }

                for (int col = 0;col < n; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkPlaced(row, col);
                        Solve(board, row + 1);
                        UnmarkPlaced(row,col);
                    }
                }

            }

            

            bool CanPlaceQueen(int row, int col)
            {
                if (attackedRows.Contains(row)) return false;
                if (attackedCols.Contains(col)) return false;

                var diagonalCheck = CheckDiagonal.Apply(row).Apply(col);

                return 
                    diagonalCheck(upRow, leftCol) &&
                    diagonalCheck(upRow, rightCol) && 
                    diagonalCheck(downRow, leftCol) && 
                    diagonalCheck(downRow, rightCol);

            }

            void MarkPlaced(int row, int col)
            {
                board[row, col] = 'q';
                attackedCols.Add(col);
                attackedRows.Add(row);
            }

            void UnmarkPlaced(int row, int col)
            {
                board[row, col] = '-';
                attackedCols.Remove(col);
                attackedRows.Remove(row);
            }
        }       
    }
}
