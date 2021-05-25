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
    class MenuVictoryScreen : GameState
    {
        SpriteGameObject background;
        GameObjectList texten;

        public MenuVictoryScreen() : base()
        {
            background = new SpriteGameObject("HomeScreen", 0.5f);
            gameObjects.AddChild(background);

            texten = new GameObjectList();
            gameObjects.AddChild(texten);

            gameObjects.AddChild(Game1.player);
            Game1.player.sprite = new SpriteSheet("Player", 1);
            gameObjects.AddChild(Game1.playerShadow);

            texten.AddChild(new mapObjects.IntroText("Made by\n\nJordi van der Lem\nJordy Wolf\nNidal Toufik\nNick Baptist\nOlivier Molenaar\nJort Keppel", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 200)));


            texten.AddChild(new mapObjects.IntroText("Produced by", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 500)));
            texten.AddChild(new mapObjects.IntroText("Team 41 Groente", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 600)));
            texten.AddChild(new mapObjects.IntroText("Hva", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 620)));
            texten.AddChild(new mapObjects.IntroText("Monogame", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 640)));

            texten.AddChild(new mapObjects.IntroText("Thank you for playing", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 750)));
            texten.AddChild(new mapObjects.IntroText("Press space to return to menu", "Eightbit", Color.White, new Vector2(Game1.width / 5 * 4, Game1.height + 770)));

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (mapObjects.IntroText i in texten.children)
            {
                i.LocalPosition = new Vector2(i.LocalPosition.X, i.LocalPosition.Y - 1);
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (inputHelper.KeyDown(Keys.Space))
            {
                Game1.GameStateManager.SwitchTo("menuStartSelectedState", "menuVictoryScreen", new GameStates.MenuVictoryScreen());
            }
        }
    }
}
