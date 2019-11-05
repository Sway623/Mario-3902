using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public static class Display
    {
        private static int numCoins;
        public static int Score { get; set; }
        static TimeSpan Time { get; set; }

        static int pointsForACoin = 200;
        static int pointsForAnEnemy = 100;
        static ICoin coin;
            
        public static void Initalize()
        {
            Time = new TimeSpan(0, 0, 200);
            numCoins = 0;
            coin = new VisibleCoin(new Vector2(180, 30));
        }

        public static void UpdateNumCoins()
        {
            numCoins++;
            SoundManager.PlaySound(Game1.collectCoinSound);
            UpdateScore(pointsForACoin);
        }

        public static void UpdateKilledEnemy()
        {
            UpdateScore(pointsForAnEnemy);
        }

        public static void UpdateScore(int pointsToAdd)
        {
            if(pointsToAdd == 0)
            {
                Score = 0;
            }

            Score += pointsToAdd;
        }

        public static void AnimatePoints(int points)
        {

        }

        public static void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            spriteBatch.DrawString(TextureManager.marioFont, "MARIO", new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(TextureManager.marioFont, "" + Score, new Vector2(10, 30), Color.White);
            coin.Draw(spriteBatch, new Vector2(0, 0));
            spriteBatch.DrawString(TextureManager.marioFont, " x" + numCoins, new Vector2(200, 30), Color.White);
            spriteBatch.DrawString(TextureManager.marioFont, "WORLD", new Vector2(300, 10), Color.White);
            spriteBatch.DrawString(TextureManager.marioFont, "1-1", new Vector2(300, 30), Color.White);
            spriteBatch.DrawString(TextureManager.marioFont, "TIME", new Vector2(400, 10), Color.White);
            spriteBatch.DrawString(TextureManager.marioFont, "" +(int)(Time.TotalSeconds), new Vector2(400, 30), Color.White);
            if (Game1.jumpOnlyMode)
                spriteBatch.DrawString(TextureManager.marioFont, "Jump Only Mode", new Vector2(10, 75), Color.White);
        }

        public static void Update(GameTime gameTime)
        {
            coin.Update();

            Time = Time.Subtract(gameTime.ElapsedGameTime);

            if ((int)Time.TotalSeconds == 0) 
            {  
                // need to end the game if he runs out of time 
           
            }
        }


    }

}
