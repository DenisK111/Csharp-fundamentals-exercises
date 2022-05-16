using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampBunnies_exam
{
    class Program
    {

        /* Browsing through GitHub, you come across an old JS Basics teamwork game. It is about very nasty bunnies that multiply extremely fast. There’s also a player that has to escape from their lair. You like the game, so you decide to port it to C# because that’s your language of choice. The last thing that is left is the algorithm that decides if the player will escape the lair or not.
First, you will receive a line holding integers N and M, which represent the rows and columns in the lair. Then you receive N strings that can only consist of ".", "B", "P". The bunnies are marked with "B", the player is marked with "P", and everything else is free space, marked with a dot ".". They represent the initial state of the lair. There will be only one player. Then you will receive a string with commands such as LLRRUUDD – where each letter represents the next move of the player (Left, Right, Up, Down).
After each step of the player, each of the bunnies spread to the up, down, left, and right (neighboring cells marked as "." changes their value to "B"). If the player moves to a bunny cell or a bunny reaches the player, the player has died. If the player goes out of the lair without encountering a bunny, the player has won.
When the player dies or wins, the game ends. All the activities for this turn continue (e.g. all the bunnies spread normally), but there are no more turns. There will be no stalemates where the moves of the player end before he dies or escapes.
Finally, print the final state of the lair with every row on a separate line. On the last line, print either "dead: {row} {col}" or "won: {row} {col}". Row and col are the coordinates of the cell where the player has died or the last cell he has been in before escaping the lair.
Input
•	On the first line of input, the numbers N and M are received – the number of rows and columns in the lair
•	On the next N lines, each row is received in the form of a string. The string will contain only ".", "B", "P". All strings will be the same length. There will be only one "P" for all the input
•	On the last line, the directions are received in the form of a string, containing "R", "L", "U", "D"
Output
•	On the first N lines, print the final state of the bunny lair
•	On the last line, print the outcome – "won:" or "dead:" + {row} {col}
Constraints
•	The dimensions of the lair are in the range [3…20]
•	The directions string length is in the range [1…20]
*/
        static void Main(string[] args)
        {

            var matrix = ReadMatrix();

            char[] commands = Console.ReadLine().ToCharArray();
            int startIndexRows = 0;
            int startIndexCols = 0;
            string outcome = "won";
            bool gameOver = false;
            List<Dictionary<int, int>> listOfBunnies = new List<Dictionary<int, int>>();
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        startIndexRows = row;
                        startIndexCols = col;
                    }

                    if (matrix[row,col] == 'B')
                    {
                        listOfBunnies.Add(new Dictionary<int, int>() { [row] = col });
                    }


                }
            }

            foreach (var item in commands)
            {
                int outputIndexRows = startIndexRows;
                int outputIndexCols = startIndexCols;
                switch (item)
                {
                    case 'U':
                        matrix[startIndexRows--, startIndexCols] = '.';
                        break;
                    case 'D':
                        matrix[startIndexRows++, startIndexCols] = '.';

                        break;
                    case 'L':
                        matrix[startIndexRows, startIndexCols--] = '.';

                        break;
                    case 'R':
                        matrix[startIndexRows, startIndexCols++] = '.';

                        break;
                }

                var tempList = listOfBunnies.ToList();

                foreach (var bunny in tempList)
                {
                    bool createNew = false;
                    int row = bunny.Keys.First();
                    int col = bunny.Values.First();
                    if (0 < row)
                    {
                        createNew = matrix[row - 1, col] == 'B' ? false : true;
                        matrix[row - 1, col] = 'B';
                        if (createNew)
                        {
                            listOfBunnies.Add(new Dictionary<int, int>() { [row - 1] = col });
                        }
                    }
                    if (row < matrix.GetUpperBound(0))
                    {
                        createNew = matrix[row + 1, col] == 'B' ? false : true;
                        matrix[row + 1, col] = 'B';
                        if (createNew)
                        {
                            listOfBunnies.Add(new Dictionary<int, int>() { [row + 1] = col });
                        }
                    }
                    if (0 < col)
                    {
                        createNew = matrix[row, col-1] == 'B' ? false : true;
                        matrix[row, col - 1] = 'B';
                        if (createNew)
                        {
                            listOfBunnies.Add(new Dictionary<int, int>() { [row] = col -1 });
                        }
                    }
                    if (col < matrix.GetUpperBound(1))
                    {
                        createNew = matrix[row, col + 1] == 'B' ? false : true;
                        matrix[row, col + 1] = 'B';
                        if (createNew)
                        {
                            listOfBunnies.Add(new Dictionary<int, int>() { [row] = col + 1 });
                        }
                    }


                }
                                            
                if (startIndexRows < 0 || startIndexCols < 0 || startIndexRows > matrix.GetUpperBound(0) || startIndexCols > matrix.GetUpperBound(1))
                {
                    gameOver = true;
                }

                else if (matrix[startIndexRows,startIndexCols] == 'B')
                {
                    gameOver = true;
                    outcome = "dead";
                    outputIndexRows = startIndexRows;
                    outputIndexCols = startIndexCols;

                }

                if (gameOver)
                {
                    for (int r = 0; r < matrix.GetLength(0); r++)
                    {
                        for (int c = 0; c < matrix.GetLength(1); c++)
                        {
                            Console.Write(matrix[r, c]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"{outcome}: {outputIndexRows} {outputIndexCols}");
                    break;
                }


            }
        }



        static char[,] ReadMatrix()
        {
            int[] inputCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputCoords[0];
            int m = inputCoords[1];
            int rows = n;
            int cols = m;
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
    }
}

