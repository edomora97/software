using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Classi
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
                _isRight = true;
                _life = 0;
                _speed = 1;
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
                _isRight = true;
                _life = 0;
                _speed = 1;
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
                _isRight = true;
                _life = 0;
                _speed = 1;
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
                _isRight = true;
                _life = 0;
                _speed = 1;
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
        private bool _isRight;
        private long _life;
        private float _speed;
        private Bonus _bonus;

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
        /// Ottiene o imposta il numero di salti effettuati su questo blocco
        /// </summary>
        public int Jump
        {
            get { return _jump; }
            set { _jump = value; }
        }
        /// <summary>
        /// Ottiene o imposta la vita del blocco
        /// </summary>
        public long Life
        {
            get { return _life; }
            set { _life = value; }
        }
        /// <summary>
        /// Ottiene o imposta la velocità del blocco
        /// </summary>
        public float Velocità
        {
            get { return _speed; }
            set { _speed = value; }
        }
        /// <summary>
        /// Ottiene o imposta il bonus associato al blocco
        /// </summary>
        public Bonus Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }


        /// <summary>
        /// Disegna il blocco attuale applicando le diverse trasformazioni
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch con il Begin già fatto</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                if (_tipo == TipoPosizione.Normale)
                    DisegnaNormale(spriteBatch);
                if (_tipo == TipoPosizione.Falso)
                    DisegnaFalso(spriteBatch);
                if (_tipo == TipoPosizione.MovimOrriz)
                    DisegnaMovimOrriz(spriteBatch);
                if (_tipo == TipoPosizione.Distruttibile)
                    DisegnaDistruttibile(spriteBatch);
                if (_tipo == TipoPosizione.SaltoSingolo)
                    DisegnaSaltoSingolo(spriteBatch);
                if (_bonus != null)
                    _bonus.Draw(spriteBatch);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna il blocco attuale applicando le diverse trasformazioni
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch con cui disegnare il blocco</param>
        /// <param name="isInizialized">True se spriteBatch è già stato inizializzato, false altrimenti</param>
        public void Draw(SpriteBatch spriteBatch, bool isInizialized)
        {
            try
            {
                if (!isInizialized)
                    spriteBatch.Begin();

                Draw(spriteBatch);

                if (!isInizialized)
                    spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Contiene una stringa con i dettagli della posizione
        /// </summary>
        /// <returns></returns>
        public string Details()
        {
            try
            {
                string temp = "{";
                temp += "X: " + PosizioneAttuale.X;
                temp += "; Y: " + PosizioneAttuale.Y;
                temp += "; Tipo: " + Tipo.ToString();
                temp += "; Jump: " + Jump.ToString();
                temp += "; Life: " + Life.ToString();
                temp += "}";
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return "";
        }
        /// <summary>
        /// Disegnaun blocco di tipo Normale
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch già inizializzato</param>
        private void DisegnaNormale(SpriteBatch spriteBatch)
        {
            try
            {
                spriteBatch.Draw(VariabiliGioco.tx_blockNormale, _posizioneAttuale, Color.White);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegnaun blocco di tipo Falso
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch già inizializzato</param>
        private void DisegnaFalso(SpriteBatch spriteBatch)
        {
            try
            {
                if (!_isRight)
                {
                    _posizioneAttuale.Y += 1.5f;
                    spriteBatch.Draw(VariabiliGioco.tx_blockFalsoDist, _posizioneAttuale, Color.White);
                }
                else
                    spriteBatch.Draw(VariabiliGioco.tx_blockFalso, _posizioneAttuale, Color.White);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegnaun blocco di tipo MovimOrriz
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch già inizializzato</param>
        private void DisegnaMovimOrriz(SpriteBatch spriteBatch)
        {
            try
            {
                // Se il blocco si muove verso destra e si trova a sinistra del limite
                if (_isRight && _posizioneAttuale.X < _x + Costanti.DELTA_X)
                {
                    // Sposta il blocco verso destra
                    _posizioneAttuale.X += _speed;
                    // Se si trova oltre il limite lo sposta verso sinistra
                    if (_posizioneAttuale.X >= _x + Costanti.DELTA_X)
                        _isRight = false;
                }

                // Se il blocco si muove verso sinistra e si trova più a destra della posizione iniziale
                if (_isRight == false && _posizioneAttuale.X > _x)
                {
                    // Sposta il blocco verso sinistra
                    _posizioneAttuale.X -= _speed;
                    // Se si trova più a sinistra della posizione iniziale, lo sposta verso destra
                    if (_posizioneAttuale.X <= _x)
                        _isRight = true;
                }

                // Disegna il blocco nella nuova posizione
                spriteBatch.Draw(VariabiliGioco.tx_blockMovimOrriz, _posizioneAttuale, Color.White);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        // RIMOSSO BLOCCO VERTICALE //
        ///// <summary>
        ///// Disegnaun blocco di tipo MovimVert
        ///// </summary>
        ///// <param name="spriteBatch">SpriteBatch già inizializzato</param>
        //private void DisegnaMovimVert(SpriteBatch spriteBatch)
        //{
        //    if (_isRight && _posizioneAttuale.Y < _y + Costanti.DELTA_Y)
        //    {
        //        _posizioneAttuale.Y += Costanti.VELOCITA_BLOCCHI_Y;
        //        if (_posizioneAttuale.Y >= _y + Costanti.DELTA_Y)
        //            _isRight = false;
        //    }
        //    if (_isRight == false && _posizioneAttuale.Y > _y)
        //    {
        //        // Sposta il blocco verso sinistra
        //        _posizioneAttuale.Y -= Costanti.VELOCITA_BLOCCHI_Y;
        //        // Se si trova più a sinistra della posizione iniziale, lo sposta verso destra
        //        if (_posizioneAttuale.Y <= _y)
        //            _isRight = true;
        //    }

        //    // Disegna il blocco nella nuova posizione
        //    spriteBatch.Draw(VariabiliGioco.tx_blockMovimVert, _posizioneAttuale, Color.White);
        //}
        /// <summary>
        /// Disegnaun blocco di tipo Distruttibile
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch già inizializzato</param>
        private void DisegnaDistruttibile(SpriteBatch spriteBatch)
        {
            try
            {
                if (_jump == 0)
                    spriteBatch.Draw(VariabiliGioco.txs_blockDistruttibile[0], PosizioneAttuale, Color.White);
                else
                    _life++;

                if (_life > 0 && _life <= 30)
                    spriteBatch.Draw(VariabiliGioco.txs_blockDistruttibile[1], PosizioneAttuale, Color.White);
                if (_life > 30 && _life <= 60)
                    spriteBatch.Draw(VariabiliGioco.txs_blockDistruttibile[2], PosizioneAttuale, Color.White);
                if (_life > 60 && _life <= 90)
                    spriteBatch.Draw(VariabiliGioco.txs_blockDistruttibile[3], PosizioneAttuale, Color.White);
                if (_life > 90 && _life <= 120)
                    spriteBatch.Draw(VariabiliGioco.txs_blockDistruttibile[4], PosizioneAttuale, Color.White);
                if (_life > 120)
                    VariabiliTemp.posizioni.Remove(this);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegnaun blocco di tipo SaltoSingolo
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch già inizializzato</param>
        private void DisegnaSaltoSingolo(SpriteBatch spriteBatch)
        {
            try
            {
                if (_jump > 0)
                    _posizioneAttuale = new Vector2(-250, 250);
                spriteBatch.Draw(VariabiliGioco.tx_blockSaltoSingolo, _posizioneAttuale, Color.White);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
