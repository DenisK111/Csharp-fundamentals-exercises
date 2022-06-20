using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
    public abstract class GlobalConstants
    {
        public static int test = 1;
        public static int highScore = 0;
        public static readonly int consoleHeight = 20;
        public static readonly int consoleWidth = 50;
        public static readonly bool cursorVisible = false;
        public static readonly char dotSymbol = '\U000025A0';
        public static readonly string symbolOfHeadDot = "\U000025A0";
        public static readonly string symbolOfBodyDot = "\U000025A0";
        public static readonly string foodSymbol = "\U000025A0";
        public static readonly ConsoleKeyInfo initialDirection = new ConsoleKeyInfo((char)ConsoleKey.LeftArrow, ConsoleKey.LeftArrow, false, false, false);
        public static readonly int initialCursorPositionX = consoleWidth / 2;
        public static readonly int initialCursorPositionY = consoleHeight / 2;
        public static readonly int upperBorder = 0;
        public static readonly int lowerBorder = consoleHeight;
        public static readonly int leftBorder = 0;
        public static readonly int rightBorder = consoleWidth;
        public static readonly int initialBodyLength = 20;
        public static readonly int delay = 120;
        public static readonly string font = "Lucida Console";
        public static readonly short fontSize = 20;
        public static readonly ConsoleColor bodyDotColor = ConsoleColor.Yellow;
        public static readonly ConsoleColor headColor = ConsoleColor.Blue;
        public static readonly ConsoleColor foodColor = ConsoleColor.Red;
        public static readonly ConsoleColor pauseColor = ConsoleColor.Cyan;
        public static readonly string soundFilePath = @"..\..\..\converted_mixkit-positive-interface-beep-221.wav";
        public static readonly string endGameSoundFilePath = @"..\..\..\mixkit-wrong-answer-fail-notification-946.wav";
        public static readonly HashSet<ConsoleKey> activeDirections = new HashSet<ConsoleKey>() {
             ConsoleKey.RightArrow,
             ConsoleKey.LeftArrow,
            ConsoleKey.UpArrow,
             ConsoleKey.DownArrow };
        public static readonly int renderDelay = 20;
        public static readonly int gameEndDelay = 150;


    }
}
