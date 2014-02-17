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
    /// Disegna e gestisce il menu principale del gioco
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Costruttore della classe Menu
        /// </summary>
        public Menu() 
        {
            VariabiliTemp.posizionePlayerMenu = new Vector2(15, 200);     
        }

        private int index = 0;
        private double sin, rad, deg;

        /// <summary>
        /// Gestisce l'input nel menu principale
        /// </summary>
        private void Input()
        {
            try
            {
                // Sposta il cursore verso l'alto e il basso
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Down) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Down) && index < Costanti.PULSANTI_MENU - 1)
                    index++;
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Up) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Up) && index > 0)
                    index--;
                // Se enter viene premuto
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Enter) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Enter))
                {
                    switch (index)
                    {
                        case 0: btnPlay(); break;
                        case 1: btnHight(); break;
                        case 2: btnExit(); break;
                        default: Helper.ShowFatalError(); break;
                    }
                }

                if (VariabiliGioco.mouseState.X >= 70 && VariabiliGioco.mouseState.X <= 70 + VariabiliGioco.tx_btnPlay.Width)
                    if (VariabiliGioco.mouseState.Y >= 160 && VariabiliGioco.mouseState.Y <= 160 + VariabiliGioco.tx_btnPlay.Height)
                        index = 0;

                if (VariabiliGioco.mouseState.X >= 70 && VariabiliGioco.mouseState.X <= 70 + VariabiliGioco.tx_btnHight.Width)
                    if (VariabiliGioco.mouseState.Y >= 200 && VariabiliGioco.mouseState.Y <= 200 + VariabiliGioco.tx_btnHight.Height)
                        index = 1;

                if (VariabiliGioco.mouseState.X >= 70 && VariabiliGioco.mouseState.X <= 70 + VariabiliGioco.tx_btnExit.Width)
                    if (VariabiliGioco.mouseState.Y >= 240 && VariabiliGioco.mouseState.Y <= 240 + VariabiliGioco.tx_btnExit.Height)
                        index = 2;

                if (VariabiliGioco.mouseState.LeftButton == ButtonState.Pressed && VariabiliGioco.mouseState_old.LeftButton == ButtonState.Released)
                {
                    if (Helper.IsMouseIn(new Rectangle(70, 160, VariabiliGioco.tx_btnPlay.Width, VariabiliGioco.tx_btnPlay.Height)))
                        btnPlay();
                    if (Helper.IsMouseIn(new Rectangle(70, 200, VariabiliGioco.tx_btnHight.Width, VariabiliGioco.tx_btnHight.Height)))
                        btnHight();
                    if (Helper.IsMouseIn(new Rectangle(70, 240, VariabiliGioco.tx_btnExit.Width, VariabiliGioco.tx_btnExit.Height)))
                        btnExit();
                }
                if (Helper.IsMouseIn(new Rectangle(5, 0, 15, 15)) && VariabiliGioco.mouseState.LeftButton == ButtonState.Pressed)
                    btnCredits();
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.F1) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.F1))
                    btnCredits();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Azione del pulsante Play
        /// </summary>
        private void btnPlay()
        {
            try
            {
                VariabiliGioco.loadData.Carica();
                VariabiliGioco.loadData.CaricaPosizioni();
                VariabiliTemp.posizionePlayer = Costanti.PLAYER_DEFAULT_POSITION;
                VariabiliGioco.isMenu = false;
                VariabiliGioco.isClassifica = false;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isGame = true;
                VariabiliTemp.gameOverTemp = true;
                VariabiliGioco.game.start = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Debug.WriteLine("Start: " + VariabiliGioco.game.start.ToString());
                Debug.WriteLine("Premuto play");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Azione del pulsante Hight
        /// </summary>
        private void btnHight()
        {
            try
            {
                // evita che la classifica esca entrando
                VariabiliTemp.classificaTemp = false;

                VariabiliGioco.isMenu = false;
                VariabiliGioco.isClassifica = true;
                VariabiliGioco.isGame = false;
                VariabiliGioco.isGameOver = false;
                Debug.WriteLine("Premuto high scores");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Azione del pulsante Exit
        /// </summary>
        private void btnExit()
        {
            try
            {
                Variabili.game.Exit();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Azione del pulsante ?
        /// </summary>
        private void btnCredits()
        {
            try
            {
                VariabiliGioco.isMenu = false;
                VariabiliGioco.isCredits = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Calcola la posizione del player nel menu
        /// </summary>
        /// <returns></returns>
        private Vector2 posizione()
        {
            try
            {
                deg += 1.2f;
                rad = Helper.DegToRad(deg);
                sin = Math.Sin(rad);
                if (rad > Math.PI)
                    deg = 0;
                Vector2 temp = VariabiliTemp.posizionePlayerMenu;
                temp.Y = temp.Y - ((float)sin * 100);
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return Vector2.Zero;
        }
        /// <summary>
        /// Disegna il menu principale e gestisce le funzioni
        /// </summary>
        /// <param name="gameTime"></param>
        public void Draw()
        {
            // Controlla l'input
            Input();
            try
            {
                Variabili.spriteBatch.Begin();
                // Disegna lo sfondo e il titolo del gioco                
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_sfondo_main, Vector2.Zero, Color.White);
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_titolo, new Vector2(40, 40), Color.White);

                // Seleziona quale pulsante evidenziare
                if (index == 0)
                {
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnPlay, new Vector2(70, 160), Color.OrangeRed);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnHight, new Vector2(70, 200), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnExit, new Vector2(70, 240), Color.White);
                }
                if (index == 1)
                {
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnPlay, new Vector2(70, 160), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnHight, new Vector2(70, 200), Color.OrangeRed);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnExit, new Vector2(70, 240), Color.White);
                }
                if (index == 2)
                {
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnPlay, new Vector2(70, 160), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnHight, new Vector2(70, 200), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnExit, new Vector2(70, 240), Color.OrangeRed);
                }
                                
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_blockNormale, new Vector2(10, 235), Color.White);
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_player, posizione(), Color.White);

                // Scrive la versione del programma
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, Helper.Versione(), new Vector2(150, 290), Color.LightGray);
                if (Helper.IsMouseIn(new Rectangle(5, 0, 15, 15)))
                    Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, "?", new Vector2(8, -4), Color.Red);
                else
                    Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, "?", new Vector2(8, -4), Color.LightGray);
                Variabili.spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
