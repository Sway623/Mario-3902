using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaDeadSprite : ISprite
    {
        int timer = 0;
        int offset = 0;
        bool onScreen = true;

        public KoopaDeadSprite()
        {
            if (WorldManager.spriteSet.players[0].GetEnemyMultiplier() == 0) { WorldManager.spriteSet.players[0].IncrementEnemyMultiplier(); }
            Display.UpdateScore(100 * WorldManager.spriteSet.players[0].GetEnemyMultiplier());
            WorldManager.spriteSet.players[0].ResetEnemyMultiplier(1);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if(onScreen)
            {
                Vector2 pointsLoc = location;
                pointsLoc.Y -= offset;
                int point = 100;
                spriteBatch.DrawString(TextureManager.marioSmallFont, "" + point * WorldManager.spriteSet.players[0].GetEnemyMultiplier(), pointsLoc, Color.White);
            }
        }

        public void Update()
        {
            timer++;
            offset+=7;
            if (timer == 15)
            {
                onScreen = false;
            }
        }
    }
}
