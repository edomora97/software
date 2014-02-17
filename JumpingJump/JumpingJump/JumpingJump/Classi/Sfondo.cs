using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per il disegno dello sfondo animato nel gioco
    /// </summary>
    public class Sfondo
    {
        /// <summary>
        /// Costruttore standard
        /// </summary>
        public Sfondo()
        {
            try
            {
                posStella = new Vector2(-30, -30);
                rotation = 0;
                spriteBatch = Variabili.spriteBatch;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        private Vector2 posStella;
        private Vector2 destination;
        private double rotation;
        private SpriteBatch spriteBatch;
        private bool isMouve;
        private bool isRight;
        private float rappXY;

        /// <summary>
        /// Disegna lo sfondo
        /// </summary>
        public void Draw()
        {
            try
            {
                CalcDestination();
                CalcPosizione();
                spriteBatch.Begin();
                spriteBatch.Draw(VariabiliGioco.tx_sfondo_game, Vector2.Zero, Color.White);
                if (isRight)
                    spriteBatch.Draw(VariabiliGioco.tx_stella, posStella, null, Color.White, (float)Helper.DegToRad(rotation), Vector2.Zero, 0.2f, SpriteEffects.None, 0);
                else
                    spriteBatch.Draw(VariabiliGioco.tx_stella, new Vector2(320 - posStella.X, posStella.Y), null, Color.White, (float)Helper.DegToRad(rotation - 90), Vector2.Zero, 0.2f, SpriteEffects.FlipHorizontally, 0);
                spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Calcola la destinazione dell'asteroide
        /// </summary>
        private void CalcDestination()
        {
            try
            {
                if (!isMouve)
                {
                    int randX = Variabili.random.Next(50, 290);
                    int randY = Variabili.random.Next(50, 370);
                    destination = new Vector2(randX, randY);
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Calcola la posizione dell'asteroide
        /// </summary>
        private void CalcPosizione()
        {
            try
            {
                // Controlla l'inizializzazione della discesa del blocco
                int rand = Variabili.random.Next(1000);
                // Probabilità 1%
                if (!isMouve)
                {
                    if (rand < 5f)
                    {
                        isMouve = true;
                        if (rand % 2 == 0)
                            isRight = true;
                        else
                            isRight = false;
                    }
                }

                if (isMouve)
                {
                    rappXY = destination.Y / destination.X;
                    rotation = Helper.RadToDeg(Math.Acos(destination.X / Helper.Pitagora(destination.X, destination.Y)));
                    posStella.X += Costanti.VELOCTA_ASTEROIDE;
                    posStella.Y = posStella.X * rappXY;
                }

                if (posStella.X > 250 && posStella.Y > 330)
                {
                    isMouve = false;
                    posStella = new Vector2(-30, -30);
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
