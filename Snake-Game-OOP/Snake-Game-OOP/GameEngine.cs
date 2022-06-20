using Snake_Game_OOP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;


namespace Snake_Game_OOP
{
    public class GameEngine
    {

        public void Start(Body snake, IRenderer renderer, IProperties properties, IGameEnd gameEnd, ISoundPlayer soundPlayer, IPauser pauser)
        {
            renderer.Clear();
            GlobalConstants.highScore = 0;
            StateChecker checker = new StateChecker();
            properties.SetProperties();
            Random random = new Random();
            IFood food = new Food(random.Next(GlobalConstants.leftBorder, GlobalConstants.rightBorder), random.Next(GlobalConstants.upperBorder, GlobalConstants.lowerBorder));
            checker.CheckIfFoodLocationIsInsideSnake(food,snake);
            Direction direction = new Direction();
            if (GlobalConstants.test==1)
            {
                /// Fix this!
                GlobalConstants.test = 2;
                return;
            }

            while (true)
            {
                DateTime nextCheck = DateTime.Now.AddMilliseconds(GlobalConstants.delay);
                while (nextCheck > DateTime.Now)
                {
                    if (direction.Move(snake, gameEnd, pauser)) return;
                    Thread.Sleep(GlobalConstants.renderDelay);
                    renderer.Render(snake);
                    renderer.Render(food);
                    if (checker.CheckIfEaten<IDot>(snake.BodyOutput.First, food))
                    {
                        snake.AddDot(direction.CurrentDirect, snake.BodyOutput.Last);
                        soundPlayer.Play();
                        checker.CheckIfFoodLocationIsInsideSnake(food, snake);
                        properties.SetTitle();
                    }
                    if (checker.CheckIfDead(snake, gameEnd)) return;
                }
            }


        }
    }
}
