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
    class IntroGameState : GameState
    {
        Random rnd = new Random();

        public IntroGameState(String Text1, String Text2, String Text3, String Text4) : base()
        {
            for (int i = 1; i <= 4; i++)
            {
                //gameObjects.AddChild(new mapObjects.IntroText(i, "Eightbit", Color.White, rnd.Next());
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
