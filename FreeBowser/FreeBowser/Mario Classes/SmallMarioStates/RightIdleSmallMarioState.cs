using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightIdleSmallMarioState : IMarioState
    {
        private Mario mario;
        bool switchingToBig = false;

        public RightIdleSmallMarioState(Mario mario)
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
            // no op
        }

        public void Up()
        {
            mario.state = new RightJumpingSmallMarioState(mario);
            mario.marioSprite = new RightJumpingSmallMario();
        }

        public void Right()
        {

            if (!mario.IsInSpecialAnimationState())
            {
                mario.state = new RightRunningSmallMarioState(mario);
                mario.marioSprite = new RightRunningSmallMario();
            }
        }

        public void Left()
        {
           mario.state = new LeftIdleSmallMarioState(mario);
           mario.marioSprite = new LeftIdleSmallMario();
        }

        public void Idle()
        {

        }

        public void SwitchToBigMario(bool animate)
        {
            if (animate)
            {
                mario.inSpecialAnimationState = animate;
                switchingToBig = true;
            }
            else
            {
                mario.state = new RightIdleBigMarioState(mario);
                mario.marioSprite = new RightIdleLargeMario();
            }
            
        }

        public void SwitchToFireMario(bool animate)
        {
            mario.state = new RightIdleFireMarioState(mario);
            mario.marioSprite = new RightIdleFireMario();
        }
        public void SwitchToSmallMario(bool animate)
        {
            
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
