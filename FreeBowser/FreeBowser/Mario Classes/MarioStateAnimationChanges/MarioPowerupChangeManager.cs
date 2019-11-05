using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace FreeBowser
{
    public class MarioPowerupChangeManager 
    {
        private Mario mario;
        int frameTimer = 0;
        int totalFrames = 50;
        int numberOfSprites = 2;
        int transformationDisplacement = 17;
        public MarioPowerupChangeManager()
        {
        }

        public bool ChangeStateAnimation(Mario mario, IMarioSprite initialSprite, IMarioSprite finalSprite)
        {
            bool finished = false;
            int firstFrameChangeRotation = totalFrames * 1 / 5;
            int secondFrameChangeRotation = totalFrames * 2 / 5;
            int thirdFrameChangeRotation = totalFrames * 3 / 5;
            int fourthFrameChangeRotation = totalFrames * 4 / 5;





            if (frameTimer < totalFrames)
            {
                if (frameTimer < firstFrameChangeRotation)
                {
                    if (frameTimer == 0)
                    {
                        mario.location.Y -= transformationDisplacement;
                    }
                    mario.SetIMarioSprite(finalSprite);
                    mario.dimensions.Y = MarioUtility.marioNormalHeight;
                    mario.dimensions.X = MarioUtility.marioNormalWidth;

                }
                else if (frameTimer < secondFrameChangeRotation)
                {
                    if (frameTimer == firstFrameChangeRotation)
                    {
                        mario.location.Y += transformationDisplacement;
                    }
                    mario.SetIMarioSprite(initialSprite);
                    mario.dimensions.Y = MarioUtility.marioSmallHeight;
                    mario.dimensions.X = MarioUtility.marioSmallWidth;
                }
                else if (frameTimer < thirdFrameChangeRotation)
                {
                    if (frameTimer == secondFrameChangeRotation)
                    {
                        mario.location.Y -= transformationDisplacement;
                    }
                    mario.SetIMarioSprite(finalSprite);
                    mario.dimensions.Y = MarioUtility.marioNormalHeight;
                    mario.dimensions.X = MarioUtility.marioNormalWidth;
                }
                else if (frameTimer < fourthFrameChangeRotation)
                {
                    if (frameTimer == thirdFrameChangeRotation)
                    {
                        mario.location.Y += transformationDisplacement;
                    }
                    mario.SetIMarioSprite(initialSprite);
                    mario.dimensions.Y = MarioUtility.marioSmallHeight;
                    mario.dimensions.X = MarioUtility.marioSmallWidth;
                }
                else
                {
                    if (frameTimer == fourthFrameChangeRotation)
                    {
                        mario.location.Y -= transformationDisplacement;
                    }
                    mario.SetIMarioSprite(finalSprite);
                    mario.dimensions.Y = MarioUtility.marioNormalHeight;
                    mario.dimensions.X = MarioUtility.marioNormalWidth;
                }

                frameTimer++;
                if (frameTimer == totalFrames)
                {
                    finished = true;
                    frameTimer = 0;
                }
            }

            return finished;
        }

    }
}
