using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


class Selin : Engine.GameObjectList
{
    SelinBody selinBody;
    Selin_Hammer selin_HammerL;
    Selin_Hammer selin_HammerR;

    Random Random = new Random();

    public Engine.GameObjectList hammers;
    public Engine.GameObjectList shocks;

    /// <summary>
    /// deze class is een bijeenkomst met alles wat met selin te maken heeft
    /// hier worden grotendeels van alle methodes in de update gezet zodat dit nauwelijks meer hoeft in de gamestate class
    /// </summary>

    public Selin() : base()
    {
        selinBody = new SelinBody();
        AddChild(selinBody);
        selinBody.LocalPosition = new Vector2(BaseProject.Game1.width / 2, -200);

        //een lijst met hamers
        hammers = new Engine.GameObjectList();
        AddChild(hammers);

        //een lijst met shock aanvallen
        shocks = new Engine.GameObjectList();
        AddChild(shocks);

        //hieronder staan de standaard hamers die worden aangemaakt
        selin_HammerL = new Selin_Hammer("Hamer 1");
        hammers.AddChild(selin_HammerL);

        selin_HammerR = new Selin_Hammer("Hamer 2");
        hammers.AddChild(selin_HammerR);

        //de startposities van de standaard hamers
        selin_HammerL.LocalPosition = new Vector2(selinBody.LocalPosition.X - selinBody.sprite.Width / 2, selinBody.LocalPosition.Y);
        selin_HammerR.LocalPosition = new Vector2(selinBody.LocalPosition.X + selinBody.sprite.Width / 2, selinBody.LocalPosition.Y);
    }

    //deze method zorgt ervoor dat selin een spritegameobject kan targeten, de aparte target methods zitten in de hamers zelf
    public void Targeting(Engine.SpriteGameObject target)
    {
        selin_HammerR.targetPos = target.LocalPosition;
        selin_HammerL.targetPos = target.LocalPosition;
        selin_HammerL.returnPos = selinBody.LocalPosition;
        selin_HammerR.returnPos = selinBody.LocalPosition;

        selinBody.targetPos = target.LocalPosition;
    }

    //deze method zorgt ervoor dat selin een vector kan targeten, de aparte target methods zitten in de hamers zelf
    public void Targeting(Vector2 targetPos)
    {
        foreach (Selin_Hammer h in hammers.children)
        {
            h.targetPos = targetPos;
            h.returnPos = selinBody.LocalPosition;

        }

        selinBody.targetPos = targetPos;
    }

    //een overlaps functie, dez houdt rekening met de scale van een plaatje
    public bool OverlapsWith(Engine.SpriteGameObject thisOne, Engine.SpriteGameObject thatOne)
    {
        return (thisOne.LocalPosition.X + thisOne.sprite.Width * thisOne.scale / 2 > thatOne.LocalPosition.X - thatOne.sprite.Width * thatOne.scale / 2
            && thisOne.LocalPosition.X - thisOne.sprite.Width * thisOne.scale / 2 < thatOne.LocalPosition.X + thatOne.sprite.Width * thatOne.scale / 2
            && thisOne.LocalPosition.Y + thisOne.sprite.Height * thisOne.scale / 2 > thatOne.LocalPosition.Y - thatOne.sprite.Height * thatOne.scale / 2
            && thisOne.LocalPosition.Y - thisOne.sprite.Height * thisOne.scale / 2 < thatOne.LocalPosition.Y + thatOne.sprite.Height * thatOne.scale / 2);
    }

    //deze checkd de collisions met een shock die wordt aangemaakt, daarnaast checkt dit ook de collision met selins lichaam en een spritegameobject
    public void CollShockPlayer(Engine.SpriteGameObject p)
    {

        foreach (SelinShock sk in shocks.children)
        {
            if (OverlapsWith(sk, p) && sk.Visible)
            {
                BaseProject.Game1.player.Hit();
            }
        }

        if (OverlapsWith(selinBody, p))
        {
            BaseProject.Game1.player.Hit();
        }
    }

    //dit zorgt ervoor dat de hamers uit elkaar worden gehouden
    public void HammerPush()
    {
        for (int i = 0; i < hammers.children.Count - 1; i++)
        {
            if (OverlapsWith((Engine.SpriteGameObject)hammers.children[i], (Engine.SpriteGameObject)hammers.children[i + 1]))
            {
                Vector2 aimDir = new Vector2(hammers.children[i].LocalPosition.X - hammers.children[i + 1].LocalPosition.X,
                    hammers.children[i].LocalPosition.Y - hammers.children[i + 1].LocalPosition.Y);

                aimDir.Normalize();

                hammers.children[i].LocalPosition = new Vector2(hammers.children[i].LocalPosition.X + aimDir.X * 10, 
                    hammers.children[i].LocalPosition.Y + aimDir.Y * 10);
            }
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        HammerPush();

        //deze funcites zorgen ervoor dat de hamers worden geupdate en dat de shockwaves op de juiste plekken worden gecreeërd
        foreach (Selin_Hammer s in hammers.children)
        {
            if ((s.inRange() || s.outRange()) && !s.shocked)
            {
                s.shocked = true;
                shocks.AddChild(new SelinShock(s.LocalPosition));
                BaseProject.Game1.HammerHit.Play(volume: 1, Random.Next(-1, 2), pan: 0);
            }
            else if (s.atSelin())
            {
                s.shocked = false;
            }
        }
    }
}
