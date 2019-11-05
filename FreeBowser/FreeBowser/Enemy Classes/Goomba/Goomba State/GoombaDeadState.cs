using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaDeadState : IEnemyState
    {
        private Goomba goomba;

        public GoombaDeadState(Goomba myGoomba)
	    {
		    this.goomba = myGoomba;
            this.goomba.goombaSprite = new GoombaDeadSprite();
	    }

        public void ChangeDirection()
        {
            // NO OP
        }

        public void BeStomped()
        {
            // NO OP
        }

        public void BeFlipped()
        {
            // NO OP
        }

        public void BeKilled()
        {
            // NO OP
        }

        public void Update()
        {
            if(Game1.nightmare)
            {
                this.goomba.goombaState = new NightmareState(goomba);
            }
        }
    }
}
