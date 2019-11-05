using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;


namespace FreeBowser
{
    public class ActionText
    {

        String text;
        Vector2 location;
        Rectangle destinationRect;

        public ActionText(String option, Vector2 position, Vector2 size)
        {
            //An actiontext will have coordinates, a size, and a font. It will return the option to cycle to.
            text = option;
            location = position;
            destinationRect = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
        }

        public String GetOption()
        {
            return text;
        }

        public Rectangle GetRectangle()
        {
            return destinationRect;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(TextureManager.marioFont, text, location, Color.White);
        }

    }
}
