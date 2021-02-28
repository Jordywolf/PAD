using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class GameObject
{
    //Decleratie van variabelen
    protected GameObject parent;
    public Vector2 position;
    protected Vector2 velocity;
    protected Texture2D texture;
    protected float scale = 2.5f;
    protected float angle = 0.0f;
    protected float angleOffset = 0.0f;
    protected float totalangle = 0.0f;

    public GameObject(Vector2 position, Vector2 velocity, Texture2D texture)
    {
        this.position = position;
        this.velocity = velocity;
        this.texture = texture;

    }
    public virtual void Update()
    {
        position += velocity;      
    }

    public virtual void Draw(SpriteBatch myspriteBatch)
    {
        myspriteBatch.Begin(SpriteSortMode.Texture, null, null, null, null, null, Matrix.CreateScale(scale));
        myspriteBatch.Draw(texture, position, null, Color.White, totalangle, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        myspriteBatch.End();
    }

    public void Reset()
    {

        //suck ma dick
    }

}

