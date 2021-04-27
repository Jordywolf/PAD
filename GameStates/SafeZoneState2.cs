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
    class SafeZoneState2 : GameState
    {
        BaseProject.SafeZone2 safeZone2;


        public SafeZoneState2() : base()
        {
            safeZone2 = new BaseProject.SafeZone2();
        }

        public void Safezone2Construction(SpriteBatch spriteBatch, BaseProject.Player player, List<BaseProject.Sprite> sprites, Texture2D ZandTile, Texture2D Sleutel, Texture2D TileSz2, Texture2D TileSz3)
        {
            spriteBatch.Begin();

            safeZone2.MovingPlatForm(TileSz3, spriteBatch);
            safeZone2.SafeZone(TileSz2, spriteBatch);
            safeZone2.SafeZonePlatForm(TileSz2, spriteBatch);
            safeZone2.NextLevel2();
            spriteBatch.End();
            foreach (var sprite in sprites)
                sprite.Draw(spriteBatch);
            player.Draw(spriteBatch);

        }
    }
}
