
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class CastleFlag : IItem
    {
        //int castleWidth = 81;
        //int castleHeight = 79;
        int castleMidpointX = 81 / 2;


        int spriteWidth = 17;
        int spriteHeight = 17;

        Rectangle sourceRectangle = new Rectangle(125, 1, 19, 15);
        int dy = 17;

        Vector2 location;
        public CastleFlag(Vector2 initLocation)
        {
            location = initLocation;
        }

        public void SetLocation(Vector2 coords)
        {
            location.X = coords.X;
            location.Y = coords.Y;
        }

        public void AdjustLocation(Vector2 coords)
        {
            location.X += coords.X;
            location.Y += coords.Y;
        }

        public void ChangeState()
        {

        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
            return currentRectangle;
        }

        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            
        }

        public void SetVerticalVelocity(double newVelocity)
        {
        }

        public double GetVerticalVelocity()
        {
            return 0;
        }
        public void SetGrounded()
        {

        }
        public void Update()
        {
            //Begin the castle flag at center of castle and draw it underneath the castle, so that it slowly rises
            if (dy > -17)
            {
                dy--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X + (castleMidpointX - (spriteWidth / 2)), (int)location.Y + dy, spriteWidth, spriteHeight);
            spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
