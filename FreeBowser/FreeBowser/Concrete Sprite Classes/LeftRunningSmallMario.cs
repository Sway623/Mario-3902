﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class LeftRunningSmallMario : IMarioSprite
    {
        
        int spaceWidth = 31;
        int currentFrame = 2;
        int timer = 0;
        private int starMarioDrawCounter = 0;
        public LeftRunningSmallMario()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(89 + (spaceWidth * currentFrame), 0, 17, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 17, 16);
            if (starMarioDrawCounter >= 5 && StarUtility.isStarMario)
            {
                spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.Green);
                starMarioDrawCounter = 0;
            }
            else
            {
                spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.White);
            }
            starMarioDrawCounter++;

        }

        public void Update(bool isRunning)
        {
            timer++;
            if (!isRunning)
            {
                if (timer == 10)
                {
                    timer = 0;
                    currentFrame--;
                    if (currentFrame == -1)
                    {
                        currentFrame = 2;
                    }
                }
            }
            else
            {

                if (timer >= 5)
                {
                    timer = 0;
                    currentFrame--;
                    if (currentFrame == -1)
                    {
                        currentFrame = 2;
                    }
                }
            }
        }
        public void Update()
        {
        }
    }
}
