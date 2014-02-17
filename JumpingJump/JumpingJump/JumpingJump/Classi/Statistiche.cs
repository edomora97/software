using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Classi
{
    public class Statistiche
    {
        /// <summary>
        /// Costruttore della classe statistiche
        /// </summary>
        public Statistiche() { }
        
        /// <summary>
        /// Gestisce l'input da tastiera o da mouse
        /// </summary>
        private void Input()
        {
            try
            {
                if (VariabiliTemp.statisticheTemp)
                {
                    if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Enter) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Enter))
                        BtnMenu();
                    if (Helper.IsMouseIn(new Rectangle(40, 200, VariabiliGioco.tx_btnMenu.Width, VariabiliGioco.tx_btnMenu.Height)) && VariabiliGioco.mouseState.LeftButton == ButtonState.Pressed)
                        BtnMenu();
                }
                VariabiliTemp.statisticheTemp = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Torna al menu. Uso per bottone "MENU"
        /// </summary>
        private void BtnMenu()
        {
            try
            {
                VariabiliGioco.isStatistiche = false;
                VariabiliGioco.isMenu = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna il menu statistiche
        /// </summary>
        public void Draw()
        {
            try
            {
                Input();

                SpriteBatch spriteBatch = Variabili.spriteBatch;
                spriteBatch.Begin();
                spriteBatch.Draw(VariabiliGioco.tx_sfondo_main, Vector2.Zero, Color.White);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Salti totali: " + VariabiliTemp.totalJump, new Vector2(20, 20), Color.Blue);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Partite giocate: " + VariabiliTemp.totalGame, new Vector2(20, 40), Color.Blue);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Punti totali: " + VariabiliTemp.totalScore, new Vector2(20, 60), Color.Blue);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Salti medi: " + VariabiliTemp.avarangeJump, new Vector2(20, 80), Color.Blue);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Punti medi: " + VariabiliTemp.avarangeScore, new Vector2(20, 100), Color.Blue);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Ultimi salti: " + VariabiliTemp.lastJump, new Vector2(20, 120), Color.Blue);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Ultimi punti: " + VariabiliTemp.lastScore, new Vector2(20, 140), Color.Blue);
                spriteBatch.DrawString(Variabili.FontStatistiche, "Tempo di gioco: " + Helper.TimeSpanToString(VariabiliTemp.totalGameTime), new Vector2(20, 160), Color.Blue);
                spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 200), Color.OrangeRed);
                spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
