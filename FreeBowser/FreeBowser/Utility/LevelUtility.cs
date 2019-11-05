using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public static class LevelUtility
    {
        public struct SpriteSet
        {
            public List<IPlayer> players;
            public List<IBlock> blocks;
            public List<IPipe> pipes;
            public List<IEnemy> goombas;
            public List<IEnemy> koopas;
            public List<ICoin> coins;
            public List<IItem> items;
            public List<Fireball> projectiles;
            public List<IBackgroundObject> objects;
            public int setNum;

            public SpriteSet(int x)
            {
                setNum = x;
                players = new List<IPlayer>();
                blocks = new List<IBlock>();
                pipes = new List<IPipe>();
                goombas = new List<IEnemy>();
                koopas = new List<IEnemy>();
                coins = new List<ICoin>();
                items = new List<IItem>();
                projectiles = new List<Fireball>();
                objects = new List<IBackgroundObject>();
            }
        }
       
        public static void InitializePositionKey(Dictionary<String, List<Vector2>> d)
        {
            d.Add("p", new List<Vector2>());
            d.Add("fb", new List<Vector2>());
            d.Add("hb", new List<Vector2>());
            d.Add("?coin", new List<Vector2>());
            d.Add("?multicoin", new List<Vector2>());
            d.Add("?powerup", new List<Vector2>());
            d.Add("?ff", new List<Vector2>());
            d.Add("?st", new List<Vector2>());
            d.Add("?rm", new List<Vector2>());
            d.Add("?gm", new List<Vector2>());
            d.Add("hgm", new List<Vector2>());
            d.Add("bb", new List<Vector2>());
            d.Add("ub", new List<Vector2>());
            d.Add("pm", new List<Vector2>());
            d.Add("sp", new List<Vector2>());
            d.Add("mp", new List<Vector2>());
            //d.Add("largewarp(0-0)Underground.csv", new List<Vector2>());
            //d.Add("sidewarp(2567-250)Mario Level 1-1.csv", new List<Vector2>());
            d.Add("lp", new List<Vector2>());
            d.Add("ap", new List<Vector2>());
            d.Add("gb", new List<Vector2>());
            d.Add("kp", new List<Vector2>());
            d.Add("rm", new List<Vector2>());
            d.Add("gm", new List<Vector2>());
            d.Add("st", new List<Vector2>());
            d.Add("ff", new List<Vector2>());
            d.Add("vc", new List<Vector2>());
            d.Add("c1", new List<Vector2>());
            d.Add("c2", new List<Vector2>());
            d.Add("c3", new List<Vector2>());
            d.Add("b1", new List<Vector2>());
            d.Add("b2", new List<Vector2>());
            d.Add("b3", new List<Vector2>());
            d.Add("sh", new List<Vector2>());
            d.Add("bh", new List<Vector2>());
            d.Add("castle", new List<Vector2>());
            d.Add("f", new List<Vector2>());
            d.Add("xfb", new List<Vector2>());
            d.Add("xbb", new List<Vector2>());
        }

        public static void InitializeTypeDict(Dictionary<Type, String> d)
        {
            d.Add(typeof(Mario), "p");
            d.Add(typeof(FloorBlock), "fb");
            d.Add(typeof(BlockCoin), "?coin");
            d.Add(typeof(MultiCoin), "?multicoin");
            d.Add(typeof(QuestionBlock), "?powerup");
            d.Add(typeof(HiddenBlock), "hgm");
            d.Add(typeof(BrickBlock), "bb");
            d.Add(typeof(UsedBlock), "ub");
            d.Add(typeof(UnbreakableBlock), "pm");
            d.Add(typeof(SmallPipe), "sp");
            d.Add(typeof(MediumPipe), "mp");
            //d.Add("largewarp(0-0)Underground.csv");
            //d.Add("sidewarp(2567-250)Mario Level 1-1.csv");
            d.Add(typeof(LargePipe), "lp");
            d.Add(typeof(AestheticPipe), "ap");
            d.Add(typeof(Goomba), "gb");
            d.Add(typeof(Koopa), "kp");
            d.Add(typeof(RedMushroom), "rm");
            d.Add(typeof(GreenMushroom), "gm");
            d.Add(typeof(Star), "st");
            d.Add(typeof(FireFlower), "ff");
            d.Add(typeof(VisibleCoin), "vc");
            d.Add(typeof(SmallCloud), "c1");
            d.Add(typeof(MediumCloud), "c2");
            d.Add(typeof(LargeCloud), "c3");
            d.Add(typeof(SmallBush), "b1");
            d.Add(typeof(MediumBush), "b2");
            d.Add(typeof(LargeBush), "b3");
            d.Add(typeof(SmallHill), "sh");
            d.Add(typeof(BigHill), "bh");
            d.Add(typeof(Castle), "castle");
            d.Add(typeof(Flag), "f");
            d.Add(typeof(UndergroundFloorBlock), "xfb");
            d.Add(typeof(UndergroundBrickBlock), "xbb");
        }

    }
}
