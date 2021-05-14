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
    class SelinLevelPlayingState : Engine.LevelPlayingState
    {
        Selin selinBoss;
        Player playerTest;
        SpriteGameObject platform;
        SpriteGameObject background;
        GameObjectList pillars;
        GameObjectList stenen;

        Random rnd = new Random();

        private int maxPillars = 4;
        private int maxStenen = 10;

        List<Vector2> pillarPS;

        public SelinLevelPlayingState() : base()
        {
            background = new SpriteGameObject("Fontein", 0.5f);
            gameObjects.AddChild(background);
            background.Origin = new Vector2(background.sprite.Width / 2, background.sprite.Height / 2);
            background.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 4);
            background.scale = 20;

            platform = new SpriteGameObject("Selin_Arena_Pr", 0.6f);
            gameObjects.AddChild(platform);
            platform.Origin = new Vector2(platform.sprite.Width / 2, platform.sprite.Height / 2);
            platform.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            pillarPS = new List<Vector2>();
            pillarPS.Add(new Vector2(platform.LocalPosition.X - platform.sprite.Width / 2, 100));     
            pillarPS.Add(new Vector2(platform.LocalPosition.X + platform.sprite.Width / 2, 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X - platform.sprite.Width / 2, Game1.height - 100));
            pillarPS.Add(new Vector2(platform.LocalPosition.X + platform.sprite.Width / 2, Game1.height - 100));

            LoadSquareFloor("PAD_Sn_stone_small", 10, 10, new Vector2 (Game1.width/2 - 32, Game1.height/2-32));            

            pillars = new GameObjectList();
            gameObjects.AddChild(pillars);

            stenen = new GameObjectList();
            gameObjects.AddChild(stenen);

            selinBoss = new Selin();
            gameObjects.AddChild(selinBoss);

            playerTest = Game1.player;
            gameObjects.AddChild(playerTest);
            playerTest.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);
            

            for (int iPillar = 0; iPillar < maxPillars; iPillar++)
            {
                Pillar pilaar = new Pillar(pillarPS[iPillar], "Pilaar");
                pillars.AddChild(pilaar);
            }

            for (int iSteen = 0; iSteen < maxStenen; iSteen++)
            {
                SpriteGameObject steen = new SpriteGameObject("Rots", 1);
                steen.LocalPosition = new Vector2(rnd.Next(0, Game1.width - steen.sprite.Width),
                    rnd.Next(0, Game1.height - steen.sprite.Height));
                //stenen.AddChild(steen);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            CollisionUpdate(playerTest);

            //selinBoss.CollShockPlayer(playerTest);

            //foreach (ObjectTile o in walls.children)
            //if (OverlapsWith(o, playerTest))

            /*if (!OverlapsWith(platform, playerTest))
            {
                Game1.GameStateManager.SwitchTo("deathState");
            }*/

            /*foreach (Pillar p in pillars.children)
            {
                foreach (Selin_Hammer s in selinBoss.hammers.children)
                {
                    if (OverlapsWith(s, p))
                    {
                        p.Visible = false;
                    }
                }
            }*/

            /*bool tmp = true;
            foreach (Pillar p in pillars.children)
            {
                if (p.Visible == false && pillars.children.Count < 1)
                {
                    Game1.GameStateManager.SwitchTo("menuCreditsState");
                }

            }*/
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            selinBoss.Targeting(playerTest.LocalPosition);

        }
    }
}
