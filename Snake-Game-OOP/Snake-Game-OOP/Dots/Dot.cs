using Snake_Game_OOP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
    public abstract class Dot : IDot
    {
        protected Dot(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual char Symbol => GlobalConstants.dotSymbol;

        public virtual ConsoleColor Color => GlobalConstants.bodyDotColor;

        public int X { get ; set; }
        public int Y { get ; set; }
    }
}
