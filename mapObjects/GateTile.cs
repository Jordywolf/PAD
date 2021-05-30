using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.mapObjects
{
    class GateTile : ObjectTile
    {
        /// <summary>
        /// deze tile zorgt ervoor dat de speler naar een andere gamestate kan worden gezet, hiervoor is wel een andere overlaps functe
        /// </summary>
        /// <param name="assetname"></param>
        /// <param name="position"></param>

        public GateTile(String assetname, Vector2 position) : base(assetname, position, 0.8f)
        {
        }

        public void WarpCheck(String targetGameState, SpriteGameObject p)
        {
            if (CollisionDetection.ShapesIntersect(this.collisionRec, p.collisionRec))
            {
                Game1.player.LocalPosition = new Vector2(Game1.width / 2, Game1.height - Game1.player.Height);
                Game1.GameStateManager.SwitchTo(targetGameState);
            }
        }
    }
}
