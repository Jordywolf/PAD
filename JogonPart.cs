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

        public JogonPart(Vector2 position, float velocity, string texture, float followDist, Engine.SpriteGameObject Target, float depth) : base(texture,depth)
        {
            scale = 1.5f;
            _followRange = followDist;
            Origin = new Vector2(this.sprite.Width / 2, this.Height / 2);
            localPosition = position;
            _followSpeed = velocity;
            target = Target;
        }

        public override void Update(GameTime gameTime)
        {
            offsetDegrees = 90;
            base.Update(gameTime);
                if (!isInRange(this.localPosition, target.LocalPosition, _followRange))
                {
                    LookAt(target,offsetDegrees);
                    velocity = AngularDirection * _followSpeed;
                }
            
                if (isInRange(this.localPosition, target.LocalPosition, _followRange))
                {
                    StopLookingAtTarget();
                }
            
        }
        protected bool isInRange(Vector2 V1, Vector2 V2, float range)
        {
            float dx = V2.X - V1.X;
            float dy = V2.Y - V2.Y;
            return MathF.Sqrt((dx * dx) + (dy * dy)) < range;
        }
    }
}
