using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Snake_Game_OOP.Contracts
{
    class ConsoleSoundPlayer : ISoundPlayer
    {
        SoundPlayer player;
        public ConsoleSoundPlayer(string path)
        {
            player = new SoundPlayer();
            player.SoundLocation = path;
        }
        public void Play()
        {
            player.Play();
        }
    }
}
