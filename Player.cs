﻿using System;
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
        public float moveSpeed = 10f;
        public int health;
        private int IframesCounter = 0;
        private int Iframes = 120;
        public ActionHandeler actionHandeler;

        public Player()
            : base("De_Rakker", 1)
        {
            health = 3;
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            actionHandeler = new ActionHandeler();
        }
        public override void Update(GameTime gameTime)
        {
            collisionRec = new Rectangle((int)localPosition.X - sprite.Width / 2, (int)localPosition.Y - sprite.Height / 2, sprite.Width, sprite.Height);

            actionHandeler.Update();
            collisionRec = new Rectangle((int)localPosition.X - sprite.Width / 2, (int)localPosition.Y - sprite.Height / 2, sprite.Width, sprite.Height);
            if (actionHandeler.actionId == 1)
            {
                Game1.playerShadow.LocalPosition = new Vector2(ActionJump.jumpLocation.X + sprite.Width / 2 - Game1.playerShadow.Width / 1.5f, ActionJump.jumpLocation.Y + sprite.Height - Game1.playerShadow.Height / 1.5f);
            }
            else
            {
                Game1.playerShadow.LocalPosition = new Vector2(LocalPosition.X + sprite.Width / 2 - Game1.playerShadow.Width / 1.5f, localPosition.Y + sprite.Height - Game1.playerShadow.Height / 1.5f);
            }

            Game1.playerHealth1.LocalPosition = Game1.playerHealth2.LocalPosition = Game1.playerHealth3.LocalPosition = new Vector2(-300, 0);

            if (health >= 1)
            {
                Game1.playerHealth1.LocalPosition = new Vector2(Game1.playerHealth1.Width * 0.5f, Game1.playerHealth1.Height / 2);
            }
            if (health >= 2)
            {
                Game1.playerHealth2.LocalPosition = new Vector2(Game1.playerHealth2.Width * 1.75f, Game1.playerHealth2.Height / 2);
            }
            if (health >= 3)
            {
                Game1.playerHealth3.LocalPosition = new Vector2(Game1.playerHealth3.Width * 3f, Game1.playerHealth3.Height / 2);
            }

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

            if (inputHelper.KeyDown(Keys.H))
            {
                localPosition = new Vector2(Game1.width / 2, Game1.height / 4);
            }
        }

        public void SpawnLocationDefault()
        {
            localPosition = new Vector2(Game1.width / 2, Game1.height/5*4);
        }

        public void SpawnLocationDown()
        {
            localPosition = new Vector2(Game1.width / 2, Game1.height - Game1.player.Height);
        }

        public void Hit()
        {
            if (IframesCounter == 0)
            {
                if (health > 1)
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
    }
}
