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
    class MenuStartSelectedState : Engine.GameState
    {
        Engine.TextGameObject instructions;
        public MenuStartSelectedState() : base()
        {
            gameObjects.AddChild(new Engine.SpriteGameObject("HomeScreen", 1));
            gameObjects.AddChild(new Engine.SpriteGameObject("MenuCredits", 1));
            gameObjects.AddChild(new Engine.SpriteGameObject("MenuStartGameSelected", 1));

            instructions = new Engine.TextGameObject("Credit", 1, Color.Beige);
            gameObjects.AddChild(instructions);
            
            instructions.Text = "press \narrow keys \npress space";
            instructions.LocalPosition = new Vector2(0, 500);
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
