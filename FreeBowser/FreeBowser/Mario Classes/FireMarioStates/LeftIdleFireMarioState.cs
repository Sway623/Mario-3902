using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class LeftIdleFireMarioState : IMarioState
    {
        private Mario mario;
        
        public LeftIdleFireMarioState(Mario mario)
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
            mario.state = new LeftCrouchingFireMarioState(mario);
            mario.marioSprite = new LeftCrouchingFireMario(); mario.MoveY();
        }

        public void Up()
        {
            mario.state = new LeftJumpingFireMarioState(mario);
            mario.marioSprite = new LeftJumpingFireMario(); mario.MoveY();
        }

        public void Right()
        {
            mario.state = new RightIdleFireMarioState(mario);
            mario.marioSprite = new RightIdleFireMario(); mario.MoveY();
        }

        public void Left()
        {
            mario.state = new LeftRunningFireMarioState(mario);
            mario.marioSprite = new LeftRunningFireMario(); mario.MoveY();
        }

        public void Idle()
        {

        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new LeftIdleBigMarioState(mario);
            mario.marioSprite = new LeftIdleLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {
            // no op here
        }
        public void SwitchToSmallMario(bool animate)
        {
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
            // no op here
        }

        public void ThrowFireball()
        {
            Fireball fireball = new Fireball(this.mario.location, -1);
            WorldManager.spriteSet.projectiles.Add(fireball);
        }

    }
}
