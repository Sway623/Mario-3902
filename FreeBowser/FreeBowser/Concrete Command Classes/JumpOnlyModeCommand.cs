using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class JumpOnlyModeCommand : ICommand
    {
        int playerNumber;

        public JumpOnlyModeCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            game.SwitchJumpOnlyMode();
        }
    }
}
