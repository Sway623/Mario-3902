using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GoombaCollisionChecker
    {
        public GoombaCollisionChecker()
        {

        }


        public void CheckGoombaCollisions(List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            EnemyGravityHandler gravityHandler = new EnemyGravityHandler();

            for (int loop = 0; loop < goombas.Count; loop++)
            {
                Goomba goomba = (Goomba)goombas.ElementAt(loop);
                Rectangle currentGoomba = goomba.GetRectangle();
                bool goombaIsSupported = false;

                for (int secondLoop = loop + 1; secondLoop < goombas.Count; secondLoop++)
                {
                    Goomba secondGoomba = (Goomba)goombas.ElementAt(secondLoop);
                    Rectangle currentSecondGoomba = secondGoomba.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentGoomba, currentSecondGoomba);
                    EnemyEnemyCollisionHandler.HandleCollision(goomba, secondGoomba, collisionType);

                }

                foreach (Koopa koopa in koopas)
                {
                    Rectangle currentKoopa = koopa.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentGoomba, currentKoopa);
                    EnemyEnemyCollisionHandler.HandleCollision(goomba, koopa, collisionType);

                }

                foreach (IPipe pipe in pipes)
                {
                    Rectangle currentPipe = pipe.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentGoomba, currentPipe);
                    EnemyPipeCollisionHandler.HandleCollision(goomba, pipe, collisionType);

                    if (collisionType.Equals(Game1.Side.Bottom) || (currentPipe.Top - currentGoomba.Bottom <= 3 && generalDetector.IsAlongSameYAxis(currentGoomba, currentPipe)))
                    {
                        goombaIsSupported = true;
                    }
                }

                foreach (IBlock block in blocks)
                {
                    Rectangle currentBlock = block.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentGoomba, currentBlock);
                    EnemyBlockCollisionHandler.HandleCollision(goomba, block, collisionType);

                    if (collisionType.Equals(Game1.Side.Bottom) || (currentBlock.Top - currentGoomba.Bottom <= 3 && generalDetector.IsAlongSameYAxis(currentGoomba, currentBlock)))
                    {
                        goombaIsSupported = true;
                    }
                }

                if (!goombaIsSupported)
                {
                    gravityHandler.ApplyGravityToEnemy(goomba);
                }
                else
                {
                    goomba.SetGrounded();
                }

            }
        }


      
    }
}