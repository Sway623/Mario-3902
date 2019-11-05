using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class RightJumpingSmallMario : IMarioSprite
    {
        //Comments code are for future use
        /*int spriteWidth = 32;
        int currentFrame = 0;
        int timer = 0;
         * */
        private int starMarioDrawCounter = 0;
        public RightJumpingSmallMario()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle(359, 0, 17, 16);
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
            /*timer++;

            if (timer == 10)
            {
                timer = 0;
                currentFrame++;
                if (currentFrame == 3)
                {
                    currentFrame = 0;
                }
            }
             * */

        }
        public void Update(bool isRunning)
        {
        }
    }
}
