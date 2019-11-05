using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightCrouchingBigMarioState : IMarioState
    {
        private Mario mario;

        public RightCrouchingBigMarioState(Mario mario)
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
            mario.state = new RightIdleBigMarioState(mario);
            mario.marioSprite = new RightIdleLargeMario();
        }

        public void Right()
        {
            mario.state = new RightRunningBigMarioState(mario);
            mario.marioSprite = new RightRunningLargeMario();
        }

        public void Left()
        {
            mario.state = new LeftCrouchingBigMarioState(mario);
            mario.marioSprite = new LeftCrouchingLargeMario();
        }

        public void Idle()
        {
            mario.state = new RightIdleBigMarioState(mario);
            mario.marioSprite = new RightIdleLargeMario();
        }

        public void SwitchToBigMario(bool animate)
        {
            // no op here
        }
        public void SwitchToFireMario(bool animate)
        {
            mario.state = new RightCrouchingFireMarioState(mario);
            mario.marioSprite = new RightCrouchingFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            // no crouchingsmallmario, so change to right idlesmall
            mario.state = new RightIdleSmallMarioState(mario);
            mario.marioSprite = new RightIdleSmallMario();
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
