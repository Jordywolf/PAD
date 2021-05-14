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
        public Vector2 TileSz2Pos= new Vector2(0, 0);
        public int LowerPosY = 570;
        public int PlatformPosY;

       
        public SafeZoneState2() : base()
        {
            PlatformPosY = 380;
            //Upper Row
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(0, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(80, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(160, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(240, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(320, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(480, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(560, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(640, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(720, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(800, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(880, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(960, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(1040, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(1120, 0));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(1200, 0));
            //PlatForm

               ///First Row 
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400, PlatformPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(480, PlatformPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(560, PlatformPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(640, PlatformPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(720, PlatformPosY));
            //Third Row
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400, PlatformPosY-70));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(480, PlatformPosY-70));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(560, PlatformPosY-70));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(640, PlatformPosY-70));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(720, PlatformPosY-70));
                //Second Row
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400, PlatformPosY - 140));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(480, PlatformPosY - 140));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(560, PlatformPosY - 140));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(640, PlatformPosY - 140));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(720, PlatformPosY - 140));
                //First row
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400, PlatformPosY - 210));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(480, PlatformPosY - 210));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(560, PlatformPosY - 210));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(640, PlatformPosY - 210));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(720, PlatformPosY - 210));


            //Lower Row
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(0, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(80, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(160, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(240, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(320, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(480, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(560, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(640, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(720, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(800, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(880, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(960, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(1040, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(1120, LowerPosY));
            LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(1200, LowerPosY));

            deur2 = new SpriteGameObject("Deur", 1);
            gameObjects.AddChild(deur2);
            deur2.LocalPosition = deurPos;
            deur2.scale = 0.58f;
            Fontein2 = new SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(Fontein2);
            Fontein2.scale = 0.3f;
            Fontein2.LocalPosition = new Vector2(Game1.width/2 - 200, 200);
            rots2 = new SpriteGameObject("Rots", 1);
            gameObjects.AddChild(rots2);
            rots2.scale = 0.3f;
            rots2.LocalPosition = new Vector2(Game1.width/2+ 100, 300);





        }
        
        
    }

}