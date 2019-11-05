using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaLeftMovingState : IEnemyState
    {
        private Goomba goomba;

        public GoombaLeftMovingState(Goomba myGoomba)
	    {
		    this.goomba = myGoomba;
            this.goomba.goombaSprite = new GoombaSprite();
	    }

        public void ChangeDirection()
        {
            goomba.goombaState = new GoombaRightMovingState(goomba);
        }

        public void BeStomped()
        {
            goomba.goombaState = new GoombaStompedState(goomba);
        }

        public void BeFlipped()
        {
            goomba.goombaState = new GoombaFlippedState(goomba);
        }

        public void BeKilled()
        {
            // no op, needs to be stomped first
        }

        public void Update()
        {
            goomba.moveX(-1);
        }

    }
}
