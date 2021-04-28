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
    class NewGameState : Engine.GameState
    {
        Engine.SpriteGameObject background;
        Engine.SpriteGameObject newGame;
        Engine.SpriteGameObject continueGame;
        Engine.SpriteGameObject back;

        public NewGameState() : base()
        {
            background = new Engine.SpriteGameObject("SecondStart", 1);
            gameObjects.AddChild(background);
            background.scale = 2.1f;
            background.LocalPosition = new Vector2(0, -105);

            newGame = new Engine.SpriteGameObject("MenuNewGameSelected", 1);
            gameObjects.AddChild(newGame);
            newGame.scale = 2.7f;
            newGame.LocalPosition = new Vector2(540,135);

            continueGame = new Engine.SpriteGameObject("MenuContinue", 1);
            gameObjects.AddChild(continueGame);
            continueGame.scale = 2.7f;
            continueGame.LocalPosition = new Vector2(540, 270);

            back = new Engine.SpriteGameObject("MenuBack", 1);
            gameObjects.AddChild(back);
            back.scale = 2.7f;
            back.LocalPosition = new Vector2(945, 486);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("continueState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("selinLevelPlayingState");
                Game1.framecount = Game1.startframe;
            }
        }

        /*public virtual void Draw(SpriteBatch spriteBatch, Texture2D texture9, Texture2D texture11, Texture2D texture12, Texture2D texture7)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.1f));
            spriteBatch.Draw(texture9, new Vector2(0, -50), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.7f));
            spriteBatch.Draw(texture11, new Vector2(200, 50), Color.White);
            spriteBatch.Draw(texture12, new Vector2(200, 100), Color.White);
            spriteBatch.Draw(texture7, new Vector2(350, 180), Color.White);
            spriteBatch.End();



            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.menuchoice = 5;
                Game1.framecount = Game1.startframe;
            }
        }*/
    }
}
