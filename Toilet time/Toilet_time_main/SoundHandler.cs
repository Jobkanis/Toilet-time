using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace Toilet_time_main
{

    public class SoundHandler: iSoundHandler // global sound handler 
    {

        SoundEffectInstance menu_background;
        SoundEffectInstance ingame_background;
        SoundEffectInstance baby_laugh;
        SoundEffectInstance baby_cry;
        SoundEffectInstance end_level;

        ChooseBackGroundMusic current_background = ChooseBackGroundMusic.none;

        public bool togglebackground = true;
        public bool togglesoundeffect = true;

        public SoundHandler(SoundEffect menu_background, SoundEffect ingame_background, SoundEffect end_level, SoundEffect baby_laugh, SoundEffect baby_cry) // instatiates sounds from game1

        {
            this.menu_background = menu_background.CreateInstance();
            this.menu_background.IsLooped = true;

            this.ingame_background = ingame_background.CreateInstance();
            this.ingame_background.IsLooped = true;

            this.baby_cry = baby_cry.CreateInstance();
            this.baby_cry.Volume = 0.1f;
            this.baby_cry.IsLooped = true;

            this.end_level = end_level.CreateInstance();
            this.end_level.IsLooped = false;

            this.baby_laugh = baby_laugh.CreateInstance();
            this.baby_laugh.IsLooped = false;


        }

        public void PlayBackground(Toilet_time_main.ChooseBackGroundMusic music) //plays the backgroundmusic
        {

            switch (music)

            {

                case (ChooseBackGroundMusic.menu): //plays background for menu
                    {
                        current_background = ChooseBackGroundMusic.menu;
                        if (togglebackground)
                        {
                            menu_background.Play();
                            ingame_background.Stop();
                            baby_cry.Stop();
                        }
                        break;
                    }
                case (ChooseBackGroundMusic.game_noncry): // plays background ingame when not crying baby
                    {
                        current_background = ChooseBackGroundMusic.game_noncry;
                        if (togglebackground)
                        {
                            menu_background.Stop();
                            ingame_background.Play();
                            baby_cry.Stop();
                        }
                        break;
                    }
                case (Toilet_time_main.ChooseBackGroundMusic.game_cry): // plays background with crying baby
                    {
                        current_background = ChooseBackGroundMusic.game_cry;
                        if (togglebackground)
                        {
                            menu_background.Stop();
                            ingame_background.Play();
                            baby_cry.Play();
                        }
                        break;
                    }
                default: // stopps all music
                    {
                        menu_background.Stop();
                        ingame_background.Stop();
                        baby_cry.Stop();
                        break;
                    }
            }

        }

        public void PlaySoundEffect(Toilet_time_main.ChooseSoundEffect sound_effect) // plays sound effects
        {

            switch (sound_effect)
            {

                case (Toilet_time_main.ChooseSoundEffect.baby_laugh): // babylaugh sound
                    {
                        if (togglesoundeffect)
                        {
                            baby_laugh.Play();
                        }
                        break;
                    }
                case (Toilet_time_main.ChooseSoundEffect.game_end): // gameend sound
                    {
                        if (togglesoundeffect)
                        {
                            end_level.Play();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        public void ToggleBackground(bool stats) // toggle background to stats (on = true)
        {
            togglebackground = stats;
            if (stats == true)
            {
                PlayBackground(current_background); // play current background
            }
            else
            {
                PlayBackground(ChooseBackGroundMusic.none); // quiets background
            }
        }

        public void Togglesoundeffect(bool stats) // toggle soundeffects (on = true)
        {
            togglesoundeffect = stats;
        }
    }
}
