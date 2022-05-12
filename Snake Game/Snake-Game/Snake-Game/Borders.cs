using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Borders
    {

        public static int UpperBorder { get; set; }
        public static int LowerBorder { get; set; } 
        public static int LeftBorder { get; set; } 
        public static int RightBorder { get; set; }
        public static void SetBorders()
        {
            UpperBorder = GlobalConstants.upperBorder;
            LowerBorder = GlobalConstants.lowerBorder;
            LeftBorder = GlobalConstants.leftBorder;
            RightBorder = GlobalConstants.rightBorder;

        }
    }
}
