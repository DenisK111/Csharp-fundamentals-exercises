using Snake_Game_OOP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Game_OOP.ConsoleSettings
{
    public class ConsoleGameEnd : IGameEnd
    {
        private ISoundPlayer soundPlayer;

        public ConsoleGameEnd(ISoundPlayer soundPlayer)
        {
            this.soundPlayer = soundPlayer;
        }
        public bool End()
        {
            
            soundPlayer.Play(true);
            Thread.Sleep(GlobalConstants.gameEndDelay);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(GlobalConstants.consoleWidth / 2 - 5, GlobalConstants.consoleHeight / 2 - 2);
            Console.Write("GAME OVER");
            Console.SetCursorPosition(GlobalConstants.consoleWidth / 2 - 7, GlobalConstants.consoleHeight / 2);
            Console.Write($"High Score: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{--GlobalConstants.highScore}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(GlobalConstants.consoleWidth / 2 - 6, GlobalConstants.consoleHeight / 2 + 2);
            Console.Write("Play Again?");
            Console.SetCursorPosition(GlobalConstants.consoleWidth / 2 - 10, GlobalConstants.consoleHeight / 2 + 3);
            Console.Write("y = yes     n = no");
            ConsoleKeyInfo input = Console.ReadKey(true);
            while (input.Key != ConsoleKey.Y)
            {
                if (input.Key == ConsoleKey.N)
                {
                    Console.ResetColor();
                    Environment.Exit(0);

                }
                input = Console.ReadKey(true);
            }
            Console.ResetColor();
            return false;

        }
    }
}
