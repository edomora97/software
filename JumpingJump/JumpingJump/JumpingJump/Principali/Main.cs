using System;
using System.Collections.Generic;
using System.Diagnostics;
using JumpingJump.Classi;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// Costruttore della classe del gioco
        /// </summary>
        public Main()
        {
            //Assegna la cartella dove salvare i file del content
            Content.RootDirectory = "Content";
            //Rende il mouse visibile
            IsMouseVisible = true;
            //Assegna il valore a graphics
            Variabili.graphics = new GraphicsDeviceManager(this);
            //Imposta la grandezza dello schermo
            Variabili.graphics.PreferredBackBufferHeight = 320;
            Variabili.graphics.PreferredBackBufferWidth = 240;
            //Assegna la variabile del gioco
            Variabili.game = this;
            // Limita i frame a 60fps
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / 60);
            Variabili.graphics.SynchronizeWithVerticalRetrace = true;
        }
        
        /// <summary>
        /// Inizializza le variabili del gioco, inclusa la GODMODE
        /// </summary>
        protected override void Initialize()
        {
            try
            {
                Configuration con = new Configuration();
                con.LoadOption();
                Load(this);
                // Inizializza le principali funzioni
                Variabili.spriteBatch = new SpriteBatch(GraphicsDevice);
                Variabili.random = new Random();
                // Inizializza le classi
                VariabiliGioco.menu = new Menu();
                VariabiliGioco.statistiche = new Statistiche();
                VariabiliGioco.classifica = new Classifica();
                VariabiliGioco.game = new JumpingJump.Classi.Game();
                VariabiliGioco.gameOver = new GameOver();
                VariabiliGioco.pauseMenu = new PauseMenu();
                VariabiliGioco.loadData = new LoadData();
                VariabiliGioco.sfondo = new Sfondo();
                VariabiliGioco.credits = new Credits();
                // Imposta le variabili principali
                VariabiliGioco.isClassifica = false;
                VariabiliGioco.isGame = false;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isMenu = true;
                VariabiliGioco.nome = "";
                VariabiliTemp.nemici = new List<Nemico>();
                VariabiliTemp.gameOverTemp = true;
                // Carica la classifica e i livelli
                VariabiliGioco.classifica.Carica();
                VariabiliGioco.loadData.Carica();
                VariabiliTemp.currBonus = null;


                // Effettua le operazioni se si ha abilitato la GODMODE
                if (VariabiliGioco.godMode)
                {
                    VariabiliGioco.isMenu = false;
                    VariabiliGioco.isGame = true;
                }
                base.Initialize();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Abilita la GODMODE
        /// </summary>
        public void GodMode()
        {
            try
            {
                VariabiliGioco.godMode = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Carica le texture in VariabiliGioco
        /// </summary>
        public static void Load(Microsoft.Xna.Framework.Game game)
        {
            try
            {
                // Carica le immagini base
                VariabiliGioco.tx_sfondo_main = Helper.LoadTextureFromFile(Costanti.PATH_tx_sfondo_main, game);
                VariabiliGioco.tx_sfondo_game = Helper.LoadTextureFromFile(Costanti.PATH_tx_sfondo_game, game);
                VariabiliGioco.tx_stella = Helper.LoadTextureFromFile(Costanti.PATH_tx_stella, game);
                VariabiliGioco.tx_titolo = Helper.LoadTextureFromFile(Costanti.PATH_tx_titolo, game);
                VariabiliGioco.tx_hightScores = Helper.LoadTextureFromFile(Costanti.PATH_tx_hightScores, game);
                VariabiliGioco.tx_player = Helper.LoadTextureFromFile(Costanti.PATH_tx_player, game);
                VariabiliGioco.tx_dot = Helper.LoadTextureFromFile(Costanti.PATH_tx_dot, game);
                VariabiliGioco.tx_proiettile = Helper.LoadTextureFromFile(Costanti.PATH_tx_proiettile, game);

                // Carica le immagini dei pulsanti
                VariabiliGioco.tx_btnPlay = Helper.LoadTextureFromFile(Costanti.PATHS_tx_btns[0], game);
                VariabiliGioco.tx_btnHight = Helper.LoadTextureFromFile(Costanti.PATHS_tx_btns[1], game);
                VariabiliGioco.tx_btnExit = Helper.LoadTextureFromFile(Costanti.PATHS_tx_btns[2], game);
                VariabiliGioco.tx_btnMenu = Helper.LoadTextureFromFile(Costanti.PATHS_tx_btns[3], game);
                VariabiliGioco.tx_btnReset = Helper.LoadTextureFromFile(Costanti.PATHS_tx_btns[4], game);
                VariabiliGioco.tx_btnTryAgain = Helper.LoadTextureFromFile(Costanti.PATHS_tx_btns[5], game);
                VariabiliGioco.tx_btnStats = Helper.LoadTextureFromFile(Costanti.PATHS_tx_btns[6], game);

                // Carica le immagini dei blocchi
                VariabiliGioco.tx_blockFalso = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[0], game);
                VariabiliGioco.tx_blockFalsoDist = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[1], game);
                VariabiliGioco.tx_blockMovimOrriz = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[2], game);
                VariabiliGioco.tx_blockMovimVert = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[3], game);
                VariabiliGioco.tx_blockNormale = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[4], game);
                VariabiliGioco.tx_blockSaltoSingolo = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[5], game);

                // Carica le immagini del blocco distruttibile
                VariabiliGioco.txs_blockDistruttibile = new Texture2D[5];
                VariabiliGioco.txs_blockDistruttibile[0] = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[6], game);
                VariabiliGioco.txs_blockDistruttibile[1] = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[7], game);
                VariabiliGioco.txs_blockDistruttibile[2] = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[8], game);
                VariabiliGioco.txs_blockDistruttibile[3] = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[9], game);
                VariabiliGioco.txs_blockDistruttibile[4] = Helper.LoadTextureFromFile(Costanti.PATHS_tx_blocks[10], game);

                // Carica le immagini dei nemici
                VariabiliGioco.tx_nemico1 = Helper.LoadTextureFromFile(Costanti.PATHS_tx_nemici[0], game);
                VariabiliGioco.tx_nemico2 = Helper.LoadTextureFromFile(Costanti.PATHS_tx_nemici[1], game);
                VariabiliGioco.tx_nemico3 = Helper.LoadTextureFromFile(Costanti.PATHS_tx_nemici[2], game);
                VariabiliGioco.tx_nemico4 = Helper.LoadTextureFromFile(Costanti.PATHS_tx_nemici[3], game);
                VariabiliGioco.tx_nemico5 = Helper.LoadTextureFromFile(Costanti.PATHS_tx_nemici[4], game);
                VariabiliGioco.tx_nemico6 = Helper.LoadTextureFromFile(Costanti.PATHS_tx_nemici[5], game);
                VariabiliGioco.tx_nemico7 = Helper.LoadTextureFromFile(Costanti.PATHS_tx_nemici[6], game);

                // Carica del immagini dei bonus
                VariabiliGioco.tx_cappello = Helper.LoadTextureFromFile(Costanti.PATHS_tx_bonus[0], game);
                VariabiliGioco.tx_cappello_player = Helper.LoadTextureFromFile(Costanti.PATHS_tx_bonus[1], game);
                VariabiliGioco.tx_jetpack = Helper.LoadTextureFromFile(Costanti.PATHS_tx_bonus[2], game);
                VariabiliGioco.tx_jetpack_player = Helper.LoadTextureFromFile(Costanti.PATHS_tx_bonus[3], game);
                VariabiliGioco.tx_molla = Helper.LoadTextureFromFile(Costanti.PATHS_tx_bonus[4], game);
                VariabiliGioco.tx_razzo = Helper.LoadTextureFromFile(Costanti.PATHS_tx_bonus[5], game);
                VariabiliGioco.tx_razzo_player = Helper.LoadTextureFromFile(Costanti.PATHS_tx_bonus[6], game);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Inizializa i file della grafica del gioco
        /// </summary>
        protected override void LoadContent()
        {
            try
            {
                // Carica i font
                Variabili.FontClassificaS = Content.Load<SpriteFont>(@"Font\ClassificaSmall");
                Variabili.FontClassificaL = Content.Load<SpriteFont>(@"Font\ClassificaBig");
                Variabili.FontStatistiche = Content.Load<SpriteFont>(@"Font\Statistiche");
                Variabili.FontCreditMenu = Content.Load<SpriteFont>(@"Font\CreditsMenu");

                Load(this);
                base.LoadContent();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Se viene premuto il tasto esc l'applicazione si chiude
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            try
            {
                Variabili.gameTime = gameTime;
                base.Update(gameTime);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Effettua la scelta del menu da utilizzare
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            try
            {
                VariabiliGioco.keyboardState_old = VariabiliGioco.keyboardState;
                VariabiliGioco.keyboardState = Keyboard.GetState();
                VariabiliGioco.mouseState_old = VariabiliGioco.mouseState;
                VariabiliGioco.mouseState = Mouse.GetState();
                GraphicsDevice.Clear(Color.Red);
                if (VariabiliGioco.isMenu)
                    VariabiliGioco.menu.Draw();
                if (VariabiliGioco.isClassifica)
                    VariabiliGioco.classifica.Draw();
                if (VariabiliGioco.isGameOver)
                    VariabiliGioco.gameOver.Draw();
                if (VariabiliGioco.isGame)
                    VariabiliGioco.game.Draw(gameTime);
                if (VariabiliGioco.isPause)
                    VariabiliGioco.pauseMenu.Draw();
                if (VariabiliGioco.isStatistiche)
                    VariabiliGioco.statistiche.Draw();
                if (VariabiliGioco.isCredits)
                    VariabiliGioco.credits.Draw();
                if (VariabiliGioco.godMode)
                {
                    Variabili.spriteBatch.Begin();
                    Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, "GODMODE", new Vector2(160, 20), Color.Red);
                    Variabili.spriteBatch.End();
                }
                Variabili.spriteBatch.Begin();
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaS, "BETA!", new Vector2(10, 295), Color.Red);
                Variabili.spriteBatch.End();
                base.Draw(gameTime);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }        
        /// <summary>
        /// Quando stà uscendo dal gioco, salva la classifia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnExiting(object sender, EventArgs args)
        {
            // Salva la classifica
            VariabiliGioco.classifica.Salva();
            try
            {
                JumpingJump.Piattaforme.VariabiliCondivise.AddText("Chiusura di JumpingJump");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);            
            }
            base.OnExiting(sender, args);
        }
    }
}
