using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

public class Pillar : SpriteGameObject
{
    public int Pillartimer;

    public Pillar(Vector2 pillarPosition, String pillarTexture) : base(pillarTexture, 1)
    {
        this.localPosition = pillarPosition;
        Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
    }

    public bool Collision(Vector2 playerPosition, Texture2D playerTexture, Vector2 pillarPosition)
     {
        return (playerPosition.X + playerTexture.Width > pillarPosition.X && playerPosition.X < pillarPosition.X + sprite.Width 
            && playerPosition.Y + playerTexture.Height > pillarPosition.Y && playerPosition.Y < pillarPosition.Y + sprite.Height);
    }

    public bool Collision(Vector2 playerPosition, Rectangle playerRectangle, Vector2 pillarPosition)
    {
        return (playerPosition.X + playerRectangle.Width > pillarPosition.X && playerPosition.X < pillarPosition.X + sprite.Width
            && playerPosition.Y + playerRectangle.Height > pillarPosition.Y && playerPosition.Y < pillarPosition.Y + sprite.Height);
    }
}

