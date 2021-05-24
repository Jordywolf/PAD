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

    public Engine.GameObjectList hammers;
    public Engine.GameObjectList shocks;

    public Selin() : base()
    {
        selinBody = new SelinBody();
        AddChild(selinBody);
        selinBody.LocalPosition = new Vector2(BaseProject.Game1.width / 2, -200);

        hammers = new Engine.GameObjectList();
        AddChild(hammers);

        shocks = new Engine.GameObjectList();
        AddChild(shocks);

        selin_HammerL = new Selin_Hammer("Selin_HmrL");
        hammers.AddChild(selin_HammerL);

        selin_HammerR = new Selin_Hammer("Selin_HmrR");
        hammers.AddChild(selin_HammerR);

        selin_HammerL.LocalPosition = new Vector2(selinBody.LocalPosition.X - selinBody.sprite.Width / 2, selinBody.LocalPosition.Y);
        selin_HammerR.LocalPosition = new Vector2(selinBody.LocalPosition.X + selinBody.sprite.Width / 2, selinBody.LocalPosition.Y);
    }

    public void Targeting(Engine.SpriteGameObject target)
    {
        selin_HammerR.targetPos = target.LocalPosition;
        selin_HammerL.targetPos = target.LocalPosition;
        selin_HammerL.returnPos = selinBody.LocalPosition;
        selin_HammerR.returnPos = selinBody.LocalPosition;

        selinBody.targetPos = target.LocalPosition;
    }

    public void Targeting(Vector2 targetPos)
    {
        foreach (Selin_Hammer h in hammers.children)
        {
            h.targetPos = targetPos;
            h.returnPos = selinBody.LocalPosition;

        }

        selinBody.targetPos = targetPos;
    }

    public bool OverlapsWith(Engine.SpriteGameObject thisOne, Engine.SpriteGameObject thatOne)
    {
        return (thisOne.LocalPosition.X + thisOne.sprite.Width * thisOne.scale / 2 > thatOne.LocalPosition.X - thatOne.sprite.Width * thatOne.scale / 2
            && thisOne.LocalPosition.X - thisOne.sprite.Width * thisOne.scale / 2 < thatOne.LocalPosition.X + thatOne.sprite.Width * thatOne.scale / 2
            && thisOne.LocalPosition.Y + thisOne.sprite.Height * thisOne.scale / 2 > thatOne.LocalPosition.Y - thatOne.sprite.Height * thatOne.scale / 2
            && thisOne.LocalPosition.Y - thisOne.sprite.Height * thisOne.scale / 2 < thatOne.LocalPosition.Y + thatOne.sprite.Height * thatOne.scale / 2);
    }

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

        foreach (Selin_Hammer s in hammers.children)
        {
            if ((s.inRange() || s.outRange()) && !s.shocked)
            {
                s.shocked = true;
                shocks.AddChild(new SelinShock(s.LocalPosition));
            }
            else if (s.atSelin())
            {
                s.shocked = false;
            }
        }
    }
}
