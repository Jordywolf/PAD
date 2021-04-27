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
    class SelinLevelPlayingState : Engine.GameState
    {
        public Texture2D stone_grnd, grass_grnd, obstacle, pillar, brokenPillar;
        private int levelWidth, levelHeight;
        private Vector2 pillarPositionCollision;
        private bool PillarCollided;

        MapConstruction mapConstruction;
        Decoy selinTest;

        private int pillarBrokenTimer;
        private int pillerBrokenMax = 100;

        public SelinLevelPlayingState(Texture2D Sn_stone_grnd, Texture2D Sn_grass_grnd, Texture2D Sn_obstacle, Texture2D Sn_pillar, Texture2D Sn_brokenPillar) : base()
        {
            stone_grnd = Sn_stone_grnd;
            grass_grnd = Sn_grass_grnd;
            obstacle = Sn_obstacle;
            pillar = Sn_pillar;
            brokenPillar = Sn_brokenPillar;

            levelHeight = GameEnvironment.Screen.Y;
            levelWidth = GameEnvironment.Screen.X;

            mapConstruction = new MapConstruction(pillar);
            selinTest = new Decoy(brokenPillar);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            mapConstruction.FloorConstruction(new Vector2(0, 0), grass_grnd, levelWidth, levelHeight, Color.Green);
            mapConstruction.PillarSetup(pillar, levelWidth, levelHeight, new Vector2(0, 0), Color.Gray);

            selinTest.update();

            //pillar collision met selin's hamer
            for (int iPillarsX = 1; iPillarsX <= mapConstruction.maxPillarsX; iPillarsX++)
            {
                for (int iPillarsY = 1; iPillarsY <= mapConstruction.maxPillarsY; iPillarsY++)
                {
                    pillarPositionCollision.X = ((levelWidth / (mapConstruction.maxPillarsX + 1)) * (iPillarsX)) - (mapConstruction.pillarTile.Width / 2);
                    pillarPositionCollision.Y = ((levelHeight / (mapConstruction.maxPillarsY + 1)) * (iPillarsY)) - (mapConstruction.pillarTile.Height / 2);

                     
                    if (mapConstruction.pillars[iPillarsX * iPillarsY].Collision(selinTest.position, selinTest.texture, pillarPositionCollision) && !PillarCollided)
                    {
                        if (pillarBrokenTimer < pillerBrokenMax)
                        {
                            mapConstruction.pillars[iPillarsX * iPillarsY].myTexture = grass_grnd;
                            pillarBrokenTimer++;
                        } else if (pillarBrokenTimer >= pillerBrokenMax)
                        {
                            pillarBrokenTimer = 0;
                            mapConstruction.pillars[iPillarsX * iPillarsY].myTexture = pillar;
                        }


                        PillarCollided = true;
                    }
                    else if (!mapConstruction.pillars[iPillarsX * iPillarsY].Collision(selinTest.position, selinTest.texture, pillarPositionCollision))
                    {
                        PillarCollided = false;
                    }
                }
            }
        }

        /*public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            mapConstruction.Draw(spriteBatch);
            selinTest.Draw(spriteBatch);
        }*/
    }
}
