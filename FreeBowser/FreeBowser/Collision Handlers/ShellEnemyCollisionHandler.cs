using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class ShellEnemyCollisionHandler
    {
        public static void HandleCollision(IItem koopaShell, IEnemy enemy, Game1.Side side)
        {
            KoopaShell shell = (KoopaShell)koopaShell;
            if (shell.isHit)
            {
                if (!side.Equals(Game1.Side.None))
                enemy.BeFlipped();
            }
        }

    }

}
 