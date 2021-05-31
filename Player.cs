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
        public float moveSpeed = 10f;           //Movementspeed van de speler
        public int health;                      //Healt van de speler
        private int IframesCounter = 0;         //De timer die de invincibility van de speler bij houdt
        private int Iframes = 120;              //Het aantal frames dat de speler invisible is na een hit 
        public ActionHandeler actionHandeler;

        //De player wordt geinstantiate 
        public Player()
            : base("De_Rakker", 1)
        {
            health = 3;                                                 //Health wordt op 3 gezet
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);  //Origin wordt in het midden van de sprite gezet
            actionHandeler = new ActionHandeler();                      //De speler maakt zijn ActionHandler aan
        }
        public override void Update(GameTime gameTime)
        {
            actionHandeler.Update();

            //Collisionbox van de speler
            collisionRec = new Rectangle((int)localPosition.X - sprite.Width / 2, (int)localPosition.Y - sprite.Height / 2, sprite.Width, sprite.Height);
            
            //player shadow position word aangepast als de jump actief staat
            if (actionHandeler.actionId == 1)
            {
                Game1.playerShadow.LocalPosition = new Vector2(ActionJump.jumpLocation.X + sprite.Width / 2 - Game1.playerShadow.Width / 1.5f, ActionJump.jumpLocation.Y + sprite.Height - Game1.playerShadow.Height / 1.5f);
            }
            else
            {
                Game1.playerShadow.LocalPosition = new Vector2(LocalPosition.X + sprite.Width / 2 - Game1.playerShadow.Width / 1.5f, localPosition.Y + sprite.Height - Game1.playerShadow.Height / 1.5f);
            }

            //De Health van de player word offscreen gezet
            Game1.playerHealth1.LocalPosition = Game1.playerHealth2.LocalPosition = Game1.playerHealth3.LocalPosition = new Vector2(-300, 0);

            //Voor elke Health point de speler heeft word er een van de hartjes onscreen gezet
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

            //De invincibility tijd van de speler word afgeteld als het niet al 0 heeft bereikt
            if (IframesCounter != 0)
            {
                IframesCounter--;
            }
        }

        //De input van de speler
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            //De pijltjestoetsen en de WASD toetsen kunnen beide gebruikt worden
            //De JumpLocation wordt bijgehouden naast de speler zodat er gelopen kan worden tijdens de jumo

            if (inputHelper.KeyDown(Keys.Left) || inputHelper.KeyDown(Keys.A))
            {
                velocity.X = -moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.X -= moveSpeed;
                }
            }
            else if (inputHelper.KeyDown(Keys.Right) || inputHelper.KeyDown(Keys.D))
            {
                velocity.X = moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.X += moveSpeed;
                }
            }

            if (inputHelper.KeyDown(Keys.Up) || inputHelper.KeyDown(Keys.W))
            {
                velocity.Y = -moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.Y -= moveSpeed;
                }
            }
            else if (inputHelper.KeyDown(Keys.Down) || inputHelper.KeyDown(Keys.S))
            {
                velocity.Y = moveSpeed;
                if (ActionJump.playerOnGround == false)
                {
                    ActionJump.jumpLocation.Y += moveSpeed;
                }
            }

            //De positie van de speler word geupdate met de waardes die zijn gekregen door op de toetsen te drukken
            localPosition += velocity;
            velocity = Vector2.Zero;
        }

        //De spawn positie van de speler als hij op zijn normale plek moet beginnen
        public void SpawnLocationDefault()
        {
            localPosition = new Vector2(Game1.width / 2, Game1.height / 5 * 4);
        }

        //De spawn positie van de speler als hij onderaan het scherm moet beginnen
        public void SpawnLocationDown()
        {
            localPosition = new Vector2(Game1.width / 2, Game1.height - Game1.player.Height);
        }

        //De Hit functie zorgt er voor dat de speler gehit kan worden en zal health afrekken, als er geen health over is gaat de game naar de Death state
        //Ook wordt de invincibility timer aan gezet
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
