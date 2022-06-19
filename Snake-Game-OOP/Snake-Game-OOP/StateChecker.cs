using Snake_Game_OOP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
    public class StateChecker
    {

        public bool CheckIfEaten<T>(LinkedListNode<LinkedListNode<IDot>> head, IFood food)
        {

            if (head.Value.Value.X == food.X && head.Value.Value.Y == food.Y)
            {

                return true;
            }

            return false;


        }

        public bool CheckIfDead(Body snake, IGameEnd gameEnd)
        {
            foreach (var item in snake.BodyOutput.Where(x => x.Value.Color == GlobalConstants.bodyDotColor && x != snake.BodyOutput.Last.Value))
            {
                if (snake.BodyOutput.First.Value.Value.X == item.Value.X && snake.BodyOutput.First.Value.Value.Y == item.Value.Y)
                {
                    gameEnd.End();
                    return true;
                }
            }

            return false;
        }

        public bool CheckIfFoodLocationIsInsideSnake(IFood food, Body snake)
        {
            foreach (var item in snake.BodyOutput)
            {
                
                if (food.X == item.Value.X && food.Y == item.Value.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
