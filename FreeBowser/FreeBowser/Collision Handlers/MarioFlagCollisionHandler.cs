using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioFlagCollisionHandler
    {
        public static void HandleCollision(IPlayer player, IItem item)
        {
            Flag myFlag = (Flag)item;
            myFlag.active = true;
            Mario mario = (Mario)player;
            mario.BeginEndingAnimation();
            mario.SetVelo(0);

            //NEED TO FIND A WAY TO MAKE IT ACTIVATE NOT BEING ABLE TO CONTROL MARIO AND THEN DO STUFF
        }
    }
}
