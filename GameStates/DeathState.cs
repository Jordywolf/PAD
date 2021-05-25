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
    class DeathState : GameState
    {
        SpriteGameObject deathground;

        public DeathState() : base()
        {
            deathground = new SpriteGameObject("DeathScreen", 1);
            gameObjects.AddChild(deathground);
            deathground.scale = 1.3f;
            deathground.LocalPosition = new Vector2(25, -70);

            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);



            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Game1.framecount > Game1.startframe + 10)
            {
                Game1.GameStateManager.SwitchTo("menuStartSelectedState", "jogonLevelPlayingState", new GameStates.JogonLevelPlayingState(Game1.jogonSound, Game1.Player));
                Game1.GameStateManager.SwitchTo("menuStartSelectedState", "selinLevelPlayingState", new GameStates.SelinLevelPlayingState());
                Game1.GameStateManager.SwitchTo("menuStartSelectedState", "safeZoneState", new GameStates.SafeZoneState());
                Game1.GameStateManager.SwitchTo("menuStartSelectedState", "safeZoneState2", new GameStates.SafeZoneState2());
                Game1.buttonPressed = true;
                Game1.framecount = Game1.startframe;
                Game1.ButtonSound.Play();

            }
        }
    }
}
