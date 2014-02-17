using System;
using System.Diagnostics;
using JumpingJump.Classi;
using Microsoft.Xna.Framework;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

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
            try
            {
                _x = x;
                _y = y;
                _posizioneAttuale = new Vector2(x, y);
                _tipo = TipoPosizione.Normale;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="x">Coordinata X del blocco</param>
        /// <param name="y">Coordinata Y del blocco</param>
        /// <param name="tipo">Tipo di blocco</param>
        public Posizione(float x, float y, TipoPosizione tipo)
        {
            try
            {
                _x = x;
                _y = y;
                _posizioneAttuale = new Vector2(x, y);
                _tipo = tipo;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="posizione">Posizione del blocco</param>
        public Posizione(Vector2 posizione)
        {
            try
            {
                _x = posizione.X;
                _y = posizione.Y;
                _posizioneAttuale = posizione;
                _tipo = TipoPosizione.Normale;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="posizione">Posizione del blocco</param>
        /// <param name="tipo">Tipo di blocco</param>
        public Posizione(Vector2 posizione, TipoPosizione tipo)
        {
            try
            {
                _x = posizione.X;
                _y = posizione.Y;
                _posizioneAttuale = posizione;
                _tipo = tipo;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="posizione">Posizione del blocco</param>
        /// <param name="posizioneAttuale">Posizione attuale del blocco</param>
        /// <param name="tipo">Tipo di blocco</param>
        public Posizione(Vector2 posizione, Vector2 posizioneAttuale, TipoPosizione tipo)
        {
            try
            {
                _x = posizione.X;
                _y = posizione.Y;
                _posizioneAttuale = posizioneAttuale;
                _tipo = tipo;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore della classe Posizione
        /// </summary>
        /// <param name="posizione">Posizione del blocco</param>
        /// <param name="tipo">Tipo di blocco</param>
        /// <param name="jump">Numero di salti del blocco / Vite del nemico</param>
        public Posizione(Vector2 posizione, TipoPosizione tipo, int jump)
        {
            try
            {
                _x = posizione.X;
                _y = posizione.Y;
                _posizioneAttuale = posizione;
                _tipo = tipo;
                _jump = jump;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }


        private TipoPosizione _tipo;
        private float _x;
        private float _y;
        private Vector2 _posizioneAttuale;
        private int _jump;
        private float _speed;
        private Bonus _bonus;

        /// <summary>
        /// Ottiene o imposta la velocità del blocco
        /// </summary>
        public float Velocità
        {
            get { return _speed; }
            set { _speed = value; }
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
        public TipoPosizione Tipo
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
        /// Ottiene o imposta il numero di salti effettuati su questo blocco. 
        /// Se il tipo è Nemico allora rappresenta il numero di vite
        /// </summary>
        public int Jump
        {
            get { return _jump; }
            set { _jump = value; }
        }
        /// <summary>
        /// Ottiene o imposta il bonus associato al blocco
        /// </summary>
        public Bonus Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }
    }
}
