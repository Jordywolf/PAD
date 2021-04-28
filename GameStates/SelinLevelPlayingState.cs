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
    class SelinLevelPlayingState : Engine.GameState
    {
        Selin selinBoss;
        Decoy playerTest;
        SpriteGameObject platform;
        SpriteGameObject background;

        private int maxPillars = 4;

        List<Vector2> pillarPS;

        public SelinLevelPlayingState() : base()
        {
            background = new SpriteGameObject("Fontein", 1);
            gameObjects.AddChild(background);
            background.Origin = new Vector2(background.sprite.Width / 2, background.sprite.Height / 2);
            background.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 4);
            background.scale = 20;

            platform = new SpriteGameObject("Selin_Arena_Pr", 1);
            gameObjects.AddChild(platform);
            platform.Origin = new Vector2(platform.sprite.Width / 2, platform.sprite.Height / 2);
            platform.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            pillarPS = new List<Vector2>();
            pillarPS.Add(new Vector2()

            selinBoss = new Selin();
            gameObjects.AddChild(selinBoss);

            playerTest = new Decoy("Deur");
            gameObjects.AddChild(playerTest);
            playerTest.LocalPosition = new Vector2(Game1.width / 2, Game1.height / 2);

            
            for (int iPillar = 0; iPillar < maxPillars; iPillar++)
            {
                Pillar pilaar = new Pillar(, "Pilaar");
            }
            
        }

        public bool OverlapsWith(Engine.SpriteGameObject thisOne, Engine.SpriteGameObject thatOne)
        {
            return (thisOne.LocalPosition.X + thisOne.sprite.Width / 2 > thatOne.LocalPosition.X - thatOne.sprite.Width / 2
                && thisOne.LocalPosition.X - thisOne.sprite.Width / 2 < thatOne.LocalPosition.X + thatOne.sprite.Width / 2
                && thisOne.LocalPosition.Y + thisOne.sprite.Height / 2 > thatOne.LocalPosition.Y - thatOne.sprite.Height / 2
                && thisOne.LocalPosition.Y - thisOne.sprite.Height / 2 < thatOne.LocalPosition.Y + thatOne.sprite.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            selinBoss.CollShockPlayer(playerTest);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            selinBoss.Targeting(playerTest.LocalPosition);

        }
    }
}
