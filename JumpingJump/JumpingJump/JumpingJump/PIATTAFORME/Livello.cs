using System;
using System.Collections.Generic;
using System.Diagnostics;
using JumpingJump.Classi;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Piattaforme
{
    /// <summary>
    /// Classe che contiene un livello. Una lista di posizioni
    /// </summary>
    public class Livello
    {
        /// <summary>
        /// Costruttore vuoto. La difficoltà è 0
        /// </summary>
        public Livello()
        {
            try
            {
                _difficoltà = 0;
                _posizioni = new List<Posizione>();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore, copia la lista da posizioni. La difficoltà è 0.
        /// </summary>
        /// <param name="posizioni">Posizioni da copiare</param>
        public Livello(List<Posizione> posizioni)
        {
            try
            {
                this._posizioni = posizioni;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore completo.
        /// </summary>
        /// <param name="posizioni">Posizioni da copiare</param>
        /// <param name="difficoltà">Difficoltà del livello</param>
        public Livello(List<Posizione> posizioni, int difficoltà)
        {
            try
            {
                _posizioni = posizioni;
                _difficoltà = difficoltà;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        private List<Posizione> _posizioni;
        private List<Bonus> _bonus;
        private int _difficoltà;

        /// <summary>
        /// Posizioni all'interno del livello
        /// </summary>
        public List<Posizione> Posizioni
        {
            get { return _posizioni; }
            set { _posizioni = value; }
        }
        /// <summary>
        /// Bonus all'interno del livello
        /// </summary>
        public List<Bonus> Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }
        /// <summary>
        /// Difficoltà del livello
        /// </summary>
        public int Difficoltà
        {
            get { return _difficoltà; }
            set { _difficoltà = value; }
        }
    }
}
