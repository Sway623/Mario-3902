using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class ResetAllCommand : ICommand
    {

        public ResetAllCommand()
        {
        }

        public void Execute(Game1 game)
        {
            game.ResetStates();
        }
    }
}
