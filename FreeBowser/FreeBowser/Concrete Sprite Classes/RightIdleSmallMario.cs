using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class RightIdleSmallMario : IMarioSprite
    {
           private int starMarioDrawCounter = 0;
        public RightIdleSmallMario()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(211, 0, 17, 16);
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
            //nothing to do
        }
        public void Update(bool isRunning)
        {
        }
    }
}
