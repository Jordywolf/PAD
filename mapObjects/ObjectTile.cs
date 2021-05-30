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
        public int invisTimer = 0;

        /// <summary>
        /// deze class is een licht aangepaste versie van een spritegameobject waarbij je gelijk de positi kan aanpassen en de depth is al bepaald
        /// daarnaast zit er ook een collision rectangle ingebouwd
        /// </summary>
        /// <param name="assetname"></param>
        /// <param name="position"></param>
        public ObjectTile(String assetname, Vector2 position, float depth) : base(assetname, depth)
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
