using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toilet_time
{
    public class DrawVisitor
    {
        public SpriteBatch spriteBatch;
        public GraphicsDeviceManager graphics;
        public Texture2D Texture_Platform;
        Texture2D Texture_Main_Char;
        public int CurrentHeight;
        public int CurrentWidth;

        public DrawVisitor(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, Texture2D Texture_Platform, Texture2D Texture_Main_Char)
        {
            this.graphics = graphics;
            CurrentHeight = 600;
            CurrentWidth = 800;

            this.spriteBatch = spriteBatch;
            this.Texture_Platform = Texture_Platform;
            this.Texture_Main_Char = Texture_Main_Char;

        }

        public void DrawCharacter(Main_Character character)
        {
            spriteBatch.Draw(Texture_Main_Char, new Rectangle(character.position.x, character.position.y, character.size.x, character.size.y), Color.White);
        }

        public void DrawBaby(Baby baby)
        {

        }

        public void DrawPlatform(Platform platform)
        {
            spriteBatch.Draw(Texture_Platform, new Rectangle(platform.position.x, platform.position.y, platform.size.x, platform.size.y), Color.White);
        }

        public void DrawSpawn(Spawn spawn)
        {

        }

        public void DrawEnd(End_Goal end)
        {

        }

        public void DrawRectale(iObject screengui)
        {

        }

        public void DrawLabel(Label label)
        {

        }

        enum Dimensions { x, y }
        private int ConvertToSize(Dimensions dimension, float percent, int extra)
        {
            int returntype = 0;
            switch (dimension)
            {
                case Dimensions.x:
                    {
                        returntype = (int)(CurrentWidth * percent) + extra;
                        break;
                    }
                case Dimensions.y:
                    {
                        returntype = (int)(CurrentHeight * percent) + extra;
                        break;
                    }
            }

            return returntype;
        }

    }
}
