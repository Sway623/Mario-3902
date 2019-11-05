using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class ShellPipeCollisionHandler
    {
        public static void HandleCollision(IItem koopaShell, Game1.Side side)
        {
            KoopaShell shell = (KoopaShell)koopaShell;
            if (shell.isHit)
            {
                if (side.Equals(Game1.Side.Left) || side.Equals(Game1.Side.Right))
                    shell.ChangeDirection();
            }
        }

    }

}
 