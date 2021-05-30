using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.mapObjects
{
    class PillarTile : ObjectTile
    {
        public bool hit = false;

        /// <summary>
        /// deze class is een objectile class met een timer zodat dit object 'stuk' kan gaan waarbij hij switched tussen 2 plaatjes met een
        /// timer die er aan gebonden zit
        /// </summary>
        /// <param name="assetname"></param>
        /// <param name="position"></param>
        
        public PillarTile(String assetname, Vector2 position) : base(assetname, position, 0.8f)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (invisTimer > 0)
            {
                invisTimer--;
                sprite = new SpriteSheet("PAD_Jg_pillar_broken", 1);
                hit = true;
            }
            else if (invisTimer <= 0)
            {
                invisTimer = 0;
                sprite = new SpriteSheet("PAD_Jg_pillar", 1);
                hit = false;
            }
        }
    }
}
