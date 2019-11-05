
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class Flag : IItem
    {
        int dy = 0;
        int flagBottom = -147;
        Rectangle sourceRectangle = new Rectangle(128, 16, 16, 17);
        static readonly Rectangle flagpoleSource = new Rectangle(113, 593, 33, 170);

        int spriteWidth = 16;
        int spriteHeight = 17;

        int poleWidth = 33;
        int poleHeight = 170;

        public bool active = false;

        Vector2 location;
        public Flag(Vector2 initLocation)
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

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y-50, poleWidth, poleHeight+50);
            return currentRectangle;
        }

        public void ChangeState()
        {

        }

        public void SetCreatedFromBlock(bool itemCreatedFromBlock)
        {
            
        }

        public void Update()
        {
            if (active)
            {
                if (dy > flagBottom)
                {
                    dy--;
                }
            }
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
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {

            Rectangle destinationRectangle = new Rectangle((int)(location.X-cameraPosition.X), (int)(location.Y - dy-cameraPosition.Y), 17, 17);
            Rectangle flagpoleDest = new Rectangle((int)(location.X-1-cameraPosition.X), (int)(location.Y-10-cameraPosition.Y), 35, 185);
            spriteBatch.Draw(TextureManager.itemTexture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.Draw(TextureManager.pipeTexture, flagpoleDest, flagpoleSource, Color.White);
            
            
        }
    }
}
