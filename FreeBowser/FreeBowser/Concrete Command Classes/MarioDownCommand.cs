using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
   public class MarioDownCommand : ICommand
    {
       int playerNumber;
        public MarioDownCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].Down();
        }
    }
}
