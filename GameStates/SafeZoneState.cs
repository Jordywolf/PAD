using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.GameStates
{
    class SafeZoneState : Engine.LevelPlayingState
    {
       
        public int height = 1080;
        public int width = 1920;
        Player player1;
        private Vector2 steenSize = new Vector2(0, 0);
        private Vector2 steenPos = new Vector2(8, 8);
        SpriteGameObject Fontein, rots, boom, deur;
        mapObjects.Item Key;
        ObjectTile pilaar;
        TextGameObject NotCollected, Collected, PillarText;
        Boolean KeyCollected = false;
        public Vector2 TileSz2Pos = new Vector2(0, 0);
        public int LowerPosY = 570;
        public int PlatformPosY;
        private bool playerSpawned;

        public SafeZoneState() : base()
        {


            //Floor Construction + Stone Tiles
            LoadFullFloor("ZandTile");
            LoadSquareWalls("PAD_Jg_walltileCornerDL", "PAD_Jg_walltileStraightD", "PAD_Jg_walltileCornerDR", "PAD_Jg_walltileR",
   "PAD_Jg_walltileCornerR", "PAD_Jg_walltileStraight", "PAD_Jg_walltileCornerL", "PAD_Jg_walltileL");


            deur = new ObjectTile("Deur", new Vector2(0, 0), 1);
            Fontein = new ObjectTile("Fontein", new Vector2(0, 0), 1);
            rots = new SpriteGameObject("Rots", 1);
            boom = new ObjectTile("boom", new Vector2(0,0), 1);
            NotCollected = new TextGameObject("Eightbit", 1, Color.Black);
            Key = new mapObjects.Item("Sleutel", new Vector2(1000, 100));
            pilaar = new ObjectTile("Pilaar", new Vector2(0,0), 1);
            

            walls.AddChild(deur);
            walls.AddChild(Fontein);
            gameObjects.AddChild(rots);
            walls.AddChild(boom);
            gameObjects.AddChild(NotCollected);
            
            gameObjects.AddChild(Key);
            walls.AddChild(pilaar);

            deur.Origin = new Vector2(deur.sprite.Width / 2, deur.sprite.Height / 2 -30);
            deur.LocalPosition = new Vector2(600, 80);
            deur.scale = 1.2f;


            Fontein.Origin = new Vector2(Fontein.sprite.Width / 2, Fontein.Height / 2 - 30);
            Fontein.scale = 1f;
           
            Fontein.LocalPosition = new Vector2(250, 80);
           
            
            
            rots.Origin = new Vector2(rots.sprite.Width / 2, rots.Height / 2);
            rots.scale = 1f;
            rots.LocalPosition = new Vector2(300, 300);

            
            boom.LocalPosition = new Vector2(300, 470);
            boom.Origin = new Vector2(boom.sprite.Width / 2, boom.Height / 2 );
            boom.scale = 1.5f;
            

            
            
            NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 110);

            
            pilaar.LocalPosition = new Vector2(980, 110);
            pilaar.Origin = new Vector2(pilaar.sprite.Width / 2, pilaar.sprite.Height / 2);
            pilaar.scale = 1f;
           
            
            
            pilaar.Origin = new Vector2(Key.sprite.Width / 2, Key.sprite.Height / 2);
            Key.scale = 0.5f;
 

            player1 = Game1.player;
            gameObjects.AddChild(player1);
            player1.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);
            gameObjects.AddChild(Game1.playerShadow);
            Game1.playerShadow.Origin = Game1.playerShadow.sprite.Center;
            gameObjects.AddChild(Game1.playerHealth1);
            gameObjects.AddChild(Game1.playerHealth2);
            gameObjects.AddChild(Game1.playerHealth3);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!playerSpawned)
            {
                Game1.player.SpawnLocationDefault();
                Game1.player.actionHandeler.actionId = 0;
                playerSpawned = true;
            }

            if (OverlapsWith(rots, player1) == true)
            {
                Vector2 PushDir = new Vector2(rots.LocalPosition.X - player1.LocalPosition.X, rots.LocalPosition.Y - player1.LocalPosition.Y);
                
                PushDir.Normalize();

                rots.LocalPosition = new Vector2(rots.LocalPosition.X + PushDir.X * 20, rots.LocalPosition.Y + PushDir.Y * 20);
                Game1.BoulderShove.Play(1, Game1.Random.Next(-1, 2), 0);
            }
            if(OverlapsWith(pilaar,rots) == true)
            {
                Vector2 PushRots = new Vector2(pilaar.LocalPosition.X - rots.LocalPosition.X, pilaar.LocalPosition.Y - rots.LocalPosition.Y);
                PushRots.Normalize();
                pilaar.LocalPosition = new Vector2(pilaar.LocalPosition.X + PushRots.X * 20, pilaar.LocalPosition.Y + PushRots.Y * 20);
                pilaar.LocalPosition = new Vector2(-100, -100);
                rots.LocalPosition = new Vector2(-100, -100);
            }
            if(OverlapsWith(Key,player1)== true)
            {
                KeyCollected = true;
                Key.LocalPosition = new Vector2(-100, -100);
            }

           
            CollisionUpdate(player1);  CollisionUpdate(rots);

            if (OverlapsWith(player1, deur) && KeyCollected == false )
            {
                NotCollected.Color = Color.Red;
                NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 160);
                NotCollected.Text = "Oh, Seems i have to collect some sort of key first!";
            }
            
           
            if (OverlapsWith(player1, pilaar) && KeyCollected == false)
            {
                NotCollected.Color = Color.Red;
                NotCollected.LocalPosition = new Vector2(pilaar.LocalPosition.X - 170, pilaar.LocalPosition.Y + 100);
                NotCollected.Text = "There seems to be some sort of key behind this pillar \nbut i cant push it!";
            }
            if (OverlapsWith(player1, deur) && KeyCollected == true)
            {
                NotCollected.Color = Color.Green;
                NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 160);
                NotCollected.Text = "Press Space to  enter Jogon's Lair";
            }
            if (OverlapsWith(player1, boom))
            {
                
                NotCollected.Color = Color.Red;
                NotCollected.LocalPosition = new Vector2(boom.LocalPosition.X, boom.LocalPosition.Y - 100);
                NotCollected.Text = "This tree seems pretty useless.....";
            }
            if (OverlapsWith(player1,Fontein))
            {

                NotCollected.Color = Color.Blue;
                NotCollected.LocalPosition = new Vector2(Fontein.LocalPosition.X, Fontein.LocalPosition.Y + 100);
                NotCollected.Text = "This fontain's water restored my health!";
                player1.health = 3;
                gameObjects.AddChild(Game1.playerHealth1);
                gameObjects.AddChild(Game1.playerHealth2);
                gameObjects.AddChild(Game1.playerHealth3);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && KeyCollected == true && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("jogonLevelPlayingState", "safeZoneState", new GameStates.SafeZoneState());
                Game1.framecount = Game1.startframe;
            }
        }
    }
}
