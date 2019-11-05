using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FreeBowser
{
    public class TextBox
    {
        Texture2D textBoxTexture;
        Rectangle textBox;
        StringBuilder sb;

        String fileExtension = "";
        String message;
        Vector2 messageCoordinates;
        Vector2 filenameCoordinates;
        String[] files;

        Dictionary<String, Rectangle> fileRects;

        int offset = 12;

        public TextBox(Vector2 textBoxCoords, String extn, String msg, Vector2 msgCoords, Vector2 fileCoords)
        {
            fileExtension = extn;
            message = msg;
            messageCoordinates = msgCoords;
            filenameCoordinates = fileCoords;
            textBox = new Rectangle((int)textBoxCoords.X, (int)textBoxCoords.Y, Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2);
            sb = new StringBuilder("");
        }

        public TextBox(Vector2 textBoxCoords, String[] f, String msg, Vector2 msgCoords, Vector2 fileCoords)
        {
            files = f;
            message = msg;
            messageCoordinates = msgCoords;
            filenameCoordinates = fileCoords;
            textBox = new Rectangle((int)textBoxCoords.X, (int)textBoxCoords.Y, Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2);
            sb = new StringBuilder("");
            fileRects = new Dictionary<string, Rectangle>();

            for (int i = 0; i < files.Length; i++)
            {
                int fileBeginIndex = files[i].LastIndexOf('\\');
                string filename = files[i].Substring(fileBeginIndex + 1);
                //Vector2 size = TextureManager.arialFont.MeasureString(filename);
                fileRects.Add(filename, new Rectangle((int)filenameCoordinates.X, (int)filenameCoordinates.Y + (offset * i), 100, 16));
                offset += 12;
            }

        }

        public void AppendLetter(String letter)
        {
            sb.Append(letter);
        }

        public void RemoveLastLetter()
        {
            sb.Remove(sb.Length - 1, 1);
        }

        public String GetText()
        {
            return sb.ToString();
        }

        public string CheckMultilineCollisions(MouseState mouseState)
        {

            int x = mouseState.X;
            int y = mouseState.Y;

            Rectangle mouseRect = new Rectangle(x, y, 1, 1);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int index = 0;
                foreach (KeyValuePair<String, Rectangle> entry in fileRects)
                {
                    if (mouseRect.Intersects(entry.Value))
                    {
                        //Mouse is on our rectangle.
                        //We need to return the filename and
                        return files[index];
                    }
                    index++;
                }
            }

            return @"";
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            spriteBatch.Draw(TextureManager.whiteTexture, textBox, Color.White);
            spriteBatch.DrawString(TextureManager.arialFont, message, messageCoordinates, Color.Black);
            if (!fileExtension.Equals(""))
            {
                spriteBatch.DrawString(TextureManager.arialFont, GetText() + fileExtension, filenameCoordinates, Color.Black);
            }
            else
            {
                foreach(KeyValuePair<String, Rectangle> entry in fileRects)
                {
                    int fileBeginIndex = entry.Key.LastIndexOf('\\');
                    spriteBatch.DrawString(TextureManager.arialFont, entry.Key, new Vector2(entry.Value.X, entry.Value.Y), Color.Black);
                    
                }
            }
            
        }
    }
}
