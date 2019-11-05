using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
   
    public class MarioUpCommand : ICommand
    {
        int playerNumber;
        public MarioUpCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].Up();
            SoundManager.playJumpSound(WorldManager.spriteSet.players[playerNumber]);
        }
    }
}
