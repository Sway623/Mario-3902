using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaStompedSprite : ISprite
    {
        int koopaSpriteX = 328;
        int koopaSpriteY = 0;

        public KoopaStompedSprite()
        {           

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle(EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreen, EnemySpriteUtility.offScreenSize, EnemySpriteUtility.offScreenSize);
            Rectangle sourceRectangle = new Rectangle(koopaSpriteX, koopaSpriteY, EnemySpriteUtility.koopaSourceWidth, EnemySpriteUtility.koopaDestWidth);
            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {

        }
    }
}
