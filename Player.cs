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
        

        public Player(Texture2D texture, Vector2 position)
            : base(texture)
        {
            this.Position = position;
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
            {
                Velocity.X = -Speed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.X -= Speed;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.X += Speed;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.Y -= Speed;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.Y += Speed;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.Draw(Game1.PlayerShadow, new Vector2(ActionJump.jumpLocation.X + _texture.Width / 2 - Game1.PlayerShadow.Width / 2, ActionJump.jumpLocation.Y + _texture.Height - Game1.PlayerShadow.Height / 2), new Color(color, 100));
            spriteBatch.End();
        }
    }
}
