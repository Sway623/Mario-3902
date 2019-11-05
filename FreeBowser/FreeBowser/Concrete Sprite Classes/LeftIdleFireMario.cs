using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class LeftIdleFireMario : IMarioSprite
    {
        private int starMarioDrawCounter = 0;
        public LeftIdleFireMario()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            starMarioDrawCounter++;
            
            
            Rectangle sourceRectangle = new Rectangle(180, 120, 16, 34);
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
        }
    }
}
