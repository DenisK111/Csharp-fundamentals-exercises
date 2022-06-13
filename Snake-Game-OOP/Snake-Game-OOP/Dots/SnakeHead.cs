using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP.Dots
{
    public class SnakeHead : Dot
    {
        public SnakeHead(int x, int y) : base(x, y)
        {
        }

        public override ConsoleColor Color => GlobalConstants.headColor;
    }
}
