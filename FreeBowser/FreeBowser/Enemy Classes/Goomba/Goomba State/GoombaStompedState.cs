using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaStompedState : IEnemyState
    {
	    private Goomba goomba;

        public GoombaStompedState(Goomba goomba)
	    {
		    this.goomba = goomba;
            this.goomba.goombaSprite = new GoombaStompedSprite();
	    }

	    public void ChangeDirection()
	    {
            // no op
	    }
	
	    public void BeStomped()
	    {
		    // NO-OP
		    // already stomped, do nothing
	    }
	
    	public void BeFlipped()
	    {
		    // NO-OP
		    // if stomped, do not respond to being attacked by star mario (assumed but not tested behavior)
	    }

        public void BeKilled()
        {
            goomba.goombaState = new GoombaDeadState(goomba);
        }
	
    	public void Update()
	    {
            // no op
	    }

        }
}
