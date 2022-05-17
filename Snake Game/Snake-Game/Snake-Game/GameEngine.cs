using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Game
{
    class GameEngine
    {
        public static void Start()
        {

            bool newGame = false;
            SetConsoleProperties();

            Head head = new Head();

            List<BodyDot> body = GenerateBody(head);
            Dot dot = new Dot();
            CheckDotLocation(body, dot, head);


            DateTime nextCheck = DateTime.Now.AddMilliseconds(GlobalConstants.delay);
            while (nextCheck > DateTime.Now)
            {

                newGame = Directions.Move();
                if (newGame)
                    break;
                MoveBody(body, head);
                Console.Clear();
                dot.Render(dot);
                head.Render(head);
                head.Render(body);


                newGame = CheckIfDead(head, body);
                if (newGame)
                    break;
                if (CheckIfEaten(head, dot))
                {
                    Console.Title = $"Snake  Highscore: {++GlobalConstants.highScore} | Controls: Arrow Keys (UP , DOWN, LEFT, RIGHT) | Press SPACE to Pause | Press ESC to Exit";
                    switch (Directions.CurrentDirection.Key)
                    {
                        case ConsoleKey.UpArrow:
                            body.Add(new BodyDot(body[body.Count - 1].BodyDotPositionX, body[body.Count - 1].BodyDotPositionY + 1));
                            break;
                        case ConsoleKey.DownArrow:
                            body.Add(new BodyDot(body[body.Count - 1].BodyDotPositionX, body[body.Count - 1].BodyDotPositionY - 1));
                            break;
                        case ConsoleKey.LeftArrow:
                            body.Add(new BodyDot(body[body.Count - 1].BodyDotPositionX + 1, body[body.Count - 1].BodyDotPositionY));

                            break;
                        case ConsoleKey.RightArrow:
                            body.Add(new BodyDot(body[body.Count - 1].BodyDotPositionX - 1, body[body.Count - 1].BodyDotPositionY));
                            break;

                    }
                    dot = new Dot();
                    CheckDotLocation(body, dot, head);
                }


                Thread.Sleep(35);

                nextCheck = DateTime.Now.AddMilliseconds(GlobalConstants.delay);

            }


        }

        public static void SetConsoleProperties()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsoleHelper.SetCurrentFont(GlobalConstants.font,GlobalConstants.fontSize);
            Console.WindowHeight = GlobalConstants.consoleHeight;
            Console.WindowWidth = GlobalConstants.consoleWidth;
            Console.BufferHeight = GlobalConstants.consoleHeight;
            Console.BufferWidth = GlobalConstants.consoleWidth;
            Console.CursorVisible = false;
            Borders.SetBorders();
            Console.Title = GlobalConstants.title;



        }

        public static List<BodyDot> GenerateBody(Head head)
        {
            List<BodyDot> body = new List<BodyDot>();
            for (int i = 1; i <= BodyDot.Length; i++)
            {
                body.Add(new BodyDot(head.HeadPostionX + i, head.HeadPostionY));
            }

            return body;
        }

        public static void MoveBody(List<BodyDot> body, Head head)
        {

            int prevX = head.HeadPostionX;
            int prevY = head.HeadPostionY;

            for (int i = 0; i < body.Count; i++)
            {
                int currX = body[i].BodyDotPositionX;
                int currY = body[i].BodyDotPositionY;
                body[i].BodyDotPositionX = prevX;
                body[i].BodyDotPositionY = prevY;
                prevX = currX;
                prevY = currY;
            }

        }

        public static bool CheckIfDead(Head head, List<BodyDot> body)
        {
            int[][] allLengths = new int[body.Count][];

            for (int i = 0; i < body.Count; i++)
            {
                allLengths[i] = new int[] { body[i].BodyDotPositionX, body[i].BodyDotPositionY };
            }

            foreach (var item in allLengths)
            {
                if (head.HeadPostionX == item[0] && head.HeadPostionY == item[1])
                {
                    return GameEnd();
                }

            }

            return false;
        }

        public static bool CheckIfEaten(Head head, Dot dot)
        {

            return head.HeadPostionX == dot.DotX && head.HeadPostionY == dot.DotY;

        }

        public static void CheckDotLocation(List<BodyDot> body, Dot dot, Head head)
        {
            Random random = new Random();


            while (body.FirstOrDefault(x => ((x.BodyDotPositionX == dot.DotX && x.BodyDotPositionY == dot.DotY) || (head.HeadPostionX == dot.DotX && head.HeadPostionY == dot.DotY))) != null)
            {
                dot.DotX = random.Next(1, GlobalConstants.consoleWidth);
                dot.DotY = random.Next(1, GlobalConstants.consoleHeight);
            }


        }

        public static bool GameEnd()
        {



            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Coordinates.SetPosition(GlobalConstants.consoleWidth / 2 - 5, GlobalConstants.consoleHeight / 2 - 2);
            Console.Write("GAME OVER");
            Coordinates.SetPosition(GlobalConstants.consoleWidth / 2 - 7, GlobalConstants.consoleHeight / 2);
            Console.Write($"High Score: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{GlobalConstants.highScore}");
            Console.ForegroundColor = ConsoleColor.Red;
            Coordinates.SetPosition(GlobalConstants.consoleWidth / 2 - 6, GlobalConstants.consoleHeight / 2 + 2 );
            Console.Write("Play Again?");
            Coordinates.SetPosition(GlobalConstants.consoleWidth / 2 - 10, GlobalConstants.consoleHeight / 2 + 3);
            Console.Write("y = yes     n = no");
            ConsoleKeyInfo input = Console.ReadKey(true);
            while (input.Key != ConsoleKey.Y)
            {
                if (input.Key == ConsoleKey.N)
                {
                    Environment.Exit(0);

                }
                input = Console.ReadKey(true);
            }
            Console.ResetColor();
            return true;


        }
    }
}
