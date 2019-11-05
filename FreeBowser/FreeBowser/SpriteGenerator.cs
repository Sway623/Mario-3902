using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    class SpriteGenerator
    {
        int warpLength = "warp".Length;

        public SpriteGenerator()
        {

        }

        public void generateSprites(String key, List<Vector2> coordsList, List<IPlayer> players, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas, List<ICoin> coins, List<IItem> items, List<IBackgroundObject> objects)
        {
            if (key.Contains("warp") && coordsList.Count() > 0)
            {
                int warpIndex = key.IndexOf("warp");
                int endparan = key.IndexOf(")");
                String pipeType = key.Substring(0, warpIndex);
                String coords = key.Substring(warpIndex + warpLength + 1, endparan - warpIndex - warpLength - 1);
                String filename = key.Substring(endparan + 1);

                char[] separator = { '-' };
                string[] pos = coords.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);

                int xCoord;
                int yCoord;

                int.TryParse(pos[0], out xCoord);
                int.TryParse(pos[1], out yCoord);

                if (pipeType.Equals("large"))
                {
                    foreach (Vector2 positions in coordsList)
                    {
                        pipes.Add(new LargePipe(positions, true, filename, new Vector2(xCoord, yCoord)));
                    }
                }
                else if (pipeType.Equals("side"))
                {
                    foreach (Vector2 positions in coordsList)
                    {
                        pipes.Add(new UndergroundSidePipe(positions, true, filename, new Vector2(xCoord, yCoord)));
                    }
                }
            }
            else
            {
                switch (key)
                {
                    case "p":

                        foreach (Vector2 coords in coordsList)
                        {
                            if (!WorldManager.currentFilename.Equals("Mario Level 1-1.csv") && !WorldManager.currentFilename.Equals("Underground.csv"))
                            {
                                WorldManager.marioStartLocation = coords;
                            }
                            players.Add(new Mario(WorldManager.marioStartLocation, new SoundManager()));
                        }
                        break;
                    case "fb":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new FloorBlock(coords));
                        }
                        break;
                    case "?coin":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new QuestionBlock(coords, new BlockCoin(new Vector2(coords.X, coords.Y - 16)), false));
                        }
                        break;
                    case "?multicoin":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new QuestionBlock(coords, new MultiCoin(new Vector2(coords.X, coords.Y - 16)), true));
                        }
                        break;
                    case "?powerup":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new QuestionBlock(coords, new PowerUpPlaceholder(new Vector2(coords.X, coords.Y - 16)), false));
                        }
                        break;
                    case "?ff":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new QuestionBlock(coords, new FireFlower(new Vector2(coords.X, coords.Y - 16)), false));
                        }
                        break;
                    case "?st":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new QuestionBlock(coords, new Star(new Vector2(coords.X, coords.Y - 16)), true));
                        }
                        break;
                    case "?rm":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new QuestionBlock(coords, new RedMushroom(new Vector2(coords.X, coords.Y - 16)), false));
                        }
                        break;
                    case "?gm":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new QuestionBlock(coords, new GreenMushroom(new Vector2(coords.X, coords.Y - 16)), false));
                        }
                        break;
                    case "hgm":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new HiddenBlock(coords, new GreenMushroom(new Vector2(coords.X, coords.Y - 16))));
                        }
                        break;
                    case "bb":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new BrickBlock(coords));
                        }
                        break;
                    case "ub":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new UsedBlock(coords));
                        }
                        break;
                    case "pm":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new UnbreakableBlock(coords));
                        }
                        break;
                    case "sp":
                        foreach (Vector2 coords in coordsList)
                        {
                            pipes.Add(new SmallPipe(coords, false, "", new Vector2(0, 0)));
                        }
                        break;
                    case "mp":
                        foreach (Vector2 coords in coordsList)
                        {
                            pipes.Add(new MediumPipe(coords, false, "", new Vector2(0, 0)));
                        }
                        break;
                    case "lp":
                        foreach (Vector2 coords in coordsList)
                        {
                            pipes.Add(new LargePipe(coords, false, "", new Vector2(0, 0)));
                        }
                        break;
                    case "ap":
                        foreach (Vector2 coords in coordsList)
                        {
                            pipes.Add(new AestheticPipe(coords, false, "", new Vector2(0, 0)));
                        }
                        break;
                    case "castle":
                        foreach (Vector2 coords in coordsList)
                        {
                            items.Add(new Castle(coords));
                        }
                        break;
                    case "f":
                        foreach (Vector2 coords in coordsList)
                        {
                            items.Add(new Flag(coords));
                        }
                        break;
                    case "xfb":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new UndergroundFloorBlock(coords));
                        }
                        break;
                    case "xbb":
                        foreach (Vector2 coords in coordsList)
                        {
                            blocks.Add(new UndergroundBrickBlock(coords));
                        }
                        break;
                    case "gb":
                        foreach (Vector2 coords in coordsList)
                        {
                            goombas.Add(new Goomba(coords));
                        }
                        break;
                    case "kp":
                        foreach (Vector2 coords in coordsList)
                        {
                            koopas.Add(new Koopa(coords));
                        }
                        break;
                    case "rm":
                        foreach (Vector2 coords in coordsList)
                        {
                            items.Add(new RedMushroom(coords));
                        }
                        break;
                    case "gm":
                        foreach (Vector2 coords in coordsList)
                        {
                            items.Add(new GreenMushroom(coords));
                        }
                        break;
                    case "st":
                        foreach (Vector2 coords in coordsList)
                        {
                            items.Add(new Star(coords));
                        }
                        break;
                    case "ff":
                        foreach (Vector2 coords in coordsList)
                        {
                            items.Add(new FireFlower(coords));
                        }
                        break;
                    case "vc":
                        foreach (Vector2 coords in coordsList)
                        {
                            items.Add(new VisibleCoin(coords));
                        }
                        break;

                    case "c1":
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new SmallCloud(coords));
                        }
                        break;

                    case "c2":
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new MediumCloud(coords));
                        }
                        break;

                    case "c3":
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new LargeCloud(coords));
                        }
                        break;

                    case "b1":
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new SmallBush(coords));
                        }
                        break;

                    case "b2":
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new MediumBush(coords));
                        }
                        break;

                    case "b3":
                        Rectangle largeBushSourceRectangle = new Rectangle(85, 253, 64, 18);
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new LargeBush(coords));
                        }
                        break;

                    case "sh":
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new SmallHill(coords));
                        }
                        break;

                    case "bh":
                        foreach (Vector2 coords in coordsList)
                        {
                            objects.Add(new BigHill(coords));
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
