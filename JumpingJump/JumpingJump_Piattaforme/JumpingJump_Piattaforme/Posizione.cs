using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumpingJump.Piattaforme
{
    public class Posizione
    {
        /// <summary>
        /// Costruttore vuoto
        /// </summary>
        public Posizione() { }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="x">Coordinata X del blocco</param>
        /// <param name="y">Coordinata Y del blocco</param>
        public Posizione(float x, float y)
        {
            _x = x;
            _y = y;
            _posizioneAttuale = new Vector2(x, y);
            _tipo = Tipo.Normale;
            _isRight = true;
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="x">Coordinata X del blocco</param>
        /// <param name="y">Coordinata Y del blocco</param>
        /// <param name="tipo">Tipo di blocco</param>
        public Posizione(float x, float y, Tipo tipo)
        {
            _x = x;
            _y = y;
            _posizioneAttuale = new Vector2(x, y);
            _tipo = tipo;
            _isRight = true;
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="posizione">Posizione del blocco</param>
        public Posizione(Vector2 posizione)
        {
            _x = posizione.X;
            _y = posizione.Y;
            _posizioneAttuale = posizione;
            _tipo = Tipo.Normale;
            _isRight = true;
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="posizione">Posizione del blocco</param>
        /// <param name="tipo">Tipo di blocco</param>
        public Posizione(Vector2 posizione, Tipo tipo)
        {
            _x = posizione.X;
            _y = posizione.Y;
            _posizioneAttuale = posizione;
            _tipo = tipo;
            _isRight = true;
        }
        public Posizione(Vector2 posizione, Vector2 posizioneAttuale, Tipo tipo)
        {
            _x = posizione.X;
            _y = posizione.Y;
            _posizioneAttuale = posizioneAttuale;
            _tipo = tipo;
            _isRight = true;
        }


        private Tipo _tipo;
        private float _x;
        private float _y;
        private Vector2 _posizioneAttuale;
        private int _jump;
        private bool _isRight;

        /// <summary>
        /// Ottiene o imposta la direzione del blocco
        /// </summary>
        public bool IsRight
        {
            get { return _isRight; }
            set { _isRight = value; }
        }
        /// <summary>
        /// Ottiene o imposta la coordinata X del blocco
        /// </summary>
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        /// <summary>
        /// Ottiene o imposta la coordinata Y del blocco
        /// </summary>
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        /// <summary>
        /// Ottiene o imposta il tipo di blocco
        /// </summary>
        public Tipo Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        /// <summary>
        /// Ottiene o imposta le coordinate del blocco
        /// </summary>
        public Vector2 Coordinate
        {
            get { return new Vector2(_x, _y); }
            set { _x = value.X; _y = value.Y; }
        }
        /// <summary>
        /// Ottiene la posizione attuale del blocco
        /// </summary>
        public Vector2 PosizioneAttuale
        {
            get { return _posizioneAttuale; }
            set { _posizioneAttuale = value; }
        }
        /// <summary>
        /// Ottiene o imposta il numero di salti effettuati su questo blocco
        /// </summary>
        public int Jump
        {
            get { return _jump; }
            set { _jump = value; }
        }
    }
}
