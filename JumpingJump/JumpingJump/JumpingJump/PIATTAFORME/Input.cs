using System;
using System.Diagnostics;
using JumpingJump.Classi;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Piattaforme
{
    /// <summary>
    /// Classe per la gestione dell'input
    /// </summary>
    public class Input : GameComponent
    {
        private KeyboardState keyboard_pre;
        private KeyboardState keyboard;
        private MouseState mouse_pre;
        private MouseState mouse;
        private static Microsoft.Xna.Framework.Game _game;

        public Input(Microsoft.Xna.Framework.Game game)
            : base(game)
        {
            try
            {
                _game = game;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Aggiorna lo stato della testiera e del mouse, controllandone i tasti
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            try
            {
                keyboard_pre = Keyboard.GetState();
                mouse_pre = Mouse.GetState();

                #region SWITCH TASTIERA

                if (keyboard.IsKeyDown(Keys.N) && keyboard_pre.IsKeyUp(Keys.N))
                {
                    Add(TipoPosizione.Normale);
                }

                if (keyboard.IsKeyDown(Keys.F) && keyboard_pre.IsKeyUp(Keys.F))
                {
                    Add(TipoPosizione.Falso);
                }

                if (keyboard.IsKeyDown(Keys.O) && keyboard_pre.IsKeyUp(Keys.O))
                {
                    Add(TipoPosizione.MovimOrriz);
                }

                if (keyboard.IsKeyDown(Keys.D) && keyboard_pre.IsKeyUp(Keys.D))
                {
                    Add(TipoPosizione.Distruttibile);
                }
                if (keyboard.IsKeyDown(Keys.E) && keyboard_pre.IsKeyUp(Keys.E))
                {
                    Add(TipoPosizione.Nemico1);
                }
                if (keyboard.IsKeyDown(Keys.R) && keyboard_pre.IsKeyUp(Keys.R))
                {
                    Debug.WriteLine("RESET! cancellate " + Variabili.posizioni.Count + " posizioni");
                    Reset();
                }

                if (keyboard.IsKeyDown(Keys.S) && keyboard_pre.IsKeyUp(Keys.S))
                {
                    Add(TipoPosizione.SaltoSingolo);
                }
                if (keyboard.IsKeyDown(Keys.F1) && keyboard_pre.IsKeyUp(Keys.F1))
                {
                    Variabili.saveData.Salva("data", 0);
                }
                if (keyboard.IsKeyDown(Keys.F2) && keyboard_pre.IsKeyUp(Keys.F2))
                {
                    Variabili.saveData.Salva("data", 1);
                }
                if (keyboard.IsKeyDown(Keys.F3) && keyboard_pre.IsKeyUp(Keys.F3))
                {
                    Variabili.saveData.Salva("data", 2);
                }
                if (keyboard.IsKeyDown(Keys.F4) && keyboard_pre.IsKeyUp(Keys.F4))
                {
                    Variabili.saveData.Salva("data", 3);
                }
                if (keyboard.IsKeyDown(Keys.F5) && keyboard_pre.IsKeyUp(Keys.F5))
                {
                    Variabili.saveData.Salva("data", 4);
                }
                if (keyboard.IsKeyDown(Keys.F6) && keyboard_pre.IsKeyUp(Keys.F6))
                {
                    Variabili.saveData.Salva("data", 5);
                }
                if (keyboard.IsKeyDown(Keys.F7) && keyboard_pre.IsKeyUp(Keys.F7))
                {
                    Variabili.saveData.Salva("data", 6);
                }
                if (keyboard.IsKeyDown(Keys.F8) && keyboard_pre.IsKeyUp(Keys.F8))
                {
                    Variabili.saveData.Salva("data", 7);
                }
                if (keyboard.IsKeyDown(Keys.F9) && keyboard_pre.IsKeyUp(Keys.F9))
                {
                    Variabili.saveData.Salva("data", 8);
                }
                if (keyboard.IsKeyDown(Keys.F10) && keyboard_pre.IsKeyUp(Keys.F10))
                {
                    Variabili.saveData.Salva("data", 9);
                }
                if (keyboard.IsKeyDown(Keys.F11) && keyboard_pre.IsKeyUp(Keys.F11))
                {
                    Variabili.saveData.Salva("data", 10);
                }
                #endregion
                #region SWITCH MOUSE
                if (mouse.LeftButton == ButtonState.Pressed && mouse_pre.LeftButton == ButtonState.Released && mouse.X > 0 && mouse.X < 240 && mouse.Y > 0 && mouse.Y < 320)
                {
                    Add();
                }
                Variabili.offset = mouse.ScrollWheelValue / 25;
                if (VariabiliCondivise.Offset != Variabili.offset)
                    VariabiliCondivise.Offset = Variabili.offset;
                VariabiliCondivise.PosizioneMouse = new Vector2(mouse.X, mouse.Y);
                #endregion

                keyboard = keyboard_pre;
                mouse = mouse_pre;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Aggiunge una posizione alla lista delle posizioni
        /// </summary>
        /// <param name="tipo">Tipo di posizione</param>
        private void Add(TipoPosizione tipo)
        {
            try
            {
                Posizione posizione;
                if (tipo == TipoPosizione.MovimOrriz)
                {
                    posizione = new Posizione(new Vector2(20, mouse.Y - Variabili.offset), new Vector2(mouse.X, mouse.Y - Variabili.offset), TipoPosizione.MovimOrriz);
                    if (VariabiliCondivise.Bonus != TipoBonus.Nessuno)
                    {
                        Bonus bonus = new Bonus();
                        bonus.PosizioneBlocco = posizione.PosizioneAttuale;
                        bonus.Tipo = VariabiliCondivise.Bonus;
                        bonus.Durata = VariabiliCondivise.BonusJumpHeight;
                        bonus.Speed = VariabiliCondivise.BonusSpeed;
                        posizione.Bonus = bonus;
                    }
                    else
                        posizione.Bonus = null;
                    Variabili.posizioni.Add(posizione);
                    Debug.WriteLine("Posizione aggiunta: X: " + posizione.X.ToString() + "\tY: " + posizione.Y.ToString() + "\t Posizione Attuale: " + posizione.PosizioneAttuale.ToString() + "\tTipo: " + posizione.Tipo.ToString());
                }
                else
                {
                    posizione = new Posizione(mouse.X, mouse.Y - Variabili.offset, tipo);
                    if (VariabiliCondivise.Bonus != TipoBonus.Nessuno)
                    {
                        Bonus bonus = new Bonus();
                        bonus.PosizioneBlocco = posizione.PosizioneAttuale;
                        bonus.Tipo = VariabiliCondivise.Bonus;
                        bonus.Durata = VariabiliCondivise.BonusJumpHeight;
                        bonus.Speed = VariabiliCondivise.BonusSpeed;
                        posizione.Bonus = bonus;
                    }
                    else
                        posizione.Bonus = null;
                    Variabili.posizioni.Add(posizione);
                    Debug.WriteLine("Posizione aggiunta: X: " + posizione.X.ToString() + "\tY: " + posizione.Y.ToString() + "\tTipo: " + posizione.Tipo.ToString());
                }
                VariabiliCondivise.AddText("Posizione aggiunta: X: " + posizione.X.ToString() + "\tY: " + posizione.Y.ToString() + "\t Posizione Attuale: " + posizione.PosizioneAttuale.ToString() + "\tTipo: " + posizione.Tipo.ToString());
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Aggiunge una posizione alla lista delle posizioni
        /// </summary>
        private void Add()
        {
            try
            {
                Posizione posizione;
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.MovimOrriz)
                {
                    VariabiliCondivise.Posizione = new Vector2(20, mouse.Y - Variabili.offset);
                    VariabiliCondivise.PosizioneAttuale = new Vector2(mouse.X, mouse.Y - Variabili.offset);
                    posizione = new Posizione(VariabiliCondivise.Posizione, VariabiliCondivise.PosizioneAttuale, VariabiliCondivise.tipoBlocco);
                    if (VariabiliCondivise.Speed > 0)
                        posizione.Velocità = VariabiliCondivise.Speed;
                    else
                        posizione.Velocità = 1;
                }
                else if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico1)
                {
                    VariabiliCondivise.Posizione = new Vector2(mouse.X, mouse.Y - Variabili.offset);
                    VariabiliCondivise.PosizioneAttuale = new Vector2(mouse.X, mouse.Y - Variabili.offset);
                    posizione = new Posizione(VariabiliCondivise.Posizione, VariabiliCondivise.tipoBlocco, VariabiliCondivise.maxLife);
                }
                else
                {
                    VariabiliCondivise.Posizione = new Vector2(mouse.X, mouse.Y - Variabili.offset);
                    VariabiliCondivise.PosizioneAttuale = new Vector2(mouse.X, mouse.Y - Variabili.offset);
                    posizione = new Posizione(VariabiliCondivise.Posizione, VariabiliCondivise.tipoBlocco);
                }
                if (VariabiliCondivise.Bonus != TipoBonus.Nessuno)
                {
                    Bonus bonus = new Bonus();
                    bonus.PosizioneBlocco = posizione.PosizioneAttuale;
                    bonus.Tipo = VariabiliCondivise.Bonus;
                    bonus.Durata = VariabiliCondivise.BonusJumpHeight;
                    bonus.Speed = VariabiliCondivise.BonusSpeed;
                    posizione.Bonus = bonus;
                }
                else
                    posizione.Bonus = null;
                Variabili.posizioni.Add(posizione);
                VariabiliCondivise.NumPosizioni = Variabili.posizioni.Count;
                VariabiliCondivise.AddText("Posizione aggiunta: X: " + posizione.X.ToString() + "\tY: " + posizione.Y.ToString() + "\t Posizione Attuale: " + posizione.PosizioneAttuale.ToString() + "\tTipo: " + posizione.Tipo.ToString());
                Debug.WriteLine("Posizione aggiunta: X: " + posizione.X.ToString() + "\tY: " + posizione.Y.ToString() + "\t Posizione Attuale: " + posizione.PosizioneAttuale.ToString() + "\tTipo: " + posizione.Tipo.ToString());
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Popola la lista con 10000 posizioni casuali
        /// </summary>
        public static void Populate()
        {
            try
            {
                VariabiliCondivise.AddText("Popola avviato");
                for (int i = 0; i < 10000; i++)
                {
                    Random rnd = new Random();
                    Posizione pos = new Posizione(rnd.Next(240), rnd.Next(320), (TipoPosizione)rnd.Next(12));
                    Variabili.posizioni.Add(pos);
                    VariabiliCondivise.NumPosizioni = Variabili.posizioni.Count;
                }
                VariabiliCondivise.AddText("Popola completato");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Salva il file del livello
        /// </summary>
        public static void Salva()
        {
            try
            {
                Variabili.saveData.Salva("data", VariabiliCondivise.difficoltà);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Resetta il livello
        /// </summary>
        public static void Reset()
        {
            try
            {
                Variabili.posizioni.Clear();
                Variabili.offset = 0;                
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }      
        }
        /// <summary>
        /// Esce dall'editor
        /// </summary>
        public static void Exit()
        {
            try
            {
                VariabiliCondivise.AddText("Uscita da JumpingJump Piattaforme");
                _game.Exit();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Cancella l'ultima posizione aggiunta
        /// </summary>
        public static void UnDo()
        {
            if (Variabili.posizioni.Count > 0)
            {
                Variabili.posizioni.RemoveAt(Variabili.posizioni.Count - 1);
                VariabiliCondivise.NumPosizioni = Variabili.posizioni.Count;
            }
        }
    }
}
