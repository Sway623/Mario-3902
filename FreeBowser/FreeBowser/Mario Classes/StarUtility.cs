using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FreeBowser
{
    public class StarUtility
    {
        public static TimeSpan Time { get; set; }
        public static int starTime = 0;
        public static bool StarMarioLock { get; set; }
        public static bool isStarMario;
        public static bool isFirstShown = false;

        public void Update(GameTime gameTime)
        {
            if (starTime != 0)
            {
                if (((int)gameTime.TotalGameTime.TotalSeconds - (int)Time.TotalSeconds) > starTime)
                {

                    starTime = 0;
                    isStarMario = false;
                    Console.Out.WriteLine("star state changed");
                }
            }
        }
    }
}
