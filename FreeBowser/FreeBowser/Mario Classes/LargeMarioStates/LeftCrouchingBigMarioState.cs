using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftCrouchingBigMarioState : IMarioState
    {
        private Mario mario;

        public LeftCrouchingBigMarioState(Mario mario)
        {
            int oldHeight = (int)mario.dimensions.Y;
            int yShift = oldHeight - MarioUtility.marioCrouchingHeight;
            this.mario = mario;
            mario.dimensions.X = MarioUtility.marioNormalWidth;
            mario.dimensions.Y = MarioUtility.marioCrouchingHeight;
            mario.ManualMoveY(yShift);
        }

        public void Down()
        {
        }

        public void Up()
        {
            mario.state = new LeftIdleBigMarioState(mario);
            mario.marioSprite = new LeftIdleLargeMario();
        }

        public void Right()
        {
            mario.state = new RightCrouchingBigMarioState(mario);
            mario.marioSprite = new RightCrouchingLargeMario();
        }

        public void Left()
        {
            mario.state = new LeftRunningBigMarioState(mario);
            mario.marioSprite = new LeftRunningLargeMario();
        }

        public void Idle()
        {
            mario.state = new LeftIdleBigMarioState(mario);
            mario.marioSprite = new LeftIdleLargeMario();
        }

        public void SwitchToBigMario(bool animate)
        {
            // no op
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new LeftCrouchingFireMarioState(mario);
            mario.marioSprite = new LeftCrouchingFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            //since there is no small crouching mario, change the sprite to leftIdleMario
            mario.state = new LeftIdleSmallMarioState(mario);
            mario.marioSprite = new LeftIdleSmallMario();
        }

        public void BeKilled()
        {
            mario.state = new DeadMarioState(mario);
            mario.marioSprite = new MarioDeadSprite();
        }


        public void Update()
        {

        }

        public void ThrowFireball()
        {
            
        }

    }
}
