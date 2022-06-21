using Microsoft.Extensions.DependencyInjection;
using Snake_Game_OOP.ConsoleSettings;
using Snake_Game_OOP.Contracts;
using System;


namespace Snake_Game_OOP
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = new DependencyConfigurator().Configure();
            while (true)
            {
                serviceProvider.GetRequiredService<GameEngine>().Start();

            }


        }
    }
}

//InitialCoordinates initialCoordinates = new InitialCoordinates();
//  Body snake = new Body(initialCoordinates);
//IRenderer renderer = new ConsoleRenderer();
//IProperties consoleProperties = new ConsoleProperties();
//ISoundPlayer soundPlayer = new ConsoleSoundPlayer(GlobalConstants.soundFilePath);
// ISoundPlayer endSoundPlayer = new ConsoleSoundPlayer(GlobalConstants.endGameSoundFilePath);
// IGameEnd gameEnd = new ConsoleGameEnd(endSoundPlayer);
// IPauser pauser = new ConsolePauser();
