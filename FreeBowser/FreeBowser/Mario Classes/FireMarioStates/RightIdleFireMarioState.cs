using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class RightIdleFireMarioState : IMarioState
    {
        private Mario mario;

        public RightIdleFireMarioState(Mario mario)
        {
            int oldHeight = (int)mario.dimensions.Y;
            int yShift = oldHeight - MarioUtility.marioNormalHeight;
            this.mario = mario;
            mario.dimensions.X = MarioUtility.marioNormalWidth;
            mario.dimensions.Y = MarioUtility.marioNormalHeight;
            mario.ManualMoveY(yShift);
        }

        public void ThrowFireball()
        {
            Fireball fireball = new Fireball(this.mario.location, 1);
            WorldManager.spriteSet.projectiles.Add(fireball);
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
            mario.state = new RightRunningFireMarioState(mario);
            mario.marioSprite = new RightRunningFireMario();
            mario.MoveX(mario.velo);
        }

        public void Left()
        {
            mario.state = new LeftIdleFireMarioState(mario);
            mario.marioSprite = new LeftIdleFireMario();
        }

        public void Idle()
        {

        }

        public void SwitchToBigMario(bool animate)
        {
            mario.state = new RightIdleBigMarioState(mario);
            mario.marioSprite = new RightIdleLargeMario();
        }
        public void SwitchToFireMario(bool animate)
        {
            // no op
        }
        public void SwitchToSmallMario(bool animate)
        {
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
            // no op here
        }

    }
}
