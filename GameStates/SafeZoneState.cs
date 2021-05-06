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
    class SafeZoneState : GameState
    {
        SafeZone1 safeZone;
        public int height = 1080;
        public int width = 1920;
        Engine.SpriteGameObject Fontein, Key, rots, pilaar, boom, deur;




        public SafeZoneState(SpriteBatch spriteBatch,Texture2D ZandTile, Texture2D Sleutel, Texture2D SteenTile, Texture2D SteenVert) : base()
        {
            
        safeZone = new SafeZone1();
            
            spriteBatch.Begin();
            safeZone.SafeZone(ZandTile, Sleutel, spriteBatch);
            safeZone.SafeZoneStone(SteenTile, spriteBatch);
            safeZone.SafeZoneStoneVert(SteenVert, spriteBatch);
            safeZone.NextLevel1();
            spriteBatch.End();

            deur = new Engine.SpriteGameObject("Deur", 1);
            gameObjects.AddChild(deur);
            deur.LocalPosition = new Vector2(600, 0);
            deur.scale = 0.7f;
            Fontein = new Engine.SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(Fontein);
            Fontein.scale = 0.5f;
            Fontein.LocalPosition = new Vector2(200, 50);
            rots = new Engine.SpriteGameObject("Rots", 1);
            gameObjects.AddChild(rots);
            rots.scale = 0.5f;
            rots.LocalPosition = new Vector2(300, 300);
            boom = new Engine.SpriteGameObject("boom", 1);
            gameObjects.AddChild(boom);
            boom.scale = 0.5f;
            boom.LocalPosition = new Vector2(300, 400); 
            
            Key = new Engine.SpriteGameObject("Sleutel", 1);
            gameObjects.AddChild(Key);
            Key.LocalPosition = new Vector2(1000, 100);
            Key.scale = 0.5f;
            pilaar = new Engine.SpriteGameObject("Pilaar", 1);
            gameObjects.AddChild(pilaar);
            pilaar.LocalPosition = new Vector2(1000, 100);
            pilaar.scale = 0.5f;



        }

        public void SafzoneConstruction(SpriteBatch spriteBatch, Player player, List<Sprite> sprites, Texture2D ZandTile, Texture2D Sleutel, Texture2D SteenTile, Texture2D SteenVert)
        {
            spriteBatch.Begin();

            safeZone.SafeZone(ZandTile, Sleutel, spriteBatch);
            safeZone.SafeZoneStone(SteenTile, spriteBatch);
            safeZone.SafeZoneStoneVert(SteenVert, spriteBatch);
            safeZone.NextLevel1();

            spriteBatch.End();
            foreach (var sprite in sprites)
                sprite.Draw(spriteBatch);
        }
    }
}
