namespace Snake_Game_OOP.Contracts
{
    using System;
    public interface IDot
    {
        
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; }

        public ConsoleColor Color {get;}

        

    }
}