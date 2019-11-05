using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaLeftMovingSprite : ISprite
    {
        int spriteX = 0;
        int spriteY = 0;
        int currentFrame = 1;
        int timer = 0;

        public KoopaLeftMovingSprite()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            EnemySpriteUtility.koopaLeftSpriteSheetWidths.TryGetValue(currentFrame, out spriteX);

            Rectangle sourceRectangle = new Rectangle(spriteX, spriteY, EnemySpriteUtility.koopaSourceWidth, EnemySpriteUtility.koopaSourceHeight);
            Rectangle destinationRectangle = new Rectangle((int)(location.X), (int)location.Y+8, EnemySpriteUtility.koopaDestWidth, EnemySpriteUtility.koopaDestHeight);
            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, sourceRectangle, Color.White);
        }


        public void Update()
        {
            timer++;
            if(timer == 20)
            {
                currentFrame++;
                timer = 0;
            }
            if (currentFrame == 5) currentFrame = 1;

        }
    }
}
