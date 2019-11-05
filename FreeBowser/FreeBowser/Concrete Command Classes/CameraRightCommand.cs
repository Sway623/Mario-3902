using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
   
    public class CameraRightCommand : ICommand
    {
        CameraController camera;
        public CameraRightCommand(CameraController c)
        {
            camera = c;
        }

        public void Execute(Game1 game)
        {
            camera.ManualMoveRight();
        }
    }
}
