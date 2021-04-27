using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Engine.GameStates
{
    class SafeZoneState : GameState
    {
        BaseProject.SafeZone1 safeZone;
        BaseProject.Fontein fontein;


        public SafeZoneState() : base()
        {
            safeZone = new BaseProject.SafeZone1();
        }

        public void SafeZoneConstruction(SpriteBatch spriteBatch, BaseProject.Player player, List<BaseProject.Sprite> sprites, Texture2D ZandTile, Texture2D Sleutel, Texture2D SteenTile, Texture2D SteenVert)
        {
            spriteBatch.Begin();
            fontein = new BaseProject.Fontein();
            //this.AddChild(fontein);
            
            safeZone.SafeZone(ZandTile, Sleutel, spriteBatch);
            safeZone.SafeZoneStone(SteenTile, spriteBatch);
            safeZone.SafeZoneStoneVert(SteenVert, spriteBatch);
            safeZone.NextLevel1();
            spriteBatch.End();
            foreach (var sprite in sprites)
                sprite.Draw(spriteBatch);
            player.Draw(spriteBatch);

        }
    }
}
