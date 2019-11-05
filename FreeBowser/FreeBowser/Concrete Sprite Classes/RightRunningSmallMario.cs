using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class RightRunningSmallMario : IMarioSprite
    {
        
        int spaceWidth = 31;
        int currentFrame = 0;
        int timer = 0;
        private int starMarioDrawCounter = 0;
        public RightRunningSmallMario()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(240 + (spaceWidth * currentFrame), 0, 17, 16);
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
