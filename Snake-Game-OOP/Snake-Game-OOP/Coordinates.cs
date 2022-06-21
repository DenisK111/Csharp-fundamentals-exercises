using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
   public class InitialCoordinates
    {
  

        public InitialCoordinates()
        {
            CursorPositionX = GlobalConstants.initialCursorPositionX;
            CursorPositionY = GlobalConstants.initialCursorPositionY;
        }

        public int CursorPositionX { get; set; }
        public int CursorPositionY { get; set; }
    }
}
