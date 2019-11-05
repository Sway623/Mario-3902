﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeBowser
{
    public class GeneralCollisionDetector : ICollision
    {
      

        public GeneralCollisionDetector()
        {
          
        }

        public FreeBowser.Game1.Side DetermineCollision(Rectangle referenceRectangle, Rectangle otherRectangle)
        {
            Rectangle area = Rectangle.Intersect(referenceRectangle, otherRectangle);
            Game1.Side collisionSide = Game1.Side.None;
            if (area.Height == 0 && area.Width == 0)
            {
                collisionSide = Game1.Side.None;
            }

            else if (area.Right > referenceRectangle.Left && area.Left <= referenceRectangle.Left && area.Bottom <= referenceRectangle.Bottom && area.Top >= referenceRectangle.Top)                   
            {
                collisionSide = Game1.Side.Left;

                if (otherRectangle.Right < ((referenceRectangle.Center.X + referenceRectangle.Left)/2.0))
                {
                    //if (!(area.Bottom >= referenceRectangle.Top && area.Top <= referenceRectangle.Top))

                        return collisionSide;
                }
            }
            else if (area.Left < referenceRectangle.Right && area.Right >= referenceRectangle.Right && (area.Bottom <= referenceRectangle.Bottom || area.Top >= referenceRectangle.Top) )              
            {
                collisionSide = Game1.Side.Right;

                if (otherRectangle.Left > ((referenceRectangle.Center.X + referenceRectangle.Right) / 2.0))
                {
                    //if (!(area.Bottom >= referenceRectangle.Top && area.Top <= referenceRectangle.Top))
                        return collisionSide;
                }
            }


            if (area.Bottom >= referenceRectangle.Top && area.Top == referenceRectangle.Top)//&& (area.Left >= ((referenceRectangle.Center.X + referenceRectangle.Right) / 2.0 )|| (area.Right <= ((referenceRectangle.Center.X + referenceRectangle.Left) / 2.0))))
            {
                if (collisionSide.Equals(Game1.Side.Left))
                {
                    if (!(referenceRectangle.Top <= otherRectangle.Top))//|| referenceRectangle.Bottom >= otherRectangle.Bottom))
                    {
                        collisionSide = Game1.Side.Top;
                    }
                }
                else if (collisionSide.Equals(Game1.Side.Right))
                {
                    if (!(referenceRectangle.Top <= otherRectangle.Top))//|| referenceRectangle.Bottom >= otherRectangle.Bottom))
                    {
                        collisionSide = Game1.Side.Top;
                    }
                }
                else
                {
                    collisionSide = Game1.Side.Top;
                }
            }

            else if (area.Top <= referenceRectangle.Bottom && area.Bottom == referenceRectangle.Bottom)
            {
                if (collisionSide.Equals(Game1.Side.Left))
                {
                    if (!(referenceRectangle.Bottom >= otherRectangle.Bottom))
                    {
                        collisionSide = Game1.Side.Bottom;
                    }
                }
                else if (collisionSide.Equals(Game1.Side.Right))
                {
                    if (!(referenceRectangle.Bottom >= otherRectangle.Bottom))
                    {
                        collisionSide = Game1.Side.Bottom;
                    }
                }
                else
                {
                    collisionSide = Game1.Side.Bottom;
                }

            }
            return collisionSide;
        }

        public bool IsAlongSameYAxis(Rectangle referenceRectangle, Rectangle otherRectangle)
        {
            bool isOnYAxis = false;

            double leftOfReference = referenceRectangle.Left;
            double rightOfReference = referenceRectangle.Right;
            double leftOfOther = otherRectangle.Left;
            double rightOfOther = otherRectangle.Right;
            double bottomOfReference = referenceRectangle.Bottom;
            double topOfOther = otherRectangle.Top;
            if (rightOfReference >= leftOfOther  && leftOfReference <= rightOfOther || leftOfReference < rightOfOther && rightOfReference >= leftOfOther || leftOfReference >= leftOfOther && rightOfReference <= rightOfOther)
            {
                if (bottomOfReference < topOfOther)
                isOnYAxis = true;
            }
            return isOnYAxis;

        }

        public double DistanceToNearestLowerSupport(Rectangle referenceRectangle, Rectangle otherRectangle)
        {
            double distance = 0;

            double bottomOfReference = referenceRectangle.Bottom;
            double topOfOther = otherRectangle.Top;


            return distance;
        }
    }
}
