using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    public class ActionHandeler //Action handler class
    {
        public int actionId;
        public ActionJump Jump = new ActionJump();
        private bool keyPressed;

        public void Update()
        {
            if (actionId == 1) //Actions die maar 1 keer moeten gebeuren als je op spatie drukt
            {
                Jump.Update();
                if (keyPressed == false)
                {
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        keyPressed = true;
                        UseAction();
                    }
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Space))
                {
                    keyPressed = false;
                }
            }
            if (actionId == 2) //Actions die elk frame moeten gebeuren als je op spatie drukt
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    UseAction();
                }
            }
        }

        //Activeer de actie die actie staat
        public void UseAction()
        {
            if (actionId == 0)
            {
                return;
            }
            else if (actionId == 1)
            {
                Jump.Jump();
                return;
            }
        }
    }
}
