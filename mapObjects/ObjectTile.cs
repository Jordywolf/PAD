using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject
{
    class ObjectTile : SpriteGameObject
    {
        public ObjectTile(String assetname, Vector2 position) : base(assetname, 0.5f)
        {
            this.localPosition = position;
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            collisionRec = new Rectangle((int)localPosition.X - sprite.Width / 2, (int)localPosition.Y - sprite.Height / 2, sprite.Width, sprite.Height);
        }
    }
}
