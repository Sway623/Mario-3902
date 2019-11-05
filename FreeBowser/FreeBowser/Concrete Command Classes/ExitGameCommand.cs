using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class ExitGameCommand : ICommand
    {
        public ExitGameCommand()
        {
        }

        public void Execute(Game1 game)
        {
            game.Exit();
        }
    }
}
