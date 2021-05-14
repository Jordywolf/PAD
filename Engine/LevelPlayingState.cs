using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;

namespace BaseProject.Engine
{
    class LevelPlayingState : GameState
    {
        protected GameObjectList floor;
        protected GameObjectList walls;

        private static int grid = 64;

        private Vector2 collisionVector;

        public LevelPlayingState() : base()
        {
            floor = new GameObjectList();
            gameObjects.AddChild(floor);

            walls = new GameObjectList();
            gameObjects.AddChild(walls);
        }

        public void LoadFullFloor(String floorTexture)
        {
            for (int iXFloor = 0; iXFloor < Game1.width / grid; iXFloor++)
            {
                for (int iYFloor = 0; iYFloor < Game1.height / grid; iYFloor++)
                {
                    floor.AddChild(new FloorTile(floorTexture, new Vector2(grid * iXFloor, grid * iYFloor)));
                }
            }
        }

        public void LoadSquareFloor(String floorTexture, int Ysize, int Xsize, Vector2 midPos)
        {
            for (int iXFloor = 0; iXFloor < Game1.width / grid; iXFloor++)
            {
                for (int iYFloor = 0; iYFloor < Game1.height / grid; iYFloor++)
                {
                    if (iXFloor * grid >= Game1.width / 2 - Xsize / 2 * grid && iXFloor * grid <= Game1.width / 2 + Xsize / 2 * grid
                        && iYFloor * grid >= Game1.height / 2 - Ysize / 2 * grid && iYFloor * grid <= Game1.height / 2 + Ysize / 2 * grid)
                    {
                        floor.AddChild(new FloorTile(floorTexture, new Vector2(grid * iXFloor - (Game1.width / 2 - midPos.X), grid * iYFloor - (Game1.height / 2 - midPos.Y))));
                    }
                }
            }
        }

        public void LoadSquareWalls(String cdl, String d, String cdr, String r, String ctr, String t, String ctl, String l)
        {
            for (int iWalltile = 0; iWalltile < Game1.width / grid; iWalltile++)
            {
                if (iWalltile <= 0)
                {
                    walls.AddChild(new ObjectTile(ctl, new Vector2(grid * iWalltile + grid / 2, grid / 2)));
                    walls.AddChild(new ObjectTile(cdl, new Vector2(grid * iWalltile + grid / 2, Game1.height - grid + grid / 2)));
                }

                else if (iWalltile >= (Game1.width / grid) - 1)
                {
                    walls.AddChild(new ObjectTile(ctr, new Vector2(grid * iWalltile + grid / 2, 0 + grid / 2)));
                    walls.AddChild(new ObjectTile(cdr, new Vector2(grid * iWalltile + grid / 2, Game1.height - grid + grid / 2)));
                }

                else
                {
                    walls.AddChild(new ObjectTile(t, new Vector2(grid * iWalltile + grid / 2, 0 + grid / 2)));
                    walls.AddChild(new ObjectTile(d, new Vector2(grid * iWalltile + grid / 2, Game1.height - grid + grid / 2)));
                    walls.AddChild(new ObjectTile(l, new Vector2(0 + grid / 2, grid * iWalltile + grid / 2)));
                    walls.AddChild(new ObjectTile(r, new Vector2(Game1.width - grid + grid / 2, grid * iWalltile + grid / 2)));
                }
            }
        }

        public bool OverlapsWith(SpriteGameObject thisOne, SpriteGameObject thatOne)
        {
            return (thisOne.LocalPosition.X + thisOne.sprite.Width * thisOne.scale / 2 > thatOne.LocalPosition.X - thatOne.sprite.Width * thisOne.scale / 2
                && thisOne.LocalPosition.X - thisOne.sprite.Width * thisOne.scale / 2 < thatOne.LocalPosition.X + thatOne.sprite.Width * thisOne.scale / 2
                && thisOne.LocalPosition.Y + thisOne.sprite.Height * thisOne.scale / 2 > thatOne.LocalPosition.Y - thatOne.sprite.Height * thisOne.scale / 2
                && thisOne.LocalPosition.Y - thisOne.sprite.Height * thisOne.scale / 2 < thatOne.LocalPosition.Y + thatOne.sprite.Height * thisOne.scale / 2);
        }

        public void CollisionUpdate(SpriteGameObject p)
        {
            foreach (ObjectTile o in walls.children)
            {
                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.X + p.Width / 2
                    > o.LocalPosition.X - o.Width / 2 && p.LocalPosition.X + p.Width / 2 < o.LocalPosition.X)
                {
                    p.LocalPosition = new Vector2(p.LocalPosition.X - CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Width,
                        p.LocalPosition.Y);
                }

                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.X - p.Width / 2
                    < o.LocalPosition.X + o.Width / 2 && p.LocalPosition.X - p.Width / 2 > o.LocalPosition.X)
                {
                    p.LocalPosition = new Vector2(p.LocalPosition.X + CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Width,
                        p.LocalPosition.Y);
                }

                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.Y + p.Height / 2
                    > o.LocalPosition.Y - o.Height / 2 && p.LocalPosition.Y + p.Height / 2 < o.LocalPosition.Y)
                {
                    p.LocalPosition = new Vector2(p.LocalPosition.X, p.LocalPosition.Y - CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Height);
                }

                if (CollisionDetection.ShapesIntersect(p.collisionRec, o.collisionRec) && p.LocalPosition.Y - p.Height / 2
                    < o.LocalPosition.Y + o.Height / 2 && p.LocalPosition.Y - p.Height / 2 > o.LocalPosition.Y)
                {
                    p.LocalPosition = new Vector2(p.LocalPosition.X, p.LocalPosition.Y + CollisionDetection.CalculateIntersection(p.collisionRec, o.collisionRec).Height);
                }
            }
        }
    }
}
