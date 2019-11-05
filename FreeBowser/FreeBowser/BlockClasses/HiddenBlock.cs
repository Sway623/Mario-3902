using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FreeBowser
{
    public class HiddenBlock : IBlock
    {
        Rectangle sourceRectangle;
        public bool isHidden;
        public bool hasItem;
        public bool isHit;
        private IItem item;
        double verticalVelocity = 0;
        bool movingUp = true;
        bool movingLeft;
        double horizontalVelocity;

        Vector2 location;

        public HiddenBlock(Vector2 initLocation, IItem initItem)
        {
            location = initLocation;
            hasItem = true;
            sourceRectangle = new Rectangle(BlockUtility.blockSize * 27, 0, BlockUtility.blockSize, BlockUtility.blockSize);
            item = initItem;
            item.SetCreatedFromBlock(true);
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

        public bool GetMovingUp()
        {
            return movingUp;
        }

        public void SetMovingUp(bool up)
        {
            movingUp = up;
        }

        public void SetMovingLeft(bool left)
        {
            movingLeft = left;
        }

        public void SetVerticalVelocity(double newVelocity)
        {
            verticalVelocity = newVelocity;
        }

        public double GetVerticalVelocity()
        {
            return verticalVelocity;
        }

        public void SetHorizontalVelocity(double newVelocity)
        {
            horizontalVelocity = newVelocity;
        }

        public double GetHorizontalVelocity()
        {
            return horizontalVelocity;
        }

        public bool GetMovingLeft()
        {
            return movingLeft;
        }

        public Rectangle GetRectangle()
        {

            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, BlockUtility.blockSize, BlockUtility.blockSize);
            return currentRectangle;
        }

        public void Update(GameTime gameTime)
        {

        }

        public Boolean IsHit()
        {
            return false;
        }

        public Boolean HasItem()
        {
            return hasItem;
        }

        public IItem ReleaseItem(MarioState state)
        {
            if (HasItem())
                if (item.GetType() == typeof(PowerUpPlaceholder))
                {
                    Rectangle loc = item.GetRectangle();
                    switch (state)
                    {
                        case MarioState.SMALL:
                            return new RedMushroom(new Vector2(loc.X, loc.Y));
                        case MarioState.LARGE:
                            return new FireFlower(new Vector2(loc.X, loc.Y));
                        case MarioState.FIRE:
                            return new Star(new Vector2(loc.X, loc.Y));
                        default:
                            return null;
                    }
                }
                else if (item.GetType() == typeof(BlockCoin))
                {
                    Display.UpdateNumCoins();
                    return item;
                }
                else
                {
                    return item;
                }
            else
                return null;
        }


        public void ChangeState(Game1.Side side)
        {
            if (side.Equals(Game1.Side.Top))
            {

                sourceRectangle = new Rectangle(BlockUtility.blockSize * 3, 0, BlockUtility.blockSize, BlockUtility.blockSize);
                isHidden = false;
                hasItem = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), BlockUtility.blockSize, BlockUtility.blockSize);
            spriteBatch.Draw(TextureManager.blockTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
