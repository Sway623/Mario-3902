using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LevelEditorCommand : ICommand
    {
        int playerNumber;
        KeyboardState previousState;
        public bool leveleditor;


        public LevelEditorCommand()
        {
        }

        public void Execute(Game1 game)
        {
            game.SwitchMode();
        }
    }
}
