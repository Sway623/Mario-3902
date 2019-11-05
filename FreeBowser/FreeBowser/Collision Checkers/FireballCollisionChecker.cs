using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class FireballCollisionChecker
    {
        public FireballCollisionChecker()
        {

        }

        public void CheckFireballCollisions(List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas, List<Fireball> projectiles)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();

            foreach (Fireball fireball in projectiles)
            {
                Rectangle currentFireball = fireball.GetRectangle();


                foreach (IBlock block in blocks)
                {
                    Rectangle currentBlock = block.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentBlock, currentFireball);

                    FireballBlockCollisionHandler.HandleCollision(fireball, block, collisionType);
                }

                foreach (Koopa koopa in koopas)
                {
                    Rectangle currentKoopa = koopa.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentKoopa, currentFireball);

                    FireballEnemyCollisionHandler.HandleCollision(fireball, koopa, collisionType);

                }

                foreach (Goomba goomba in goombas)
                {
                    Rectangle currentGoomba = goomba.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentGoomba, currentFireball);

                    FireballEnemyCollisionHandler.HandleCollision(fireball, goomba, collisionType);

                }

                foreach (IPipe pipe in pipes)
                {
                    Rectangle currentPipe = pipe.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentPipe, currentFireball);

                    FireballPipeCollisionHandler.HandleCollision(fireball, pipe, collisionType);
                }
            }
        }

    }
}