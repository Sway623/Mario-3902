using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public interface ICommand
    {
        void Execute(Game1 game);
    }
}
