using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class ShellBlockCollisionHandler
    {
        public ShellBlockCollisionHandler()
        {

        }

        public static void HandleCollision(KoopaShell shell, IBlock block, Game1.Side side)
        {
            if (shell.isHit)
            {
                if (side.Equals(Game1.Side.Left) || side.Equals(Game1.Side.Right))
                shell.ChangeDirection();
            }

        }
    }
}
 