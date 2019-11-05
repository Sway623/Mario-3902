using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
   
    public class CameraDownCommand : ICommand
    {
        CameraController camera;
        public CameraDownCommand(CameraController c)
        {
            camera = c;
        }

        public void Execute(Game1 game)
        {
            camera.ManualMoveDown();
        }
    }
}
