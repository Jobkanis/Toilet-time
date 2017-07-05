using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Toilet_time_main
{

    public interface Input_Adapter // amazing interface for inputadapter
    {
        InputData GetInput(int type);
    }
}