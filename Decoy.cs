using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class Decoy
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        public Decoy(Texture2D decoyTexture)
        {
            texture = decoyTexture;
        }

        public void update()
        {
            position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
