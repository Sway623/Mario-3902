using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RightRunningFireMarioState : IMarioState
    {
        private Mario mario;
        
        public RightRunningFireMarioState(Mario mario)
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
            mario.state = new RightCrouchingFireMarioState(mario);
            mario.marioSprite = new RightCrouchingFireMario();
        }


        public void Up()
        {
            mario.state = new RightJumpingFireMarioState(mario);
            mario.marioSprite = new RightJumpingFireMario();
        }

        public void Right()
        {
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            mario.state = new RightIdleFireMarioState(mario);
            mario.marioSprite = new RightIdleFireMario();
            
        }

        public void Idle()
        {
            mario.state = new RightIdleFireMarioState(mario);
            mario.marioSprite = new RightIdleFireMario();
        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new RightRunningBigMarioState(mario);
            mario.marioSprite = new RightRunningLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {
            // no op
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

        }

        public void ThrowFireball()
        {
            Fireball fireball = new Fireball(this.mario.location, 1);
            WorldManager.spriteSet.projectiles.Add(fireball);
        }

    }
}
