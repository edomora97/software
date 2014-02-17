using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using JumpingJump.Classi;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Piattaforme
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        bool isOK = false;

        public Main()
        {
            try
            {
                graphics = new GraphicsDeviceManager(this);
                graphics.PreferredBackBufferHeight = 320;
                graphics.PreferredBackBufferWidth = 240;
                this.IsMouseVisible = true;
                Content.RootDirectory = "Content";
                VariabiliCondivise.AddText("Avvio di JumpingJump - Piattaforme");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        protected override void Initialize()
        {
            try
            {
                VariabiliCondivise.AddText("Inizializzazione in corso...");
                this.IsMouseVisible = true;
                this.Window.Title = "JumpingJump_Piattaforme";

                Variabili.keyboard = Keyboard.GetState();
                Variabili.mouse = Mouse.GetState();
                Variabili.posizioni = new List<Posizione>();
                Variabili.input = new Input(this);
                Variabili.saveData = new SaveData();
                Variabili.saveData.GetIndex();

                Components.Add(Variabili.input);

                base.Initialize();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }        
        protected override void LoadContent()
        {
            try
            {
                VariabiliCondivise.AddText("Caricamento texture...");
                spriteBatch = new SpriteBatch(GraphicsDevice);
                VariabiliGioco.LoadContent(this);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        protected override void Update(GameTime gameTime)
        {
            try
            {
                if (!isOK)
                {
                    VariabiliCondivise.AddText("Inizializzazione completata");
                    isOK = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    this.Exit();

                base.Update(gameTime);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            try
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                spriteBatch.Begin();
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.MovimOrriz)
                    spriteBatch.Draw(VariabiliGioco.tx_dot, new Rectangle(209, 0, 1, 320), Color.CornflowerBlue);
                foreach (Posizione pos in Variabili.posizioni)
                {
                    if (pos.Tipo == TipoPosizione.Normale ||
                        pos.Tipo == TipoPosizione.MovimOrriz ||
                        pos.Tipo == TipoPosizione.Distruttibile ||
                        pos.Tipo == TipoPosizione.SaltoSingolo)
                    {
                        Helper.DrawLine(spriteBatch, new Vector2(pos.PosizioneAttuale.X - 30, pos.PosizioneAttuale.Y - 60 + Variabili.offset), new Vector2(pos.PosizioneAttuale.X + 74, pos.PosizioneAttuale.Y - 60 + Variabili.offset), Color.CornflowerBlue, 1);
                    }
                }
                Helper.DrawLine(spriteBatch, new Vector2(0, 320 + Variabili.offset), new Vector2(240, 320 + Variabili.offset), Color.Red, 3);
                foreach (Posizione posizione in Variabili.posizioni)
                {
                    if (posizione.Tipo == TipoPosizione.Normale)
                        spriteBatch.Draw(VariabiliGioco.tx_blockNormale, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Falso)
                        spriteBatch.Draw(VariabiliGioco.tx_blockFalso, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.MovimOrriz)
                        spriteBatch.Draw(VariabiliGioco.tx_blockMovimOrriz, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Distruttibile)
                        spriteBatch.Draw(VariabiliGioco.txs_blockDistruttibile[0], new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.SaltoSingolo)
                        spriteBatch.Draw(VariabiliGioco.tx_blockSaltoSingolo, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Nemico1)
                        spriteBatch.Draw(VariabiliGioco.tx_nemico1, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Nemico2)
                        spriteBatch.Draw(VariabiliGioco.tx_nemico2, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Nemico3)
                        spriteBatch.Draw(VariabiliGioco.tx_nemico3, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Nemico4)
                        spriteBatch.Draw(VariabiliGioco.tx_nemico4, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Nemico5)
                        spriteBatch.Draw(VariabiliGioco.tx_nemico5, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Nemico6)
                        spriteBatch.Draw(VariabiliGioco.tx_nemico6, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                    if (posizione.Tipo == TipoPosizione.Nemico7)
                        spriteBatch.Draw(VariabiliGioco.tx_nemico7, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                }

                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Normale)
                    spriteBatch.Draw(VariabiliGioco.tx_blockNormale, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Falso)
                    spriteBatch.Draw(VariabiliGioco.tx_blockFalso, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.MovimOrriz)
                    spriteBatch.Draw(VariabiliGioco.tx_blockMovimOrriz, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Distruttibile)
                    spriteBatch.Draw(VariabiliGioco.txs_blockDistruttibile[0], new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.SaltoSingolo)
                    spriteBatch.Draw(VariabiliGioco.tx_blockSaltoSingolo, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico1)
                    spriteBatch.Draw(VariabiliGioco.tx_nemico1, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico2)
                    spriteBatch.Draw(VariabiliGioco.tx_nemico2, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico3)
                    spriteBatch.Draw(VariabiliGioco.tx_nemico3, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico4)
                    spriteBatch.Draw(VariabiliGioco.tx_nemico4, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico5)
                    spriteBatch.Draw(VariabiliGioco.tx_nemico5, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico6)
                    spriteBatch.Draw(VariabiliGioco.tx_nemico6, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                if (VariabiliCondivise.tipoBlocco == TipoPosizione.Nemico7)
                    spriteBatch.Draw(VariabiliGioco.tx_nemico7, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
                spriteBatch.End();

                base.Draw(gameTime);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        public void Quit()
        {
            try
            {
                Exit();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }          
        }
        protected override void OnExiting(object sender, System.EventArgs args)
        {
            try
            {
                VariabiliCondivise.AddText("Chiusura di JumpingJump - Piattaforme");
                base.OnExiting(sender, args);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
