using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Engine;

namespace BaseProject
{
    public class ActionJump
    {
        float playerVelocityY;                      //De snelheid op de Y as van de sprong van de speler
        float playerJumpVelocity = 20;              //De kracht van de sprong van de speler
        float playerZwaartekracht = 1.2f;           //De kracht waarmee de speler weer terug getrokken word naar de grond
        public static Vector2 jumpLocation;         //De positie van de grond waar de speler zich boven bevindt tijdens een sprong
        public static bool playerOnGround = true;   //Een bool die zegt of de speler op de grond is

        //De functie om te springen
        public void Jump()
        {
            //Check of de speler zich op de grond bevindt voor een sprong
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
                Game1.player.LocalPosition -= new Vector2(0, playerVelocityY);  //De positioe van de speler veranderd met de Y velocity van de sprong
                playerVelocityY -= playerZwaartekracht;                         //Er wordt continu zwaartekracht aangebracht aan de Velocity

                if (Game1.player.LocalPosition.Y > jumpLocation.Y)              //Er word gechecked of de speler weer land en word weer op de juiste positie gezet
                {
                    Game1.player.LocalPosition = jumpLocation;
                    playerOnGround = true;
                }
            }
            else
            {
                jumpLocation = Game1.player.LocalPosition;  //Als de speler op de grond staat word de locatie gewoon normaal geupdate
            }
        }
    }
}
