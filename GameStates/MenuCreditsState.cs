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
    class MenuCreditsState : Engine.GameState
    {
        Engine.SpriteGameObject background;
        Engine.SpriteGameObject back;
        Engine.TextGameObject creditNames;

        public MenuCreditsState() : base()
        {
            background = new Engine.SpriteGameObject("CreditScreen", 1);
            gameObjects.AddChild(background);
            background.scale = 1.8f;

            back = new Engine.SpriteGameObject("MenuBackSelected", 1);
            gameObjects.AddChild(back);
            back.scale = 2.7f;
            back.LocalPosition = new Vector2(945, 486);

            creditNames = new Engine.TextGameObject("Credit", 1, Color.Beige);
            gameObjects.AddChild(creditNames);
            creditNames.Text = "Nick Baptist\nNidal Toufik\nOlivier Molenaar\nJordy Wolf\nJordi van der Lem\nJort Keppel";
            creditNames.LocalPosition = new Vector2(60, 60);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && !Game1.buttonPressed)
            {
                Game1.GameStateManager.SwitchTo("menuCreditsSelectedState");
                Game1.buttonPressed = true;
            }
            else { Game1.buttonPressed = false; }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !Game1.buttonPressed)
            {
                Game1.GameStateManager.SwitchTo("menuCreditsSelectedState");
                Game1.buttonPressed = true;
            }
        }

        /*public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture6, Texture2D texture8, SpriteFont font)
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
        }*/
    }
}
