using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Coordinates
    {
        

        public static int CursorPositionX { get; set; } = GlobalConstants.initialCursorPositionX;
        public static int CursorPositionY { get; set; } = GlobalConstants.initialCursorPositionY;

        public static void SetPosition()
        {

            Console.SetCursorPosition(CursorPositionX, CursorPositionY);
        }

        public static void SetPosition(int x,int y)
        {

            Console.SetCursorPosition(x, y);
        }
    }
}
