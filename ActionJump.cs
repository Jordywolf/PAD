using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    public class ActionJump : Game1
    {
        float playerVelocityY;
        float PLAYERJUMPVELOCITY = 20;
        float PLAYERZWAARTEKRACHT = 1.2f;
        Vector2 jumpLocation;
        bool playerOnGround;

        public void Jump()
        { 
            if (playerOnGround == true)
            {
                playerVelocityY = PLAYERJUMPVELOCITY;
                jumpLocation = player.Position;
                playerOnGround = false;
            }
        }

        public void Update()
        {
            if (playerOnGround == false)
            {
                player.Position.Y -= playerVelocityY;
                playerVelocityY -= PLAYERZWAARTEKRACHT;

                if (player.Position.Y > jumpLocation.Y)
                {
                    player.Position.Y = jumpLocation.Y;
                    playerOnGround = true;
                }
            }
        }
    }
}
