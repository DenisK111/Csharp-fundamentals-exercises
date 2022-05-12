using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Dot : Renderer
    {


        public Dot()
        {
            Random = new Random();
            DotX = Random.Next(1, GlobalConstants.consoleWidth);
            DotY = Random.Next(1, GlobalConstants.consoleHeight);

           


        }

        public static string HeadDotSymbol { get; set; } = GlobalConstants.symbolOfHeadDot;
        public static string BodyDotSymbol { get; set; } = GlobalConstants.symbolOfBodyDot;

        public string FoodDotSymbol { get; set; } = GlobalConstants.foodSymbol;

        public int DotX { get; set; }
        public int DotY { get; set; }

        public Random Random { get; set; }
    }
}
