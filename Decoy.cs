using System;
using System.Collections.Generic;
using System.Text;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class Decoy : SpriteGameObject
    {
        public Rectangle collision;

        public Decoy(String decoyTexture) : base(decoyTexture, 1)
        {
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            velocity = Vector2.Zero;

            collision = new Rectangle((int)localPosition.X - sprite.Width/2, (int)localPosition.Y - sprite.Height/2, sprite.Width, sprite.Height);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyDown(Keys.Up))
            {
                velocity.Y = -500;
            }
            if (inputHelper.KeyDown(Keys.Down))
            {
                velocity.Y = 500;
            }
            if (inputHelper.KeyDown(Keys.Left))
            {
                velocity.X = -500;
            }
            if (inputHelper.KeyDown(Keys.Right))
            {
                velocity.X = 500;
            }
        }
    }
}