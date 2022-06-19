using Snake_Game_OOP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP.ConsoleSettings
{
    class ConsolePauser : IPauser
    {
        public void Pause()
        {
            Console.ForegroundColor = GlobalConstants.pauseColor;
            Console.SetCursorPosition(GlobalConstants.consoleWidth / 2 - 3, GlobalConstants.consoleHeight / 2 -2);
            Console.Write("PAUSE");
            Console.SetCursorPosition(GlobalConstants.consoleWidth / 2 - 13, GlobalConstants.consoleHeight / 2);
            Console.Write("Press \"Space\" to continue");

            var input = Console.ReadKey(true);

            while (input.Key != ConsoleKey.Spacebar)
            {
                input = Console.ReadKey(true);
            }

            Console.Clear();

            

        }

           }
}
