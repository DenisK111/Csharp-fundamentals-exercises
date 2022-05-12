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
            SetConsoleProperties();

            Head head = new Head();

            List<BodyDot> body = GenerateBody(head);
            Dot dot = new Dot();
            CheckDotLocation(body, dot, head);


            while (true)
            {

                Directions.Move();
                MoveBody(body, head);
                head.Render(head);
                head.Render(body);
                dot.Render(dot);
                

                CheckIfDead(head, body);
                if (CheckIfEaten(head, dot))
                {
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

              
                Thread.Sleep(100);
                Console.Clear();

            }


        }

        public static void SetConsoleProperties()
        {

            Console.WindowHeight = GlobalConstants.consoleHeight;
            Console.WindowWidth = GlobalConstants.consoleWidth;
            Console.BufferHeight = GlobalConstants.consoleHeight;
            Console.BufferWidth = GlobalConstants.consoleWidth;
            Console.CursorVisible = false;
            Borders.SetBorders();
            // Thread movement = new Thread(new ThreadStart(Directions.Move));
            // movement.Start();


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

        public static void CheckIfDead(Head head, List<BodyDot> body)
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
                    GameEnd();
                }

            }


        }

        public static bool CheckIfEaten(Head head, Dot dot)
        {

            return head.HeadPostionX == dot.DotX && head.HeadPostionY == dot.DotY;

        }

        public static void CheckDotLocation(List<BodyDot> body, Dot dot, Head head)
        {
            Random random = new Random();
            bool flag = true;
            while (flag)
            {
                for (int i = 0; i < body.Count; i++)
                {
                    if (body[i].BodyDotPositionX == dot.DotX && body[i].BodyDotPositionY == dot.DotY)
                    {
                        dot.DotX = random.Next(1, GlobalConstants.consoleWidth);
                        dot.DotY = random.Next(1, GlobalConstants.consoleHeight);
                        break;
                    }

                    if (i == body.Count - 1 && head.HeadPostionX != dot.DotX && head.HeadPostionY != dot.DotY)
                    {
                        flag = false;
                    }
                }
            }
        }

        public static void GameEnd()
        {



            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Coordinates.SetPosition(GlobalConstants.consoleWidth / 2 - 5, GlobalConstants.consoleHeight / 2);
            Console.Write("GAME OVER");
            Console.ReadKey();
            Environment.Exit(0);

        }
    }
}
