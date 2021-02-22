using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    class GameObject
    {
        //Decleratie van variabelen
        protected Vector2 position;
        protected Vector2 velocity;
        protected Texture2D texture;

        public GameObject(Vector2 position, Vector2 velocity, Texture2D texture)
        {
            this.position = position;
            this.velocity = velocity;
            this.texture = texture;
        }
        protected void update()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;

        }

        protected void draw()
        {
           
        }


    }



}
