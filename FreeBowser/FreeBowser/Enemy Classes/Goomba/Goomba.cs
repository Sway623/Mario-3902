using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class Goomba : IEnemy
    {
        Vector2 location;

        Vector2 dimensions = new Vector2(16, 16);
        public IEnemyState goombaState;
        public ISprite goombaSprite;
        private bool isAlive = true;
        private double verticalVelocity;
        public bool stomped;
        int count = 0;
        int dx = 40;

        public Goomba(Vector2 initLocation)
        {
            location = initLocation;
            goombaState = new GoombaLeftMovingState(this);
            goombaSprite = new GoombaSprite();
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle;
            if (isAlive)
             currentRectangle = new Rectangle((int)location.X, (int)location.Y, (int)dimensions.X, (int)dimensions.Y);
            else
            {
                currentRectangle = new Rectangle(-1000, -1000, 0, 0);
            }
            return currentRectangle;
        }

        public void SetLocation(Vector2 coords)
        {
            location.X = coords.X;
            location.Y = coords.Y;
        }

        public void AdjustLocation(Vector2 coords)
        {
            location.X += coords.X;
            location.Y += coords.Y;
        }

        public void ChangeDirection()
        {
            goombaState.ChangeDirection();
        }

        public void BeStomped()
        {
            isAlive = false;
            SoundManager.PlaySound(Game1.stompSound);
            goombaState.BeStomped();
            stomped = true;
        }

        public void BeFlipped()
        {
            isAlive = false;
            SoundManager.PlaySound(Game1.stompSound);
            goombaState.BeFlipped();
        }

        public void BeKilled()
        {
            goombaState.BeKilled();
        }

        public void KillEnemy()
        {
            BeStomped();
            BeKilled();
        }

        public void moveX(int distance)
        {
             location.X += distance;
        }

        public void moveY()
        {
            location.Y += (int)verticalVelocity;
        }

        public double GetVerticalVelocity()
        {
            return verticalVelocity;
        }

        public void SetVerticalVelocity(double newVelocity)
        {
            verticalVelocity = newVelocity;
        }

        public void ManualMoveX(double displacement)
        {
            location.X += (int)displacement;

        }

        public void ManualMoveY(double displacement)
        {
            location.Y += (int)displacement;
        }

        public void SetGrounded()
        {
            verticalVelocity = 0;
        }

        public IEnemyState GetState()
        {
            return this.goombaState;
        }

        public void Update()
        {

            if (Game1.nightmare && count == 0 && isAlive == false)
            {
                //add the goomba back in about 20 paces behind mario - but they can't all be the same
                /*dx = (int)location.X;
                dx = dx % 10;
                 */
                dx = 100;
                location = WorldManager.spriteSet.players[0].GetLocation();
                location.X -= dx;
                count++;
                isAlive = true;
                this.goombaState = new NightmareState(this);
            }

            moveY();
            goombaSprite.Update();
            goombaState.Update();
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            goombaSprite.Draw(spriteBatch, location - cameraPosition);
        }


    }
}