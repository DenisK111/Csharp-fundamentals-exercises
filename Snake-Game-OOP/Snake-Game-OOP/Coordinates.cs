using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
   public class InitialCoordinates
    {
        public InitialCoordinates(int cursorPositionX, int cursorPositionY)
        {
            CursorPositionX = cursorPositionX;
            CursorPositionY = cursorPositionY;
        }

        public int CursorPositionX { get; set; }
        public int CursorPositionY { get; set; }
    }
}
