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
    class PauseStateJogon : GameState
    {
        SpriteGameObject background;
        SpriteGameObject back;
        TextGameObject pause;

        public PauseStateJogon() : base()
        {
            background = new SpriteGameObject("CreditScreen", 1);
            gameObjects.AddChild(background);
            background.scale = 1.8f;

            back = new SpriteGameObject("MenuBackSelected", 1);
            gameObjects.AddChild(back);
            back.scale = 2.7f;
            back.LocalPosition = new Vector2(500, 400);

            pause = new TextGameObject("Credit", 1, Color.Beige);
            gameObjects.AddChild(pause);
            pause.LocalPosition = new Vector2(450, 60);
            pause.Text = "PAUSED";
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);



            if (Keyboard.GetState().IsKeyDown(Keys.Space) &&  Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("jogonLevelPlayingState");
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();
            }
        }
    }
}
