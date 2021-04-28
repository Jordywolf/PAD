using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


class Selin_Hammer : Engine.SpriteGameObject
{
    public Vector2 targetPos;
    public Vector2 returnPos;
    private Vector2 aimDirection;

    public float speed;

    private bool m1;
    private bool attack;
    private bool m2;
    private bool readyToLaunch;

    public bool shocked;


    public Selin_Hammer(String HmrName) : base(HmrName, 1)
    {
        returnPos = new Vector2(0, 300);
        targetPos = new Vector2(1000, 300);
        localPosition = returnPos;
        scale = 0.15f;
        speed = 500;
        Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        shocked = false;
    }

    public bool inRange()
    {
        return (Vector2.Distance(localPosition, targetPos) < 50);
    }

    public bool outRange()
    {
        return (Vector2.Distance(localPosition, returnPos) > 500);
    }

    public bool atSelin()
    {
        return (Vector2.Distance(localPosition, returnPos) < 30);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (!m1)
        {
            m1 = true;
            aimDirection = targetPos - returnPos;
            aimDirection.Normalize();
            velocity = aimDirection * speed;
            readyToLaunch = false;
        }
        else if (!attack && (inRange() || outRange()))
        {
            attack = true;
            localPosition.Y += 100;
            m2 = true;
        }
        else if (m2)
        {
            aimDirection = returnPos - localPosition;
            aimDirection.Normalize();
            velocity = aimDirection * speed;
        }

        if (atSelin() && !readyToLaunch)
        {
            m1 = false;
            attack = false;
            m2 = false;
        }

    }
}

