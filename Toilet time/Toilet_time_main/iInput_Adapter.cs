using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Toilet_time_main
{

    public interface Input_Adapter
    {
        InputData GetInput(int type);
    }
}