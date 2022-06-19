using Snake_Game_OOP.ConsoleSettings;
using Snake_Game_OOP.Contracts;
using System;


namespace Snake_Game_OOP
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                InitialCoordinates initialCoordinates = new InitialCoordinates(GlobalConstants.initialCursorPositionX, GlobalConstants.initialCursorPositionY);
                IRenderer renderer = new ConsoleRenderer();
                IProperties consoleProperties = new ConsoleProperties();
                Body snake = new Body(initialCoordinates);
                ISoundPlayer soundPlayer = new ConsoleSoundPlayer(GlobalConstants.soundFilePath);
                ISoundPlayer endSoundPlayer = new ConsoleSoundPlayer(GlobalConstants.endGameSoundFilePath);
                IGameEnd gameEnd = new ConsoleGameEnd(endSoundPlayer);
                IPauser pauser = new ConsolePauser();
                GameEngine engine = new GameEngine();
                engine.Start(snake, renderer, consoleProperties,gameEnd,soundPlayer,pauser);
            }


        }
    }
}
