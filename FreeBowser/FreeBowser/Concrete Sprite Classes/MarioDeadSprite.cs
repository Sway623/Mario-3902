using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioDeadSprite : IMarioSprite
    {
        
        const int totalFrames = 80;
        
        static readonly Rectangle sourceRectangle = new Rectangle(0, 12, 18, 22);

        public MarioDeadSprite()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 18, 22);
            spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            //no op here
            //  codes below are for future use 
            /*if (movingUp)
            {
                currentFrame++;
                if (currentFrame == totalFrames) movingUp = false;
            }
            else
            {
                currentFrame--;
                if (currentFrame == -totalFrames) movingUp = true;
            }
             * */
        }
        public void Update(bool isRunning)
        {
        }

    }
}
