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
        private float Speed = 300;


        public Fireball(Vector2 position, String texture, GameObject target) : base(texture,1)
        {
            TargetPosition = target;
            localPosition = position;
            Reset();
        }

        override public void Reset()
        {
            Timer = 0;
            SpawnPosition = localPosition;// hier komt de target te staat wss dus de player
            LookAt(TargetPosition);
            //totalangle = (float)Math.Atan2(TargetPosition.Y - SpawnPosition.Y, TargetPosition.X - SpawnPosition.X);
        }

        override public void Update(GameTime gameTime)
        {
            velocity = AngularDirection * Speed;
            /*
            float distance = Vector2.Distance(SpawnPosition, TargetPosition);
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            localPosition = Vector2.Lerp(SpawnPosition, TargetPosition, Timer * Speed / distance);
            */
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
