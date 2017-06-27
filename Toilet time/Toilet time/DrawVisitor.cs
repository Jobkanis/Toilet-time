﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toilet_time
{
    public class DrawVisitor
    {
        public SpriteBatch spriteBatch;
        public SpriteFont arial;
        public GraphicsDeviceManager graphics;
        public Texture2D Texture_White_Pixel;
        public Texture2D Texture_Platform;
        public Texture2D Texture_Main_Char;
        public Texture2D Texture_Main_Char_with_Baby;
        public Texture2D Texture_Baby;

        public int CurrentHeight;
        public int CurrentWidth;

        public DrawVisitor(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, SpriteFont arial, Texture2D Texture_White_Pixel, Texture2D Texture_Platform, Texture2D Texture_Main_Char, Texture2D Texture_Main_Char_with_Baby, Texture2D Texture_Baby, Texture2D Texture_Toilet, Texture2D Texture_Toilet_With_Baby)
        {
            this.graphics = graphics;
            CurrentHeight = 600;
            CurrentWidth = 800;

            this.spriteBatch = spriteBatch;
            this.Texture_White_Pixel = Texture_White_Pixel;
            this.Texture_Platform = Texture_Platform;
            this.Texture_Main_Char = Texture_Main_Char;
            this.Texture_Main_Char_with_Baby = Texture_Main_Char_with_Baby;
            this.Texture_Baby = Texture_Baby;
            this.arial = arial;

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

        public void DrawButton(Button button)
        {
            spriteBatch.Draw(Texture_White_Pixel, new Rectangle((int)button.position.x, (int)button.position.y, (int)button.size.x, (int)button.size.y), button.color);
            if (button.label != null)
            {
                this.DrawLabel(button.label);
            }

        }

        public void DrawLabel(Label label)
        {
            Vector2 textsize = arial.MeasureString(label.text);
            int textsize_x = (int)textsize.X;
            int textsize_y = (int)textsize.Y;
            spriteBatch.DrawString(arial, label.text, new Vector2(label.position.x + ((label.size.x - textsize_x) / 2), label.position.y + ((label.size.y - textsize_y) / 2)), label.color);
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
