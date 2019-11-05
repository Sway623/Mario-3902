using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
   
    public class CameraLeftCommand : ICommand
    {
        CameraController camera;
        public CameraLeftCommand(CameraController c)
        {
            camera = c;
        }

        public void Execute(Game1 game)
        {
            camera.ManualMoveLeft();
        }
    }
}
