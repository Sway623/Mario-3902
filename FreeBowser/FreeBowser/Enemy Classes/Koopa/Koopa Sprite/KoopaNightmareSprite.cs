using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace FreeBowser
{
    public class KoopaNightmareSprite : ISprite
    {
        int spriteX = 0;
        int spriteY = 60;
        int currentFrame = 1;
        int timer = 0;

        public KoopaNightmareSprite()
        {
            
        }

        public void Update()
        {
            timer++;
            if (timer == 20)
            {
                currentFrame++;
                timer = 0;
            }

            if (currentFrame == 3) currentFrame = 1;
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            EnemySpriteUtility.koopaNightmareRightSpriteSheetWidths.TryGetValue(currentFrame, out spriteX);

            Rectangle sourceRectangle = new Rectangle(spriteX, spriteY, EnemySpriteUtility.koopaSourceWidth, EnemySpriteUtility.koopaSourceHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y+8, EnemySpriteUtility.koopaDestWidth, EnemySpriteUtility.koopaDestHeight);

            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, sourceRectangle, Color.Gray);
        }
    }
}
