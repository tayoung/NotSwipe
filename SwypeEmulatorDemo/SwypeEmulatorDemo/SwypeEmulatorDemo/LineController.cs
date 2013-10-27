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
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwypeEmulatorDemo
{
    public class LineController
    {
        private ArrayList points;
        private Vector2 cursorPosition;
        private Texture2D tex;

        public LineController()
        {
            points = new ArrayList();
        }

        public Vector2 getLastPoint()
        {
            return (Vector2)points[points.Count-1];
        }

        public bool addPoint(Vector2 param){
            if (!param.Equals(cursorPosition))
            {
                points.Add(param);
                cursorPosition = param;
                return true;
            }
            return false;
        }

        public void clear()
        {
            points.Clear();
        }

        public void draw(SpriteBatch spriteBatch)
        {
            for (int i = 1; i < points.Count; i++)
            {
                Vector2 t1 = (Vector2)points[i - 1];
                Vector2 t2 = (Vector2)points[i];
                float angle = (float)Math.Atan2(t1.Y - t2.Y, t1.X - t2.X);
                float dist = Vector2.Distance(t1, t2);
                spriteBatch.Draw(tex, new Rectangle((int)t2.X, (int)t2.Y, (int)dist, 1), null, Color.White, angle, Vector2.Zero, SpriteEffects.None, 0);
            }
        }

        public void setTexture(Texture2D param)
        {
            tex = param;
        }
    }
}
