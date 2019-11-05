using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace FreeBowser
{
    public class MarioEndOfLevelAnimationManager
    {
        int frameTimer = 0;
        int totalFrames = 150;
        int walkingVelo = 1;
        int offScreen = -1000;
        int firstFrame = 1;
        public MarioEndOfLevelAnimationManager()
        {
        }

        public bool ChangeStateAnimation(Mario mario)
        {
            bool finished = false;
            if (frameTimer < totalFrames)
            {
                frameTimer++;
                if (frameTimer == firstFrame)
                {
                    if (mario.GetState().Equals((MarioState.LARGE)))
                    {
                        mario.state = new RightRunningBigMarioState(mario);
                        mario.marioSprite = new RightRunningLargeMario();
                    }
                    else if (mario.GetState().Equals((MarioState.FIRE)))
                    {
                        mario.state = new RightRunningFireMarioState(mario);
                        mario.marioSprite = new RightRunningFireMario();
                    }
                    else
                    {
                        mario.state = new RightRunningSmallMarioState(mario);
                        mario.marioSprite = new RightRunningSmallMario();
                    }
                }

                mario.MoveX(walkingVelo);
                mario.marioSprite.Update(true);
                if (frameTimer == totalFrames)
                {
                    finished = true;
                }
            }   
            else
            {
                mario.location.X = offScreen;
                mario.location.Y = offScreen;
            }
            return finished;
        }

    }
}
