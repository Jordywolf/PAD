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
        SpriteGameObject Fontein, Key, rots, boom, deur;
        ObjectTile pilaar;
        TextGameObject NotCollected, Collected, PillarText;
        Boolean KeyCollected = false;
        public Vector2 TileSz2Pos = new Vector2(0, 0);
        public int LowerPosY = 570;
        public int PlatformPosY;

        public SafeZoneState(SpriteBatch spriteBatch, Texture2D ZandTile, Texture2D Sleutel, Texture2D SteenTile, Texture2D SteenVert) : base()
        {


            //Floor Construction + Stone Tiles
            LoadFullFloor("ZandTile");
            
            
            deur = new SpriteGameObject("Deur", 1);
            Fontein = new SpriteGameObject("Fontein", 1);
            rots = new SpriteGameObject("Rots", 1);
            boom = new SpriteGameObject("boom", 1);
            NotCollected = new TextGameObject("Eightbit", 1, Color.Black);
            Key = new SpriteGameObject("Sleutel", 1);
            pilaar = new ObjectTile("Pilaar", new Vector2(0,0));
            

            gameObjects.AddChild(deur);
            gameObjects.AddChild(Fontein);
            gameObjects.AddChild(rots);
            gameObjects.AddChild(boom);
            gameObjects.AddChild(NotCollected);
            
            gameObjects.AddChild(Key);
            walls.AddChild(pilaar);

            deur.LocalPosition = new Vector2(600, 0);
            deur.scale = 0.7f;
           
            
            
            Fontein.scale = 0.7f;
            Fontein.Origin = new Vector2(Fontein.sprite.Width / 2, Fontein.Height / 2);
            Fontein.LocalPosition = new Vector2(250, 150);
           
            
            
            rots.Origin = new Vector2(rots.sprite.Width / 2, rots.Height / 2);
            rots.scale = 0.9f;
            rots.LocalPosition = new Vector2(300, 300);


            boom.Origin = new Vector2(boom.sprite.Width / 2, boom.Height / 2);
            boom.scale = 0.5f;
            boom.LocalPosition = new Vector2(300, 550);

            
            
            NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 110);

            
            pilaar.LocalPosition = new Vector2(1000, 140);
            pilaar.Origin = new Vector2(pilaar.sprite.Width / 2, pilaar.sprite.Height / 2);
            pilaar.scale = 0.9f;
           
            
            
            Key.LocalPosition = new Vector2(1000, 100);
            pilaar.Origin = new Vector2(Key.sprite.Width / 2, Key.sprite.Height / 2);
            Key.scale = 0.5f;
 

            player1 = new Player();
            gameObjects.AddChild(player1);
            player1.Origin = new Vector2(player1.sprite.Width / 2, player1.sprite.Height / 2);
            player1.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(OverlapsWith(rots, player1) == true)
            {
                Vector2 PushDir = new Vector2(rots.LocalPosition.X - player1.LocalPosition.X, rots.LocalPosition.Y - player1.LocalPosition.Y);
                
                PushDir.Normalize();

                rots.LocalPosition = new Vector2(rots.LocalPosition.X + PushDir.X * 20, rots.LocalPosition.Y + PushDir.Y * 20);
            }
            if(OverlapsWith(pilaar,rots) == true)
            {
                Vector2 PushRots = new Vector2(pilaar.LocalPosition.X - rots.LocalPosition.X, pilaar.LocalPosition.Y - rots.LocalPosition.Y);
                PushRots.Normalize();
                pilaar.LocalPosition = new Vector2(pilaar.LocalPosition.X + PushRots.X * 20, pilaar.LocalPosition.Y + PushRots.Y * 20);

            }
            if(OverlapsWith(Key,player1)== true)
            {
                KeyCollected = true;
                Key.LocalPosition = new Vector2(-100, -100);
            }
            CollisionUpdate(player1);
            
            if (OverlapsWith(player1, deur) && KeyCollected == false)
            {
                NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 110);
                NotCollected.Text = "Oh, Seems i have to collect some sort of key first!";
            }
            if (OverlapsWith(player1, deur) && KeyCollected == true)
            {
                NotCollected.LocalPosition = new Vector2(deur.LocalPosition.X - 150, 110);
                NotCollected.Text = "Press Space to  enter Jogon's Lair";
            }
            if (OverlapsWith(player1, boom))
            {
                //player1.moveSpeed = 0;
                NotCollected.LocalPosition = new Vector2(boom.LocalPosition.X, boom.LocalPosition.Y - 100);
                NotCollected.Text = "This tree seems pretty useless.....";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && KeyCollected == true && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("jogonLevelPlayingState");
                Game1.framecount = Game1.startframe;
            }
        }
    }
}
