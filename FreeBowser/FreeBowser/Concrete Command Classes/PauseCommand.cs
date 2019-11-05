using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class PauseCommand : ICommand
    {
        int playerNumber;
        KeyboardState previousState;
        public bool isPaused;

        public PauseCommand(int playerNum)
        {
            playerNumber = playerNum;
        }
        public void Execute(Game1 game)
        {
            Game1.notPaused = !Game1.notPaused;
        }
    }
}
