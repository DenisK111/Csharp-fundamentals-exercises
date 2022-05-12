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
            Console.Write(Head.SnakeHead);
        }

        public void Render(List<BodyDot> body)
        {
            for (int i = 0; i < body.Count; i++)
            {
                Coordinates.SetPosition(body[i].BodyDotPositionX, body[i].BodyDotPositionY);
                Console.Write(BodyDot.BodyDotSymbol);
            }

        }

        public void Render(Dot dot)
        {
            
            Coordinates.SetPosition(dot.DotX, dot.DotY);
            Console.Write(dot.FoodDotSymbol);
            

        }






    }



}

