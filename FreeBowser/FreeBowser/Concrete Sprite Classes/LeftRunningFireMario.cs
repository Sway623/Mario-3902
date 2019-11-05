using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class LeftRunningFireMario : IMarioSprite
    {

        int spaceWidth = 24;
        int currentFrame = 2;
        int timer = 0;
        private int starMarioDrawCounter = 0;

        public LeftRunningFireMario()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(103 + (spaceWidth * currentFrame), 120, 16, 34);
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
    }
}
