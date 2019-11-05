using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class RightRunningFireMario : IMarioSprite
    {
        int spaceWidth = 24;
        int currentFrame = 0;
        int timer = 0;
        private int starMarioDrawCounter = 0;

        public RightRunningFireMario()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(238 + (spaceWidth * currentFrame), 120, 16, 34);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 34);
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
        public void Update()
        {

        }
        public void Update(bool isRunning)
        {
            timer++;
            if (!isRunning)
            {
                //case walk
                if (timer == 10)
                {
                    timer = 0;
                    currentFrame++;
                    if (currentFrame == 3)
                    {
                        currentFrame = 0;
                    }
                }
            }
            else
            {

                if (timer >= 5)
                {
                    timer = 0;
                    currentFrame++;
                    if (currentFrame == 3)
                    {
                        currentFrame = 0;
                    }
                }
            }
            //case Run
        }
    }
}
