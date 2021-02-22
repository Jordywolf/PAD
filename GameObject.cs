using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

    class GameObject
    {
        //Decleratie van variabelen
        protected Vector2 position;
        protected Vector2 velocity;
        protected Texture2D texture;

        public GameObject(Vector2 position, Vector2 velocity, string textureName)
        {
            this.position = position;
            this.velocity = velocity;
            texture = GameEnvironment.ContentManager.Load<Texture2D>(textureName);
        }
        public void Update()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,position,Color.White);
        }

    public void Reset()
    {
    
    //suck ma dick
    }

    }

