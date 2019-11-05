using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class SmallPipe : IPipe
    {
        Rectangle sourceRectangle;
        int spriteHeight = 32;
        int spriteWidthTop = 32;
        //int spriteWidthBottom = 28;

        bool isWarpPipe;

        Vector2 location;
        String filename;
        Vector2 spawnLoc;

        public SmallPipe(Vector2 initLocation, bool isWarp, String fn, Vector2 marioSpawn)
        {
            location = initLocation;
            filename = fn;
            spawnLoc = marioSpawn;
            isWarpPipe = isWarp;
            sourceRectangle = new Rectangle(309, 417, spriteWidthTop, spriteHeight);
        }

        public void Update()
        {

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

        public bool IsWarp()
        {
            return isWarpPipe;
        }

        public String GetFileName()
        {
            return filename;
        }

        public Vector2 GetSpawnCoords()
        {
            return spawnLoc;
        }
        
        public Rectangle GetRectangle()
        {
            int givePixels = 10;
            Rectangle currentRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidthTop, spriteHeight + givePixels);
            return currentRectangle;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            Rectangle destinationRectangle = new Rectangle((int)(location.X - cameraPosition.X), (int)(location.Y - cameraPosition.Y), spriteHeight, spriteHeight);
            spriteBatch.Draw(TextureManager.pipeTexture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
