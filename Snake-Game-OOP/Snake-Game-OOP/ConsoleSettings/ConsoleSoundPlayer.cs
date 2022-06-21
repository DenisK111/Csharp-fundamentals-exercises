
using System.Linq;
using System.Media;


namespace Snake_Game_OOP.Contracts
{
    class ConsoleSoundPlayer : ISoundPlayer
    {
        private string path;
        SoundPlayer player;
        public ConsoleSoundPlayer(string path)
        {
            player = new SoundPlayer();
            this.path = path;
            player.SoundLocation = path;
        }
        public void Play()
        {
            player.Play();
        }

        public void Play(bool gameEnded)
        {
            player.SoundLocation = GlobalConstants.endGameSoundFilePath;
            player.Play();
            player.SoundLocation = path;
        }
    }
}
