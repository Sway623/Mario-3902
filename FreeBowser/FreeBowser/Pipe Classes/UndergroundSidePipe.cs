using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeBowser
{
    public class UndergroundSidePipe : IPipe
    {
        Rectangle sourceRectangle;
        int spriteHeight = 31;
        int spriteWidthTop = 34;

        Vector2 location;

        bool isWarpPipe;
        String filename;
        Vector2 spawnLoc;

        public UndergroundSidePipe(Vector2 initLocation, bool isWarp, String fn, Vector2 marioSpawn)
        {
            location = initLocation;
            filename = fn;
            Console.WriteLine(marioSpawn.X);
            Console.WriteLine(marioSpawn.Y);
            spawnLoc = marioSpawn;
            isWarpPipe = isWarp;
            sourceRectangle = new Rectangle(84, 417, spriteWidthTop, spriteHeight);
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

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), spriteWidthTop, spriteHeight);
            spriteBatch.Draw(TextureManager.pipeTexture, destinationRectangle, sourceRectangle, Color.White);
        }

        public bool IsWarp()
        {
            return isWarpPipe;
        }

        public string GetFileName()
        {
            return filename;
        }

        public Vector2 GetSpawnCoords()
        {
            return spawnLoc;
        }

        public Rectangle GetRectangle()
        {
            int givePixels = 0;
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidthTop, spriteHeight + givePixels);
            return currentRectangle;
        }

        public void Update()
        {
            
        }
    }
}
