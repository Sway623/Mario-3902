using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeBowser;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint3Tests
{
    [TestClass]
    public class Sprint3Tests
    {
        /* Mario on Block */

        [TestMethod]
        public void TestMarioOnLeftOfBlockCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(101, 100));
            FloorBlock block = new FloorBlock(new Vector2(120, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, blockRect);

            Assert.AreEqual(collisionType, Game1.Side.Right);
        }

        public void TestMarioOnLeftOfBlockCollisionHandling()
        {
            Mario mario = new Mario(new Vector2(101, 100));
            FloorBlock block = new FloorBlock(new Vector2(120, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            Game1.Side collisionType = Game1.Side.Right;
            MarioBlockCollisionHandler.HandleCollision(mario, block, collisionType);

            //Assert.AreEqual(102, mario.location.X);
        }

        [TestMethod]
        public void TestMarioOnRightOfBlockCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(110, 100));
            FloorBlock block = new FloorBlock(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, blockRect);

            Assert.AreEqual(collisionType, Game1.Side.Left);
        }

        [TestMethod]
        public void TestMarioOnRightOfBlockCollisionHandling()
        {
            Mario mario = new Mario(new Vector2(101, 100));
            FloorBlock block = new FloorBlock(new Vector2(120, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            Game1.Side collisionType = Game1.Side.Left;
            MarioBlockCollisionHandler.HandleCollision(mario, block, collisionType);

            //Assert.AreEqual(100, mario.location.X);
        }

        [TestMethod]
        public void TestMarioOnTopOfBlockCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(100, 100));
            FloorBlock block = new FloorBlock(new Vector2(100, 110));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, blockRect);

            Assert.AreEqual(collisionType, Game1.Side.Bottom);
        }

        [TestMethod]
        public void TestMarioOnTopOfBlockCollisionHandling()
        {
            Mario mario = new Mario(new Vector2(100, 110));
            FloorBlock block = new FloorBlock(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            Game1.Side collisionType = Game1.Side.Bottom;
            MarioBlockCollisionHandler.HandleCollision(mario, block, collisionType);

            //Assert.AreEqual(111, mario.location.Y);
        }

        [TestMethod]
        public void TestMarioOnBottomOfBlockCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(100, 110));
            FloorBlock block = new FloorBlock(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, blockRect);

            Assert.AreEqual(collisionType, Game1.Side.Top);
        }

        [TestMethod]
        public void TestMarioOnBottomOfBlockCollisionHandling()
        {
            Mario mario = new Mario(new Vector2(100, 110));
            FloorBlock block = new FloorBlock(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            Game1.Side collisionType = Game1.Side.Top;
            MarioBlockCollisionHandler.HandleCollision(mario, block, collisionType);

            //Assert.AreEqual(109, mario.location.Y);
        }

        /* Mario on Enemy */

        [TestMethod]
        public void TestMarioOnLeftOfEnemyCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(100, 100));
            Goomba enemy = new Goomba(new Vector2(115, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();

            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, enemyRect);
            Game1.Side expectedType = Game1.Side.Right;
            Assert.AreEqual(expectedType, collisionType);
        }

        [TestMethod]
        public void TestMarioOnLeftOfEnemyCollisionHandling()
        {
            Mario mario = new Mario(new Vector2(105, 100));
            Goomba enemy = new Goomba(new Vector2(115, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            Game1.Side collisionType = Game1.Side.Right;
            MarioEnemyCollisionHandler.HandleCollision(mario, enemy, collisionType);
            bool actualValue = mario.IsDying();
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestMarioOnRightOfEnemyCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(133, 100));
            Goomba enemy = new Goomba(new Vector2(115, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();

            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, enemyRect);
            Game1.Side expectedType = Game1.Side.Left;
            Assert.AreEqual(expectedType, collisionType);
        }

        [TestMethod]
        public void TestMarioOnRightOfEnemyCollisionHandling()
        {
            Mario mario = new Mario(new Vector2(130, 100));
            Goomba enemy = new Goomba(new Vector2(115, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            Game1.Side collisionType = Game1.Side.Left;
            MarioEnemyCollisionHandler.HandleCollision(mario, enemy, collisionType);
            bool actualValue = mario.IsDying();
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestMarioOnTopOfEnemyCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(100, 87));
            Goomba enemy = new Goomba(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();

            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, enemyRect);
            Game1.Side expectedType = Game1.Side.Bottom;
            Assert.AreEqual(expectedType, collisionType);
        }

        [TestMethod]
        public void TestMarioOnTopOfEnemyCollisionHandling()
        {

            Mario mario = new Mario(new Vector2(100, 83));
            Goomba enemy = new Goomba(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            Game1.Side collisionType = Game1.Side.Bottom;
            MarioEnemyCollisionHandler.HandleCollision(mario, enemy, collisionType);
            bool actualValue = mario.IsDying();
            bool expectedValue = false;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TestMarioOnBottomOfEnemyCollisionDetector()
        {
            Mario mario = new Mario(new Vector2(100, 115));
            Goomba enemy = new Goomba(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();

            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, enemyRect);
            Game1.Side expectedType = Game1.Side.Top;
            Assert.AreEqual(expectedType, collisionType);
        }

        [TestMethod]
        public void TestMarioOnBottomOfEnemyCollisionHandling()
        {
            Mario mario = new Mario(new Vector2(100, 115));
            Goomba enemy = new Goomba(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle enemyRect = enemy.GetRectangle();

            Game1.Side collisionType = Game1.Side.Top;
            MarioEnemyCollisionHandler.HandleCollision(mario, enemy, collisionType);
            bool actualValue = mario.IsDying();
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        /* Mario on Item */

        [TestMethod]
        public void TestMarioOnLeftOfItemCollision()
        {
            Mario mario = new Mario(new Vector2(101, 100));
            FireFlower flower = new FireFlower(new Vector2(120, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle flowerRect = flower.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, flowerRect);

            Assert.AreEqual(collisionType, Game1.Side.Right);
        }

        [TestMethod]
        public void TestMarioOnRightOfItemCollision()
        {
            Mario mario = new Mario(new Vector2(120, 100));
            RedMushroom redMushroom = new RedMushroom(new Vector2(105, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle redMushroomRect = redMushroom.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, redMushroomRect);

            Assert.AreEqual(collisionType, Game1.Side.Left);
        }

        [TestMethod]
        public void TestMarioOnTopOfItemCollision()
        {
            Mario mario = new Mario(new Vector2(100, 86));
            RedMushroom redMushroom = new RedMushroom(new Vector2(100, 100));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle redMushroomRect = redMushroom.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, redMushroomRect);

            Assert.AreEqual(collisionType, Game1.Side.Bottom);
        }

        [TestMethod]
        public void TestMarioOnBottomOfItemCollision()
        {
            Mario mario = new Mario(new Vector2(100, 100));
            FireFlower flower = new FireFlower(new Vector2(100, 86));

            Rectangle marioRect = mario.GetRectangle();
            Rectangle flowerRect = flower.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(marioRect, flowerRect);

            Assert.AreEqual(collisionType, Game1.Side.Top);
        }

        /* Enemy on Block */

        [TestMethod]
        public void TestEnemyOnRightOfBlockCollisionDetector()
        {
            Goomba enemy = new Goomba(new Vector2(110, 100));
            FloorBlock block = new FloorBlock(new Vector2(100, 100));

            Rectangle enemyRect = enemy.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(enemyRect, blockRect);

            Assert.AreEqual(collisionType, Game1.Side.Left);
        }

        [TestMethod]
        public void TestEnemyOnRightOfBlockCollisionHandling()
        {
            IEnemy enemy = new Goomba(new Vector2(110, 100));
            Goomba staticEnemy = new Goomba(new Vector2(100, 100));
            FloorBlock block = new FloorBlock(new Vector2(100, 100));

            Rectangle enemyRect = enemy.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            Game1.Side collisionType = Game1.Side.Left;
            EnemyBlockCollisionHandler.HandleCollision(enemy, block, collisionType);

            IEnemyState enemyState = enemy.GetState();
            IEnemyState expectedState = new GoombaLeftMovingState(staticEnemy);

            Assert.AreEqual(enemyState.ToString(), expectedState.ToString());
        }

        [TestMethod]
        public void TestEnemyOnLeftOfBlockCollisionDetection()
        {
            Goomba enemy = new Goomba(new Vector2(100, 100));
            FloorBlock block = new FloorBlock(new Vector2(120, 100));

            Rectangle enemyRect = enemy.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            GeneralCollisionDetector generalDetector = new GeneralCollisionDetector();
            Game1.Side collisionType = generalDetector.DetermineCollision(enemyRect, blockRect);

            Assert.AreEqual(collisionType, Game1.Side.Right);
        }

        [TestMethod]
        public void TestEnemyOnLeftOfBlockCollisionHandling()
        {
            IEnemy enemy = new Goomba(new Vector2(100, 100));
            Goomba staticEnemy = new Goomba(new Vector2(100, 100));
;           FloorBlock block = new FloorBlock(new Vector2(110, 100));

            Rectangle enemyRect = enemy.GetRectangle();
            Rectangle blockRect = block.GetRectangle();

            Game1.Side collisionType = Game1.Side.Right;
            EnemyBlockCollisionHandler.HandleCollision(enemy, block, collisionType);

            IEnemyState enemyState = enemy.GetState();
            IEnemyState expectedState = new GoombaLeftMovingState(staticEnemy);

            Console.Write(enemyState.ToString());
            Assert.AreEqual(enemyState.ToString(), expectedState.ToString());
        }


    }
}