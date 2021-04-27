using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class Fireball : GameObject //fireball class
    {
        Vector2 SpawnPosition;
        Vector2 TargetPosition;
        private float Timer;
        private float Speed = 300;

        Player player;

        public Fireball(Vector2 position, Vector2 velocity, float rotation, float scale, Texture2D texture, Player player) : base(position, velocity, rotation, scale, texture)
        {
            this.player = player;

            Reset();
        }

        override public void Reset()
        {
            Timer = 0;
            SpawnPosition = position;
            TargetPosition = this.player.LocalPosition; // hier komt de target te staat wss dus de player
            totalangle = (float)Math.Atan2(TargetPosition.Y - SpawnPosition.Y, TargetPosition.X - SpawnPosition.X);
        }

        override public void Update(GameTime gameTime)
        {
            float distance = Vector2.Distance(SpawnPosition, TargetPosition);
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            position = Vector2.Lerp(SpawnPosition, TargetPosition, Timer * Speed / distance);
        }

        public override void Draw(SpriteBatch myspriteBatch)
        {
            base.Draw(myspriteBatch);
        }

        public bool IsObjectOffScreen(GameObject gameObject)
        {
            if (gameObject.position.X + gameObject.texture.Width < 0 || 
                gameObject.position.X - gameObject.texture.Width > 64*20 ||
                gameObject.position.Y + gameObject.texture.Height < 0 ||
                gameObject.position.Y - gameObject.texture.Height > 64*10)   
            {
                return true;
            }
            else return false;
        }
    }
}
