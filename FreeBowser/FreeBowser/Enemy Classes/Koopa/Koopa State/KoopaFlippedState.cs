using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaFlippedState : IEnemyState
    {
        private Koopa koopa;

        public KoopaFlippedState(Koopa koopa)
	    {
		    this.koopa = koopa;
            this.koopa.koopaSprite = new KoopaFlippedSprite();
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
            koopa.koopaState = new KoopaDeadState(koopa);
        }
	
    	public void Update()
	    {
            koopa.moveX(2);
	    }
    }
}
