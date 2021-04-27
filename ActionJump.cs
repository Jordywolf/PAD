using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    public class ActionJump
    {
        float playerVelocityY;
        float playerJumpVelocity = 20;
        float playerZwaartekracht = 1.2f;
        public static Vector2 jumpLocation;
        public static bool playerOnGround = false;

        public void Jump()
        { 
            if (playerOnGround == true)
            {
                playerVelocityY = playerJumpVelocity;
                jumpLocation = Game1.player.LocalPosition;
                playerOnGround = false;
            }
        }

        public void Update()
        {
            if (playerOnGround == false)
            {
                Game1.player.LocalPosition -= new Vector2(0, playerVelocityY);
                playerVelocityY -= playerZwaartekracht;

                if (Game1.player.LocalPosition.Y > jumpLocation.Y)
                {
                    Game1.player.LocalPosition = new Vector2(Game1.player.LocalPosition.X, playerVelocityY);
                    playerOnGround = true;
                }
            }
            else
            {
                jumpLocation = Game1.player.LocalPosition;
            }
        }
    }
}
