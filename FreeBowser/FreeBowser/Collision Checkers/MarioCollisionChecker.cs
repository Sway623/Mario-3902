using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class MarioCollisionChecker
    {
        public MarioCollisionChecker()
        {

        }

        public void CheckMariosCollisions(List<IPlayer> players, List<IItem> items, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            BlockCollisionDetector blockDetector = new BlockCollisionDetector();
            MarioGravityHandler2 gravityHandler = new MarioGravityHandler2();

            double initialDistance = 1000;
            foreach (Mario mario in players)
            {
                if (!mario.isDying)
                {
                    Rectangle currentMario = mario.GetRectangle();
                    bool marioIsSupported = false;
                    bool marioIsBlocked = false;
                    bool wasTopCollision = false;
                    bool marioBounceOffEnemy = false;
                    IBlock closestBlock = (IBlock)blocks.ElementAt(0);
                    double distanceToClosestBlock = initialDistance;

                    for (int loop = 0; loop < blocks.Count; loop++)
                    {
                        IBlock block = (IBlock)blocks.ElementAt(loop);
                        Rectangle currentBlock = block.GetRectangle();

                        collisionType = blockDetector.DetermineCollision(currentMario, currentBlock);

                        if (collisionType.Equals(Game1.Side.Bottom) || (currentBlock.Top - currentMario.Bottom <= 2 && blockDetector.IsAlongSameYAxis(currentMario, currentBlock)))
                        {
                            marioIsSupported = true;
                        }
                        else if (collisionType.Equals(Game1.Side.Top))
                        {
                            marioIsBlocked = true;
                            SoundManager.PlaySound(Game1.bumpSound);
                        }

                        if (collisionType.Equals(Game1.Side.Top))
                        {
                            wasTopCollision = true;
                            if (blockDetector.DistanceToCenterOfPlayer(currentMario, currentBlock) < distanceToClosestBlock)
                            {
                                closestBlock = block;
                            }
                        }
                        else
                        {
                            BlockMarioCollisionHandler.HandleCollision(mario, block, collisionType);

                        }
                        MarioBlockCollisionHandler.HandleCollision(mario, block, collisionType);
                    }

                    if (wasTopCollision)
                    {
                        if (closestBlock.HasItem())
                        {
                            //Console.WriteLine(mario.GetState());
                            IItem createdItem = closestBlock.ReleaseItem(mario.GetState());
                            if (items != null)
                            {
                                createdItem.SetCreatedFromBlock(true);
                                items.Add(createdItem);
                            }
                        }
                        BlockMarioCollisionHandler.HandleCollision(mario, closestBlock, Game1.Side.Top);

                    }

                    foreach (Goomba goomba in goombas)
                    {
                        Rectangle currentGoomba = goomba.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentMario, currentGoomba);
                        if (collisionType.Equals(Game1.Side.Bottom))
                        {
                            marioBounceOffEnemy = true;
                        }
                        MarioEnemyCollisionHandler.HandleCollision(mario, goomba, collisionType);

                    }

                    foreach (Koopa koopa in koopas)
                    {
                        Rectangle currentKoopa = koopa.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentMario, currentKoopa);
                        //Console.WriteLine(collisionType);
                        MarioEnemyCollisionHandler.HandleCollision(mario, koopa, collisionType);
                        if (collisionType.Equals(Game1.Side.Bottom))
                        {
                            marioBounceOffEnemy = true;
                            if(!Game1.nightmare)
                            {
                                IItem shell = koopa.CreateShell();
                                items.Add(shell);
                            }
                        }
                    }

                    foreach (IPipe pipe in pipes)
                    {
                        Rectangle currentPipe = pipe.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentMario, currentPipe);


                        if (collisionType.Equals(Game1.Side.Bottom)) //|| (currentPipe.Top - currentMario.Bottom <= 3 && generalDetector.IsAlongSameYAxis(currentMario, currentPipe)))
                        {
                            collisionType = Game1.Side.Bottom;
                            marioIsSupported = true;
                        }
                        else if (collisionType.Equals(Game1.Side.Top))
                        {
                            marioIsBlocked = true;
                        }

                        MarioPipeCollisionHandler.HandleCollision(mario, pipe, collisionType);
                    }

                    foreach (IItem item in items)
                    {

                        Rectangle currentItem = item.GetRectangle();

                        collisionType = generalDetector.DetermineCollision(currentItem, currentMario);
                        if (!collisionType.Equals(Game1.Side.None))
                        {
                            //Console.WriteLine("touching item: " + item);
                        }
                        MarioItemCollisionHandler.HandleCollision(mario, item, collisionType);
                    }


                    if (!marioIsSupported)
                    {
                        if (!mario.IsInSpecialAnimationState())

                            gravityHandler.ApplyGravityToMario(mario);

                    }
                    else if (marioIsBlocked)
                    {
                        mario.ManualMoveY(4);
                        mario.SetFalling();
                    }
                    else if (!marioBounceOffEnemy)
                    {
                        mario.SetGrounded();
                    }
                }

            }
        }
    }
}

