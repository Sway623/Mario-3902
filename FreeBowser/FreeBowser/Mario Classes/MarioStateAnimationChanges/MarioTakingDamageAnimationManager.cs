using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace FreeBowser
{
    public class MarioTakingDamageAnimationManager
    {
        private Mario mario;
        int frameTimer = 0;
        int totalFrames = 50;
        int numberOfSprites = 2;
        int transformationDisplacement = 18;
        public MarioTakingDamageAnimationManager()
        {
        }

        public bool ChangeStateAnimation(Mario mario)
        {
            bool finished = false;
            int firstFrameChangeRotation = totalFrames * 1 / 5;
            int secondFrameChangeRotation = totalFrames * 2 / 5;
            int thirdFrameChangeRotation = totalFrames * 3 / 5;
            int fourthFrameChangeRotation = totalFrames * 4 / 5;
            IMarioSprite finalSprite = new RightIdleSmallMario();
            IMarioSprite blinkingSprite = new SmallMarioBlankSprite();

            if (frameTimer < totalFrames)
            {
                if (frameTimer < firstFrameChangeRotation)
                {
                    if (frameTimer == 0)
                    {
                        mario.location.Y += transformationDisplacement;
                    }
                    mario.SetIMarioSprite(finalSprite);
                    mario.dimensions.X = MarioUtility.marioSmallWidth;
                    mario.dimensions.Y = MarioUtility.marioSmallHeight;

                }
                else if (frameTimer < secondFrameChangeRotation)
                {
                    mario.SetIMarioSprite(blinkingSprite);
                }
                else if (frameTimer < thirdFrameChangeRotation)
                {
                    mario.SetIMarioSprite(finalSprite);
                }
                else if (frameTimer < fourthFrameChangeRotation)
                {
                    mario.SetIMarioSprite(blinkingSprite);
                }
                else
                {
                    mario.SetIMarioSprite(finalSprite);
                }

                frameTimer++;
                if (frameTimer == totalFrames)
                {
                    finished = true;
                    frameTimer = 0;
                    mario.SetMarioState(MarioState.SMALL);

                    mario.state = new RightIdleSmallMarioState(mario);
                    mario.marioSprite = new RightIdleSmallMario();
                }
            }

            return finished;
        }

    }
}
