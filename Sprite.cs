﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BaseProject
{
    public class Sprite
    {
        protected Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public Color color = Color.White;
        public float Speed;
        public Input Input;
        public Vector2 Direction = new Vector2(1, 1);

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        { }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, Position, color);
            spriteBatch.End();

        }
        #region Collision 
        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Left &&
                this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom;
            Game1.menuchoice = 7;
            this.Position.X = +Direction.X;
            
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
                this.Rectangle.Right > sprite.Rectangle.Right &&
                this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom;
            Game1.menuchoice = 7;
            this.Position.X = -Direction.X;
            

        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Top &&
                this.Rectangle.Right > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Right;
            Game1.menuchoice = 7;
            this.Position.Y = +Direction.X;
            

        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
                this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                this.Rectangle.Right > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Right;
            Game1.menuchoice = 7;
            this.Position.Y = -Direction.X;
            
        }

        #endregion

    }
}
