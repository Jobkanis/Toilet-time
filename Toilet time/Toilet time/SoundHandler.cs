using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace Toilet_time
{
    public enum BackGroundMusic { none, menu, game}

    public class SoundHandler
    {

        SoundEffect menu_background;
        SoundEffect game_background;



       public SoundHandler(SoundEffect menu_background, SoundEffect game_background)
        {
            this.menu_background = menu_background;
            this.game_background = game_background;
        }

        public void PlayBackground(BackGroundMusic music)
        {
            switch (music)
            {
                case (BackGroundMusic.menu):
                    {
                        SoundEffectInstance background_instance = menu_background.CreateInstance();
                        background_instance.IsLooped = true;
                        background_instance.Play();

                        break;
                    }
                case (BackGroundMusic.game):
                    {
                        SoundEffectInstance gamebackground_instance = game_background.CreateInstance();
                        gamebackground_instance.IsLooped = true;
                        gamebackground_instance.Play();

                        break;
                    }
                default:
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.IsRepeating = false;
                        break;
                    }
            }
        }

    }
}
