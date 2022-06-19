using Snake_Game_OOP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP.ConsoleSettings
{
    class ConsoleRenderer : IRenderer
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Render(Body body)
        {


            foreach (var item in body.BodyOutput)
            {
            Console.SetCursorPosition(item.Value.X, item.Value.Y);
            Console.ForegroundColor = item.Value.Color;
            Console.Write(item.Value.Symbol);

            }

            
            Console.SetCursorPosition(body.BodyOutput.Last.Value.Value.X, body.BodyOutput.Last.Value.Value.Y);
            Console.Write(' ');
        }

        public void Render(IFood food)
        {
            
            Console.SetCursorPosition(food.X, food.Y);
            Console.ForegroundColor = food.Color;
            Console.Write(food.Symbol);
                  




        }

        
    }
}
