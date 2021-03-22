using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Pillar
{
    public Vector2 position;
    private Texture2D myTexture;

    public Pillar(Vector2 pillarPosition, Texture2D pillarTexture)
    {
        this.position = pillarPosition;
        myTexture = pillarTexture;
    }

    public bool Collision(Vector2 playerPosition, Texture2D playerTexture, Vector2 pillarPosition)
     {
        return (playerPosition.X + playerTexture.Width > pillarPosition.X && playerPosition.X < pillarPosition.X + myTexture.Width 
            && playerPosition.Y + playerTexture.Height > pillarPosition.Y && playerPosition.Y < pillarPosition.Y + myTexture.Height);
    }

    public bool Collision(Vector2 playerPosition, Rectangle playerRectangle, Vector2 pillarPosition)
    {
        return (playerPosition.X + playerRectangle.Width > pillarPosition.X && playerPosition.X < pillarPosition.X + myTexture.Width
            && playerPosition.Y + playerRectangle.Height > pillarPosition.Y && playerPosition.Y < pillarPosition.Y + myTexture.Height);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 pillarPosition)
    {
        spriteBatch.Draw(myTexture, pillarPosition, Color.White);
    }
}

