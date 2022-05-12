using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    class GlobalConstants
    {
        public GlobalConstants()
        {

        }

        public static int consoleHeight = 40;
        public static int consoleWidth = 100;
        public static bool cursorVisible = false;
        public static string symbolOfHeadDot = "@";
        public static string symbolOfBodyDot = "*";
        public static ConsoleKeyInfo initialDirection = new ConsoleKeyInfo((char)ConsoleKey.LeftArrow, ConsoleKey.LeftArrow, false, false, false);
        public static int initialCursorPositionX = consoleWidth / 2;
        public static int initialCursorPositionY = consoleHeight / 2;
        public static int upperBorder = 0;
        public static int lowerBorder = consoleHeight;
        public static int leftBorder = 0;
        public static int rightBorder = consoleWidth;
        public static List<ConsoleKey> activeDirections = new List<ConsoleKey>() {ConsoleKey.RightArrow,ConsoleKey.LeftArrow,ConsoleKey.UpArrow,ConsoleKey.DownArrow };
        public static int initialBodyLength = 20;
        public static string foodSymbol = "%";
    }

}

