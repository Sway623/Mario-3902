using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftRunningSmallMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToBig = false;

        public LeftRunningSmallMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public void Down()
        {

        }

        public void Up()
        {
            if (mario.IsGrounded())
            {
                mario.state = new LeftJumpingSmallMarioState(mario);
                mario.marioSprite = new LeftJumpingSmallMario();
            }
        }

        public void Right()
        {
            mario.state = new RightIdleSmallMarioState(mario);
            mario.marioSprite = new RightIdleSmallMario();
        }

        public void Left()
        {
            mario.MoveX(mario.velo);
        }

        public void Idle()
        {
            mario.state = new LeftIdleSmallMarioState(mario);
            mario.marioSprite = new LeftIdleSmallMario();
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
                mario.state = new LeftRunningBigMarioState(mario);
                mario.marioSprite = new LeftRunningLargeMario();
            }
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new LeftRunningFireMarioState(mario);
            mario.marioSprite = new LeftRunningFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            // no op
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
