using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class CameraController
    {
        Vector2 position;
        int height;
        int width;

        private Game1 game;

        public CameraController(Game1 myGame, Vector2 initPosition, int initHeight, int initWidth)
        {
            game = myGame;
            position = initPosition;
            height = initHeight;
            width = initWidth;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public int GetWidth()
        {
            return width;
        }

        public void MoveLeft()
        {

        }

        public void ManualMoveLeft()
        {
            position.X -= 1;
        }

        public void MoveRight()
        {
            position.X += WorldManager.spriteSet.players[0].GetVelo();
        }

        public void ManualMoveRight()
        {
            position.X += 1;
        }

        public void MoveUp()
        {
            position.Y -= (float) WorldManager.spriteSet.players[0].GetVerticalVelocity();
        }

        public void ManualMoveUp()
        {
            position.Y -= 1;
        }

        public void MoveDown()
        {
            position.Y += (float)WorldManager.spriteSet.players[0].GetVerticalVelocity();
        }

        public void ManualMoveDown()
        {
            position.Y += 1;
        }

        public void IncreaseWidth()
        {

        }

        public void DecreaseWidth()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            Rectangle marioRect = WorldManager.spriteSet.players[0].GetRectangle();

            int xLocation = (int)(marioRect.Location.X);
            int yLocation = (int)(marioRect.Location.Y);

            //If last move was right
            if (xLocation > (int)(2 * (width) / 3) + position.X)
            {
                MoveRight();
            }

            if (yLocation < (int)((height) / 3) - position.Y)
            {
                MoveDown();
            }
            else if ((yLocation > (int)(2*(height) / 3) - position.Y) && position.Y < 0)
            {
                MoveUp();
            }

        }
    }
}
