using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    class ReplayCommander : ICommand
    {

        public void Execute(Game1 game)
        {
            game.isInReplayMode = true;
            new ResetAllCommand().Execute(game);
           
        }
    }
}
