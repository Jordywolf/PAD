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
    class BackState : GameState
    {
        public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture9, Texture2D texture10, Texture2D texture12, Texture2D texture8)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.1f));
            spriteBatch.Draw(texture9, new Vector2(0, -50), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.7f));
            spriteBatch.Draw(texture10, new Vector2(200, 50), Color.White);
            spriteBatch.Draw(texture12, new Vector2(200, 100), Color.White);
            spriteBatch.Draw(texture8, new Vector2(350, 180), Color.White);
            spriteBatch.End();

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Game1.framecount > Game1.startframe + 10)

            {
                Game1.menuchoice = 5;
                Game1.framecount = Game1.startframe;

            }
        }
    }
}