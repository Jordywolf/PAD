using System;
using System.Collections.Generic;
using System.Text;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    public class Player : SpriteGameObject
    {
        public float moveSpeed = 15f;
        public int health;
        private int IframesCounter = 0;
        private int Iframes = 120;

        public Player()
            : base("De_Rakker",1)
        {
            health = 3;
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }
        public override void Update(GameTime gameTime)
        {
            /*foreach (var targetSprite in sprites)
            {
                if (targetSprite == this)
                    continue;

                if (velocity.X > 0 && this.IsTouchingLeft(targetSprite))
                {
                    targetSprite.Position += new Vector2(2, 0);
                    velocity.X = 0;
                }
                if (velocity.X < 0 && this.IsTouchingRight(targetSprite))
                {
                    targetSprite.Position -= new Vector2(2, 0);
                    velocity.X = 0;
                }
                if (velocity.Y > 0 && this.IsTouchingTop(targetSprite))
                {
                    targetSprite.Position += new Vector2(0, 2);
                    velocity.Y = 0;
                }
                if (velocity.Y < 0 && this.IsTouchingBottom(targetSprite))
                {
                    targetSprite.Position -= new Vector2(0, 2);
                    velocity.Y = 0;
                }
            }*/

            if (IframesCounter != 0)
            {
                IframesCounter--;
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyDown(Keys.Left))
            {
                velocity.X = -moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.X -= moveSpeed;
                }
            }
            else if (inputHelper.KeyDown(Keys.Right))
            {
                velocity.X = moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.X += moveSpeed;
                }
            }

            if (inputHelper.KeyDown(Keys.Up))
            {
                velocity.Y = -moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.Y -= moveSpeed;
                }
            }
            else if (inputHelper.KeyDown(Keys.Down))
            {
                velocity.Y = moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.Y += moveSpeed;
                }
            }
            localPosition += velocity;
            velocity = Vector2.Zero;
        }

        public void Hit()
        {
            if(IframesCounter == 0)
            {
                if (health > 0)
                {
                    health--;
                }
                else
                {
                    Game1.GameStateManager.SwitchTo("deathState");
                    health = 3;
                }
                IframesCounter = Iframes;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (IframesCounter == 0)
            {
                base.Draw(gameTime, spriteBatch);
            }
            else
            {
                spriteBatch.Draw(Game1.Player, GlobalPosition, new Color(Color.White, 200));
            }

            spriteBatch.Draw(Game1.PlayerShadow, new Vector2(ActionJump.jumpLocation.X + sprite.Width / 2 - Game1.PlayerShadow.Width / 2, ActionJump.jumpLocation.Y + sprite.Height - Game1.PlayerShadow.Height / 2), new Color(Color.White, 100));
            
            if (health >= 1)
            {
                spriteBatch.Draw(Game1.PlayerHealth, new Vector2(Game1.PlayerHealth.Width / 2, Game1.PlayerHealth.Height / 2), Color.White);
            }
            if (health >= 2)
            {
                spriteBatch.Draw(Game1.PlayerHealth, new Vector2(Game1.PlayerHealth.Width * 1.75f, Game1.PlayerHealth.Height / 2), Color.White);
            }
            if (health >= 3)
            {
                spriteBatch.Draw(Game1.PlayerHealth, new Vector2(Game1.PlayerHealth.Width * 2f + Game1.PlayerHealth.Width, Game1.PlayerHealth.Height / 2), Color.White);
            }
        }
    }
}
