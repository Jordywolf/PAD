using System;
using System.Collections.Generic;
using System.Text;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

    class Decoy : Engine.SpriteGameObject
    {
        public Decoy(String decoyTexture) : base(decoyTexture, 1)
        {
            Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            localPosition = inputHelper.MousePositionScreen;
        }
    }