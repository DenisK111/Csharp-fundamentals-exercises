using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Snake_Game_OOP.ConsoleSettings;
using Snake_Game_OOP.Contracts;

namespace Snake_Game_OOP
{
    public class DependencyConfigurator 
    {
        public IServiceProvider Configure()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.AddSingleton<IRenderer, ConsoleRenderer>();
            collection.AddTransient<GameEngine, GameEngine>();
            collection.AddSingleton<InitialCoordinates, InitialCoordinates>();
            collection.AddSingleton<IPauser, ConsolePauser>();
            collection.AddTransient<IDot, BodyDot>();
            collection.AddTransient<IFood, Food>();
            collection.AddSingleton<IGameEnd, ConsoleGameEnd>();
            collection.AddSingleton<IProperties, ConsoleProperties>();
            collection.AddSingleton<ISoundPlayer, ConsoleSoundPlayer>();
            collection.AddTransient<Body, Body>();
            collection.AddSingleton(typeof(string),(IServiceProvider provider) => GlobalConstants.soundFilePath);
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;

        }
    }
}
