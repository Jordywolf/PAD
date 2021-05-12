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
    class SafeZoneState2 : GameState
    {
        SafeZone2 safeZone2;
        SpriteGameObject Fontein2, rots2, deur2;
        public Vector2 deurPos = new Vector2(600, 0);




        public SafeZoneState2(SpriteBatch spriteBatch, Texture2D TileSz3, Texture2D TileSz2) : base()
        {

            //safeZone2 = new SafeZone2();

            /*spriteBatch.Begin();
            safeZone2.MovingPlatForm(TileSz3, spriteBatch);
            safeZone2.SafeZone(TileSz2, spriteBatch);
            safeZone2.SafeZonePlatForm(TileSz2, spriteBatch);
            safeZone2.NextLevel2();
            spriteBatch.End();*/

            deur2 = new SpriteGameObject("Deur", 1);
            gameObjects.AddChild(deur2);
            deur2.LocalPosition = deurPos;
            deur2.scale = 0.9f;
            Fontein2 = new SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(Fontein2);
            Fontein2.scale = 0.3f;
            Fontein2.LocalPosition = new Vector2(400, 50);
            rots2 = new SpriteGameObject("Rots", 1);
            gameObjects.AddChild(rots2);
            rots2.scale = 0.3f;
            rots2.LocalPosition = new Vector2(300, 300);





        }


    }
}