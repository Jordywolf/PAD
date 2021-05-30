using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class SelinShock : Engine.SpriteGameObject
{
    private int timer;
    private int maxTimer = 10;

    /// <summary>
    /// deze class zorgt ervoor dat er een shockwave in het scherm komt
    /// deze breidt zich automatisch uit en als hij een bepaalde tijd in het scherm is maakt hij zichzelf ook weer onzichtbaar
    /// </summary>
    /// <param name="location"></param>

    public SelinShock(Vector2 location) : base("Selin_shock", 1)
    {
        this.localPosition = location;
        //Visible = false;
        timer = 0;
        scale = 0.1f;
        Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        //de timer die de shockwave groter maakt
        if (timer >= maxTimer)
        {
            this.Visible = false;
             Reset();
        }
        else
        {
            scale += 0.1f;
            timer++;
        }
    }

    //een reset functie voor de shockwave als hij groot genoeg is geworden
    public override void Reset()
    {
        base.Reset();

        scale = 0.1f;
        timer = 0;
        this.LocalPosition = new Vector2(-999, -999);
    }
}

