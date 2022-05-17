using System;

namespace Snake_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            
                GameEngine.Start();
            // start new process
            System.Diagnostics.Process.Start("Snake-Game.exe");

            // close current process
            Environment.Exit(0);

        }
    }
}
