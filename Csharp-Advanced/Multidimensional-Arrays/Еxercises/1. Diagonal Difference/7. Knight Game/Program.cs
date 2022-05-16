using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        /* Chess is the oldest game, but it is still popular these days. For this task, we will use only one chess piece – the Knight. 
The knight moves to the nearest square but not on the same row, column, or diagonal. (This can be thought of as moving two squares horizontally, then one square vertically, or moving one square horizontally then two squares vertically— i.e. in an "L" pattern.) 
The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. 
You will receive a board with K for knights and '0' for empty cells. Your task is to remove a minimum of the knights, so there will be no knights left that can attack another knight. 
Input
On the first line, you will receive the N side of the board
On the next N lines, you will receive strings with Ks and 0s.
Output
Print a single integer with the minimum number of knights that needs to be removed
Constraints
•	Size of the board will be 0 < N < 30
•	Time limit: 0.3 sec. Memory limit: 16 MB.
*/
        static void Main(string[] args)
        {
            var matrix = ReadMatrix();
            Console.WriteLine(MoveKnight(matrix));

        }

        static char[,] ReadMatrix()
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }

        public static int MoveKnight(char[,] matrix)
        {
            const int LENGTH = 2;
            const int TAIL = 1;
            int matrixColsLength = matrix.GetLength(1);
            int matrixRowsLength = matrix.GetLength(0);
            int totalKnightsRemoved = 0;
            int countOfOneMatches = 0;
            int maxMatches = 0;
            int timesRunning = 0;
            while (true)
            {

                for (int row = 0; row < matrixRowsLength; row++)
                {
                    for (int col = 0; col < matrixColsLength; col++)
                    {
                        bool RightX = col < matrixColsLength - LENGTH;
                        bool leftX = col >= LENGTH;
                        bool xDown = row < matrixRowsLength - TAIL;
                        bool xUp = row >= TAIL;
                        bool xRight = col < matrixColsLength - TAIL;
                        bool xLeft = col >= TAIL;
                        bool downX = row < matrixRowsLength - LENGTH;
                        bool upX = row >= LENGTH;
                        int matches = 0;


                        if (matrix[row, col] == 'K')
                        {
                            if (RightX && xDown)
                            {
                                matches += KnightMatchRightDown(matrix, row, col);
                            }

                            if (downX && xRight)
                            {
                                matches += KnightMatchDownRight(matrix, row, col);
                            }

                            if (RightX && xUp)
                            {
                                matches += KnightMatchRightUp(matrix, row, col);
                            }

                            if (upX && xRight)
                            {
                                matches += KnightMatchUpRight(matrix, row, col);
                            }

                            if (leftX && xDown)
                            {
                                matches += KnightMatchLeftDown(matrix, row, col);
                            }

                            if (leftX && xUp)
                            {
                                matches += KnightMatchLeftUp(matrix, row, col);
                            }

                            if (downX && xLeft)
                            {
                                matches += KnightMatchDownLeft(matrix, row, col);
                            }
                            if (upX && xLeft)
                            {
                                matches += KnightMatchUpLeft(matrix, row, col);
                            }

                            if (matches > maxMatches)
                            {
                                maxMatches = matches;
                            }

                            if (matches == maxMatches && timesRunning > 0 && maxMatches > 1)
                            {
                                matrix[row, col] = '0';
                                totalKnightsRemoved++;
                            }

                            if (matches == maxMatches && timesRunning > 0 && maxMatches == 1)
                            {
                                countOfOneMatches++;
                            }
                        }


                    }
                }

                if (timesRunning > 0)
                {
                    maxMatches--;
                }
                timesRunning++;
                if (maxMatches == 0)
                {
                    break;
                }
            }




            return totalKnightsRemoved + countOfOneMatches / 2;
        }
        public static int KnightMatchRightDown(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row + 1, col + 2] ? 1 : 0;

        }

        public static int KnightMatchDownRight(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row + 2, col + 1] ? 1 : 0;

        }

        public static int KnightMatchRightUp(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row - 1, col + 2] ? 1 : 0;

        }

        public static int KnightMatchUpRight(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row - 2, col + 1] ? 1 : 0;

        }

        public static int KnightMatchLeftDown(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row + 1, col - 2] ? 1 : 0;

        }

        public static int KnightMatchDownLeft(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row + 2, col - 1] ? 1 : 0;

        }

        public static int KnightMatchLeftUp(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row - 1, col - 2] ? 1 : 0;

        }

        public static int KnightMatchUpLeft(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == matrix[row - 2, col - 1] ? 1 : 0;

        }
    }
}
