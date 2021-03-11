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
    class JogonLevelPlayingState
    {
        MapConstruction mapConstruction;

        public JogonLevelPlayingState(Texture2D aPillarTile) : base()
        {
            mapConstruction = new MapConstruction(aPillarTile);
        }

        public void JogonLevelConstruction(SpriteBatch spriteBatch, Player player, Jogonhead Jogon, List<JogonPart> JogonDragon, Texture2D Floortile, int width, int height, Texture2D WalltileStr, Texture2D WalltileStrD, Texture2D WalltileL, Texture2D WalltileR, Texture2D WalltileCrnL, Texture2D WalltileCrnR, Texture2D WalltileCrnDL, Texture2D WalltileCrnDR, Texture2D PillarTile)
        {
            mapConstruction.FloorConstruction(new Vector2(0, 0), Floortile, spriteBatch, width, height);
            mapConstruction.WallConstruction(new Vector2(0, 0), new Vector2(0, ((int)(height / Floortile.Height) - 1) * Floortile.Height), new Vector2(0, 0), new Vector2(((int)(width / Floortile.Width) - 1) * Floortile.Width, 0), spriteBatch, width, height, WalltileStr, WalltileStrD, WalltileL, WalltileR, WalltileCrnL, WalltileCrnR, WalltileCrnDL, WalltileCrnDR);
            mapConstruction.PillarSetup(spriteBatch, PillarTile, width, height, new Vector2(0, 0));


            foreach (Fireball fireball in Jogon.fireballs)
            {
                fireball.Draw(spriteBatch);
            }
            foreach (JogonPart part in JogonDragon)
            {
                part.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            Jogon.Draw(spriteBatch);

        }
    }
}
