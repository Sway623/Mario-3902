using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class QuestionBlock : IBlock
    {
        public bool hasItem;
        public bool isHit = false;
        public bool movingUp = true;
        public bool doneUp = false;
        public bool movingLeft;

        private IItem item;
        Rectangle sourceRectangle;
        private Texture2D sourceFile;
        
        int spriteLoc = 48;
        int offset = 0;
        double horizontalVelocity = 0;
        double verticalVelocity = 0;

        int frameCounter = 0;
        int frameCountToUpdate = 25;
        int currentFrame = 0;
        int frameToDisplay = 0;
        int numberOfFrames = 3;

        float timer = 0;
        int hitCount = 0;

        int maxTimer = 10;
        int maxHitCount = 8;

        bool isBrick;
        GameTime lastUpdate;
        Vector2 location;
        Vector2 pointsLoc;

        public QuestionBlock(Vector2 initLocation, IItem initItem, bool usesBrickTexture)
        {
            location = initLocation;
            hasItem = true;
            isHit = false;
            item = initItem;
            item.SetCreatedFromBlock(true);
            isBrick = usesBrickTexture;

            if (isBrick)
            {
                sourceRectangle = new Rectangle(BlockUtility.blockSize * 1, 0, BlockUtility.blockSize, BlockUtility.blockSize);
            }
            else
            {
                sourceRectangle = new Rectangle(BlockUtility.blockSize * frameToDisplay, spriteLoc, BlockUtility.blockSize, BlockUtility.blockSize);
            }
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

        public void Update(GameTime gameTime)
        {
            if (!isBrick)
            {
                frameCounter++;
                if (hasItem && (frameCounter > frameCountToUpdate))
                {
                    frameCounter = 0;
                    currentFrame++;
                    if (currentFrame > numberOfFrames)
                    {
                        currentFrame = 0;
                    }
                    frameToDisplay = currentFrame;
                    sourceRectangle = new Rectangle(BlockUtility.blockSize * frameToDisplay, spriteLoc, BlockUtility.blockSize, BlockUtility.blockSize);

                }
            }
            if(isHit == true)
            {
                pointsLoc.Y--;
            }
            lastUpdate = gameTime;

        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, BlockUtility.blockSize, BlockUtility.blockSize);
            return currentRectangle;
        }

        public void ChangeState(Game1.Side side)
        {
            if (side.Equals(Game1.Side.Top))
            {
                if (item.GetType() != typeof(MultiCoin))
                {
                    sourceRectangle = new Rectangle(BlockUtility.blockSize * numberOfFrames, 0, BlockUtility.blockSize, BlockUtility.blockSize);
                    hasItem = false;
                    isHit = true;
                }
                else if (hitCount > maxHitCount || timer > maxTimer)
                {
                    sourceRectangle = new Rectangle(BlockUtility.blockSize * numberOfFrames, 0, BlockUtility.blockSize, BlockUtility.blockSize);
                    hasItem = false;
                    isHit = true;
                }
            }
        }

        public Boolean HasItem()
        {
            return hasItem;
        }

        public bool GetMovingLeft()
        {
            return movingLeft;
        }

        public Boolean IsHit()
        {
            return isHit;
        }

        public IItem ReleaseItem(MarioState state)
        {

            if (HasItem())
            {

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
                else if (item.GetType() == typeof(MultiCoin))
                {
                    Display.UpdateNumCoins();
                    timer += (float)lastUpdate.ElapsedGameTime.Seconds;
                    hitCount++;
                    return new MultiCoin(new Vector2(location.X, location.Y - 16));
                }
                else
                {
                    return item;
                }
            }
            else
            {
                return null;
            }
        }

        public int adjustOffset()
        {
            if (doneUp && offset < 0)
            {
                offset++;
            }
            else if (!doneUp)
            {
                offset--;
                if (offset <= -5)
                {
                    doneUp = true;
                }
            }

            return offset;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {

            if (isBrick)
            {
                sourceFile = TextureManager.blockTexture;
            }
            else if (hasItem)
            {

                sourceFile = TextureManager.itemTexture;

            }
            else
            {
                item.Draw(spriteBatch, cameraPosition);
                sourceFile = TextureManager.blockTexture;
            }

            if (isHit)
            {
                adjustOffset();
            }

            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y) + offset, BlockUtility.blockSize, BlockUtility.blockSize);
            spriteBatch.Draw(sourceFile, destinationRectangle, sourceRectangle, Color.White);


        }
    }
}
