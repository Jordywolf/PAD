using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace BaseProject.GameStates
{
    class SafeZoneState : Engine.GameState
    {
        SafeZone1 safeZone;


        public SafeZoneState() : base()
        {
            safeZone = new SafeZone1();
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
