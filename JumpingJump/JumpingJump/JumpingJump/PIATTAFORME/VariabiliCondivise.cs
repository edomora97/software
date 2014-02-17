using Microsoft.Xna.Framework;
using System;

namespace JumpingJump.Piattaforme
{
    /// <summary>
    /// Struttura delle variabili condivise con il programma JumpingJump Piattaforme
    /// </summary>
    public struct VariabiliCondivise
    {
        /// <summary>
        /// Tipo di blocco o di nemico
        /// </summary>
        public static TipoPosizione tipoBlocco;

        private static Vector2 _posizioneMouse;
        private static Vector2 _posizioneAttuale;
        private static float _offset;
        private static int _numPosizioni;

        private static Vector2 _posizione;
        /// <summary>
        /// Posizione del blocco o del nemico
        /// </summary>
        public static Vector2 Posizione
        {
            get { return _posizione; }
            set { _posizione = value;  OnPosizioneChanged(); }
        }
        /// <summary>
        /// Positione attuale del mouse
        /// </summary>
        public static Vector2 PosizioneMouse
        {
            get { return _posizioneMouse; }
            set { _posizioneMouse = value; OnMousePositionChanged(); }
        }
        /// <summary>
        /// Posizione attuale del blocco (uguale a 
        /// posizione se il blocco è fermo)
        /// </summary>
        public static Vector2 PosizioneAttuale
        {
            get { return _posizioneAttuale; }
            set { _posizioneAttuale = value; OnPosizioneAttualeChanged(); }
        }
        /// <summary>
        /// Indica se il blocco che se muove 
        /// stà andando a sinistra
        /// </summary>
        public static bool isRight;
        /// <summary>
        /// Indica il numero di vite del nemico
        /// </summary>
        public static int maxLife;
        /// <summary>
        /// Difficoltà del livello
        /// </summary>
        public static int difficoltà;
        /// <summary>
        /// Offset nel livello attuale
        /// </summary>
        public static float Offset
        {
            get { return _offset; }
            set { _offset = value; OnOffsetChanged(); }
        }
        /// <summary>
        /// Numero delle posizioni salvate
        /// </summary>
        public static int NumPosizioni
        {
            get { return _numPosizioni; }
            set { _numPosizioni = value; OnNumPosizioniChanged(); }
        }
        /// <summary>
        /// Velocità del blocco
        /// </summary>
        public static float Speed;
        /// <summary>
        /// Tipo di bonus associato al blocco
        /// </summary>
        public static TipoBonus Bonus;
        /// <summary>
        /// Altezza del salto con il bonus
        /// </summary>
        public static float BonusJumpHeight;
        /// <summary>
        /// Velocità di risalita relativa al bonus
        /// </summary>
        public static float BonusSpeed;

        /// <summary>
        /// Salva il livello corrente
        /// </summary>
        public static void Salva()
        {
            Input.Salva();
        }
        /// <summary>
        /// Resetta tutte le posizioni
        /// </summary>
        public static void Reset()
        {
            Input.Reset();
        }
        /// <summary>
        /// Popola il livello di 10000 posizioni casuali
        /// </summary>
        public static void Populate()
        {
            Input.Populate();
        }
        /// <summary>
        /// Esce dal gioco
        /// </summary>
        public static void Exit()
        {
            Input.Exit();
        }
        /// <summary>
        /// Cancella l'ultima posizione inserita
        /// </summary>
        public static void UnDo()
        {
            Input.UnDo();
        }

        public static void AddText(string text)
        {
            OnAddTextToLog(text);
        }

        public static event EventHandler PosizioneChanged;
        private static void OnPosizioneChanged()
        {
            if (PosizioneChanged != null)
                PosizioneChanged("Posizione changed", EventArgs.Empty);
        }    

        public static event EventHandler PosizioneAttualeChanged;
        private static void OnPosizioneAttualeChanged()
        {
            if (PosizioneAttualeChanged != null)
                PosizioneAttualeChanged("Posizione attuale changed", EventArgs.Empty);
        }

        public static event EventHandler OffsetChanged;
        private static void OnOffsetChanged()
        {
            if (OffsetChanged != null)
                OffsetChanged("Offset changed", EventArgs.Empty);
        }

        public static event EventHandler NumPosizioniChanged;
        private static void OnNumPosizioniChanged()
        {
            if (NumPosizioniChanged != null)
                NumPosizioniChanged("Num posizioni changed", EventArgs.Empty);
        }

        public static event EventHandler AddTextToLog;
        private static void OnAddTextToLog(string text)
        {
            if (AddTextToLog != null)
                AddTextToLog(text, EventArgs.Empty);
        }

        public static event EventHandler MousePositionChanged;
        private static void OnMousePositionChanged()
        {
            if (MousePositionChanged != null)
                MousePositionChanged("Mouse position changed", EventArgs.Empty);
        }
    }
}
