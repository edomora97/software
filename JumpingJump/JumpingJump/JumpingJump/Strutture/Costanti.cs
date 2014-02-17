using Microsoft.Xna.Framework;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump
{
    public struct Costanti
    {
        /// <summary>
        /// Numero di elementi nella classifica
        /// </summary>
        public static int CLASSIFICA_SAVED = 5;
        /// <summary>
        /// Difficoltà massima di un livello
        /// </summary>
        public static int MAX_LEVEL = 10;

        /// <summary>
        /// Numero di pulstanti nella classifica
        /// </summary>
        public static int PULSANTI_CLASSIFICA = 3;
        /// <summary>
        /// Numero di pulsanti nel menu statistiche
        /// </summary>
        public static int PULSANTI_STATISTICHE = 1;
        /// <summary>
        /// Numero di pulsanti nel GameOver
        /// </summary>
        public static int PULSANTI_GAMEOVER = 2;
        /// <summary>
        /// Numero di pulsanti nel menu di pausa
        /// </summary>
        public static int PULSANTI_PAUSE_MENU = 2;
        /// <summary>
        /// Numero di pulsanti nel menu principale
        /// </summary>
        public static int PULSANTI_MENU = 3;

        /// <summary>
        /// Velocità del player (gradi al clock)
        /// </summary>
        public static float VELOCITA_ANGOLARE_PLAYER_Y = 1.5f;
        /// <summary>
        /// Coefficiente di incremento dell'altezza di un salto
        /// </summary>
        public static float ALTEZZA_SALTO = 2f;
        /// <summary>
        /// Velocità del player (px al clock)
        /// </summary>
        public static float VELOCITA_PLAYER_X = 2f;

        /// <summary>
        /// Limite massimo della posizione Y
        /// </summary>
        public static float LIMITE_Y = 80;
        /// <summary>
        /// Velocità dei blocchi lungo Y
        /// </summary>
        public static float VELOCITA_BLOCCHI_Y = 1;
        /// <summary>
        /// Velocità dei blocchi lungo X
        /// </summary>
        public static float VELOCITA_BLOCCHI_X = 1;
        /// <summary>
        /// Lunghezza dell'oscillazione dei blocchi lungo X
        /// </summary>
        public static float DELTA_X = 150;

        /// <summary>
        /// Costante di accelerazione di un asteroide, deve essere maggiore di 1
        /// </summary>
        public static float VELOCTA_ASTEROIDE = 3f;
        /// <summary>
        /// Velocità di un proiettile
        /// </summary>
        public static float VELOCITA_PROIETTILE = 2f;

        /// <summary>
        /// Posizione del player alla partenza
        /// </summary>
        public static Vector2 PLAYER_DEFAULT_POSITION = new Vector2(105, 200);

        /// <summary>
        /// Path dell'immagine di sfondo principale
        /// </summary>
        public static string PATH_tx_sfondo_main;
        /// <summary>
        /// Path dell'immagine di sfondo del gioco
        /// </summary>
        public static string PATH_tx_sfondo_game;
        /// <summary>
        /// Path dell'immagine dell'asteroide
        /// </summary>
        public static string PATH_tx_stella;
        /// <summary>
        /// Path dell'immagine del titolo
        /// </summary>
        public static string PATH_tx_titolo;
        /// <summary>
        /// Path dell'immagine del titolodi hightScores
        /// </summary>
        public static string PATH_tx_hightScores;
        /// <summary>
        /// Path dell'immagine del player
        /// </summary>
        public static string PATH_tx_player;
        /// <summary>
        /// Path dell'immagine di un px
        /// </summary>
        public static string PATH_tx_dot;
        /// <summary>
        /// Path dell'immagine del proiettile
        /// </summary>
        public static string PATH_tx_proiettile;
        /// <summary>
        /// Array di stringhe con le path dei pulsanti
        /// </summary>
        public static string[] PATHS_tx_btns;
        /// <summary>
        /// Array di stringhe con le path dei blocchi
        /// </summary>
        public static string[] PATHS_tx_blocks;
        /// <summary>
        /// Array di stringhe con le path dei nemici
        /// </summary>
        public static string[] PATHS_tx_nemici;
        /// <summary>
        /// Array di stringhe con le path dei bonus
        /// </summary>
        public static string[] PATHS_tx_bonus;
     }
}
