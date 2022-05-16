using System;

namespace _9._Miner_exam_
{
    class Program
    {

        /* We get as input the size of the field in which our miner moves. The field is always a square. After that, we will receive the commands which represent the directions in which the miner should move. The miner starts from position – ‘s’. The commands will be: left, right, up, and down. If the miner has reached a side edge of the field and the next command indicates that he has to get out of the field, he must remain in his current position and ignore the current command. The possible characters that may appear on the screen are:
•	* – a regular position on the field.
•	e – the end of the route. 
•	c  - coal
•	s - the place where the miner starts
Each time when the miner finds coal, he collects it and replaces it with '*'. Keep track of the count of the collected coals. If the miner collects all of the coals in the field, the program stops and you have to print the following message: "You collected all coals! ({rowIndex}, {colIndex})".
If the miner steps at 'e' the game is over (the program stops) and you have to print the following message: "Game over! ({rowIndex}, {colIndex})".
If there are no more commands and none of the above cases had happened, you have to print the following message: "{remainingCoals} coals left. ({rowIndex}, {colIndex})".
Input
•	Field size – an integer number.
•	Commands to move the miner – an array of strings separated by " ".
•	The field: some of the following characters (*, e, c, s), separated by whitespace (" ");
Output
•	There are three types of output:
o	If all the coals have been collected, print the following output: "You collected all coals! ({rowIndex}, {colIndex})"
o	If you have reached the end, you have to stop moving and print the following line: "Game over! ({rowIndex}, {colIndex})"
o	If there are no more commands and none of the above cases had happened, you have to print the following message: "{totalCoals} coals left. ({rowIndex}, {colIndex})"
Constraints
•	The field size will be a 32-bit integer in the range [0 … 2 147 483 647].
•	The field will always have only one's.
•	Allowed working time for your program: 0.1 seconds.
•	Allowed memory: 16 MB.
*/

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();
            char[,] matrix = ReadMatrix(n);
            int startIndexRows = 0;
            int startIndexCols = 0;
            int numOfCoals = 0;
            int numOfCollectedCoals = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startIndexRows = row;
                        startIndexCols = col;
                    }

                    if (matrix[row, col] == 'c')
                    {
                        numOfCoals++;
                    }
                }
            }

            foreach (var item in commands)
            {
                switch (item)
                {
                    case "up":

                        startIndexRows -= 0 < startIndexRows ? 1 : 0;
                        break;
                    case "down":
                        startIndexRows += startIndexRows < matrix.GetUpperBound(0) ? 1 : 0;

                        break;
                    case "right":
                        startIndexCols += startIndexCols < matrix.GetUpperBound(1) ? 1 : 0;
                        break;
                    case "left":
                        startIndexCols -= 0 < startIndexCols ? 1 : 0;
                        break;

                }

                if (matrix[startIndexRows,startIndexCols] == 'e')
                {
                    Console.WriteLine($"Game over! ({startIndexRows}, {startIndexCols})");
                    Environment.Exit(0);
                }

                else if (matrix[startIndexRows, startIndexCols] == 'c')
                {
                    matrix[startIndexRows, startIndexCols] = '*';
                    numOfCollectedCoals++;
                }

                if (numOfCoals == numOfCollectedCoals)
                {
                    Console.WriteLine($"You collected all coals! ({startIndexRows}, {startIndexCols})");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine($"{numOfCoals-numOfCollectedCoals} coals left. ({startIndexRows}, {startIndexCols})");

        }

        
        static char[,] ReadMatrix(int n)
        {

            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] input = Console.ReadLine().Replace(" ","").ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }
    }
}
