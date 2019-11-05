using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace FreeBowser
{
    class CSVParser
    {
        public CSVParser()
        {

        }

        public void parse(Dictionary<string, List<Vector2>> spriteDict, List<string> csvLines, int screenHeight, int screenWidth)
        {
            int xPos = 0;
            int yPos = 0;

            int spriteWidth = 16;
            int spriteHeight = 16;
            int yShiftFactor = screenHeight - (csvLines.Count * spriteWidth);

            foreach (string line in csvLines)
            {
                string[] sprites = line.Split(',');
                xPos = 0;
                foreach (string sprite in sprites)
                {
                    List<Vector2> coords;
                    if (spriteDict.TryGetValue(sprite, out coords))
                    {
                        coords.Add(new Vector2(xPos, yPos + yShiftFactor));
                        spriteDict[sprite] = coords;
                    }
                    else if (sprite.Contains("warp"))
                    {
                        coords = new List<Vector2>();
                        coords.Add(new Vector2(xPos, yPos + yShiftFactor));
                        spriteDict.Add(sprite, coords);
                    }
                    xPos += spriteWidth;
                }
                yPos += spriteHeight;
            }

        }
    }
}
