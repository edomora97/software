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
    /// <summary>
    /// Classe per la visualizzazione del menu credits
    /// </summary>
    public class Bonus
    {
        /// <summary>
        /// Costruttore della classe bonus
        /// </summary>
        public Bonus()
        {
            try
            {
                PosizioneBloccoChanged += new EventHandler(UpdatePosition);
                PosizioneBlocco = new Vector2();
                _tipo = TipoBonus.Nessuno;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore della classe bonus
        /// </summary>
        /// <param name="posizioneBlocco">Posizione del blocco associato al bonus</param>
        /// <param name="texture">Texture del bonus</param>
        public Bonus(Vector2 posizioneBlocco, Texture2D texture)
        {
            try
            {
                PosizioneBloccoChanged += new EventHandler(UpdatePosition);
                PosizioneBlocco = posizioneBlocco;
                _tipo = TipoBonus.Molla;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore della classe Bonus
        /// </summary>
        /// <param name="posizioneBlocco">Posizione del blocco associato al bonus</param>
        /// <param name="tipo">Tipo di bonus</param>
        /// <param name="texture">Texture del bonus</param>
        public Bonus(Vector2 posizioneBlocco, TipoBonus tipo, Texture2D texture)
        {
            try
            {
                PosizioneBloccoChanged += new EventHandler(UpdatePosition);
                _texture = texture;
                PosizioneBlocco = posizioneBlocco;
                _tipo = tipo;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        
        private Texture2D _texture;
        private TipoBonus _tipo;
        private Vector2 _posizione;
        private Vector2 _posizioneBlocco;
        private float _jumpHeight;
        private float _speed;
        private float _durata;
        private float _countTime;
        public Vector2 _direction;
        public float _velocitàCaduta = 1f;
        private bool _isFlying;
        private bool _isEndedFly;

        /// <summary>
        /// Ottiene o imposta il tipo di bonus
        /// </summary>
        public TipoBonus Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        /// <summary>
        /// Ottiene o imposta la posizione del bonus
        /// </summary>
        public Vector2 Posizione
        {
            get { return _posizione; }
            set { _posizione = value; }
        }
        /// <summary>
        /// Posizione del blocco a cui è associato il bonus
        /// </summary>
        public Vector2 PosizioneBlocco
        {
            get { return _posizioneBlocco; }
            set { _posizioneBlocco = value; OnPosizioneBloccoChanged(); }
        }
        /// <summary>
        /// Altezza del salto da fare
        /// </summary>
        public float JumpHeight
        {
            get { return _jumpHeight; }
            set { _jumpHeight = value; }
        }
        /// <summary>
        /// Ottiene o imposta la texture del bonus
        /// </summary>
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value;}
        }
        /// <summary>
        /// Ottiene true se il giocatore stà volando
        /// </summary>
        public bool IsFlying
        {
            get { return _isFlying; }
        }
        /// <summary>
        /// Ottiene o imposta la velocità del salto
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        /// <summary>
        /// Ottiene o imposta la durata del volo
        /// </summary>
        public float Durata
        {
            get { return _durata; }
            set { _durata = value; }
        }

        private event EventHandler PosizioneBloccoChanged;
        private void OnPosizioneBloccoChanged()
        {
            PosizioneBloccoChanged(null, EventArgs.Empty);
        }        
        /// <summary>
        /// Aggiorna la posizione del bonus
        /// </summary>
        private void UpdatePosition(object sender, EventArgs e)
        {
            try
            {
                _posizione = _posizioneBlocco;
                if (_texture != null)
                {
                    _posizione.X += (VariabiliGioco.tx_blockNormale.Width - _texture.Width) / 2;
                    _posizione.Y -= _texture.Height;
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Controlla se il giocatore ottiene il bonus
        /// </summary>
        public void CheckFly()
        {
            try
            {
                if (VariabiliTemp.posizionePlayer.X + VariabiliGioco.tx_player.Width > _posizione.X && VariabiliTemp.posizionePlayer.X < _posizione.X + _texture.Width)
                {
                    if (VariabiliTemp.posizionePlayer.Y < _posizione.Y + _texture.Height && VariabiliTemp.posizionePlayer.Y + VariabiliGioco.tx_player.Height > _posizione.Y)
                    {
                        if (VariabiliTemp.currBonus == null)
                        {
                            _isFlying = true;
                            VariabiliTemp.currBonus = this;
                            if (_tipo != TipoBonus.Molla)
                                _texture = new Texture2D(Variabili.game.GraphicsDevice, 1, 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Effettua la risalita
        /// </summary>
        public void Fly(GameTime gameTime)
        {
            try
            {
                if (_isFlying)
                {
                    _countTime += 1;
                    VariabiliTemp.posizionePlayer.Y -= 100 * _speed;
                    if (_countTime > _durata)
                    {
                        _isFlying = false;
                        _countTime = 0;
                        VariabiliTemp.isSin = true;
                        VariabiliGioco.game.canJump = true;
                    }
                }
                else
                {
                    _isEndedFly = true;
                    //_posizione = VariabiliTemp.posizionePlayer;
                    //_direction = new Vector2(_posizione.X, 400) - _posizione;
                    //Caduta(gameTime);
                    VariabiliTemp.currBonusCaduta = this;
                    if (VariabiliTemp.currBonusCaduta.Tipo == TipoBonus.Molla)
                        VariabiliTemp.currBonusCaduta.Texture = new Texture2D(Variabili.game.GraphicsDevice, 1, 1);
                    VariabiliTemp.currBonusCaduta.Posizione = VariabiliTemp.posizionePlayer;
                    VariabiliTemp.currBonusCaduta._direction = new Vector2(VariabiliTemp.currBonusCaduta.Posizione.X, 400) - VariabiliTemp.currBonusCaduta.Posizione;
                    VariabiliTemp.currBonus = null;
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna il bonus nella posizione corrente
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch con già il begin</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                spriteBatch.Draw(_texture, _posizione, Color.White);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Effettua lo spostamento
        /// </summary>
        /// <param name="gameTime"></param>
        public void Caduta(GameTime gameTime)
        {
            try
            {
                if (_isEndedFly)
                    _posizione += _direction * _velocitàCaduta * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_posizione.Y > 320)
                {
                    VariabiliTemp.currBonusCaduta = null;
                    VariabiliTemp.currBonus = null;
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
