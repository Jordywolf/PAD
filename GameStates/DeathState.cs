﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace BaseProject.GameStates
{
    class DeathState : Engine.GameState
    {
        Engine.SpriteGameObject deathground;

        public DeathState() : base()
        {
            deathground = new Engine.SpriteGameObject("DeathScreen", 1);
            gameObjects.AddChild(deathground);
            deathground.scale = 1.3f;
            deathground.LocalPosition = new Vector2(25, -70);

            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);



            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("menuStartSelectedState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;

                
            }
        }
    }
}