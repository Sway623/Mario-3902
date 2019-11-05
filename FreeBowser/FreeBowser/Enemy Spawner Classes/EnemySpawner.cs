using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class EnemySpawner
    {
        int counter = 0;
        int dx = 30;
        int dy = 30;

        Random rand = new Random();

        

        public EnemySpawner()
        {

        }


        public void Update()
        {
            Vector2 location = WorldManager.spriteSet.players[0].GetLocation();

            dx = rand.Next(40, 50);
            dy = rand.Next(5, 30);

            location.X += dx;
            location.Y -= dy;

            if (counter % 100 == 0)
            {
                WorldManager.spriteSet.goombas.Add(new Goomba(location));
            }
            else if (counter % 150 == 0)
            {
                WorldManager.spriteSet.koopas.Add(new Koopa(location));
            }

            Console.WriteLine(dx);

            counter++;


            
        }

        public void Draw()
        {

        }
    }
}
