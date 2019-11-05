using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class KoopaShellCollisionChecker
    {
        public KoopaShellCollisionChecker()
        {

        }

        public void CheckKoopaShellCollisions(List<IItem> items, List<IEnemy> goombas, List<IEnemy> koopas, List<IBlock> blocks, List<IPipe> pipes)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            ItemGravityHandler gravityHandler = new ItemGravityHandler();

            foreach (IItem item in items)
            {
                if (item is KoopaShell)
                {
                    KoopaShell shell = (KoopaShell)item;
                    Rectangle currentShell = shell.GetRectangle();
                    bool itemIsSupported = false;


                    foreach (IBlock block in blocks)
                    {
                        Rectangle currentBlock = block.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentBlock, currentShell);

                        ShellBlockCollisionHandler.HandleCollision(shell, block, collisionType);
                        if (collisionType.Equals(Game1.Side.Top) || (currentBlock.Top - currentShell.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentShell, currentBlock)))
                        {
                            itemIsSupported = true;
                        }
                    }

                    foreach (IPipe pipe in pipes)
                    {
                        Rectangle currentPipe = pipe.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentPipe, currentShell);

                        ShellPipeCollisionHandler.HandleCollision(shell, collisionType);

                        if (collisionType.Equals(Game1.Side.Top) || (currentPipe.Top - currentShell.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentShell, currentPipe)))
                        {
                            itemIsSupported = true;
                        }
                    }
                    foreach (Goomba goomba in goombas)
                    {
                        Rectangle currentGoomba = goomba.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentShell, currentGoomba);

                        ShellEnemyCollisionHandler.HandleCollision(shell, goomba, collisionType);

                    }

                    foreach (Koopa koopa in koopas)
                    {
                        Rectangle currentKoopa = koopa.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentShell, currentKoopa);

                        ShellEnemyCollisionHandler.HandleCollision(shell, koopa, collisionType);

                    } 

                    if (!(itemIsSupported))
                    {
                        gravityHandler.ApplyGravityToItem(shell);
                    }
                    else
                    {
                        shell.SetGrounded();
                    }







                }
            }
        }
    }
}