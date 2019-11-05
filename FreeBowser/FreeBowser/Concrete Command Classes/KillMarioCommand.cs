using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KillMarioCommand : ICommand
    {
        int playerNumber;
        public KillMarioCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].GetKilled();
        }
    }
}
