using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


class Pillar
{
    public Vector2 position;
    private Texture2D myTexture;

    public Pillar(Vector2 pillarPosition, Texture2D pillarTexture)
    {
        position = pillarPosition;
        myTexture = pillarTexture;
    }

    public void Collision(Vector2 playerPosition, Texture2D playerTexture)
    {
        if (playerPosition.X >= position.X - myTexture.Width/2)
        {
            playerPosition.X = position.X - myTexture.Width/2;
        }

        if (playerPosition.X <= position.X + myTexture.Width / 2)
        {
            playerPosition.X = position.X + myTexture.Width / 2;
        }

        if (playerPosition.Y >= position.Y - myTexture.Height / 2)
        {
            playerPosition.Y = position.Y - myTexture.Height / 2;
        }

        if (playerPosition.Y >= position.Y - myTexture.Height / 2)
        {
            playerPosition.Y = position.Y - myTexture.Height / 2;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 pillarPosition)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(myTexture, pillarPosition, Color.White);
        spriteBatch.End();
    }
}

