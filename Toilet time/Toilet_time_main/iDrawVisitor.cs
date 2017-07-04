using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toilet_time_main
{
    public enum BackgroundType { menubackground, ingamebackground }

    public interface iDrawVisitor
    {
        SpriteBatch spriteBatch { get; }

        void DrawCursor(Point mousepoint);

        void DrawCharacter(Main_Character character);

        void DrawBaby(Baby baby);

        void DrawPlatform(Platform platform);

        void DrawMoveablePlatform(Moveable_Platform platform);

        void DrawSpawn(Spawn spawn);

        void DrawEnd(End_Goal end);

        void DrawDeadlyBrick(Deadly_Brick brick);

        void DrawButton(Button button);

        void DrawLabel(Label label);

        void DrawToiletPaper(Toilet_Paper toilet_paper);

        void DrawDebugConsole(Gui_Manager guimanager);

        void DrawBackground(BackgroundType background);

        
    }
}
