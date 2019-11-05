using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    class SmallMarioBlankSprite : IMarioSprite
    {
        private int starMarioDrawCounter = 0;
        public SmallMarioBlankSprite()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 17, 16);
           
           
            
                spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.White);
            
        }

        public void Update()
        {

        }
        public void Update(bool isRunning)
        {
        }
    }
}
