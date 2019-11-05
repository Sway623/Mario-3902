using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class Fireball
    {
        int spriteWidth = 11;
        int spriteHeight = 11;
        bool isHidden = false;
        public bool isFalling = true;

        public Vector2 location;
        public int direction;
        float currentFallSpeed = 0;

        int textureX;
        int textureY = 945;
        int currentFrame = 0;

        public Fireball(Vector2 initLocation, int dir)
        {
            direction = dir;
            location = initLocation;
        }

        public void SetLocation(Vector2 coords)
        {
            location.X = coords.X;
            location.Y = coords.Y;
        }

        public void Update()
        {
            if (!isHidden)
            {
                if (direction == 1)
                {
                    location.X += 5;
                    if (isFalling)
                    {
                        location.Y += currentFallSpeed;
                        currentFallSpeed += (float)0.25;
                    }
                    else
                    {
                        int x = 0;
                        while (x < 11)
                        {
                            location.Y -= (float).5;
                            x++;

                        }
                        isFalling = true;
                    }
                }
                else
                {
                    location.X -= 5;
                    if (isFalling)
                    {
                        location.Y += currentFallSpeed;
                        currentFallSpeed += (float)0.25;
                    }
                    else
                    {
                        int x = 0;
                        while (x < 11)
                        {
                            location.Y -= 1;
                            x++;
                        }
                        isFalling = true;
                    }
                }

            }

            if (currentFrame == 0)
            {
                textureX = 312;
            }
            else if (currentFrame == 1)
            {
                textureX = 323;  
            }
            else if (currentFrame == 2)
            {
                textureX = 334;
            }
            else if (currentFrame==3)
            {
                textureX = 345;
            }
            else if(currentFrame == 4)
            {
                currentFrame = 0;
            }

            currentFrame++;
        }

        public void ChangeState()
        {
            location.X = -100;
            location.Y = -100;
            isHidden = true;
        }

        public void Bounce()
        {
            for (int i = 0; i < 13; i++)
            {
                location.Y -= 1;
            }
            currentFallSpeed = 0;
            isFalling = false;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle sourceRectangle = new Rectangle(textureX, textureY, spriteWidth, spriteHeight);
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), 17, spriteHeight);
            spriteBatch.Draw(TextureManager.miscTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)location.X, (int)location.Y, spriteWidth-1, spriteHeight-2);
        }
    }
}
