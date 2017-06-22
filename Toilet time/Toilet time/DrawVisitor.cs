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
        public int CurrentHeight;
        public int CurrentWidth; 

        public DrawVisitor(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, Texture2D Texture_Platform)
        {
            this.graphics = graphics;
            CurrentHeight = 600;
            CurrentWidth = 800;

            this.spriteBatch = spriteBatch;
            this.Texture_Platform = Texture_Platform;

        }

        public void DrawCharacter(Main_Character character)
        {

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
