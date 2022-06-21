using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
   public interface ISoundPlayer
    {
        void Play();

        void Play(bool gameOver);
    }
}
