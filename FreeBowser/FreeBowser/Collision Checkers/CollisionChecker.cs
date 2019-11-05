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

        public void CheckEachCollision(List<IPlayer> players, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas, List<ICoin> coins, List<IItem> items, List<Fireball>projectiles)
        {
            CheckMarioCollisions(players, items, blocks, pipes, goombas, koopas);
            CheckGoombaCollisions(blocks, pipes, goombas, koopas);
            CheckKoopaCollisions(blocks, pipes, koopas);
            CheckFireballCollisions(blocks, pipes, goombas, koopas, projectiles);
            CheckMushroomCollisions(items, blocks, pipes);
            CheckStarCollisions(items, blocks, pipes);
            CheckBlockCollisions(blocks, players);
            CheckKoopaShellCollisions(items, goombas, koopas, blocks, pipes);
        }

        public void CheckStarCollisions(List<IItem> items, List<IBlock> blocks, List<IPipe> pipes)
        {
            StarCollisionChecker starChecker = new StarCollisionChecker();
            starChecker.CheckStarCollisions(items, blocks, pipes);
        }

        public void CheckMushroomCollisions(List<IItem>items, List<IBlock>blocks, List<IPipe> pipes)
        {
            MushroomCollisionChecker mushroomChecker = new MushroomCollisionChecker();
            mushroomChecker.CheckMushroomCollisions(items, blocks, pipes);

        }

        public void CheckFireballCollisions(List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas, List<Fireball>projectiles)
        {
            FireballCollisionChecker fireballChecker = new FireballCollisionChecker();
            fireballChecker.CheckFireballCollisions(blocks, pipes, goombas, koopas, projectiles);
        }

        public void CheckMarioCollisions(List<IPlayer> players, List<IItem> items, List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas)
        {
            MarioCollisionChecker marioChecker = new MarioCollisionChecker();
            marioChecker.CheckMariosCollisions(players, items, blocks, pipes, goombas, koopas);
        }
            

        public void CheckGoombaCollisions(List<IBlock> blocks, List<IPipe> pipes, List<IEnemy> goombas, List<IEnemy> koopas)
        {
            GoombaCollisionChecker goombaChecker = new GoombaCollisionChecker();
            goombaChecker.CheckGoombaCollisions(blocks, pipes, goombas, koopas);
        }

        public void CheckKoopaCollisions(List<IBlock> blocks, List<IPipe> pipes,  List<IEnemy> koopas)
        {
            KoopaCollisionChecker koopaChecker = new KoopaCollisionChecker();
            koopaChecker.CheckKoopaCollisions(blocks, pipes,  koopas);
        }

        public void CheckBlockCollisions(List<IBlock> blocks, List<IPlayer> players)
        {
            BlockCollisionChecker blockChecker = new BlockCollisionChecker();
            blockChecker.CheckBlockCollisions(blocks, players);
        }

        public void CheckKoopaShellCollisions(List<IItem> items, List<IEnemy> goombas, List<IEnemy> koopas, List<IBlock> blocks, List<IPipe> pipes)
        {
            KoopaShellCollisionChecker shellChecker = new KoopaShellCollisionChecker();
            shellChecker.CheckKoopaShellCollisions(items, goombas, koopas, blocks, pipes);
        }
    }
}
