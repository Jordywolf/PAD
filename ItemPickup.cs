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
    public class ItemPickup : mapObjects.Item
    {
        int actionId;

        public ItemPickup(string spriteName, int pActionId) : base(spriteName, new Vector2(Game1.width / 2 + 200, Game1.height / 2)) //Instantiate het item iets rechts van het midden van het scherm
        {
            Origin = sprite.Center; //De origin wordt naar het midden van de sprite gezet
            actionId = pActionId;   //Het item wordt naar het goede ID gezet wanneer hij geinstantiate wordt
        }

        public override void Update(GameTime gameTime)
        {
            if (CollisionDetection.ShapesIntersect(collisionRec, Game1.player.collisionRec))    //Collision check tussen het item en de speler
            {
                Game1.player.actionHandeler.actionId = actionId;                                //Zet het ID van de speler actie naar hetzelfde ID als de pickup
            }
            base.Update(gameTime);
        }
    }
}