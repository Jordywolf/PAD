using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject
{
    public class ActionHandeler // action handler class
    {
        int actionId = 1;
        public ActionJump Jump = new ActionJump();
        bool keyPressed;

        public void Update()
        {
            if (actionId == 1) // actions die maar 1 keer moeten gebeuren als je op spatie drukt
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
            if (actionId == 2) // actions die elk frame moeten gebeuren als je op spatie drukt
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    UseAction();
                }
            }
        }

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
