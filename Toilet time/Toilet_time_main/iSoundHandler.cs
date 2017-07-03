using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace Toilet_time_main
{
    public enum ChooseBackGroundMusic { none, menu, game_noncry, game_cry }

    public enum ChooseSoundEffect { game_end, baby_laugh}

    public interface iSoundHandler
    {

        void PlayBackground(ChooseBackGroundMusic music);

        void PlaySoundEffect(ChooseSoundEffect sound_effect);

        void ToggleBackground(bool stats);

        void Togglesoundeffect(bool stats);

    }
}
