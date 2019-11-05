using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class SwitchToFireMarioCommand : ICommand
    {
        int playerNumber;
        public SwitchToFireMarioCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].SwitchToFireMario(true);
        }
    }
}
