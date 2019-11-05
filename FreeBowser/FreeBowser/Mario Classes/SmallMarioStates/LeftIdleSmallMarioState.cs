using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftIdleSmallMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToBig = false;
        public LeftIdleSmallMarioState(Mario mario)
        {
            int oldHeight = (int)mario.dimensions.Y;
            int yShift = oldHeight - MarioUtility.marioSmallHeight;
            this.mario = mario;
            mario.dimensions.X = MarioUtility.marioSmallWidth;
            mario.dimensions.Y = MarioUtility.marioSmallHeight;
            mario.ManualMoveY(yShift);
        }

        public void Down()
        {
           //no op
           
        }

        public void Up()
        {
            mario.state = new LeftJumpingSmallMarioState(mario);
            mario.marioSprite = new LeftJumpingSmallMario();
        }

        public void Right()
        {
            mario.state = new RightIdleSmallMarioState(mario);
            mario.marioSprite = new RightIdleSmallMario();
        }

        public void Left()
        {
            mario.state = new LeftRunningSmallMarioState(mario);
            mario.marioSprite = new LeftRunningSmallMario();
            mario.MoveX(mario.velo);
        }

        public void Idle()
        {

        }

        public void SwitchToBigMario(bool animate)
        {
            if (animate)
            {
                mario.inSpecialAnimationState = true;
                switchingToBig = true;
            }
            else
            {
                mario.state = new LeftIdleBigMarioState(mario);
                mario.marioSprite = new LeftIdleLargeMario();
            }
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new LeftIdleFireMarioState(mario);
            mario.marioSprite = new LeftIdleFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            // no op here
        }

        public void BeKilled()
        {
            mario.state = new DeadMarioState(mario);
            mario.marioSprite = new MarioDeadSprite();
        }


        public void Update()
        {
            if (switchingToBig)
            {
                bool finished = mario.powerupManager.ChangeStateAnimation(mario, new LeftIdleSmallMario(), new LeftIdleLargeMario());
                if (finished)
                {
                    mario.state = new LeftIdleBigMarioState(mario);
                    mario.marioSprite = new LeftIdleLargeMario();
                    mario.inSpecialAnimationState = false;

                }

            }

        }

        public void ThrowFireball()
        {

        }

    }
}
