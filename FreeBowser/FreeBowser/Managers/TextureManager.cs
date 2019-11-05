using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace FreeBowser
{
    public static class TextureManager
    {
        public static SpriteFont arialFont;
        public static Texture2D marioSpriteTexture;
        public static Texture2D marioPowerupChangeTexture;
        public static Texture2D itemTexture;
        public static Texture2D blockTexture;
        public static Texture2D pipeTexture;
        public static Texture2D miscTexture;
        public static Texture2D enemyTexture;
        public static SpriteFont marioFont;
        public static SpriteFont marioSmallFont;
        public static Texture2D flippedGoombaTexture;

        public static Texture2D whiteTexture;

        public static void LoadContent(Game1 game)
        {
            arialFont = game.Content.Load<SpriteFont>("Arial"); 
            marioFont = game.Content.Load<SpriteFont>("pressstart");
            marioPowerupChangeTexture = game.Content.Load<Texture2D>("mario-luigi");
            marioSmallFont = game.Content.Load<SpriteFont>("pressstartsmall");
            marioSpriteTexture = game.Content.Load<Texture2D>("mario");
            itemTexture = game.Content.Load<Texture2D>("misc-6");
            blockTexture = game.Content.Load<Texture2D>("tiles-2");
            miscTexture = game.Content.Load<Texture2D>("misc-3");
            pipeTexture = game.Content.Load<Texture2D>("misc-2");
            enemyTexture = game.Content.Load<Texture2D>("smb_enemies_sheet");
            whiteTexture = game.Content.Load<Texture2D>("white_pixel");
        }
    }
}
