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
    class ContinueState : GameState
    {

        SpriteGameObject background;
        SpriteGameObject newGame;
        SpriteGameObject continueGame;
        SpriteGameObject back;

        public ContinueState() : base()
        {
            background = new SpriteGameObject("SecondStart", 1);
            gameObjects.AddChild(background);
            background.scale = 2.1f;
            background.LocalPosition = new Vector2(0, -105);

            newGame = new SpriteGameObject("MenuNewGame", 1);
            gameObjects.AddChild(newGame);
            newGame.scale = 2.7f;
            newGame.LocalPosition = new Vector2(540, 135);

            continueGame = new SpriteGameObject("MenuContinueSelected", 1);
            gameObjects.AddChild(continueGame);
            continueGame.scale = 2.7f;
            continueGame.LocalPosition = new Vector2(540, 270);

            back = new SpriteGameObject("MenuBack", 1);
            gameObjects.AddChild(back);
            back.scale = 2.7f;
            back.LocalPosition = new Vector2(945, 486);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("backState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("newGameState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("jogonLevelPlayingState");
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }
        }

        /*public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture9, Texture2D texture10, Texture2D texture13, Texture2D texture7)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.1f));
            spriteBatch.Draw(texture9, new Vector2(0, -50), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.7f));
            spriteBatch.Draw(texture10, new Vector2(200, 50), Color.White);
            spriteBatch.Draw(texture13, new Vector2(200, 100), Color.White);
            spriteBatch.Draw(texture7, new Vector2(350, 180), Color.White);
            spriteBatch.End();

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Game1.framecount > Game1.startframe + 10)

            {
                Game1.menuchoice = 4;
                Game1.framecount = Game1.startframe;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.menuchoice = 6;
                Game1.framecount = Game1.startframe;
            }
        }*/
    }
}
