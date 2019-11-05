using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GameOver
    {
        static TimeSpan Time { get; set; }
        static bool gameIsOver = false;
        static bool endGameNow = false;

        private static int xPos = Game1.graphics.PreferredBackBufferWidth / 2;
        private static int yPos = Game1.graphics.PreferredBackBufferHeight / 2;

        public static void Initalize()
        {
            endGameNow = false;
            gameIsOver = false;
        }

        public static void Blackout()
        {
            Game1.graphics.GraphicsDevice.Clear(Color.Black);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(TextureManager.marioFont, "GAME OVER", new Vector2(xPos - 60, yPos), Color.White);
        }

        public static void ResetTimer()
        {
            Time = new TimeSpan(0, 0, 3);
        }

        public static void ZeroTimer()
        {
            Time = new TimeSpan(0, 0, 0);
        }

        public static void EndGame()
        {
            endGameNow = true;
        }

        public static bool GameIsOver()
        {
            return gameIsOver;
        }

        public static void Update(GameTime gameTime)
        {
            Time = Time.Subtract(gameTime.ElapsedGameTime);

            if ((int)Time.TotalSeconds >= 0 && endGameNow)
            {
                gameIsOver = true;
                Game1.notPaused = false;
            }
            else
            {
                gameIsOver = false;
                Game1.notPaused = true;
            }
        }

    }

}
