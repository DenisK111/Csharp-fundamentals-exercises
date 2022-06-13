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

        public void Start(Body snake, IRenderer renderer, IProperties properties, IGameEnd gameEnd, ISoundPlayer soundPlayer,IPauser pauser)
        {
            GlobalConstants.highScore = 0;
            StateChecker checker = new StateChecker();
            properties.SetProperties();
            Random random = new Random();
            IFood food = new Food(random.Next(GlobalConstants.leftBorder, GlobalConstants.rightBorder), random.Next(GlobalConstants.upperBorder, GlobalConstants.lowerBorder));
            Direction direction = new Direction();

            while (true)
            {
                DateTime nextCheck = DateTime.Now.AddMilliseconds(GlobalConstants.delay);
                while (nextCheck > DateTime.Now)
                {
                    if (direction.Move(snake, gameEnd,pauser)) return;
                    renderer.Render(snake);
                    renderer.Render(food);
                    if (checker.CheckIfEaten<IDot>(snake.BodyOutput.First, food))
                    {
                        snake.AddDot(direction.CurrentDirect, snake.BodyOutput.Last);
                        soundPlayer.Play();
                        food = new Food(random.Next(GlobalConstants.leftBorder, GlobalConstants.rightBorder), random.Next(GlobalConstants.upperBorder, GlobalConstants.lowerBorder));
                        while (checker.CheckIfFoodLocationIsInsideSnake(food, snake))
                            food = new Food(random.Next(GlobalConstants.leftBorder, GlobalConstants.rightBorder), random.Next(GlobalConstants.upperBorder, GlobalConstants.lowerBorder));
                        properties.SetTitle();
                    }
                    if (checker.CheckIfDead(snake, gameEnd)) return;
                    Thread.Sleep(GlobalConstants.renderDelay);
                    renderer.Clear();
                }
            }


        }
    }
}
