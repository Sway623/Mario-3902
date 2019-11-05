using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightRunningSmallMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToBig = false;
        public RightRunningSmallMarioState(Mario mario)
        {
            this.mario = mario;
        }

        public void Down()
        {
            // no op
        }

        public void Up()
        {
            if (mario.IsGrounded())
            {
                mario.state = new RightJumpingSmallMarioState(mario);
                mario.marioSprite = new RightJumpingSmallMario();
            }
        }

        public void Right()
        {
            if (mario.IsInSpecialAnimationState())
            {
                // mario.state = new RightIdleSmallMarioState(mario);
                // mario.marioSprite = new RightIdleSmallMario();            
            }
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            mario.state = new RightIdleSmallMarioState(mario);
            mario.marioSprite = new RightIdleSmallMario();
        }

        public void Idle()
        {
            mario.state = new RightIdleSmallMarioState(mario);
            mario.marioSprite = new RightIdleSmallMario();
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
                mario.state = new RightRunningBigMarioState(mario);
                mario.marioSprite = new RightRunningLargeMario();
            }
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new RightRunningFireMarioState(mario);
            mario.marioSprite = new RightRunningFireMario();
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
                bool finished = mario.powerupManager.ChangeStateAnimation(mario, new RightIdleSmallMario(), new RightIdleLargeMario());
                if (finished)
                {
                    mario.state = new RightIdleBigMarioState(mario);
                    mario.marioSprite = new RightIdleLargeMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {

        }

    }
}
