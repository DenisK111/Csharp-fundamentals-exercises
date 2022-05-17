using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Renderer : Coordinates
    {






        public void Render(Head head)
        {
            
            Coordinates.SetPosition();
            head.HeadPostionX = Coordinates.CursorPositionX;
            head.HeadPostionY = Coordinates.CursorPositionY;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Head.SnakeHead);
            Console.ResetColor();
        }

        public void Render(List<BodyDot> body)
        {
            for (int i = 0; i < body.Count; i++)
            {
                Coordinates.SetPosition(body[i].BodyDotPositionX, body[i].BodyDotPositionY);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(BodyDot.BodyDotSymbol);
                Console.ResetColor();
            }

        }

        public void Render(Dot dot)
        {
            
            Coordinates.SetPosition(dot.DotX, dot.DotY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(dot.FoodDotSymbol);
            Console.ResetColor();
            

        }






    }



}

