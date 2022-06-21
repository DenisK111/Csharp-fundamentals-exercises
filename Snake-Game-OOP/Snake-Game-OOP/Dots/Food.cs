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
       
        

        public Food() : base(new Random().Next(GlobalConstants.leftBorder, GlobalConstants.rightBorder), new Random().Next(GlobalConstants.upperBorder, GlobalConstants.lowerBorder))
        {
        }

        public override ConsoleColor Color => GlobalConstants.foodColor;


    }
}
