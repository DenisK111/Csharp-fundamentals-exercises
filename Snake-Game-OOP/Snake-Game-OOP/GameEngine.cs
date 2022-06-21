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
        private Body snake;
        private IRenderer renderer;
        private IProperties properties;
        private IGameEnd gameEnd;
        private ISoundPlayer soundPlayer;
        private IPauser pauser;
        private Random random = new Random();

        public GameEngine(Body snake, IRenderer renderer, IProperties properties, IGameEnd gameEnd, ISoundPlayer soundPlayer, IPauser pauser)
        {
            this.snake = snake;
            this.renderer = renderer;
            this.properties = properties;
            this.gameEnd = gameEnd;
            this.soundPlayer = soundPlayer;
            this.pauser = pauser;

        }

        public void Start()
        {
            renderer.Clear();
            GlobalConstants.highScore = 0;
            StateChecker checker = new StateChecker();
            properties.SetProperties();
            IFood food = new Food();
            checker.CheckIfFoodLocationIsInsideSnake(food, snake);
            Direction direction = new Direction();
            if (GlobalConstants.test == 1)
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
