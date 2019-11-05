using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class RemainingLives
    {
        static TimeSpan Time { get; set; }
        static bool showScreen = false;

        private static int xPos = (Game1.graphics.PreferredBackBufferWidth / 2) - 40;
        private static int yPos = Game1.graphics.PreferredBackBufferHeight / 2;

        static Rectangle sourceRectangle = new Rectangle(211, 0, 17, 16);

        static Rectangle destinationRectangle = new Rectangle(xPos, yPos, 17, 16);

        public static void Initalize()
        {
            showScreen = false;
        }

        public static void Blackout()
        {
            Game1.graphics.GraphicsDevice.Clear(Color.Black);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(TextureManager.marioFont, " x" + WorldManager.spriteSet.players[0].GetLives(), new Vector2(xPos + 60, yPos), Color.White);
            spriteBatch.Draw(TextureManager.marioSpriteTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public static void ResetTimer()
        {
            Time = new TimeSpan(0, 0, 2);
        }

        public static void ZeroTimer()
        {
            Time = new TimeSpan(0, 0, 0);
        }

        public static bool ShowScreen()
        {
            return showScreen;
        }

        public static void Update(GameTime gameTime)
        {
            Time = Time.Subtract(gameTime.ElapsedGameTime);

            if ((int)Time.TotalSeconds >= 0)
            {
                showScreen = true;
                Game1.notPaused = false;
            }
            else
            {
                showScreen = false;
                Game1.notPaused = true;
            }
        }

    }

}
