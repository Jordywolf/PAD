using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Engine;

namespace BaseProject
{
    public class ItemPickup : SpriteGameObject
    {
        int actionId;
        public ItemPickup(string spriteName, int pActionId) : base(spriteName, 1)
        {
            Origin = sprite.Center;
            actionId = pActionId;
            LocalPosition = new Vector2(Game1.width / 2 + 200, Game1.height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (CollisionDetection.ShapesIntersect(BoundingBox, Game1.player.BoundingBox))
            {
                Game1.player.actionHandeler.actionId = actionId;
                LocalPosition = new Vector2(-300, 0);
                Game1.GameStateManager.SwitchTo("safeZoneState2");
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}