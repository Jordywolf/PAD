using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    public class Player : Sprite
    {
        

        public Player(Texture2D texture)
            : base(texture)
        {

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            foreach (var targetSprite in sprites)
            {
                if (targetSprite == this)
                    continue;

               if (this.Velocity.X > 0 && this.IsTouchingLeft(targetSprite))
                {
                    targetSprite.Position += new Vector2(2, 0);
                    this.Velocity.X = 0;
                }
                if (this.Velocity.X < 0 && this.IsTouchingRight(targetSprite))
                {
                    targetSprite.Position -= new Vector2(2, 0);
                    this.Velocity.X = 0;
                }
                if (this.Velocity.Y > 0 && this.IsTouchingTop(targetSprite))
                {
                    targetSprite.Position += new Vector2(0, 2);
                    this.Velocity.Y = 0;
                }
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(targetSprite))
                {
                    targetSprite.Position -= new Vector2(0, 2);
                    this.Velocity.Y = 0;
                }
            }
            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;

            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity.Y = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity.Y = Speed;
        }

    }
}
