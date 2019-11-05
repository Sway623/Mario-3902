using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class SwitchToBigMarioCommand : ICommand
    {
        int playerNumber;
        public SwitchToBigMarioCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].SwitchToBigMario(true);
        }
    }
}
