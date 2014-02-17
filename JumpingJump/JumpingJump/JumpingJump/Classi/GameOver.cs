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
    /// Classe per il disegno e la gestione del GameOver
    /// </summary>
    public class GameOver
    {
        /// <summary>
        /// Costruttore della classe GameOver
        /// </summary>
        public GameOver() { }

        /// <summary>
        /// Posizione del pulsante selezionato
        /// </summary>
        private int index = 1;
        /// <summary>
        /// Indica il record delle partite
        /// </summary>
        private int _record = 0;

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
                        BtnMenu();
                    if (Helper.IsMouseIn(new Rectangle(40, 80, VariabiliGioco.tx_btnReset.Width, VariabiliGioco.tx_btnReset.Height)))
                        BtnRestart();
                }

                // Aggiunge il testo al nome
                string text = Helper.GetChar();
                if (text == "-BACK-" && VariabiliGioco.nome.Length > 0)
                    VariabiliGioco.nome = VariabiliGioco.nome.Remove(VariabiliGioco.nome.Length - 1);
                if (text != "-BACK-")
                    VariabiliGioco.nome += text;

                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Enter) && VariabiliGioco.keyboardState_old.IsKeyDown(Keys.Enter))
                {
                    // In base all'indice esegue l'azione specifica
                    switch (index)
                    {
                        case 0: BtnMenu(); break;
                        case 1: BtnRestart(); break;
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
        /// Ricomincia la partita. Utilizzo per il bottone "RESTART"
        /// </summary>
        private void BtnRestart()
        {
            try
            {
                if (VariabiliGioco.nome != "")
                {
                    VariabiliGioco.classifica.Add(VariabiliGioco.nome, VariabiliGioco.punteggio, VariabiliGioco.salti);
                    VariabiliGioco.salti = 0;
                }
                else
                {
                    VariabiliGioco.classifica.Add("Anonimo", VariabiliGioco.punteggio, VariabiliGioco.salti);
                    VariabiliGioco.salti = 0;
                }
                VariabiliGioco.classifica.Salva();
                // Riposiziona i blocchi
                VariabiliGioco.loadData.CaricaPosizioni();
                // Risposizione il player
                VariabiliTemp.posizionePlayer = Costanti.PLAYER_DEFAULT_POSITION;
                VariabiliGioco.punteggio = 0;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isGame = true;
                VariabiliTemp.gameOverTemp = true;
                VariabiliGioco.game.start = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Debug.WriteLine("Start: " + VariabiliGioco.game.start.ToString());
                Debug.WriteLine("Premuto Restart");
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
                VariabiliGioco.isMenu = true;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isGame = false;
                if (VariabiliGioco.nome != "")
                {
                    VariabiliGioco.classifica.Add(VariabiliGioco.nome, VariabiliGioco.punteggio, VariabiliGioco.salti);
                    VariabiliGioco.salti = 0;
                }
                else
                {
                    VariabiliGioco.classifica.Add("Anonimo", VariabiliGioco.punteggio, VariabiliGioco.salti);
                    VariabiliGioco.salti = 0;
                }
                VariabiliGioco.classifica.Salva();
                VariabiliGioco.punteggio = 0;
                VariabiliTemp.gameOverTemp = true;
                Debug.WriteLine("Premuto menu");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Ottiene il record
        /// </summary>
        /// <returns></returns>
        private int CheckRecord()
        {
            try
            {
                if (VariabiliTemp.gameOverTemp)
                {
                    // Ricerca il record
                    _record = VariabiliGioco.classifica.GetRecord().Punteggio;
                    // Imposta il record a punteggio se il punteggio attuale è maggiore del record
                    if (_record < VariabiliGioco.punteggio)
                        _record = VariabiliGioco.punteggio;
                    // Evita un loop
                    VariabiliTemp.gameOverTemp = false;
                }
                return _record;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return -1;
        }
        /// <summary>
        /// Disegna il menu di GameOver
        /// </summary>
        public void Draw()
        {
            try
            {
                Input();
                // Ottiene il record
                int record = CheckRecord();
                Variabili.spriteBatch.Begin();
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_sfondo_main, Vector2.Zero, Color.White);
                try
                {
                    if (index == 0)
                    {
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 20), Color.OrangeRed);
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnTryAgain, new Vector2(40, 80), Color.White);
                    }
                    if (index == 1)
                    {
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 20), Color.White);
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnTryAgain, new Vector2(40, 80), Color.OrangeRed);
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowFatalError("Errore D12: " + ex.Message);
                }
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, "Punteggio: " + VariabiliGioco.punteggio.ToString(), new Vector2(40, 160), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, "Record: " + record.ToString(), new Vector2(40, 180), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, "Nome: " + VariabiliGioco.nome, new Vector2(40, 200), Color.Black);
                Variabili.spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
