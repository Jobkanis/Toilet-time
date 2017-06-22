using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toilet_time
{
    public class DrawVisitor
    {
        public SpriteBatch spriteBatch;
        public Texture2D Texture_Platform;
        
        public DrawVisitor(SpriteBatch spriteBatch, Texture2D Texture_Platform)
        {
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
            
            spriteBatch.Draw(Texture_Platform, new Rectangle(platform.x, platform.y, platform.x_size, platform.y_size), Color.White);

        }

        public void DrawSpawn(Spawn spawn)
        {

        }

        public void DrawEnd(End_Goal end)
        {

        }
    }
}
