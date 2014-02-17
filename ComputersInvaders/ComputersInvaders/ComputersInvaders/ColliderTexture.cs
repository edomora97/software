using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ComputersInvaders
{
    public class ColliderTexture
    {
        public Texture2D Texture { get; private set; }
        protected Color[] texture_data;

        public ColliderTexture(Texture2D texture)
        {
            Texture = texture;
            texture_data = new Color[texture.Width * texture.Height];
            texture.GetData(texture_data);
        }

        public Rectangle GetRectangle(Vector2 position)
        {
            return new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }
        public bool Collides(Vector2 my_position, ColliderTexture other, Vector2 other_position)
        {
            return IntersectPixels(this.GetRectangle(my_position), texture_data, other.GetRectangle(other_position), other.texture_data);
        }
        static bool IntersectPixels(Rectangle rectangleA, Color[] dataA, Rectangle rectangleB, Color[] dataB)
        {
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color colorA = dataA[(x - rectangleA.Left) + (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) + (y - rectangleB.Top) * rectangleB.Width];
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
