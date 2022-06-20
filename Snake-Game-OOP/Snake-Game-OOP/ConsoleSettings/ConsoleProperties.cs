using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP.ConsoleSettings
{
    public class ConsoleProperties : IProperties
    {


        public void SetProperties()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
          ConsoleHelper.SetCurrentFont(GlobalConstants.font, GlobalConstants.fontSize);
            Console.WindowHeight = GlobalConstants.consoleHeight;
            Console.WindowWidth = GlobalConstants.consoleWidth;
            Console.BufferHeight = GlobalConstants.consoleHeight;
            Console.BufferWidth = GlobalConstants.consoleWidth;
            Console.CursorVisible = GlobalConstants.cursorVisible;
            SetTitle();
            

        }

        public void SetTitle()
        {
            Console.Title = $"Snake  Highscore: {GlobalConstants.highScore++} | Controls: Arrow Keys (UP , DOWN, LEFT, RIGHT) | Press SPACE to Pause | Press ESC to Exit";
            
        }

       
    }
}
