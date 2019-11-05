using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class NightmareModeCommand : ICommand
    {
        int playerNumber;
        KeyboardState previousState;

        public NightmareModeCommand(int playerNum)
        {
            playerNumber = playerNum;
        }

        public void Execute(Game1 game)
        {
            Game1.nightmare = true;
        }
    }
}
