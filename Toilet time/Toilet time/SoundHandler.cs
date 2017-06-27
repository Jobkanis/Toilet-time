using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace Toilet_time
{
    public enum BackGroundMusic { none, menu, game_noncry, game_cry }

    public enum BackGroundSoundEffect { game_end, baby_laugh}

    public class SoundHandler
    {
       
       SoundEffectInstance menu_background;
       SoundEffectInstance game_background;
       SoundEffectInstance game_end;
       SoundEffectInstance baby_laugh;
       SoundEffectInstance baby_cry;


       


       public SoundHandler(SoundEffect menu_background, SoundEffect game_background, SoundEffect game_end, SoundEffect baby_laugh, SoundEffect baby_cry)
        {
            this.menu_background = menu_background.CreateInstance();
            this.menu_background.IsLooped = true;

            this.game_background = game_background.CreateInstance();
            this.menu_background.IsLooped = true;

            this.game_end = game_end.CreateInstance();
            this.game_end.IsLooped = false;

            this.baby_laugh = baby_laugh.CreateInstance();
            this.baby_laugh.IsLooped = false;

            this.baby_cry = baby_cry.CreateInstance();
            this.baby_cry.IsLooped = false;
        }

       public void PlayBackground(BackGroundMusic music)
        {
            switch (music)
            {
                case (BackGroundMusic.menu):
                    {
                        menu_background.Play();
                        game_background.Stop();
                        baby_cry.Stop();
                        break;
                    }
                case (BackGroundMusic.game_noncry):
                    {
                        menu_background.Stop();
                        game_background.Play();
                        baby_cry.Stop();
                        break;
                    }
                case (BackGroundMusic.game_cry):
                    {
                        menu_background.Stop();
                        game_background.Play();
                        baby_cry.Play();
                        break;
                    }
                default:
                    {
                        menu_background.Stop();
                        game_background.Stop();
                        baby_cry.Stop();
                        break;
                    }
            }
        }

        public void PlaySoundEffect(BackGroundSoundEffect sound_effect)
        {
            switch (sound_effect)
            {
                case (BackGroundSoundEffect.baby_laugh):
                    {
                        baby_laugh.Play();
                        break;
                    }
                case (BackGroundSoundEffect.game_end):
                    {
                        game_end.Play();
                        game_background.Stop();
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
