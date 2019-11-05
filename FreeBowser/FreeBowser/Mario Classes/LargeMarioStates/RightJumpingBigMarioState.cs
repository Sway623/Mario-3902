using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightJumpingBigMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToFire = false;
        public RightJumpingBigMarioState(Mario mario)
        {
            this.mario = mario;
            
        }

        public void Down()
        {
            if (mario.IsGrounded())
            {
                mario.state = new RightIdleBigMarioState(mario);
                mario.marioSprite = new RightIdleLargeMario();
                mario.SetGrounded();
            }
        }

        public void Up()
        {
            
        }

        public void Right()
        {
            if (mario.IsGrounded())
            {
                mario.state = new RightRunningBigMarioState(mario);
                mario.marioSprite = new RightRunningLargeMario();
            }
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            if (!mario.IsGrounded())
            {
                mario.state = new LeftJumpingBigMarioState(mario);
                mario.marioSprite = new LeftJumpingLargeMario();
            }
        }

        public void Idle()
        {
            if (mario.IsJumping())
            {
                mario.SetFalling();
            }
            else if(mario.IsGrounded())
            {
                mario.state = new RightIdleBigMarioState(mario);
                mario.marioSprite = new RightIdleLargeMario();
            }
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
                mario.state = new RightJumpingFireMarioState(mario);
                mario.marioSprite = new RightJumpingFireMario();
            }
           
        }
        public void SwitchToSmallMario(bool animate)
        {
            mario.state = new RightJumpingSmallMarioState(mario);
            mario.marioSprite = new RightJumpingSmallMario();
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
                    mario.state = new RightJumpingFireMarioState(mario);
                    mario.marioSprite = new RightJumpingFireMario();
                    mario.inSpecialAnimationState = false;

                }

            }
        }

        public void ThrowFireball()
        {

        }

    }
}
