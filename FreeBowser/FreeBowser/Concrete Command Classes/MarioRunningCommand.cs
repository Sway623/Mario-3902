using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    class MarioRunningCommand:ICommand
    {
           int playerNumber;
           public MarioRunningCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            
        }

        public void Register(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].SetRun();
        }

        public void Unregister(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].UnsetRun();
        }
    }
}
