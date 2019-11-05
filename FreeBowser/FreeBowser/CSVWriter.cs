using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class CSVWriter
    {

        String path;
        String filename; 
        Vector4 extremes; 
        List<IBlock> blocks;
        List<IItem> items; 
        List<IEnemy> enemies;
        List<IPipe> pipes;
        List<IPlayer> players;

        public static Dictionary<Type, String> typeDict;

        public CSVWriter(String p, String fn, Vector4 max, List<IBlock> bs, List<IItem> its, List<IEnemy> es, List<IPipe> ps, List<IPlayer> plys)
        {
            path = p;
            filename = fn;
            extremes = max;
            blocks = bs;
            items = its;
            enemies = es;
            pipes = ps;
            players = plys;

            typeDict = new Dictionary<Type, String>();
            LevelUtility.InitializeTypeDict(typeDict);
        }

        public int FindOccurence(string s, char c, int occurence)
        {
            int currentOccurence = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    currentOccurence++;
                    if (currentOccurence == occurence)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public void Write()
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            System.IO.StreamWriter writer = new System.IO.StreamWriter(path + filename);

            //Extremes contains the values we need.
            int fileWidth = (int)(Math.Abs((extremes.X / 16.0f) - (extremes.Y / 16.0f)));
            int fileHeight = (int)((extremes.W - extremes.Z) / 16.0f);

            StringBuilder sb = new StringBuilder(2 * fileWidth + 2);

            for (int i = 0; i < fileWidth + 2; i++)
            {
                sb.Append("_,");
            }

            sb.Append("_");
            string emptycsvRow = sb.ToString();

            List<String> csvLines = Enumerable.Repeat(emptycsvRow, fileHeight + 2).ToList();

            foreach (IBlock block in blocks)
            {
                int xCoord = (int)(block.GetRectangle().X / 16.0f);
                int yCoord = (int)(block.GetRectangle().Y / 16.0f);

                if (yCoord > fileHeight)
                {
                    yCoord = fileHeight;
                }

                if (xCoord > fileWidth)
                {
                    xCoord = fileWidth;
                }

                String identifier = "";
                typeDict.TryGetValue(block.GetType(), out identifier);
                if (identifier != null)
                {
                    int endPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord % fileWidth + fileWidth) % fileWidth);
                    int startPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord - 1 % fileWidth + fileWidth) % fileWidth);

                    if (endPosition - startPosition == 2)
                    {
                        string firstPart = csvLines[yCoord].Substring(0, startPosition + 1);
                        string secondPart = csvLines[yCoord].Substring(endPosition, csvLines[yCoord].Length - endPosition);
                        csvLines[yCoord] = firstPart + identifier + secondPart;
                    }
                    
                }
            }

            foreach (IPipe pipe in pipes)
            {
                int xCoord = (int)(pipe.GetRectangle().X / 16.0f);
                int yCoord = (int)(pipe.GetRectangle().Y / 16.0f);

                if (yCoord > fileHeight)
                {
                    yCoord = fileHeight;
                }

                if (xCoord > fileWidth)
                {
                    xCoord = fileWidth;
                }

                String identifier = "";
                typeDict.TryGetValue(pipe.GetType(), out identifier);
                if (identifier != null)
                {
                    int endPosition = FindOccurence(csvLines[(yCoord%fileHeight + fileHeight) % fileHeight], ',', (xCoord%fileWidth + fileWidth) % fileWidth);
                    int startPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord - 1 % fileWidth + fileWidth) % fileWidth);

                    if (endPosition - startPosition == 2)
                    {
                        string firstPart = csvLines[yCoord].Substring(0, startPosition + 1);
                        string secondPart = csvLines[yCoord].Substring(endPosition, csvLines[yCoord].Length - endPosition);
                        csvLines[yCoord] = firstPart + identifier + secondPart;
                    }
                }
            }

            foreach (IEnemy enemy in enemies)
            {
                int xCoord = (int)(enemy.GetRectangle().X / 16.0f);
                int yCoord = (int)(enemy.GetRectangle().Y / 16.0f);

                if (yCoord > fileHeight)
                {
                    yCoord = fileHeight;
                }

                if (xCoord > fileWidth)
                {
                    xCoord = fileWidth;
                }

                String identifier = "";
                typeDict.TryGetValue(enemy.GetType(), out identifier);
                if (identifier != null)
                {
                    int endPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord % fileWidth + fileWidth) % fileWidth);
                    int startPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord - 1 % fileWidth + fileWidth) % fileWidth);

                    if (endPosition - startPosition == 2)
                    {
                        string firstPart = csvLines[yCoord].Substring(0, startPosition + 1);
                        string secondPart = csvLines[yCoord].Substring(endPosition, csvLines[yCoord].Length - endPosition);
                        csvLines[yCoord] = firstPart + identifier + secondPart;
                    }
                }
            }

            foreach (IItem item in items)
            {
                int xCoord = (int)(item.GetRectangle().X / 16.0f);
                int yCoord = (int)(item.GetRectangle().Y / 16.0f);

                if (yCoord > fileHeight)
                {
                    yCoord = fileHeight;
                }

                if (xCoord > fileWidth)
                {
                    xCoord = fileWidth;
                }

                String identifier = "";
                typeDict.TryGetValue(item.GetType(), out identifier);
                if (identifier != null)
                {
                    int endPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord % fileWidth + fileWidth) % fileWidth);
                    int startPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord - 1 % fileWidth + fileWidth) % fileWidth);

                    if (endPosition - startPosition == 2)
                    {
                        string firstPart = csvLines[yCoord].Substring(0, startPosition + 1);
                        string secondPart = csvLines[yCoord].Substring(endPosition, csvLines[yCoord].Length - endPosition);
                        csvLines[yCoord] = firstPart + identifier + secondPart;
                    }
                }
            }

            foreach (IPlayer player in players)
            {
                int xCoord = (int)(player.GetRectangle().X / 16);
                int yCoord = (int)(player.GetRectangle().Y / 16);

                if (yCoord > fileHeight){
                    yCoord = fileHeight;
                }

                if (xCoord > fileWidth)
                {
                    xCoord = fileWidth;
                }

                String identifier = "";
                typeDict.TryGetValue(player.GetType(), out identifier);
                if (identifier != null)
                {
                    int endPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord % fileWidth + fileWidth) % fileWidth);
                    int startPosition = FindOccurence(csvLines[(yCoord % fileHeight + fileHeight) % fileHeight], ',', (xCoord - 1 % fileWidth + fileWidth) % fileWidth);

                    if (endPosition - startPosition == 2)
                    {
                        string firstPart = csvLines[yCoord].Substring(0, startPosition + 1);
                        string secondPart = csvLines[yCoord].Substring(endPosition, csvLines[yCoord].Length - endPosition);
                        csvLines[yCoord] = firstPart + identifier + secondPart;
                    }
                }
            }

            foreach (string line in csvLines)
            {
                writer.WriteLine(line);
            }

            writer.Close();
        }
    }
}
