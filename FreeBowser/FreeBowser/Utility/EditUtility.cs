using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public static class EditUtility
    {
        public static void InitTypeDicts(Dictionary<Type, int> blockDict, Dictionary<Type, int> pipeDict, Dictionary<Type, int> enemyDict, Dictionary<Type, int> itemDict, Dictionary<MarioState, int> playerDict)
        {
            blockDict.Add(typeof(BrickBlock), 0);
            blockDict.Add(typeof(UsedBlock), 1);
            blockDict.Add(typeof(UnbreakableBlock), 2);
            blockDict.Add(typeof(HiddenBlock), 3);
            blockDict.Add(typeof(QuestionBlock), 4);
            blockDict.Add(typeof(FloorBlock), 5);

            pipeDict.Add(typeof(SmallPipe), 0);
            pipeDict.Add(typeof(MediumPipe), 1);
            pipeDict.Add(typeof(LargePipe), 2);

            enemyDict.Add(typeof(Goomba), 0);
            enemyDict.Add(typeof(Koopa), 1);

            itemDict.Add(typeof(FireFlower), 0);
            itemDict.Add(typeof(GreenMushroom), 1);
            itemDict.Add(typeof(RedMushroom), 2);
            itemDict.Add(typeof(Star), 3);
            itemDict.Add(typeof(VisibleCoin), 4);

            playerDict.Add((MarioState.SMALL), 0);
            playerDict.Add((MarioState.LARGE), 1);
            playerDict.Add((MarioState.FIRE), 2);
        }

        public static void blockCreator(IBlock displayBlock, IDictionary<Type, int> blockDict, List<IBlock> blocks, int x, int y)
        {
            switch (blockDict[displayBlock.GetType()])
            {
                case 0:
                    blocks.Add(new BrickBlock(new Vector2(x, y)));
                    break;
                case 1:
                    blocks.Add(new UsedBlock(new Vector2(x, y)));
                    break;
                case 2:
                    blocks.Add(new UnbreakableBlock(new Vector2(x, y)));
                    break;
                case 3:
                    blocks.Add(new HiddenBlock(new Vector2(x, y), new GreenMushroom(new Vector2(x, y - 16))));
                    break;
                case 4:
                    blocks.Add(new QuestionBlock(new Vector2(x, y), new PowerUpPlaceholder(new Vector2(x, y - 16)), false));
                    break;
                case 5:
                    blocks.Add(new FloorBlock(new Vector2(x, y)));
                    break;
            }
        }

        public static void pipeCreator(IPipe displayPipe, IDictionary<Type, int> pipeDict, List<IPipe> pipes, int x, int y)
        {
            switch(pipeDict[displayPipe.GetType()]){
                case 0:
                    pipes.Add(new SmallPipe(new Vector2(x, y), false, "", new Vector2(0, 0)));
                    break;
                case 1:
                    pipes.Add(new MediumPipe(new Vector2(x, y), false, "", new Vector2(0, 0)));
                    break;
                case 2:
                    pipes.Add(new LargePipe(new Vector2(x, y), false, "", new Vector2(0, 0)));
                    break;
            }
        }

        public static void enemyCreator(IEnemy displayEnemy, IDictionary<Type, int> enemyDict, List<IEnemy> enemies, int x, int y)
        {
            switch (enemyDict[displayEnemy.GetType()])
            {
                case 0:
                    enemies.Add(new Goomba(new Vector2(x, y)));
                    break;
                case 1:
                    enemies.Add(new Koopa(new Vector2(x, y)));
                    break;
            }
        }

        public static void itemCreator(IItem displayItem, IDictionary<Type, int> itemDict, List<IItem> items, int x, int y)
        {
            switch (itemDict[displayItem.GetType()])
            {
                case 0:
                    items.Add(new FireFlower(new Vector2(x, y)));
                    break;
                case 1:
                    GreenMushroom gm = new GreenMushroom(new Vector2(x, y));
                    gm.ToggleHidden();
                    gm.SetCurrentHeight(17);
                    items.Add(gm);
                    break;
                case 2:
                    items.Add(new RedMushroom(new Vector2(x, y)));
                    break;
                case 3:
                    Star st = new Star(new Vector2(x, y));
                    st.SetCurrentHeight(16);
                    items.Add(st);
                    break;
                case 4:
                    items.Add(new VisibleCoin(new Vector2(x, y)));
                    break;
            }
        }

        public static void playerCreator(IPlayer displayPlayer, IDictionary<MarioState, int> playerDict, List<IPlayer> players, MarioState state)
        {
            int size = players.Count;
            Console.WriteLine(state);
            switch (playerDict[state])
            {
                //int size = players.Count;
                case 0:
                    players[0].SwitchToSmallMario(false);
                    //players.Add(new Mario(new Vector2(x, y), sm));
                    break;
                case 1:
                    players[0].SwitchToBigMario(false);
                    //players.Add(new Mario(new Vector2(x, y), sm));
                    //players[size].SwitchToBigMario(false);
                    break;
                case 2:
                    players[0].SwitchToFireMario(false);
                    //players.Add(new Mario(new Vector2(x, y), sm));
                    //players[size].SwitchToFireMario(false);
                    break;
            }
        }
    }
}
