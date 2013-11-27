// ***
// *
// * Aurality Studios
// *
// * Swype Algorithm Demo
// *
// * Zackary Misso & Tyler Young
// *
// ***
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwypeEmulatorDemo
{
    public class Key
    {
        private Vector2 position;
        private String value;
        private int width;
        private int height;

        public Key(Vector2 pos, String val)
        {
            position = pos;
            value = val;
            width = 32;
            height = 32;
        }

        public bool wasClicked(Vector2 param)
        {
            if ((param.X > position.X) && (param.X < position.X + width) && (param.Y > position.Y) && (param.Y < position.Y + height))
                return true;
            return false;
        }

        public void draw(SpriteBatch spriteBatch, Texture2D tex, SpriteFont font)
        {
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.DrawString(font, value, new Vector2(position.X + 8, position.Y + 2), Color.White);
        }

        public String getValue()
        {
            return value;
        }
    }
}
