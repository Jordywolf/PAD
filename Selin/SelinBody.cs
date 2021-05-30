using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class SelinBody : Engine.SpriteGameObject
{
    public Vector2 targetPos;
    private Vector2 aimDirection;

    public float speed;

    /// <summary>
    /// deze class is voor het lichaam van selin, deze volgt de speler in een langzaam tempo
    /// </summary>
    public SelinBody() : base("Selin", 0.9f)
    {
        //enkele startwaarden voor het lichaam
        Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        scale = 0.15f;
        speed = 100;

    }
    
    //in de update wordt een targeting systeem aan het lichaam toegepast
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        aimDirection = targetPos - localPosition;
        aimDirection.Normalize();
        velocity = aimDirection * speed;
    }
}

