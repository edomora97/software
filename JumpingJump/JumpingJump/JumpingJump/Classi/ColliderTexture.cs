using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per il controllo delle collizioni tra textures
    /// </summary>
    public class ColliderTexture
    {
        /// <summary>
        /// Costruttore della classe collider texture
        /// </summary>
        /// <param name="texture">Texture da controllare</param>
        public ColliderTexture(Texture2D texture)
        {
            try
            {
                Texture = texture;
                texture_data = new Color[texture.Width * texture.Height];
                texture.GetData(texture_data);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Ottiene la texture corrente
        /// </summary>
        public Texture2D Texture 
        { 
            get; 
            private set; 
        }
        /// <summary>
        /// Array di colori della texture
        /// </summary>
        protected Color[] texture_data;

        /// <summary>
        /// Ottiene un rettangolo nella posizione selezionata, delle dimensioni della texture
        /// </summary>
        /// <param name="position">Posizione del rettangolo</param>
        /// <returns></returns>
        private Rectangle GetRectangle(Vector2 position)
        {
            try
            {
                return new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
                return Rectangle.Empty;
            }
        }
        /// <summary>
        /// Verifica se due texture si intersecano
        /// </summary>
        /// <param name="position">Posizione della texture corrente</param>
        /// <param name="other_texture">ColliderTexture contenente una seconda texture</param>
        /// <param name="other_position">Posizione della seconda texture</param>
        /// <returns></returns>
        public bool Collides(Vector2 position, ColliderTexture other_texture, Vector2 other_position)
        {
            try
            {
                return IntersectPixels(this.GetRectangle(position), texture_data, other_texture.GetRectangle(other_position), other_texture.texture_data);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Verifica se due texture si intersecano
        /// </summary>
        /// <param name="rectangleA">Rettangolo della prima texture</param>
        /// <param name="dataA">Dati della prima texture</param>
        /// <param name="rectangleB">Rettangolo della seconda texture</param>
        /// <param name="dataB">Dati della seconda texture</param>
        /// <returns></returns>
        static bool IntersectPixels(Rectangle rectangleA, Color[] dataA, Rectangle rectangleB, Color[] dataB)
        {
            try
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

            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }

            return false;
        }
    }
}
