using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject
{
    class JogonPart : RotatingSpriteGameObject
    {
        public GameObject target;
        public float _followSpeed = 70;
        protected float _followRange = 100f;
        protected bool segment = true;

        // constructor met de nodige informatie om jogonpart te laten functioneren
        public JogonPart(Vector2 position, float velocity, string texture, float followDist, SpriteGameObject Target, float depth) : base(texture, depth,100)
        {
            scale = 1.5f;
            _followRange = followDist;
            Origin = new Vector2(this.sprite.Width / 2, this.Height / 2);
            localPosition = position;
            _followSpeed = velocity;
            target = Target;
        }

        //Als jogonpart nog niet bij zijn doel is blijft hij bewegen en zijn sprite word 90 graden gedraaid
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            if (!isInRange(this.localPosition, target.LocalPosition, _followRange))
            {
                LookAt(target, offsetDegrees);
                velocity = AngularDirection * _followSpeed;
            }
            offsetDegrees = 90;
        }

        //hier kijkt een jogonpart of hij al bij zijn doel is aangekomen
        protected bool isInRange(Vector2 V1, Vector2 V2, float range)
        {
            float dx = V2.X - V1.X;
            float dy = V2.Y - V2.Y;
            return MathF.Sqrt((dx * dx) + (dy * dy)) < range;
        }
    }
}
