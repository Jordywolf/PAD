using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject
{
    class Fireball : RotatingSpriteGameObject //fireball class
    {
        Vector2 SpawnPosition;
        GameObject TargetPosition;
        private float Timer;
        public float Speed = 500;


        public Fireball(Vector2 position, String texture, float rotation) : base(texture,0.8f)
        {
            this.scale = 20.0f;
            Origin = new Vector2(this.sprite.Width / 2, this.Height / 2);
            localPosition = position;
            Reset();
            this.Angle = rotation;
        }

        override public void Reset()
        {
            Timer = 0;
            SpawnPosition = localPosition;// hier komt de target te staat wss dus de player
        }

        override public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            velocity = AngularDirection * Speed;
        }

        public bool IsObjectOffScreen(SpriteGameObject gameObject)
        {
            if (gameObject.LocalPosition.X + gameObject.sprite.Width < 0 || 
                gameObject.LocalPosition.X - gameObject.sprite.Width > 64*20 ||
                gameObject.LocalPosition.Y + gameObject.sprite.Height < 0 ||
                gameObject.LocalPosition.Y - gameObject.sprite.Height > 64*10)   
            {
                return true;
            }
            else return false;
        }
    }
}
