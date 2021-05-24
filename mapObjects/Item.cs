using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.mapObjects
{
    public class Item : SpriteGameObject
    {

        public Item(String assetName, Vector2 position , float depth = 1) : base(assetName, depth)
        {
            localPosition = position;
            Origin = sprite.Center;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            localPosition = new Vector2(localPosition.X, localPosition.Y + MathF.Sin(Game1.framecount/10)*1.5f);
        }
    }
}
