using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Storage;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Media;

namespace ComputersInvaders
{
    [Serializable]
    public struct Variabili
    {
        #region BlockData
        public struct BlockData
        {
            public Vector2 posizione;
            public Color colore_;
        }
        #endregion        
        #region Vector2
        public static Vector2 posizione_pg;
        public static Vector2 posizione_pg_2;
        public static Vector2 posizione_nemico;
        public static Vector2 fine_schermo;
        public static Vector2 posizione_mouse;
        #endregion
        #region float
        public static float velocità;
        public static float forza_grav;
        public static float incrementoY;
        public static float posizione_nemico_X;
        public static float inc_velocità = 0;
        public static float probability;
        #endregion
        #region int
        public static int punteggio_temp;
        public static int timer_count;
        public static int punteggio;
        public static int p1, p2, p3, p4, p5;
        #endregion
        #region Texture2D
        public static Texture2D background;
        public static Texture2D player;
        public static Texture2D nemico;
        public static Texture2D dot;
        #endregion
        #region SpriteBatch
        public static SpriteBatch sprite_batch;
        #endregion
        #region ColliderTexture
        public static ColliderTexture player_ct;
        public static ColliderTexture block_ct;
        #endregion
        #region SpriteFont
        public static SpriteFont font1;
        public static SpriteFont font2;
        #endregion
        #region KeyboardState
        public static KeyboardState stato_tastiera;        
        #endregion
        #region MouseState
        public static MouseState stato_mouse;
        #endregion
        #region Game
        public static Game game;
        #endregion
        #region bool
        public static bool time_over;
        public static bool pause;
        public static bool showError;
        public static bool game_over;
        public static bool pause_temp;
        public static bool nome_temp;
        public static bool isClassificated;
        public static bool truccata;
        public static bool usa_mouse;
        public static bool usa_mouse_temp;
        public static bool schermo_intero;
        public static bool schermo_intero_temp;
        #endregion
        #region List
        public static List<BlockData> blockPosition = new List<BlockData>();
        #endregion 
        #region Random
        public static Random random = new Random();
        #endregion
        #region GraphicsDeviceManager
        public static GraphicsDeviceManager graphics;
        #endregion
        #region Input
        public static Input input = new Input();
        #endregion
        #region Gravità
        public static Gravità gravità = new Gravità();
        #endregion
        #region Personaggio
        public static Personaggio player1;
        #endregion
        #region string
        public static string nome;
        public static string errore;
        public static string path = "Content/Classifica.xls";
        public static string s1, s2, s3, s4, s5;
        #endregion
        #region Classifica
        public static Classifica classifica = new Classifica();
        #endregion
        #region Forms
        public static System.Windows.Forms.Form child = new Form();
        #endregion
        #region object
        public static readonly object _lockForTextBox = new object();
        public static object stateobj;
        #endregion
        #region PauseMenu
        public static PauseMenu pausa;
        #endregion
        #region TextBox
        public static System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
        #endregion
        #region Button
        public static System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();
        #endregion
        #region DrawError
        public static DrawError drawerror;
        #endregion
        #region Timer
        public static Timer timer = new Timer();
        #endregion
        #region Input_mouse
        public static Input_mouse input_mouse = new Input_mouse();
        #endregion
        #region SoundEffect
        public static SoundEffect sound;
        #endregion
        #region StoageDevice
        public static StorageDevice device;
        #endregion
        #region SaveGame
        public static SaveGame savegame = new SaveGame();
        #endregion
    }
}