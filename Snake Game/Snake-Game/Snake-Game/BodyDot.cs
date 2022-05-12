using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class BodyDot : Dot
    {
        public BodyDot(int x, int y)
        {
            BodyDotInstance = Dot.BodyDotSymbol;
            BodyDotPositionX = x;
            BodyDotPositionY = y;


        }

        public static string BodyDotInstance { get; set; }
        public static int Length { get; set; } = GlobalConstants.initialBodyLength;
        public int BodyDotPositionX { get; set; }
        public int BodyDotPositionY { get; set; }

    }
}
