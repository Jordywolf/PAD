using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.GameStates
{
    class BackState : GameState
    {

        SpriteGameObject background;
        SpriteGameObject newGame;
        SpriteGameObject continueGame;
        SpriteGameObject back;

        public BackState() : base()
        {
            background = new SpriteGameObject("SecondStart", 1);
            gameObjects.AddChild(background);
            background.scale = 2.1f;
            background.LocalPosition = new Vector2(0, -105);

            newGame = new SpriteGameObject("MenuNewGame", 1);
            gameObjects.AddChild(newGame);
            newGame.scale = 2.7f;
            newGame.LocalPosition = new Vector2(540, 135);

            continueGame = new SpriteGameObject("MenuContinue", 1);
            gameObjects.AddChild(continueGame);
            continueGame.scale = 2.7f;
            continueGame.LocalPosition = new Vector2(540, 270);

            back = new SpriteGameObject("MenuBackSelected", 1);
            gameObjects.AddChild(back);
            back.scale = 2.7f;
            back.LocalPosition = new Vector2(945, 486);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("continueState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }

            else { Game1.buttonPressed = false; }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("menuStartSelectedState");
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }
        }

        /*public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture9, Texture2D texture10, Texture2D texture12, Texture2D texture8)
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
        }*/
    }
}
