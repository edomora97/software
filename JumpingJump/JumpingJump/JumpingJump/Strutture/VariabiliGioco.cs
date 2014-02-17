using JumpingJump.Classi;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump
{
    public struct VariabiliGioco
    {
        /// <summary>
        /// Indica se ci si trova nelmenu statistiche
        /// </summary>
        public static bool isStatistiche;
        /// <summary>
        /// Indica se ci si trova nel menu credits
        /// </summary>
        public static bool isCredits;
        /// <summary>
        /// Indica se ci si trova nel menu di pausa
        /// </summary>
        public static bool isPause;
        /// <summary>
        /// Variabile true se ci si trova nel menu principale
        /// </summary>
        public static bool isMenu;
        /// <summary>
        /// Variabile true se ci si trova nel menu classifica
        /// </summary>
        public static bool isClassifica;
        /// <summary>
        /// Variabile true se ci si trova all'interno di una partita
        /// </summary>
        public static bool isGame;
        /// <summary>
        /// Variabile true se ci si trova nel menu GameOver
        /// </summary>
        public static bool isGameOver;
        /// <summary>
        /// Variabile true se è abilitata la godmode
        /// </summary>
        public static bool godMode;
        /// <summary>
        /// Classe del menu statistiche
        /// </summary>
        public static Statistiche statistiche;
        /// <summary>
        /// Classe del menu classifica
        /// </summary>
        public static Classifica classifica;
        /// <summary>
        /// Classe per il disegno dello sfondo animato nel gioco
        /// </summary>
        public static Sfondo sfondo;
        /// <summary>
        /// Classe per il caricamento dei blocchi
        /// </summary>
        public static LoadData loadData;
        /// <summary>
        /// Classe per la visualizzazione dei credits
        /// </summary>
        public static Credits credits;
        /// <summary>
        /// Classe che disegna i blocchi e che contiene l'algoritmo di rimbalzo
        /// </summary>
        public static JumpingJump.Classi.Game game;
        /// <summary>
        /// Variabile che contiene i tasti premuti sulla tastiera
        /// </summary>
        public static KeyboardState keyboardState;
        /// <summary>
        /// Variabile che contiene i tasti premuti sulla tastiera prima
        /// </summary>
        public static KeyboardState keyboardState_old;
        /// <summary>
        /// Variabile che contiene i tasti premuti e la posizione del mouse
        /// </summary>
        public static MouseState mouseState;
        /// <summary>
        /// Variabile che contiene i tasti premuti e la posizione del mouse prima
        /// </summary>
        public static MouseState mouseState_old;
        /// <summary>
        /// Classe per il disegno del menu principale
        /// </summary>
        public static Menu menu;
        /// <summary>
        /// Nome del giocatore
        /// </summary>
        public static string nome;
        /// <summary>
        /// Texture dello sfondo nel gioco
        /// </summary>
        public static Texture2D tx_sfondo_game;
        /// <summary>
        /// Texture di una stella cadente
        /// </summary>
        public static Texture2D tx_stella;
        /// <summary>
        /// Texture dello sfondo nei menu
        /// </summary>
        public static Texture2D tx_sfondo_main;
        /// <summary>
        /// Texture del titolo
        /// </summary>
        public static Texture2D tx_titolo;
        /// <summary>
        /// Texture del pulsante play
        /// </summary>
        public static Texture2D tx_btnPlay;
        /// <summary>
        /// Texture del pulsante hight
        /// </summary>
        public static Texture2D tx_btnHight;
        /// <summary>
        /// Texture del pulsante exit
        /// </summary>
        public static Texture2D tx_btnExit;
        /// <summary>
        /// Texture del pulsante menu
        /// </summary>
        public static Texture2D tx_btnMenu;
        /// <summary>
        /// Texture del pulsante reset
        /// </summary>
        public static Texture2D tx_btnReset;
        /// <summary>
        /// Texture del pulsante try again
        /// </summary>
        public static Texture2D tx_btnTryAgain;
        /// <summary>
        /// Texture del pusante stats
        /// </summary>
        public static Texture2D tx_btnStats;
        /// <summary>
        /// Texture del titolo del menu hight score
        /// </summary>
        public static Texture2D tx_hightScores;
        /// <summary>
        /// Texture del player
        /// </summary>
        public static Texture2D tx_player;
        /// <summary>
        /// Texture di un punto (1x1 px Nero)
        /// </summary>
        public static Texture2D tx_dot;
        /// <summary>
        /// Texture di un blocco noramle
        /// </summary>
        public static Texture2D tx_blockNormale;
        /// <summary>
        /// Texture di un blocco falso distrutto
        /// </summary>
        public static Texture2D tx_blockFalsoDist;
        /// <summary>
        /// Texture di un blocco falso
        /// </summary>
        public static Texture2D tx_blockFalso;
        /// <summary>
        /// Texture di un blocco che si muove orrizzontalmente
        /// </summary>
        public static Texture2D tx_blockMovimOrriz;
        /// <summary>
        /// Texture di un blocchi che si muove verticalmente
        /// </summary>
        public static Texture2D tx_blockMovimVert;
        /// <summary>
        /// Array di texture di un blocco distruttibile
        /// </summary>
        public static Texture2D[] txs_blockDistruttibile;
        /// <summary>
        /// Texture di un blocco di tipo salto singolo
        /// </summary>
        public static Texture2D tx_blockSaltoSingolo;
        /// <summary>
        /// Texture del nemico numero 1
        /// </summary>
        public static Texture2D tx_nemico1;
        /// <summary>
        /// Texture del nemico numero 2
        /// </summary>
        public static Texture2D tx_nemico2;
        /// <summary>
        /// Texture del nemico numero 3
        /// </summary>
        public static Texture2D tx_nemico3;
        /// <summary>
        /// Texture del nemico numero 4
        /// </summary>
        public static Texture2D tx_nemico4;
        /// <summary>
        /// Texture del nemico numero 5
        /// </summary>
        public static Texture2D tx_nemico5;
        /// <summary>
        /// Texture del nemico numero 6
        /// </summary>
        public static Texture2D tx_nemico6;
        /// <summary>
        /// Texture del nemico numero 7
        /// </summary>
        public static Texture2D tx_nemico7;
        /// <summary>
        /// Texture del proiettile
        /// </summary>
        public static Texture2D tx_proiettile;
        /// <summary>
        /// Texture del cappellino
        /// </summary>
        public static Texture2D tx_cappello;
        /// <summary>
        /// Texture del player con il cappellino
        /// </summary>
        public static Texture2D tx_cappello_player;
        /// <summary>
        /// Texture del jetpack
        /// </summary>
        public static Texture2D tx_jetpack;
        /// <summary>
        /// Texture del player con il jetpack
        /// </summary>
        public static Texture2D tx_jetpack_player;
        /// <summary>
        /// Texture della molla
        /// </summary>
        public static Texture2D tx_molla;
        /// <summary>
        /// Texture del razzo
        /// </summary>
        public static Texture2D tx_razzo;
        /// <summary>
        /// Texture del player con il razzo
        /// </summary>
        public static Texture2D tx_razzo_player;
        /// <summary>
        /// Classe per visualizzare la schermata GameOver
        /// </summary>
        public static GameOver gameOver;
        /// <summary>
        /// Contiene il numero totale di salti
        /// </summary>
        public static int salti;
        /// <summary>
        /// Il punteggio della partita corrente
        /// </summary>
        public static int punteggio;
        /// <summary>
        /// Classe per visualizzare il menu di pausa
        /// </summary>
        public static PauseMenu pauseMenu;

        /// <summary>
        /// Carica le texture
        /// </summary>
        public static void LoadContent(Microsoft.Xna.Framework.Game game)
        {
            Configuration con = new Configuration();
            con.LoadOption();
            Main.Load(game);
        }
    }
}