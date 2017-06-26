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
        Texture2D Texture_Main_Char_with_Baby;
        Texture2D Texture_Baby;

        public int CurrentHeight;
        public int CurrentWidth;

        public DrawVisitor(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, Texture2D Texture_Platform, Texture2D Texture_Main_Char, Texture2D Texture_Main_Char_with_Baby, Texture2D Texture_Baby)
        {
            this.graphics = graphics;
            CurrentHeight = 600;
            CurrentWidth = 800;

            this.spriteBatch = spriteBatch;
            this.Texture_Platform = Texture_Platform;
            this.Texture_Main_Char = Texture_Main_Char;
            this.Texture_Main_Char_with_Baby = Texture_Main_Char_with_Baby;
            this.Texture_Baby = Texture_Baby;

        }

        public void DrawCharacter(Main_Character character)
        {
            if (character.HasBaby)
            {
                spriteBatch.Draw(Texture_Main_Char_with_Baby, new Rectangle(character.position.x, character.position.y, character.size.x, character.size.y), character.color);
            }
            else
            {
                spriteBatch.Draw(Texture_Main_Char, new Rectangle(character.position.x, character.position.y, character.size.x, character.size.y), character.color);
            }
        }

        public void DrawBaby(Baby baby)
        {
            if (baby.Visible == true)
            {
                spriteBatch.Draw(Texture_Baby, new Rectangle(baby.position.x, baby.position.y, baby.size.x, baby.size.y), baby.color);
            }
        }

        public void DrawPlatform(Platform platform)
        {
            spriteBatch.Draw(Texture_Platform, new Rectangle(platform.position.x, platform.position.y, platform.size.x, platform.size.y), platform.color);
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
