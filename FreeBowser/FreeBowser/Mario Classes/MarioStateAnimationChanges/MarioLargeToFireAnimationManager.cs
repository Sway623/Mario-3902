using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace FreeBowser
{
    public class MarioLargeToFireAnimationManager
    {
        int frameTimer = 0;
        int totalFrames = 50;
        int transformationDisplacement = 10;
        public MarioLargeToFireAnimationManager()
        {
        }

        public bool ChangeStateAnimation(Mario mario, IMarioSprite finalSprite, IMarioSprite initialSprite)
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
                        mario.location.Y += transformationDisplacement;
                    }
                    mario.SetIMarioSprite(finalSprite);
                    mario.dimensions.Y = MarioUtility.marioSmallHeight;
                    mario.dimensions.X = MarioUtility.marioSmallWidth;

                }
                else if (frameTimer < secondFrameChangeRotation)
                {

                    mario.SetIMarioSprite(initialSprite);
                    
                }
                else if (frameTimer < thirdFrameChangeRotation)
                {

                    mario.SetIMarioSprite(finalSprite);
                
                }
                else if (frameTimer < fourthFrameChangeRotation)
                {

                    mario.SetIMarioSprite(initialSprite);
                    
                }
                else
                {

                    mario.SetIMarioSprite(finalSprite);
                    mario.dimensions.Y = MarioUtility.marioNormalHeight;
                    mario.dimensions.X = MarioUtility.marioNormalHeight;
                }

                frameTimer++;
                if (frameTimer == totalFrames)
                {
                    mario.location.Y -= transformationDisplacement;
                    finished = true;
                    frameTimer = 0;
                }
            }

            return finished;
        }

    }
}
