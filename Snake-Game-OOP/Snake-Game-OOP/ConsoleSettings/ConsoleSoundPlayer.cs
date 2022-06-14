
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
