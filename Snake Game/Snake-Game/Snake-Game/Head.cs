using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Head : Dot
    {

      public Head()
        {
            HeadPostionX = GlobalConstants.initialCursorPositionX;
            HeadPostionY = GlobalConstants.initialCursorPositionY;
            SnakeHead = HeadDotSymbol;
           
        }

       
        public int HeadPostionX { get; set; }
        public int HeadPostionY { get; set; }
        public static string SnakeHead { get; set; }

       
    }
}
