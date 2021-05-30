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

        List<string> zinnen = new List<string>();

        //een transitie die wordt aangemaakt
        RotatingSpriteGameObject transition;

        //deze boolean geeft aan of het scherm is gestart of niet, hierdoor heeft het ene scherm geen interactie met het 2e introscherm
        private bool started;

        /// <summary>
        /// er kunnen 4 introtext onderdelen per introscherm worden aangemaakt, 
        /// </summary>
        /// <param name="Text1"></param>
        /// <param name="Text2"></param>
        /// <param name="Text3"></param>
        /// <param name="Text4"></param>
        public IntroGameState(String Text1, String Text2, String Text3, String Text4) : base()
        {
            Game1.framecount = 0;

            zinnen.Add(Text1);
            zinnen.Add(Text2);
            zinnen.Add(Text3);
            zinnen.Add(Text4);

            transition = new RotatingSpriteGameObject("JogonHead", 1);
            transition.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);
            transition.Origin = transition.sprite.Center;

            for (int i = 0; i <= 3; i++)
            {
                gameObjects.AddChild(new mapObjects.IntroText(zinnen[i], "Eightbit", Color.White, new Vector2(rnd.Next(Game1.width/5, Game1.width/2), Game1.height/5+ (i*50))));
            }

            foreach (mapObjects.IntroText i in gameObjects.children)
            {
                i.scale = 2;
                i.Color = Color.Crimson;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Game1.framecount++;

            //als de 'started' op true staat gaat de framecounter lopen
            if (!started)
            {
                Game1.framecount = 0;
                started = true;
            }

            //als de framecounter op ~11.5 seconden staat dan schakelt het scherm de transitie in
            if (Game1.framecount >= 690)
            {
                gameObjects.AddChild(transition);
                transition.scale += 1;
                transition.Angle += 5;
            }

            //hier schakelt het scherm naar de volgende gamestate
            if (Game1.framecount >= 750)
            {
                Game1.GameStateManager.SwitchTo("safeZoneState", "introGameState", new IntroGameState("Out there in the desert he lays", "His riddle is yours to solve", "He charges with some delays", "In his fire you will dissolve"));
                Game1.framecount = 0;
            }
        }
    }
}
