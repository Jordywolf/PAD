using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject
{
    class ActionJump // jump action
    {
        float playerVelocityY;
        float PLAYERJUMPVELOCITY = 20;
        float PLAYERZWAARTEKRACHT = 1.2f;
        bool playerOnGround;

        public void Jump()
        { 
            if (playerOnGround == true)
            {
                playerVelocityY = PLAYERJUMPVELOCITY;
                playerOnGround = false;
            }
        }

        public void Update()
        {
/*            playerY -= playerVelocityY;
            playerVelocityY -= PLAYERZWAARTEKRACHT;

            if (playerY > horizonY - PLAYERHEIGHT + GROUNDLEVEL)
            {
                playerY = horizonY - PLAYERHEIGHT + GROUNDLEVEL;
                playerOnGround = true;
            }*/
        }
    }
}
