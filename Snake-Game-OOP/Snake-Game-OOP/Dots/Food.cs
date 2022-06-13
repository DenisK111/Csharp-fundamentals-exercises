using Snake_Game_OOP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
   public class Food : Dot, IFood
    {
        

        public Food(int x, int y) : base(x, y)
        {
        }

        public override ConsoleColor Color => GlobalConstants.foodColor;


    }
}
