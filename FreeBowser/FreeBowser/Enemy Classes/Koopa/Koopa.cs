using FreeBowser.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class Koopa : IEnemy
    {
        Vector2 location;
        Vector2 dimensions = new Vector2(16, 20);
        public IEnemyState koopaState;
        public ISprite koopaSprite;
        public enum KoopaHealth { Normal, Stomped, Kicked, Dead };
        private KoopaHealth koopaHealth;
        double verticalVelocity;
        int count = 0;
        bool isAlive = true;
        Vector2 newLocation;
        bool hasCreatedShell;

        public Koopa(Vector2 initLocation)
        {
            location = initLocation;
            koopaHealth = KoopaHealth.Normal;
            koopaState = new KoopaLeftMovingState(this);
            koopaSprite = new KoopaLeftMovingSprite();
        }

        public Rectangle GetRectangle()
        {
            Rectangle currentRectangle;
            if (koopaHealth.Equals(KoopaHealth.Normal))
            {
               currentRectangle = new Rectangle((int)location.X, (int)location.Y, (int)dimensions.X, (int)dimensions.Y);
            }
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
            koopaState.ChangeDirection();
        }

        public void BeStomped()
        {
            koopaHealth = KoopaHealth.Stomped;
            isAlive = false;
            koopaState.BeStomped();
        }

        public void BeFlipped()
        {
            koopaState.BeFlipped();
            isAlive = false;
        }
        
        public void BeKilled()
        {
            koopaState.BeKilled();
        }

        public void KillEnemy()
        {
            BeStomped();
            BeKilled();
        }

        public IItem CreateShell()
        {
            if (!hasCreatedShell)
            {
                int verticalShellDisplacement = 18;
                Vector2 shellLocation = new Vector2(location.X, location.Y + verticalShellDisplacement);
                KoopaShell shell = new KoopaShell(shellLocation);
                hasCreatedShell = true;
                return shell;
            }
            else
            {
                return null;
            }
        }

        public void moveY()
        {
            location.Y += (int)verticalVelocity;
        }

        public void ManualMoveX(double displacement)
        {
            location.X += (int)displacement;

        }

        public void ManualMoveY(double displacement)
        {
            location.Y += (int)displacement;
        }
        public double GetVerticalVelocity()
        {
            return verticalVelocity;
        }

        public void SetVerticalVelocity(double newVelocity)
        {
            verticalVelocity = newVelocity;
        }

        public void BeKicked()
        {
         //   koopaState.BeKicked();
        }

        public void getKilled()
        {

        }

        public KoopaHealth GetKoopaHealth()
        {
            return this.koopaHealth;
        }

        public void SetKoopaHealth(KoopaHealth kh)
        {
            this.koopaHealth = kh;
        }

        public void moveX(int distance)
        {
            location.X += distance;
        }

        public IEnemyState GetState()
        {
            return this.koopaState;
        }

        public void Update()
        {
            if (Game1.nightmare && count == 0 && isAlive == false)
            {
                int dx = 100;
                newLocation = WorldManager.spriteSet.players[0].GetLocation();
                location.X = newLocation.X;
                location.X -= dx;
                count++;
                this.koopaHealth = KoopaHealth.Normal;
                this.koopaState = new KoopaNightmareState(this);
            }

            koopaSprite.Update();
            koopaState.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
                koopaSprite.Draw(spriteBatch, location - cameraPosition);
        }
     }
}
