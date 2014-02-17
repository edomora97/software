using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per il disegno e la gestione del menu di pausa
    /// </summary>
    public class PauseMenu
    {
        /// <summary>
        /// Costruttore della classe PauseMenu
        /// </summary>
        public PauseMenu()
        { }

        /// <summary>
        /// Posizione del pulsante selezionato
        /// </summary>
        private int index = 0;

        /// <summary>
        /// Esegue il controllo dell'input
        /// </summary>
        private void Input()
        {
            try
            {
                // Sposta il cursore verso l'alto
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Up) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Up) && index > 0)
                    index--;
                // Sposta il cursore vesto il basso
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Down) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Down) && index < Costanti.PULSANTI_GAMEOVER - 1)
                    index++;

                if (VariabiliGioco.mouseState.X >= 40 && VariabiliGioco.mouseState.X <= 40 + VariabiliGioco.tx_btnMenu.Width)
                    if (VariabiliGioco.mouseState.Y >= 20 && VariabiliGioco.mouseState.Y <= 20 + VariabiliGioco.tx_btnMenu.Height)
                        index = 0;

                if (VariabiliGioco.mouseState.X >= 40 && VariabiliGioco.mouseState.X <= 40 + VariabiliGioco.tx_btnReset.Width)
                    if (VariabiliGioco.mouseState.Y >= 80 && VariabiliGioco.mouseState.Y <= 80 + VariabiliGioco.tx_btnReset.Height)
                        index = 1;

                if (VariabiliGioco.mouseState.LeftButton == ButtonState.Pressed && VariabiliGioco.mouseState_old.LeftButton == ButtonState.Released)
                {
                    if (Helper.IsMouseIn(new Rectangle(40, 20, VariabiliGioco.tx_btnMenu.Width, VariabiliGioco.tx_btnMenu.Height)))
                        BtnPlay();
                    if (Helper.IsMouseIn(new Rectangle(40, 80, VariabiliGioco.tx_btnReset.Width, VariabiliGioco.tx_btnReset.Height)))
                        BtnMenu();
                }
                                
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Enter) && VariabiliGioco.keyboardState_old.IsKeyDown(Keys.Enter))
                {
                    // In base all'indice esegue l'azione specifica
                    switch (index)
                    {
                        case 0: BtnPlay(); break;
                        case 1: BtnMenu(); break;
                        default: Helper.ShowFatalError(); break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Ricomincia la partita. Utilizzo per il bottone "PLAY"
        /// </summary>
        private void BtnPlay()
        {
            try
            {
                ResumeAll();
                Debug.WriteLine("Premuto Play");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Mostra il menu. Utilizzo con il bottone menu
        /// </summary>
        private void BtnMenu()
        {
            try
            {
                VariabiliGioco.game.end = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Debug.WriteLine("End: " + VariabiliGioco.game.end.ToString());
                TimeSpan total = VariabiliGioco.game.end - VariabiliGioco.game.start;
                Debug.WriteLine("Time: " + total.ToString());
                VariabiliTemp.totalGameTime = VariabiliTemp.totalGameTime + total;
                Debug.WriteLine("Total: " + VariabiliTemp.totalGameTime);
                GoToMenu();
                Debug.WriteLine("Premuto menu");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Mette in pausa il gioco
        /// </summary>
        public static void PauseAll()
        {
            try
            {
                VariabiliGioco.isPause = true;
                VariabiliGioco.isGame = false;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isMenu = false;
                VariabiliGioco.isClassifica = false;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Riprende il gioco
        /// </summary>
        public static void ResumeAll()
        {
            try
            {
                VariabiliGioco.isPause = false;
                VariabiliGioco.isGame = true;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isMenu = false;
                VariabiliGioco.isClassifica = false;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Ritorna al menu
        /// </summary>
        public static void GoToMenu()
        {
            try
            {
                VariabiliGioco.isPause = false;
                VariabiliGioco.isGame = false;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isMenu = true;
                VariabiliGioco.isClassifica = false;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna il menu di pausa
        /// </summary>
        public void Draw()
        {
            PauseAll();
            Input();
            try
            {
                Variabili.spriteBatch.Begin();
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_sfondo_main, Vector2.Zero, Color.White);
                try
                {
                    if (index == 0)
                    {
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnPlay, new Vector2(40, 20), Color.OrangeRed);
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 80), Color.White);
                    }
                    if (index == 1)
                    {
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnPlay, new Vector2(40, 20), Color.White);
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 80), Color.OrangeRed);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
                }
                Variabili.spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
