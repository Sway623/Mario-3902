using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaSprite : ISprite
    {
        int spriteX = 0;
        int spriteY = 4;
        int currentFrame = 1;
        int timer = 0;

        public GoombaSprite()
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
            EnemySpriteUtility.goombaSpriteSheetWidths.TryGetValue(currentFrame, out spriteX);

            Rectangle sourceRectangle = new Rectangle(spriteX, spriteY, EnemySpriteUtility.goombaWidth, EnemySpriteUtility.goombaHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, EnemySpriteUtility.goombaWidth, EnemySpriteUtility.goombaHeight);

            spriteBatch.Draw(TextureManager.enemyTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
