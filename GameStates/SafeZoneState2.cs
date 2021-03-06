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
        
        SpriteGameObject Fontein2, deur2, dropZone1, dropZone2, dropZone3, dropZone4, fonteinCenter;
        public Vector2 deurPos = new Vector2(1000, 0);
        public Vector2 TileSz2Pos = new Vector2(0, 0);
        public int LowerPosY = 570;
        public int PlatformPosY;

        Player player1;

        private bool playerSpawned;

        RotatingSpriteGameObject transition;

        public SafeZoneState2() : base()
        {

            PlatformPosY = 380;
            //For loop dat de stenen rijen tekenen aan de boven en onderkant van het scherm
            for (int i = 0; i < 16; i++)
            {
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(80 * i, 0));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(80 * i, LowerPosY));
            }
            //For loop dat het platform tekent in het midden van het spel
            for (int i = 0; i < 5; i++)
            {
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY - 70));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY - 140));
                LoadSquareFloor("TileSz2", TileSz2Pos.Y, TileSz2Pos.X, new Vector2(400 + (80 * i), PlatformPosY - 210));

            }
            //Gameobjects die worden toegevoegd aan de state
            transition = new RotatingSpriteGameObject("Selin_small", 1);
            transition.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);
            transition.Origin = transition.sprite.Center;
            transition.scale = 60;

            gameObjects.AddChild(transition);

            gameObjects.AddChild(Game1.player);
            gameObjects.AddChild(Game1.playerShadow);
            Game1.playerShadow.Origin = Game1.playerShadow.sprite.Center;
            gameObjects.AddChild(Game1.playerHealth1);
            gameObjects.AddChild(Game1.playerHealth2);
            gameObjects.AddChild(Game1.playerHealth3);

            fonteinCenter = new ObjectTile("Blok3", new Vector2(0, 0), 1);
            deur2 = new ObjectTile("Deur", new Vector2(0, 0), 1);
            walls.AddChild(deur2);
            deur2.LocalPosition = deurPos;
            deur2.scale = 0.9f;
            Fontein2 = new SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(Fontein2);
            walls.AddChild(fonteinCenter);
            //Posities, schalen etc. van de gameobjecten van het level.
            Fontein2.scale = 0.6f;
            Fontein2.LocalPosition = new Vector2(Game1.width / 2 - 200, 200);
            fonteinCenter.LocalPosition = new Vector2(Fontein2.LocalPosition.X + 55, Fontein2.LocalPosition.Y + 40);
            fonteinCenter.scale = 0.5f;
            fonteinCenter.Visible = false;
            dropZone1 = new SpriteGameObject("Blok", 1);
            dropZone2 = new SpriteGameObject("Blok", 1);
            dropZone3 = new SpriteGameObject("Blok2", 1);
            dropZone4 = new SpriteGameObject("Blok2", 1);

            dropZone1.scale = 0.3f;
            dropZone2.scale = 0.3f;
            dropZone3.scale = 0.3f;
            dropZone1.LocalPosition = new Vector2(Game1.width - 350, Game1.height - 150);
            dropZone2.LocalPosition = new Vector2(Game1.width - 700, Game1.height - 520);
            dropZone3.LocalPosition = new Vector2(Game1.width - 1050, Game1.height - 250);
            dropZone4.LocalPosition = new Vector2(Game1.width - 280, Game1.height - 250);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            transition.scale -= 1;
            transition.Angle += 5;
            //Dit zorgt ervoor dat de transition goed begint aan het enteren van de tweede safezone
            if (transition.scale <= 0) { transition.Visible = false; transition.scale = 1; }
            //Zorgt ervoor dat de speler collision heeft.
            CollisionUpdate(Game1.player);
            //Als de speler in de buurt zit van de 2e fontein wordt je health gereplenisht
            if (InAura(Game1.player, Fontein2))
            {
                gameObjects.AddChild(Game1.playerHealth1);
                gameObjects.AddChild(Game1.playerHealth2);
                gameObjects.AddChild(Game1.playerHealth3);
                Game1.player.health = 3;

            }
            //Als de speler nog niet is gespawned wordt hij beneden gespawned.
            if (!playerSpawned)
            {
                Game1.player.SpawnLocationDown();
                playerSpawned = true;
            }
            //Als de speler bij de tweede deur op spatie drukt gaat hij door naar het volgende level
            if (InAura(Game1.player, deur2) && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Game1.GameStateManager.SwitchTo("safeZoneState2", "selinLevelPlayingState", new GameStates.SelinLevelPlayingState());
                Game1.GameStateManager.SwitchTo("selinLevelPlayingState", "safeZoneState2", new GameStates.SafeZoneState2());
                Game1.SelinScream.Play();
                Game1.player.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            }
            //Als de speler over de 1e dropzone loopt terwijl hij op de grond staat wordt hij teruggespawned bij het begin de level
            if (OverlapsWith(Game1.player, dropZone1) && ActionJump.playerOnGround == true)
            {

                Game1.player.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
            //Als de speler over de 2e dropzone loopt terwijl hij op de grond staat wordt hij teruggespawned bij het begin van de level
            if (OverlapsWith(Game1.player, dropZone2) && ActionJump.playerOnGround == true)
            {

                Game1.player.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
            //Als de speler over de 3e dropzone loopt terwijl hij op de grond staat wordt hij teruggespawned bij het begin van de level
            if (OverlapsWith(Game1.player, dropZone3) && ActionJump.playerOnGround == true)
            {
                
                Game1.player.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
            //Als de speler over de 4e dropzone loopt terwijl hij op de grond staat wordt hij teruggespawned bij het begin van de level
            if (OverlapsWith(Game1.player, dropZone4) && ActionJump.playerOnGround == true)
            {
                
                Game1.player.LocalPosition = new Vector2(Game1.width / 2, Game1.height - 20);
            }
        }
    }

}