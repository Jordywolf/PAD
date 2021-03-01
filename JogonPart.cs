using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class JogonPart : GameObject
    {
        public Vector2 target;
        public float _minDistanceBetweenSegments = 4;
        protected float _followSpeed = 4;
        public JogonPart Parent;
        protected bool segment = true;

        public JogonPart(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture, float followDist) : base(position, velocity, rotation, scale, texture){ _minDistanceBetweenSegments = followDist; }

        public override void Update(GameTime gameTime)
        {
            
            totalangle = MathF.Atan2(target.Y * _followSpeed, target.X * _followSpeed)-MathF.PI/2;
            if (segment)
            {
                _followSpeed = Parent._followSpeed;
                target = Parent.position - this.position;
                    float dx = (Parent.position.X - this.position.X);
                    float dy = (Parent.position.X - this.position.X);
                    float dist = MathF.Sqrt(dx * dx + dy * dy);
                    target.Normalize();

                if (dist > _minDistanceBetweenSegments)
                {
                    this.position += target * _followSpeed;
                }
            }
            base.Update(gameTime);
        }
    }
}
