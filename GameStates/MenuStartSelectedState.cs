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
    class MenuStartSelectedState : Engine.GameState
    {
        Engine.TextGameObject instructions;
        Engine.SpriteGameObject background;
        Engine.SpriteGameObject menuCredits;
        Engine.SpriteGameObject menuStart;
        //SelinBody test;
        //Selin_Hammer test2;

        Selin test;
        Decoy playerTest;

        public MenuStartSelectedState() : base()
        {
            background = new Engine.SpriteGameObject("HomeScreen", 0.1f);
            gameObjects.AddChild(background);

            menuCredits = new Engine.SpriteGameObject("MenuCredits", 0.1f);
            gameObjects.AddChild(menuCredits);

            menuStart = new Engine.SpriteGameObject("MenuStartGameSelected", 0.1f);
            gameObjects.AddChild(menuStart);

            instructions = new Engine.TextGameObject("Credit", 0.2f, Color.Beige);
            gameObjects.AddChild(instructions);

            /*test = new SelinBody();
            gameObjects.AddChild(test);

            test2 = new Selin_Hammer("Selin_HmrL");
            gameObjects.AddChild(test2);*/

            playerTest = new Decoy("Deur");
            gameObjects.AddChild(playerTest);

            test = new Selin();
            gameObjects.AddChild(test);

            instructions.Text = "Press \nPrrow Keys \nPress \nSpace";
            instructions.LocalPosition = new Vector2(0, 450);

            menuStart.LocalPosition = new Vector2(1280 / 2 - menuStart.sprite.Width * 2.7f / 2, 270);
            menuCredits.LocalPosition = new Vector2(1280 / 2 - menuCredits.sprite.Width * 2.7f / 2, 405);
            menuStart.scale = 2.7f;
            menuCredits.scale = 2.7f;

            instructions.scale = 0.45f;

            background.scale = 1.3f;
            background.LocalPosition = new Vector2(0, -65);
        }

        public bool OverlapsWith(Engine.SpriteGameObject thisOne, Engine.SpriteGameObject thatOne)
        {
            return (thisOne.LocalPosition.X + thisOne.sprite.Width / 2 > thatOne.LocalPosition.X - thatOne.sprite.Width / 2
                && thisOne.LocalPosition.X - thisOne.sprite.Width / 2 < thatOne.LocalPosition.X + thatOne.sprite.Width / 2
                && thisOne.LocalPosition.Y + thisOne.sprite.Height / 2 > thatOne.LocalPosition.Y - thatOne.sprite.Height / 2
                && thisOne.LocalPosition.Y - thisOne.sprite.Height / 2 < thatOne.LocalPosition.Y + thatOne.sprite.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("menuCreditsSelectedState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("newGameState");
                Game1.framecount = Game1.startframe;
            }

            /*foreach (SpriteGameObject spgo in test.children)
            {
                if (OverlapsWith(spgo, playerTest))
                {
                    Game1.GameStateManager.SwitchTo("newGameState");
                }
            }*/
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            test.Targeting(playerTest.LocalPosition);
        }


        /*public void Draw(SpriteBatch spriteBatch)
        {

           




            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(1.3f));
            spriteBatch.Draw(texture, new Vector2(0, -50), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null,
Matrix.CreateScale(2.7f));
            spriteBatch.Draw(texture4, new Vector2(200, 100), Color.White);
            spriteBatch.Draw(texture3, new Vector2(200, 150), Color.White);
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
            
        }*/
    }
}
