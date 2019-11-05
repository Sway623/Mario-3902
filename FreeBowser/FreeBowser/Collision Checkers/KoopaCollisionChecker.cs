using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaCollisionChecker
    {
        public KoopaCollisionChecker()
        {

        }

        public void CheckKoopaCollisions(List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> koopas)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            EnemyGravityHandler gravityHandler = new EnemyGravityHandler();

            for (int loop = 0; loop < koopas.Count; loop++)
            {
                Koopa koopa = (Koopa)koopas.ElementAt(loop);

                Rectangle currentKoopa = koopa.GetRectangle();

                for (int secondLoop = loop + 1; secondLoop < koopas.Count; secondLoop++)
                {
                    Koopa secondKoopa = (Koopa)koopas.ElementAt(secondLoop);
                    Rectangle currentSecondKoopa = secondKoopa.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentKoopa, currentSecondKoopa);
                    EnemyEnemyCollisionHandler.HandleCollision(koopa, secondKoopa, collisionType);

                }

                foreach (IPipe pipe in pipes)
                {
                    Rectangle currentPipe = pipe.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentKoopa, currentPipe);
                    EnemyPipeCollisionHandler.HandleCollision(koopa, pipe, collisionType);
                }

                foreach (IBlock block in blocks)
                {
                    Rectangle currentBlock = block.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentKoopa, currentBlock);
                    EnemyBlockCollisionHandler.HandleCollision(koopa, block, collisionType);
                }
            }
        }
    }
}