using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
   
    public class CameraUpCommand : ICommand
    {
        CameraController camera;
        public CameraUpCommand(CameraController c)
        {
            camera = c;
        }

        public void Execute(Game1 game)
        {
            camera.ManualMoveUp();
        }
    }
}
