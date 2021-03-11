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
    class MenuCreditsState : GameState 
    {
        public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture6, Texture2D texture8, SpriteFont font)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(1.8f));
            spriteBatch.Draw(texture6, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.7f));
            spriteBatch.Draw(texture8, new Vector2(350, 180), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(0.6f));

            spriteBatch.DrawString(font, "Nick Baptist", new Vector2(100, 100), Color.Beige);
            spriteBatch.DrawString(font, "Nidal Toufik", new Vector2(100, 400), Color.Beige);
            spriteBatch.DrawString(font, "Jordy Wolf", new Vector2(100, 700), Color.Beige);
            spriteBatch.DrawString(font, "Jort Keppel", new Vector2(1000, 100), Color.Beige);
            spriteBatch.DrawString(font, "Olivier Molenaar", new Vector2(1000, 400), Color.Beige);
            spriteBatch.DrawString(font, "Jordi van der Lem", new Vector2(1000, 700), Color.Beige);

            spriteBatch.End();
        }
        }
}
