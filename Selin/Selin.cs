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

    Engine.GameObjectList hammers;

    public Selin() : base()
    {
        selinBody = new SelinBody();
        AddChild(selinBody);

        hammers = new Engine.GameObjectList();
        AddChild(hammers);

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
        selin_HammerR.targetPos = targetPos;
        selin_HammerL.targetPos = targetPos;
        selin_HammerL.returnPos = selinBody.LocalPosition;
        selin_HammerR.returnPos = selinBody.LocalPosition;

        selinBody.targetPos = targetPos;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        foreach (Selin_Hammer s in hammers.children)
        {
            if ((s.inRange() || s.outRange()) && !s.shocked)
            {
                s.shocked = true;
                AddChild(new SelinShock(s.LocalPosition));
            }
            else if (s.atSelin())
            {
                s.shocked = false;
            }
        }
    }
}
