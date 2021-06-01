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

    /// <summary>
    /// deze class is voor de hamer van selin, alles wat met de hamer te maken heeft wordt grotendeels in deze class gemaakt
    /// </summary>
    /// <param name="HmrName"></param>

    public Selin_Hammer(String HmrName) : base(HmrName, 0.9f)
    {
        //de startwaarden van een nieuwe hamer
        returnPos = new Vector2(0, 300);
        targetPos = new Vector2(1000, 300);
        localPosition = returnPos;
        scale = 0.15f;
        speed = 500;
        Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        shocked = false;
    }

    //een boolean voor als de hamer dichtbij de target is
    public bool inRange()
    {
        return (Vector2.Distance(localPosition, targetPos) < 50);
    }

    //een boolean voor als de hamer de target mis en op zijn maximum range is
    public bool outRange()
    {
        return (Vector2.Distance(localPosition, returnPos) > 500);
    }
    
    //een boolean voor als de hamer bij selin/return positie is
    public bool atSelin()
    {
        return (Vector2.Distance(localPosition, returnPos) < 30);
    }

    //in de update wordt de movement van de hamer gemaakt
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        //movement m1 is de weg van de returnpositie naar de targetpositie
        //de target positie wordt maar 1 keer gezien dus beweegt hij in een rechte lijn naar deze toe
        if (!m1)
        {
            m1 = true;
            aimDirection = targetPos - returnPos;
            aimDirection.Normalize();
            velocity = aimDirection * speed;
            readyToLaunch = false;
        }

        //dit is het attacken van de hamer, dit kan maar 1 keer per bewegingscyclus gebeuren
        else if (!attack && (inRange() || outRange()))
        {
            attack = true;
            m2 = true;
        }

        //movement m2 is het terug bewegen van de target naar de returnpositie
        //de returnpositie wordt hier constant geupdate en de hamer zal dus ook altijd terug naar de returnpositie gaan
        else if (m2)
        {
            aimDirection = returnPos - localPosition;
            aimDirection.Normalize();
            velocity = aimDirection * speed;
        }

        //een reset voor de hamer als deze weer zijn cyclus kan herhalen
        if (atSelin() && !readyToLaunch)
        {
            m1 = false;
            attack = false;
            m2 = false;
        }
    }
}

