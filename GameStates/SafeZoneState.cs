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
        SafeZone1 safeZone;
        public int height = 1080;
        public int width = 1920;
        Player player1;
        private Vector2 steenSize = new Vector2(0, 0);
        private Vector2 steenPos = new Vector2(Game1.width/2, Game1.height/2);
        SpriteGameObject Fontein, Key, rots, pilaar, boom, deur;
        Boolean KeyCollected = false;


        public SafeZoneState(SpriteBatch spriteBatch,Texture2D ZandTile, Texture2D Sleutel, Texture2D SteenTile, Texture2D SteenVert) : base()
        {
            
        safeZone = new SafeZone1();
            //Floor Construction + Stone Tiles
            LoadFullFloor("ZandTile");
            


            deur = new SpriteGameObject("Deur", 1);
            gameObjects.AddChild(deur);
            deur.LocalPosition = new Vector2(600, 0);
            deur.scale = 0.7f;
            Fontein = new SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(Fontein);
            Fontein.scale = 0.7f;
            Fontein.LocalPosition = new Vector2(125, 50);
            rots = new SpriteGameObject("Rots", 1);
            gameObjects.AddChild(rots);
            rots.Origin = new Vector2(rots.sprite.Width / 2, rots.Height / 2);
            rots.scale = 0.5f;
            rots.LocalPosition = new Vector2(300, 300);
            boom = new SpriteGameObject("boom", 1);
            gameObjects.AddChild(boom);
            boom.scale = 0.5f;
            boom.LocalPosition = new Vector2(300, 400); 
            
            Key = new SpriteGameObject("Sleutel", 1);
            gameObjects.AddChild(Key);
            Key.LocalPosition = new Vector2(1000, 100);
            Key.scale = 0.5f;
            pilaar = new SpriteGameObject("Pilaar", 1);
            gameObjects.AddChild(pilaar);
            pilaar.LocalPosition = new Vector2(1000, 100);
            pilaar.scale = 0.5f;

            player1 = new Player();
            gameObjects.AddChild(player1);
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
        }
    }
}
