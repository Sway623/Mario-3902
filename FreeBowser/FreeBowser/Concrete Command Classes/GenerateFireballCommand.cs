using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace FreeBowser
{
    public class GenerateFireballCommand : ICommand
    {
        int playerNumber;
        public GenerateFireballCommand(int playerNum)
        {
            playerNumber = playerNum;
        }
        public void Execute(Game1 game)
        {
            WorldManager.spriteSet.players[playerNumber].ThrowFireball();
            
        }
    }
}
