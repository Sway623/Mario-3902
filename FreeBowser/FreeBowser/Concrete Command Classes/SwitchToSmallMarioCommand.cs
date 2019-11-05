using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class SwitchToSmallMarioCommand : ICommand
    {
        int playerNumber;
        public SwitchToSmallMarioCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].SwitchToSmallMario(true);
        }
    }
}
