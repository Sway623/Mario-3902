using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class CollisionChecker
    {
        public CollisionChecker()
        {
        }

        public void CheckEachCollision(List<IPlayer> players, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas, List<ICoin> coins, List<IItem> items, List<Fireball> projectiles)
        {
            CheckMarioCollisions(players, items, blocks, pipes, goombas, koopas);
            CheckGoombaCollisions(blocks, pipes, goombas, koopas);
            CheckKoopaCollisions(blocks, pipes, goombas, koopas);
            CheckFireballCollisions(blocks, pipes, goombas, koopas, projectiles);
            CheckMushroomCollisions(items, blocks, pipes);
        }

        public void CheckMushroomCollisions(List<IItem> items, List<IBlock> blocks, List<IPipe> pipes)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            foreach (IItem rm in items)
            {

                bool itemIsSupported = false;
                if (rm is RedMushroom)
                {
                    Rectangle currentRM = rm.GetRectangle();
                    ItemGravityHandler gravityHandler = new ItemGravityHandler(rm);

                    foreach (IBlock block in blocks)
                    {
                        Rectangle currentBlock = block.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentBlock, currentRM);

                        MushroomBlockCollisionHandler.HandleCollision(rm, block, collisionType);
                        if (collisionType.Equals(Game1.Side.Top) || (currentBlock.Top - currentRM.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentRM, currentBlock)))
                        {
                            itemIsSupported = true;
                        }
                    }

                    foreach (IPipe pipe in pipes)
                    {
                        Rectangle currentPipe = pipe.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentPipe, currentRM);

                        MushroomPipeCollisionHandler.HandleCollision(rm, pipe, collisionType);

                        if (collisionType.Equals(Game1.Side.Top) || (currentPipe.Top - currentRM.Bottom <= 5 && generalDetector.IsAlongSameYAxis(currentRM, currentPipe)))
                        {
                            itemIsSupported = true;
                        }
                    }
                    if (!(itemIsSupported))
                    {
                        gravityHandler.ApplyGravityToItem();
                    }
                    else
                    {
                        rm.SetGrounded();
                    }
                }

            }

            foreach (IItem gm in items)
            {
                if (gm is GreenMushroom)
                {
                    Rectangle currentGM = gm.GetRectangle();

                    foreach (IBlock block in blocks)
                    {
                        Rectangle currentBlock = block.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentBlock, currentGM);

                        MushroomBlockCollisionHandler.HandleCollision(gm, block, collisionType);
                    }

                    foreach (IPipe pipe in pipes)
                    {
                        Rectangle currentPipe = pipe.GetRectangle();
                        collisionType = generalDetector.DetermineCollision(currentPipe, currentGM);

                        MushroomPipeCollisionHandler.HandleCollision(gm, pipe, collisionType);
                    }
                }

            }
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

        public void CheckMarioCollisions(List<IPlayer> players, List<IItem> items, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            BlockCollisionDetector blockDetector = new BlockCollisionDetector();

            foreach (Mario mario in players)
            {
                Rectangle currentMario = mario.GetRectangle();
                MarioGravityHandler2 gravityHandler = new MarioGravityHandler2(mario);
                bool marioIsSupported = false;
                bool marioIsBlocked = false;
                foreach (IBlock block in blocks)
                {
                    Rectangle currentBlock = block.GetRectangle();
                    collisionType = blockDetector.DetermineCollision(currentMario, currentBlock);

                    if (collisionType.Equals(Game1.Side.Bottom) || (currentBlock.Top - currentMario.Bottom <= 4 && blockDetector.IsAlongSameYAxis(currentMario, currentBlock)))
                    {
                        marioIsSupported = true;
                    }
                    else if (collisionType.Equals(Game1.Side.Top))
                    {
                        marioIsBlocked = true;
                    }

                    if (block.HasItem() && collisionType.Equals(Game1.Side.Top))
                    {
                        IItem createdItem = block.ReleaseItem(mario.marioState);
                        if (items != null)
                        {
                            createdItem.SetCreatedFromBlock(true);
                            items.Add(createdItem);
                        }
                    }

                    MarioBlockCollisionHandler.HandleCollision(mario, block, collisionType);
                    BlockMarioCollisionHandler.HandleCollision(mario, block, collisionType);

                }

                foreach (Goomba goomba in goombas)
                {
                    Rectangle currentGoomba = goomba.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentMario, currentGoomba);
                    if (collisionType.Equals(Game1.Side.Bottom))
                    {
                        marioIsSupported = true;
                    }
                    MarioEnemyCollisionHandler.HandleCollision(mario, goomba, collisionType);

                }

                foreach (Koopa koopa in koopas)
                {
                    Rectangle currentKoopa = koopa.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentMario, currentKoopa);
                    if (collisionType.Equals(Game1.Side.Bottom))
                    {
                        marioIsSupported = true;
                    }
                    MarioEnemyCollisionHandler.HandleCollision(mario, koopa, collisionType);
                    if (collisionType.Equals(Game1.Side.Bottom))
                    {
                        IItem shell = koopa.CreateShell();
                        items.Add(shell);
                    }
                }

                foreach (IPipe pipe in pipes)
                {
                    Rectangle currentPipe = pipe.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentMario, currentPipe);
                    if (collisionType.Equals(Game1.Side.Bottom) || (currentPipe.Top - currentMario.Bottom <= 4 && generalDetector.IsAlongSameYAxis(currentMario, currentPipe)))
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

                    MarioItemCollisionHandler.HandleCollision(mario, item, collisionType);
                }

                if (!marioIsSupported)
                {
                    gravityHandler.ApplyGravityToMario();
                }

                else if (marioIsBlocked)
                {
                    mario.ManualMoveY(4);
                    mario.SetFalling();
                }
                else
                {
                    mario.SetGrounded();
                }
            }
        }

        public void CheckGoombaCollisions(List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();

            foreach (Goomba goomba in goombas)
            {
                EnemyGravityHandler gravityHandler = new EnemyGravityHandler(goomba);

                Rectangle currentGoomba = goomba.GetRectangle();
                bool goombaIsSupported = false;

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
                    gravityHandler.ApplyGravityToEnemy();
                }
                else
                {
                    goomba.SetGrounded();
                }

            }
        }

        public void CheckKoopaCollisions(List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas)
        {
            Game1.Side collisionType = Game1.Side.None;
            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();

            foreach (Koopa koopa in koopas)
            {
                Rectangle currentKoopa = koopa.GetRectangle();

                foreach (Goomba goomba in goombas)
                {
                    Rectangle currentGoomba = koopa.GetRectangle();
                    collisionType = generalDetector.DetermineCollision(currentKoopa, currentGoomba);
                    EnemyEnemyCollisionHandler.HandleCollision(goomba, koopa, collisionType);
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
