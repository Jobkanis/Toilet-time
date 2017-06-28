using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Media;


namespace Toilet_time
{
    public enum ChooseBackGroundMusic { none, menu, game_noncry, game_cry }

    public enum ChooseSoundEffect { game_end, baby_laugh}

    public class SoundHandler
    {
       
       SoundEffectInstance menu_background;
       SoundEffectInstance ingame_background;
       SoundEffectInstance baby_laugh;
       SoundEffectInstance baby_cry;
       SoundEffectInstance end_level;

       
       


       public SoundHandler(SoundEffect menu_background, SoundEffect ingame_background, SoundEffect end_level, SoundEffect baby_laugh, SoundEffect baby_cry)
        {
            this.menu_background = menu_background.CreateInstance();
            this.menu_background.IsLooped = true;

            this.ingame_background = ingame_background.CreateInstance();
            this.ingame_background.IsLooped = true;

            this.baby_cry = baby_cry.CreateInstance();
            this.baby_cry.Volume = 0.1f;
            this.baby_cry.IsLooped = true;

            ///////

            this.end_level = end_level.CreateInstance();
            this.end_level.IsLooped = false;

            this.baby_laugh = baby_laugh.CreateInstance();
            this.baby_laugh.IsLooped = false;


        }

       public void PlayBackground(ChooseBackGroundMusic music)
        {
            switch (music)
            {
                case (ChooseBackGroundMusic.menu):
                    {
                        menu_background.Play();
                        ingame_background.Stop();
                        baby_cry.Stop();
                        break;
                    }
                case (ChooseBackGroundMusic.game_noncry):
                    {
                        menu_background.Stop();
                        ingame_background.Play();
                        baby_cry.Stop();
                        break;
                    }
                case (ChooseBackGroundMusic.game_cry):
                    {
                        menu_background.Stop();
                        ingame_background.Play();
                        baby_cry.Play();
                        break;
                    }
                default:
                    {
                        menu_background.Stop();
                        ingame_background.Stop();
                        baby_cry.Stop();
                        break;
                    }
            }
        }

        public void PlaySoundEffect(ChooseSoundEffect sound_effect)
        {
            switch (sound_effect)
            {
                case (ChooseSoundEffect.baby_laugh):
                    {
                        baby_laugh.Play();
                        break;
                    }
                case (ChooseSoundEffect.game_end):
                    {
                        end_level.Play();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

    }
}
