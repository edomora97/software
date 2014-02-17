using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Classe che gestisce il gioco: i salti, il punteggio e la GODMODE
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Costruttore che inizializza la classe jump
        /// </summary>
        public Game()
        {
            try
            {
                VariabiliTemp.posizioneSfondo1 = Vector2.Zero;
                VariabiliTemp.posizioni = new List<Posizione>();
                // Ripristina la posizione dei blocchi
                //LoadData.Carica();
                //VariabiliTemp.posizionePlayer = new Vector2(Variabili.graphics.PreferredBackBufferWidth / 2 - (VariabiliGioco.tx_player.Width / 2), VariabiliTemp.posizioni[0].Y - VariabiliGioco.tx_player.Height);
                VariabiliTemp.posizionePlayer = new Vector2(120, 200);
                //VariabiliTemp.posizioni_now = VariabiliTemp.posizioni;
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore B01: " + ex.Message);
            }
        }

        /// <summary>
        /// Orario di inozio o di fine della partita
        /// </summary>
        public TimeSpan start, end;
        /// <summary>
        /// Indica se il player sta saltando o volando
        /// </summary>
        public bool canJump = true;
        
        /// <summary>
        /// Funzione di SenoParabola
        /// </summary>
        private void SenoParabola()
        {
            try
            {
                // Prima parte della funzione: 1/4 di seno
                if (VariabiliTemp.isSin && canJump)
                {
                    // Velocità angolare
                    VariabiliTemp.deg += Costanti.VELOCITA_ANGOLARE_PLAYER_Y;
                    VariabiliTemp.rad = Helper.DegToRad(VariabiliTemp.deg);
                    // Coseno dell'angolo
                    VariabiliTemp.cos = Math.Cos(VariabiliTemp.rad);
                    // Il seno non deve essere negativo
                    if (VariabiliTemp.cos < 0)
                        VariabiliTemp.cos *= -1;
                    // Applica la formula alla posizione del player
                    VariabiliTemp.JumpHeight = (float)VariabiliTemp.cos * Costanti.ALTEZZA_SALTO;
                    if (VariabiliTemp.isJumping)
                        VariabiliTemp.posizionePlayer.Y -= VariabiliTemp.JumpHeight / 1.3f;
                }
                // Seconda parte della funzione: parabola verso il basso
                if (!VariabiliTemp.isSin && canJump)
                {
                    // Genera una parabola e somma alla posizione Y del player
                    VariabiliTemp.inc += 0.04f;
                    VariabiliTemp.posizionePlayer.Y += VariabiliTemp.inc;
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }

            try
            {
                // Effettua la selezione tra la prima e la seconda parte della funzione
                if (VariabiliTemp.rad > Math.PI / 2)
                {
                    VariabiliTemp.isSin = false;
                    VariabiliTemp.inc = 0;
                    VariabiliTemp.deg = 0;
                    VariabiliTemp.rad = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Gestisce l'input dalla tastiera
        /// </summary>
        private void Input()
        {
            try
            {
                // Muove il personaggio vesro destra
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Right))
                {
                    VariabiliTemp.isRight = true;
                    VariabiliTemp.posizionePlayer.X += Costanti.VELOCITA_PLAYER_X;
                }

                // Muove il personaggio verso sinistra
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Left))
                {
                    VariabiliTemp.isRight = false;
                    VariabiliTemp.posizionePlayer.X -= Costanti.VELOCITA_PLAYER_X;
                }
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Up))
                    VariabiliTemp.posizionePlayer.Y--;
                // Mette il gioco in pausa
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Escape) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Escape) && !VariabiliGioco.godMode)
                    VariabiliGioco.isPause = true;

                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Space) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Space))
                    Fire();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }

            try
            {
                // Trasporta il personaggio da una parte all'altra dello schermo
                if (VariabiliTemp.posizionePlayer.X + VariabiliGioco.tx_player.Width < 0)
                    VariabiliTemp.posizionePlayer.X = 240;
                if (VariabiliTemp.posizionePlayer.X > 240)
                    VariabiliTemp.posizionePlayer.X = 0 - VariabiliGioco.tx_player.Width;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }

        }
        /// <summary>
        /// Effettua lo sparo sul nemico più vicino
        /// </summary>       
        private void Fire()
        {
            try
            {
                int index = 999;
                float minDistance = 320;

                for (int i = 0; i < VariabiliTemp.nemici.Count; i++)
                {
                    float currDistan = Vector2.Distance(VariabiliTemp.posizionePlayer, VariabiliTemp.nemici[i].PosizioneAttuale);
                    if (currDistan < minDistance)
                    {
                        index = i;
                        minDistance = currDistan;
                    }
                }
                if (index < VariabiliTemp.nemici.Count)
                    VariabiliTemp.nemici[index].Fire(VariabiliTemp.posizionePlayer);
                else
                {
                    Nemico.NullFire(VariabiliTemp.posizionePlayer);
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Metodo che fa saltare il player se va a contatto con un blocco
        /// </summary>
        private void CheckJump()
        {
            try
            {
                #region METODO VECCHIO
                //// Effettua il controllo su ogni blocco
                //for (int i = 0; i < VariabiliTemp.posizioni.Count; i++)
                //{
                //    // Se rispetta tutte le seguenti condizioni
                //    if (VariabiliTemp.posizioni[i].Tipo != Tipo.Falso &&
                //        (VariabiliTemp.posizioni[i].X < VariabiliTemp.posizionePlayer.X + VariabiliGioco.tx_player.Width - 10 &&
                //        VariabiliTemp.posizionePlayer.X < VariabiliTemp.posizioni[i].X + VariabiliGioco.tx_player.Width) &&
                //        (int)VariabiliTemp.posizionePlayer.Y > VariabiliTemp.posizioni[i].Y - 10 &&
                //        (int)VariabiliTemp.posizionePlayer.Y < VariabiliTemp.posizioni[i].Y + 10 &&
                //        VariabiliTemp.rad < Math.PI / 2 &&
                //        !VariabiliTemp.isSin)
                //    {
                //        // Incrementa i salti totali
                //        VariabiliGioco.salti++;
                //        VariabiliTemp.isSin = true;
                //        VariabiliTemp.inv = VariabiliTemp.posizioni[i].Y + VariabiliTemp.jumpHeight;
                //        VariabiliTemp.posizioni[i].Jump++;
                //    }
                //}
                #endregion

                if (VariabiliTemp.currBonus == null)
                    foreach (Posizione posizione in VariabiliTemp.posizioni)
                    {
                        if (posizione.Bonus != null)
                        {
                            posizione.Bonus.CheckFly();
                        }
                    }
                if (VariabiliTemp.currBonus != null)
                    canJump = false;
                else
                    canJump = true;

                if (canJump)
                {
                    for (int i = 0; i < VariabiliTemp.posizioni.Count; i++)
                    {
                        if (VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Falso && VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Nemico1 && VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Nemico2 && VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Nemico3 && VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Nemico4 &&
                            VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Nemico5 && VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Nemico6 && VariabiliTemp.posizioni[i].Tipo != TipoPosizione.Nemico7)
                        {
                            if (VariabiliTemp.posizionePlayer.X + VariabiliGioco.tx_player.Width - 15 > VariabiliTemp.posizioni[i].PosizioneAttuale.X && VariabiliTemp.posizionePlayer.X + 15 < VariabiliTemp.posizioni[i].PosizioneAttuale.X + VariabiliGioco.tx_blockNormale.Width)
                            {
                                if (VariabiliTemp.posizionePlayer.Y + VariabiliGioco.tx_player.Height > VariabiliTemp.posizioni[i].PosizioneAttuale.Y && VariabiliTemp.posizionePlayer.Y + VariabiliGioco.tx_player.Height < VariabiliTemp.posizioni[i].PosizioneAttuale.Y + 10)
                                {
                                    if (!VariabiliTemp.isSin && VariabiliTemp.rad < Math.PI / 2)
                                    {
                                        VariabiliGioco.salti++;
                                        VariabiliTemp.isSin = true;
                                        VariabiliTemp.posizioni[i].Jump++;
                                    }
                                }
                            }
                        }

                        else
                        {
                            if (VariabiliTemp.posizionePlayer.X + VariabiliGioco.tx_player.Width - 15 > VariabiliTemp.posizioni[i].PosizioneAttuale.X && VariabiliTemp.posizionePlayer.X + 15 < VariabiliTemp.posizioni[i].PosizioneAttuale.X + VariabiliGioco.tx_blockNormale.Width)
                            {
                                if (VariabiliTemp.posizionePlayer.Y + VariabiliGioco.tx_player.Height > VariabiliTemp.posizioni[i].PosizioneAttuale.Y && VariabiliTemp.posizionePlayer.Y + VariabiliGioco.tx_player.Height < VariabiliTemp.posizioni[i].PosizioneAttuale.Y + 10)
                                {
                                    if (!VariabiliTemp.isSin && VariabiliTemp.rad < Math.PI / 2)
                                    {
                                        VariabiliTemp.posizioni[i].IsRight = false;
                                    }
                                }
                            }
                        }
                    }
                    if (VariabiliTemp.currBonusCaduta != null)
                    {
                        switch (VariabiliTemp.currBonusCaduta.Tipo)
                        {
                            case TipoBonus.Molla:
                                VariabiliTemp.currBonusCaduta.Texture = new Texture2D(Variabili.game.GraphicsDevice, 1, 1);
                                break;
                            case TipoBonus.JetPack:
                                VariabiliTemp.currBonusCaduta.Texture = VariabiliGioco.tx_jetpack;
                                break;
                            case TipoBonus.Capellino:
                                VariabiliTemp.currBonusCaduta.Texture = VariabiliGioco.tx_cappello;
                                break;
                            case TipoBonus.Razzo:
                                VariabiliTemp.currBonusCaduta.Texture = VariabiliGioco.tx_razzo;
                                break;
                        }                       
                        VariabiliTemp.currBonusCaduta.Caduta(Variabili.gameTime);
                    }
                }
                else
                {
                    VariabiliTemp.currBonus.Fly(Variabili.gameTime);
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Effettua un salto
        /// </summary>
        public void Jump()
        {
            try
            {
                VariabiliTemp.isSin = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Meccanismo di discesa dei blocchi
        /// </summary>
        private void DiscesaBlocchi()
        {
            try
            {
                foreach (Posizione posizione in VariabiliTemp.posizioni)
                {
                    if (posizione.Bonus != null)
                        posizione.Bonus.PosizioneBlocco = posizione.PosizioneAttuale;
                }
                // Se il personaggio oltrepassa una certa soglia
                if (VariabiliTemp.posizionePlayer.Y < Costanti.LIMITE_Y)
                {
                    if (VariabiliTemp.currBonus == null)
                    {
                        // Abbassa la posizione del player
                        VariabiliTemp.isJumping = false;
                        VariabiliGioco.punteggio++;

                        try
                        {
                            // Abbassa la posizione di tutti i blocchi
                            foreach (Posizione posizione in VariabiliTemp.posizioni)
                            {
                                Vector2 temp = posizione.PosizioneAttuale;
                                temp.Y += VariabiliTemp.JumpHeight;
                                posizione.PosizioneAttuale = temp;
                            }
                            foreach (Nemico nemico in VariabiliTemp.nemici)
                            {
                                Vector2 temp = nemico.PosizioneAttuale;
                                temp.Y += VariabiliTemp.JumpHeight;
                                nemico.PosizioneAttuale = temp;

                                foreach (Proiettile proiettile in nemico.Proiettili)
                                {
                                    Vector2 tempPro = proiettile.Location;
                                    tempPro.Y += VariabiliTemp.JumpHeight;
                                    proiettile.Location = tempPro;
                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
                        }
                    }
                    else
                    {
                        VariabiliGioco.punteggio++;
                        float temp = 100 * VariabiliTemp.currBonus.Speed;
                        VariabiliTemp.posizionePlayer.Y += temp;
                        foreach (Posizione posizione in VariabiliTemp.posizioni)
                        {
                            Vector2 new_pos = posizione.PosizioneAttuale;
                            new_pos.Y += temp;
                            posizione.PosizioneAttuale = new_pos;
                        }
                        foreach (Nemico nemico in VariabiliTemp.nemici)
                        {
                            Vector2 tempPos = nemico.PosizioneAttuale;
                            tempPos.Y += temp;
                            nemico.PosizioneAttuale = tempPos;

                            foreach (Proiettile proiettile in nemico.Proiettili)
                            {
                                Vector2 tempPro = proiettile.Location;
                                tempPro.Y += temp;
                                proiettile.Location = tempPro;
                            }
                        }
                    }
                }
                else
                    VariabiliTemp.isJumping = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Da utilizzare se abilitata la GODMODE. Evita che il personaggio esca da sotto lo schermo
        /// </summary>
        private void GodMode()
        {
            try
            {
                if (VariabiliTemp.posizionePlayer.Y > 310)
                    VariabiliTemp.posizionePlayer.Y = Variabili.graphics.PreferredBackBufferHeight / 2;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Controlla se si perde la parita
        /// </summary>
        private void GameOver()
        {
            try
            {
                if (VariabiliTemp.posizionePlayer.Y > Variabili.graphics.PreferredBackBufferHeight && !VariabiliGioco.godMode)
                {
                    VariabiliGioco.isGameOver = true;
                    VariabiliGioco.isGame = false;
                    // Resetta tutte le variabili
                    VariabiliTemp.deg = 0;
                    VariabiliTemp.inc = 0;
                    VariabiliTemp.rad = 0;
                    VariabiliTemp.cos = 0;
                    end = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    VariabiliTemp.currBonus = null;
                    Debug.WriteLine("End: " + end.ToString());
                    TimeSpan total = end - start;
                    Debug.WriteLine("Time: " + total.ToString());
                    VariabiliTemp.totalGameTime = VariabiliTemp.totalGameTime + total;
                    Debug.WriteLine("Total: " + VariabiliTemp.totalGameTime);
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Controlla se i blocchi escono dallo schermo (in basso) in quel caso li elimina
        /// </summary>
        private void RimuoviBlocchi()
        {
            try
            {
                for (int i = 0; i < VariabiliTemp.posizioni.Count; i++)
                {
                    if (VariabiliTemp.posizioni[i].PosizioneAttuale.Y > Variabili.graphics.PreferredBackBufferHeight + 100)
                    {
                        Debug.WriteLine("Blocco rimosso["+ i + "]: " + VariabiliTemp.posizioni[i].Details());
                        VariabiliTemp.posizioni.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Riavvia la partita azzerando il punteggio, riposizionando i blocchi e il player
        /// </summary>
        public void Reset()
        {
            try
            {
                // Riposiziona i blocchi
                VariabiliGioco.loadData.CaricaPosizioni();

                // Azzera il punteggio
                VariabiliGioco.punteggio = 0;
                // Entra nel gioco ed esce dal gameover
                VariabiliGioco.isGame = true;
                VariabiliGioco.isGameOver = false;
                // Riposiiona il player
                VariabiliTemp.posizionePlayer.Y = VariabiliTemp.posizioni[0].Y - VariabiliGioco.tx_player.Height;
                VariabiliTemp.posizionePlayer.X = Variabili.graphics.PreferredBackBufferWidth / 2 - (VariabiliGioco.tx_player.Width / 2);
                Debug.WriteLine("Gioco resettato");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna il player e i blocchi. Applica tutte le funzioni (SenoParabola, Input, GODMODE, ecc)
        /// </summary>
        public void Draw(GameTime gameTime)
        {            
            // Applica la funzione di SenoParabola
            SenoParabola();
            // Controlla l'input
            Input();
            // Controlla se il personaggio salta
            CheckJump();
            // Fa scendere i blocchi
            DiscesaBlocchi();
            // Controlla se si perde la partita
            GameOver();
            // Controlla se deve eliminare i blocchi
            RimuoviBlocchi();
            // Controlla se la GODMODE è abilitata
            if (VariabiliGioco.godMode)
                GodMode();

            try
            {
                VariabiliGioco.sfondo.Draw();
                Variabili.spriteBatch.Begin();

                // Disegna i blocchi che si trovano sotto -50
                try
                {
                    for (int i = 0; i < VariabiliTemp.posizioni.Count; i++)
                    {
                        if (VariabiliTemp.posizioni[i].PosizioneAttuale.Y > -50)
                            VariabiliTemp.posizioni[i].Draw(Variabili.spriteBatch);
                    }
                }
                catch (Exception ex)
                {
                    Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
                }

                try
                {
                    Texture2D tx_player = VariabiliGioco.tx_player;
                    if (VariabiliTemp.currBonus != null)
                    {
                        switch (VariabiliTemp.currBonus.Tipo)
                        {
                            case TipoBonus.JetPack:
                                tx_player = VariabiliGioco.tx_jetpack_player;
                                break;
                            case TipoBonus.Capellino:
                                tx_player = VariabiliGioco.tx_cappello_player;
                                break;
                            case TipoBonus.Razzo:
                                tx_player = VariabiliGioco.tx_razzo_player;
                                break;
                        }
                    }
                    // Disegna il player rivolto a destra o a sinistra
                    if (VariabiliTemp.isRight)
                        Variabili.spriteBatch.Draw(tx_player, VariabiliTemp.posizionePlayer, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                    else
                        Variabili.spriteBatch.Draw(tx_player, VariabiliTemp.posizionePlayer, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }
                catch (Exception ex)
                {
                    Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
                }
                // Scrive il punteggio sullo schermo
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, VariabiliGioco.punteggio.ToString(), new Vector2(10, 10), Color.Red);
                if (VariabiliTemp.currBonusCaduta != null)
                    VariabiliTemp.currBonusCaduta.Draw(Variabili.spriteBatch);
                Variabili.spriteBatch.End();

                for (int i = 0; i < VariabiliTemp.nemici.Count; i++)
                {
                    VariabiliTemp.nemici[i].Draw(Variabili.spriteBatch, gameTime);
                }

                Nemico.UpdateNullPosition(gameTime);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
