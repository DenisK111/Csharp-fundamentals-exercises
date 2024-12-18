using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.Utils;

namespace Algorithms
{
    internal static class AllPaths
    {
        public static void AllPathsInALabyrinth(char[,] labyrinth) => Paths(labyrinth, 0, 0, 's');       

        private static void Paths(char[,] labyrinth, int row, int col, char direction)
        {
            if (row >= labyrinth.GetLength(0) || row < 0 || col < 0 || col >= labyrinth.GetLength(1)) return;
            if (labyrinth[row,col] == 'e')
            {
                Print(labyrinth);
                return;
            }
            if (labyrinth[row, col] != '-') return;

            labyrinth[row, col] = direction;            
            Paths(labyrinth, row - 1, col, 'U');
            Paths(labyrinth, row + 1, col, 'D');
            Paths(labyrinth, row, col - 1, 'L');
            Paths(labyrinth, row, col + 1, 'R');
            labyrinth[row, col] = '-';            
        }        
    }
}
