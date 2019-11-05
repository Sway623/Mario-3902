using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MouseCollisionChecker
    {

        public static Dictionary<Type, int> blockDict;
        public static Dictionary<Type, int> pipeDict;
        public static Dictionary<Type, int> enemyDict;
        public static Dictionary<Type, int> itemDict;
        public static Dictionary<MarioState, int> playerDict;

        public MouseCollisionChecker(Dictionary<Type, int> bDict, Dictionary<Type, int> pDict, Dictionary<Type, int> eDict, Dictionary<Type, int> iDict, Dictionary<MarioState, int> playDict)
        {
            blockDict = bDict;
            pipeDict = pDict;
            enemyDict = eDict;
            itemDict = iDict;
            playerDict = playDict;
        }

        public void CheckMouseDisplayCollisions(ActionText option, Rectangle mouseRect, Rectangle previousMouseRect, List<IBlock> displayBlocks, List<IPipe> displayPipes, List<IEnemy> displayEnemies, List<IItem> displayItems, List<IPlayer> displayPlayers, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> enemies, List<IItem> items, List<IPlayer> players)
        {
            int x = mouseRect.X;
            int y = mouseRect.Y;

            Rectangle r = new Rectangle(x, y, 1, 1);

            if (option.GetOption().Equals("Blocks"))
            {
                foreach (IBlock displayBlock in displayBlocks)
                {
                    if (mouseRect.Intersects(displayBlock.GetRectangle()))
                    {
                        EditUtility.blockCreator(displayBlock, blockDict, blocks, x, y);
                    }
                }
            }
            else if (option.GetOption().Equals("Pipes"))
            {
                foreach (IPipe displayPipe in displayPipes)
                {
                    if (mouseRect.Intersects(displayPipe.GetRectangle()))
                    {
                        EditUtility.pipeCreator(displayPipe, pipeDict, pipes, x, y);
                    }
                }
            }
            else if (option.GetOption().Equals("Enemies"))
            {
                foreach (IEnemy displayEnemy in displayEnemies)
                {
                    if (mouseRect.Intersects(displayEnemy.GetRectangle()))
                    {
                        EditUtility.enemyCreator(displayEnemy, enemyDict, enemies, x, y);
                    }
                }
            }
            else if (option.GetOption().Equals("Items"))
            {
                foreach (IItem displayItem in displayItems)
                {
                    if (mouseRect.Intersects(displayItem.GetRectangle()))
                    {
                        EditUtility.itemCreator(displayItem, itemDict, items, x, y);
                    }
                }
            }
            else if (option.GetOption().Equals("Players"))
            {
                foreach (IPlayer displayPlayer in displayPlayers)
                {
                    if (mouseRect.Intersects(displayPlayer.GetRectangle()))
                    {
                        EditUtility.playerCreator(displayPlayer, playerDict, players, displayPlayer.GetState());
                    }
                }
            }

            if (mouseRect.Intersects(option.GetRectangle()))
            {
                EditLevelDisplay.optionsIndex = (EditLevelDisplay.optionsIndex + 1) % EditLevelDisplay.options.Count();
            }

        }

        public void CheckMouseDefaultCollisions(Rectangle mouseRect, Rectangle previousMouseRect, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> enemies, List<IItem> items, List<IPlayer> players)
        {

            int x = mouseRect.X - previousMouseRect.X;
            int y = mouseRect.Y - previousMouseRect.Y;


            foreach (IBlock block in blocks)
            {
                if (mouseRect.Intersects(block.GetRectangle()))
                {
                    block.AdjustLocation(new Vector2(x, y));
                    EditLevelDisplay.SetExtremes(x + previousMouseRect.X, y + previousMouseRect.Y);
                }
            }

            foreach (IPipe pipe in pipes)
            {
                if (mouseRect.Intersects(pipe.GetRectangle()))
                {
                    pipe.AdjustLocation(new Vector2(x, y));
                    EditLevelDisplay.SetExtremes(x + previousMouseRect.X, y + previousMouseRect.Y);
                }
            }

            foreach (IEnemy enemy in enemies)
            {
                if (mouseRect.Intersects(enemy.GetRectangle()))
                {
                    enemy.AdjustLocation(new Vector2(x, y));
                    EditLevelDisplay.SetExtremes(x + previousMouseRect.X, y + previousMouseRect.Y);
                }
            }

            foreach (IItem item in items)
            {
                if (mouseRect.Intersects(item.GetRectangle()))
                {
                    item.AdjustLocation(new Vector2(x, y));
                    EditLevelDisplay.SetExtremes(x + previousMouseRect.X, y + previousMouseRect.Y);
                }
            }

            foreach (IPlayer player in players)
            {
                if (mouseRect.Intersects(player.GetRectangle()))
                {
                    player.AdjustLocation(new Vector2(x, y));
                    EditLevelDisplay.SetExtremes(x + previousMouseRect.X, y + previousMouseRect.Y);
                }
            }

        }
    }
}

