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
            //Verschillende objecten die in de state worden gebruikt worden hier toegepast en worden toegevoegd aan de Game object list
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

            //Als je op pijltje naar beneden drukt ga je op hetzelfde menu naar een andere knop, de back knop
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("backState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }

            //Als je op pijltje omhoog drukt ga je op hetzelfde menu naar een andere knop, de new game knop
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("newGameState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }

            //Als je op spatie drukt, word je doorgestuurd naar het level van Jogon
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("jogonLevelPlayingState");
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }
        }


    }
}
