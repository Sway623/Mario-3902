using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class EnemyEnemyCollisionHandler
    {
        public static void HandleCollision(IEnemy enemy1, IEnemy enemy2, Game1.Side side)
        {
            if(side.Equals(Game1.Side.Left) ||side.Equals(Game1.Side.Right)) 
            {
                enemy1.ChangeDirection();
                enemy2.ChangeDirection();
            }
        }
    }
}
