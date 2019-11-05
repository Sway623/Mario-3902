using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioMovingManager
    {
    	private Mario mario;
    	float acceleration = 0.1f;
    	const float MAX_WALK_VELO = 2.0f;
        const float MAX_WALK_LEFT_VELO = -2.0f;
        const float MAX_RUN_VELO = 4.0f;
        const float MAX_RUN_LEFT_VELO = -4.0f;
        float max_velo = 0;
        

    	public MarioMovingManager(Mario mario){
            this.mario = mario;
    	}

    	public void Damp(){
    		
    		
    		if(mario.velo > 0){
                if (mario.velo < 0.2)
                {
                    mario.velo = 0;
                }
                else
                {
                    mario.velo -= acceleration;
                    mario.state.Right();
                }
    		}
    		else if(mario.velo < 0){
                if (mario.velo > -0.2)
                {
                    mario.velo = 0;
                }
                else
                {

                    mario.velo += acceleration;
                    mario.state.Left();
                }
    		}
    	}
    	 public void Right()
        {
        	//set MAX Speed accordingly
            if (mario.isRunning)
            {
                max_velo = MAX_RUN_VELO;
            }
            else
            {
                max_velo = MAX_WALK_VELO;
            }

             //if It was moving towards left, let it damp
            if (mario.velo < 0)
            {
                Damp();
            }
            else if (mario.velo < max_velo)
            {
                mario.velo += acceleration;
                mario.state.Right();
            }
            else if (mario.velo > max_velo)
            {
                mario.velo = max_velo;
            }
            else
            {
                mario.state.Right();
            }
            
        }
        public void Left()
         {
             if (mario.isRunning)
             {
                 max_velo = MAX_RUN_LEFT_VELO;
             }
             else
             {
                 max_velo = MAX_WALK_LEFT_VELO;
             }
            //if currently moving towards right
             if (mario.velo > 0)
             {
                 Damp();
             }
             else if (mario.velo > max_velo)
             {
                 mario.velo -= acceleration;
                 mario.state.Left();
             }
             else if (mario.velo < max_velo)
             {
                 mario.velo = max_velo;
             }
             else
             {
                 mario.state.Left();
             }
         }
    }
}