using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per la gestione di un proiettile
    /// </summary>
    public class Proiettile
    {
        /// <summary>
        /// Costruttore standard
        /// </summary>
        /// <param name="start">Posizione di partenza</param>
        /// <param name="end">Posizione di arrivo</param>
        /// <param name="speed">Velocità di movimento</param>
        public Proiettile(Vector2 start, Vector2 end, float speed)
        {
            try
            {
                _location = start;
                Start = start;
                _direction = end;
                _speed = speed;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        
        private Vector2 _location;
        private Vector2 _direction;
        private float _speed;
        private double _angle;

        /// <summary>
        /// Posizione attuale del proiettile
        /// </summary>
        public Vector2 Location
        {
            get { return _location; }
            set { _location = value; }
        }
        /// <summary>
        /// Posizione di partenza del proiettile
        /// </summary>
        public Vector2 Start
        {
            get;
            set;
        }
        /// <summary>
        /// Posizione finale del proiettile
        /// </summary>
        public Vector2 Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        /// <summary>
        /// Velocità del proiettile
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        /// <summary>
        /// Angolo di rotazione del proiettile
        /// </summary>
        public double Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        /// <summary>
        /// Aggiorna la posizione del proiettile
        /// </summary>
        /// <param name="gameTime">GameTime corrente per stabilizzare il movimento (può essere null)</param>
        public void UpdatePosition(GameTime gameTime)
        {
            try
            {
                if (gameTime != null)
                    _location += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                else
                    _location += _direction * _speed * 0.016666f;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Calcola l'angolo di inclinazione del proiettile
        /// </summary>
        /// <returns></returns>
        public double CalcAngle()
        {
            try
            {
                _angle = Math.Acos((_direction.X - Start.X) / Helper.Pitagora(Start, _direction)) + Math.PI;
                return _angle;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return -1;
        }
    }
}
