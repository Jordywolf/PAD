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

        SpriteGameObject Fontein2, deur2, dropZone1,dropZone2,dropZone3,dropZone4, FonteinCenter;
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



            FonteinCenter = new ObjectTile("Blok3", new Vector2(0, 0), 1);
            player1 = new Player();

            
            gameObjects.AddChild(player1);
            player1.LocalPosition = new Vector2(Game1.width/2 , Game1.height - 50);
            deur2 = new SpriteGameObject("Deur", 1);
            gameObjects.AddChild(deur2);
            deur2.LocalPosition = deurPos;
            deur2.scale = 0.58f;
            Fontein2 = new SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(Fontein2);
            FonteinCenter.scale = 0.5f;
            walls.AddChild(FonteinCenter);
            Fontein2.scale = 0.6f;
            Fontein2.LocalPosition = new Vector2(Game1.width / 2 - 200, 200);
            FonteinCenter.LocalPosition = new Vector2(Fontein2.LocalPosition.X + 60, Fontein2.LocalPosition.Y + 40);

            dropZone1 = new SpriteGameObject("Blok", 1);
            dropZone2 = new SpriteGameObject("Blok", 1);
            dropZone3 = new SpriteGameObject("Blok2", 1);
            dropZone4 = new SpriteGameObject("Blok2", 1);

            dropZone1.scale = 0.3f;
            dropZone2.scale = 0.3f;
            dropZone3.scale = 0.3f;
            dropZone1.LocalPosition = new Vector2(Game1.width  - 350, Game1.height - 150);
            dropZone2.LocalPosition = new Vector2(Game1.width  -700, Game1.height - 520);
            dropZone3.LocalPosition = new Vector2(Game1.width  - 1050, Game1.height - 250);
            dropZone4.LocalPosition = new Vector2(Game1.width - 280, Game1.height - 250);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            CollisionUpdate(player1);
            if (OverlapsWith(player1, Fontein2))
            {
                gameObjects.AddChild(Game1.playerHealth1);
                gameObjects.AddChild(Game1.playerHealth2);
                gameObjects.AddChild(Game1.playerHealth3);
                player1.health = 3;
                
            }
            if (OverlapsWith(player1, deur2) && Keyboard.GetState().IsKeyDown(Keys.Space)) {
                Game1.GameStateManager.SwitchTo("selinLevelPlayingState", "safeZoneState2", new GameStates.SafeZoneState2());

            }
            if (OverlapsWith(player1, dropZone1) && ActionJump.playerOnGround == true)
            {
                //Game1.GameStateManager.SwitchTo("deathState", "safeZoneState", new GameStates.SafeZoneState());
                player1.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
            if (OverlapsWith(player1, dropZone2) && ActionJump.playerOnGround == true)
            {
                //Game1.GameStateManager.SwitchTo("deathState", "safeZoneState", new GameStates.SafeZoneState());
                player1.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
            if (OverlapsWith(player1, dropZone3) && ActionJump.playerOnGround == true)
            {
               // Game1.GameStateManager.SwitchTo("deathState", "safeZoneState", new GameStates.SafeZoneState());
                player1.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
            if (OverlapsWith(player1, dropZone4) && ActionJump.playerOnGround == true)
            {
               // Game1.GameStateManager.SwitchTo("deathState", "safeZoneState", new GameStates.SafeZoneState());
                player1.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
        }
    }

}