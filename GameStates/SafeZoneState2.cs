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
    class SafeZoneState2 : Engine.LevelPlayingState
    {

        SpriteGameObject Fontein2, rots2, deur2;
        public Vector2 deurPos = new Vector2(600, -10);
        public Vector2 TileSz2Pos = new Vector2(0, 0);
        public int LowerPosY = 570;
        public int PlatformPosY;
        Player player1;


        public SafeZoneState2() : base()
        {
            PlatformPosY = 380;
            //Upper Row
            //Lower Row
            for (int i = 0; i < 16; i++)
            {
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(80 * i, 0));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(80 * i, LowerPosY));
            }
            //PlatForm
            for(int i = 0; i < 5; i++)
            {
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY - 70));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY - 140));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY - 210));

            }



            player1 = new Player();
            gameObjects.AddChild(player1);
            player1.LocalPosition = new Vector2(0, 0);
            deur2 = new SpriteGameObject("Deur", 1);
            gameObjects.AddChild(deur2);
            deur2.LocalPosition = deurPos;
            deur2.scale = 0.58f;
            Fontein2 = new SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(Fontein2);
            Fontein2.scale = 0.3f;
            Fontein2.LocalPosition = new Vector2(Game1.width / 2 - 200, 200);
            rots2 = new SpriteGameObject("Rots", 1);
            gameObjects.AddChild(rots2);
            rots2.scale = 0.3f;
            rots2.LocalPosition = new Vector2(Game1.width / 2 + 100, 300);





        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (OverlapsWith(player1, deur2) && Keyboard.GetState().IsKeyDown(Keys.Space)) {
                Game1.GameStateManager.SwitchTo("selinLevelPlayingState");

            }
        }
    }

}