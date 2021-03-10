using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace BaseProject.GameStates
{
    class MenuCreditsSelectedState : GameState
    {

            public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D texture2, Texture2D texture5, SpriteFont font)
            {






            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(1.3f));
            spriteBatch.Draw(texture, new Vector2(0, -50), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.7f));
            spriteBatch.Draw(texture2, new Vector2(200, 100), Color.White);
            spriteBatch.Draw(texture5, new Vector2(200, 150), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(0.45f));
            spriteBatch.DrawString(font, "Press", new Vector2(0, 1000), Color.Beige);
            spriteBatch.DrawString(font, "Arrow Keys", new Vector2(0, 1050), Color.Beige);
            spriteBatch.DrawString(font, "Press", new Vector2(0, 1150), Color.Beige);
            spriteBatch.DrawString(font, "Space", new Vector2(0, 1200), Color.Beige);
            spriteBatch.End();

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Game1.framecount > Game1.startframe + 10)

            {
                Game1.menuchoice = 1;


            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.menuchoice = 2;

            }

        }
        }
    }

