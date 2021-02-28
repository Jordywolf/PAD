using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class GameObject
{
    public Texture2D texture;
    public Vector2 position;
    public Vector2 velocity;

    public GameObject(string objTexture)
    {
        texture = GameEnvironment.ContentManager.Load<Texture2D>(objTexture);
        Reset();
    }

    virtual public void Reset()
    {

    }

    virtual public void Update()
    {

    }

    virtual public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, Color.White);
    }
}

