using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Game
{
    class Directions
    {


        public static ConsoleKeyInfo CurrentDirection { get; set; } = GlobalConstants.initialDirection;

            public static List<ConsoleKey> ActiveDirections { get; set; } = GlobalConstants.activeDirections;

        public static bool Move()
        {



            // List<ConsoleKey> ActiveDirections = new List<ConsoleKey>() {ConsoleKey.RightArrow,ConsoleKey.LeftArrow,ConsoleKey.UpArrow,ConsoleKey.DownArrow };

            // while (true)
            // {

           var prevDirection = CurrentDirection;
           
            if (Console.KeyAvailable)
            {
                CurrentDirection = Console.ReadKey(true);
                if (CurrentDirection.Key == ConsoleKey.Escape)
                {
                   return GameEngine.GameEnd();
                }

                if (CurrentDirection.Key == ConsoleKey.Spacebar)
                {
                    var input = Console.ReadKey(true);

                    while (input.Key != ConsoleKey.Spacebar)
                    {
                        input = Console.ReadKey(true);
                    }
                    
                }

                
              if (!ActiveDirections.Contains(CurrentDirection.Key))
                {
                   CurrentDirection = prevDirection;
                    
                }
                else
                {
                    if (prevDirection.Key==ConsoleKey.RightArrow && CurrentDirection.Key == ConsoleKey.LeftArrow)
                    {
                        CurrentDirection = prevDirection;
                    }

                    else if (prevDirection.Key == ConsoleKey.UpArrow && CurrentDirection.Key == ConsoleKey.DownArrow)
                    {
                        CurrentDirection = prevDirection;
                    }
                    else if (prevDirection.Key == ConsoleKey.LeftArrow && CurrentDirection.Key == ConsoleKey.RightArrow)
                    {
                        CurrentDirection = prevDirection;
                    }
                    else if (prevDirection.Key == ConsoleKey.DownArrow && CurrentDirection.Key == ConsoleKey.UpArrow)
                    {
                        CurrentDirection = prevDirection;
                    }
                }

            }

            switch (CurrentDirection.Key)
                {
                    case ConsoleKey.LeftArrow:

                        Coordinates.CursorPositionX--;
                        break;
                    case ConsoleKey.RightArrow:
                        Coordinates.CursorPositionX++; break;
                    case ConsoleKey.UpArrow:
                        Coordinates.CursorPositionY--; break;
                    case ConsoleKey.DownArrow:
                        Coordinates.CursorPositionY++;
                        break;
                
                    
                }

                if (Coordinates.CursorPositionX<Borders.LeftBorder)
                {
                    Coordinates.CursorPositionX = Borders.RightBorder - 1;
                }
                else if (Coordinates.CursorPositionX >= Borders.RightBorder)
                {
                    Coordinates.CursorPositionX = Borders.LeftBorder + 1;
                }
                else if (Coordinates.CursorPositionY < Borders.UpperBorder)
                {
                    Coordinates.CursorPositionY = Borders.LowerBorder - 1;
                }
                else if (Coordinates.CursorPositionY >= Borders.LowerBorder)
                {
                    Coordinates.CursorPositionY = Borders.UpperBorder + 1;
                }



            return false;


               
            //
                
            }
            

        }

    }

