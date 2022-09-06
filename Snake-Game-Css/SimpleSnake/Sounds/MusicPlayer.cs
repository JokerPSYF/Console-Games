using System;
using System.Media;

namespace SimpleSnake.Sounds
{
    public sealed class MusicPlayer
    {
        private SoundPlayer player;
        private string song;

        private MusicPlayer()
        {
            if (OperatingSystem.IsWindows())
            {
                player = new SoundPlayer();
            }
        }
        private static MusicPlayer instance = null;
        public static MusicPlayer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MusicPlayer();
                }
                return instance;
            }
        }

        public void Play(string songPath)
        {
            this.song = songPath;
            if (OperatingSystem.IsWindows())
            {
                // player = music player
                this.player.SoundLocation = this.song;
                this.player.Load();
                this.player.PlayLooping();

            }
        }

        public void Stop()
        {
            if (OperatingSystem.IsWindows())
            {
                this.player.Stop();
            }
        }

    }
}
