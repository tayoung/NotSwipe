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
    public class Keyboard
    {
        private Key[] keys;
        private SpriteFont font;
        private Texture2D keyTexture;

        public Keyboard()
        {
            keys=new Key[26];
            keys[0] = new Key(new Vector2(0, 0),"q");
            keys[1] = new Key(new Vector2(32, 0), "w");
            keys[2] = new Key(new Vector2(64, 0), "e");
            keys[3] = new Key(new Vector2(96, 0), "r");
            keys[4] = new Key(new Vector2(128, 0), "t");
            keys[5] = new Key(new Vector2(160, 0), "y");
            keys[6] = new Key(new Vector2(192, 0), "u");
            keys[7] = new Key(new Vector2(224, 0), "i");
            keys[8] = new Key(new Vector2(256, 0), "o");
            keys[9] = new Key(new Vector2(288, 0), "p");
            keys[10] = new Key(new Vector2(10, 32), "a");
            keys[11] = new Key(new Vector2(42, 32), "s");
            keys[12] = new Key(new Vector2(74, 32), "d");
            keys[13] = new Key(new Vector2(106, 32), "f");
            keys[14] = new Key(new Vector2(138, 32), "g");
            keys[15] = new Key(new Vector2(170, 32), "h");
            keys[16] = new Key(new Vector2(202, 32), "j");
            keys[17] = new Key(new Vector2(234, 32), "k");
            keys[18] = new Key(new Vector2(266, 32), "l");
            keys[19] = new Key(new Vector2(20, 64), "z");
            keys[20] = new Key(new Vector2(52, 64), "x");
            keys[21] = new Key(new Vector2(84, 64), "c");
            keys[22] = new Key(new Vector2(116, 64), "v");
            keys[23] = new Key(new Vector2(148, 64), "b");
            keys[24] = new Key(new Vector2(180, 64), "n");
            keys[25] = new Key(new Vector2(212, 64), "m");
        }

        public String onClick(Vector2 param)
        {
            for (int i = 0; i < keys.Length; i++)
                if (keys[i].wasClicked(param))
                    return keys[i].getValue();
            return "";
        }

        public void draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < keys.Length; i++)
                keys[i].draw(spriteBatch,keyTexture,font);
        }

        public Key[] getKeys()
        {
            return keys;
        }

        public void setFont(SpriteFont param)
        {
            font = param;
        }

        public void setTexture(Texture2D param)
        {
            keyTexture = param;
        }
    }
}
