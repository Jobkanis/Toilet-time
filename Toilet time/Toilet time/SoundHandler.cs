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
       
       SoundEffectInstance menu_background;
       SoundEffectInstance game_background;


       public SoundHandler(SoundEffect menu_background, SoundEffect game_background)
        {
            this.menu_background = menu_background.CreateInstance();
            this.menu_background.IsLooped = true;
            this.game_background = game_background.CreateInstance();
            this.menu_background.IsLooped = false;
        }

       public void PlayBackground(BackGroundMusic music)
        {
            switch (music)
            {
                case (BackGroundMusic.menu):
                    {
                        menu_background.Play();
                        game_background.Stop();
                        break;
                    }
                case (BackGroundMusic.game):
                    {
                        menu_background.Stop();
                        game_background.Play();
                        break;
                    }
                default:
                    {
                        menu_background.Stop();
                        game_background.Stop();
                        break;
                    }
            }
        }

    }
}
