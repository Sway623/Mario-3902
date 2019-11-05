using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightRunningBigMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToFire = false;

        public RightRunningBigMarioState(Mario mario)
        {
            int oldHeight = (int)mario.dimensions.Y;
            int yShift = oldHeight - MarioUtility.marioNormalHeight;
            this.mario = mario;
            mario.dimensions.X = MarioUtility.marioNormalWidth;
            mario.dimensions.Y = MarioUtility.marioNormalHeight;
            mario.ManualMoveY(yShift);
        }

        public void Down()
        {
            mario.state = new RightCrouchingBigMarioState(mario);
            mario.marioSprite = new RightCrouchingLargeMario();
        }

        public void Up()
        {
            mario.state = new RightJumpingBigMarioState(mario);
            mario.marioSprite = new RightJumpingLargeMario();
        }

        public void Right()
        {
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            mario.state = new RightIdleBigMarioState(mario);
            mario.marioSprite = new RightIdleLargeMario();
        }

        public void Idle()
        {
            mario.state = new RightIdleBigMarioState(mario);
            mario.marioSprite = new RightIdleLargeMario();
        }

        public void SwitchToBigMario(bool animate)
        {
            // no op
        }
        public void SwitchToFireMario(bool animate)
        {
            if (animate)
            {
                mario.inSpecialAnimationState = true;
                switchingToFire = true;
            }
            else
            {
             
                mario.state = new RightRunningFireMarioState(mario);
                mario.marioSprite = new RightRunningFireMario();
            }
            
        }
        public void SwitchToSmallMario(bool animate)
        {
            mario.state = new RightRunningSmallMarioState(mario);
            mario.marioSprite = new RightRunningSmallMario();
        }

        public void BeKilled()
        {
            mario.state = new DeadMarioState(mario);
            mario.marioSprite = new MarioDeadSprite();
        }

        public void Update()
        {
            if (switchingToFire)
            {
                bool finished = mario.largeToFireManager.ChangeStateAnimation(mario, new RightFacingPowerupChangeMario(), new RightFacingPowerupChangeMario2());
                if (finished)
                {
                    mario.state = new RightIdleFireMarioState(mario);
                    mario.marioSprite = new RightIdleFireMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {

        }
    }
}
