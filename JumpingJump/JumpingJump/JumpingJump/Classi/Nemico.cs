using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumpingJump.Classi
{
    /// <summary>
    /// Clssse per gestire i nemici nel gioco
    /// </summary>
    public class Nemico
    {
        /// <summary>
        /// Costruttore vuoto. Posizione = 0, Vite = 1
        /// </summary>
        public Nemico()
        {
            try
            {
                _maxLife = 1;
                _life = _maxLife;
                _posizioneAttuale = Vector2.Zero;
                _textureNemico = VariabiliGioco.tx_nemico1;
                _textureProiettile = VariabiliGioco.tx_stella;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore standard
        /// </summary>
        /// <param name="maxLife">Numero di vite del nemico</param>
        /// <param name="posizione">Posizione del nemico</param>
        /// <param name="textureNemico">Texture del nemico</param>
        /// <param name="textureProiettile">Texture del proiettile</param>
        public Nemico(int maxLife, Vector2 posizione, Texture2D textureNemico, Texture2D textureProiettile)
        {
            try
            {
                _maxLife = maxLife;
                _life = maxLife;
                _posizioneAttuale = posizione;
                _textureNemico = textureNemico;
                _textureProiettile = textureProiettile;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        private Vector2 _posizioneAttuale = Vector2.Zero;
        private Vector2 _posizioneNemicoCenter = Vector2.Zero;
        private Vector2 _posizionePlayerCenter = Vector2.Zero;

        private ColliderTexture ctNemico;
        private ColliderTexture ctProiettile;
        private ColliderTexture ctPlayer;
        private Texture2D _textureNemico;
        private Texture2D _textureProiettile;

        private List<Proiettile> _proiettili = new List<Proiettile>();
        private static List<Proiettile> _nullProiettili = new List<Proiettile>();
        private int _life = 1;
        private int _maxLife = 1;
        private bool isFire;                    // India se si ha sparato
        private static bool isNullFire;         // Indica se il player sta sparando a vuoto

        private Color _colore = Color.White;    // Colore per il disegno del nemico


        /// <summary>
        /// Posizione attuale del nemico
        /// </summary>
        public Vector2 PosizioneAttuale
        {
            get { return _posizioneAttuale; }
            set { _posizioneAttuale = value; }
        }
        /// <summary>
        /// Ottiene la posizione centrale del nemico
        /// </summary>
        public Vector2 PosizioneAttualeCenter
        {
            get { return _posizioneNemicoCenter; }
        }
        /// <summary>
        /// Texture del nemico
        /// </summary>
        public Texture2D TextureNemico
        {
            get { return _textureNemico; }
            set { _textureNemico = value; }
        }
        /// <summary>
        /// Texture del poiettile
        /// </summary>
        public Texture2D TextureProiettile
        {
            get { return _textureProiettile; }
            set { _textureProiettile = value; }
        }
        /// <summary>
        /// Vite del nemico
        /// </summary>
        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }
        /// <summary>
        /// Vite massime del nemico
        /// </summary>
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        /// <summary>
        /// Lista dei proiettili associati a questo nemico
        /// </summary>
        public List<Proiettile> Proiettili
        {
            get { return _proiettili; }
            set { _proiettili = value; }
        }

        /// <summary>
        /// Disegna il nemico
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch senza il begin</param>
        public void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            try
            {
                InFire(time);
                spriteBatch.Begin();
                spriteBatch.Draw(_textureNemico, _posizioneAttuale, _colore);
                foreach (Proiettile proiettile in _proiettili)
                {
                    spriteBatch.Draw(_textureProiettile, proiettile.Location, null, Color.White, (float)proiettile.Angle, Vector2.Zero, 1f, SpriteEffects.None, 0);
                }
                spriteBatch.End();
                if (_colore != Color.White)
                    _colore = Color.White;
                ctNemico = new ColliderTexture(_textureNemico);
                ctPlayer = new ColliderTexture(VariabiliGioco.tx_player);
                if (VariabiliTemp.currBonus == null || VariabiliTemp.currBonus.Tipo == TipoBonus.Molla)
                {
                    if (VariabiliTemp.isSin)
                    {
                        if (ctPlayer.Collides(VariabiliTemp.posizionePlayer, ctNemico, _posizioneAttuale))
                        {
                            VariabiliGioco.isGame = false;
                            VariabiliGioco.isGameOver = true;
                        }
                    }
                    else
                    {
                        if (ctPlayer.Collides(VariabiliTemp.posizionePlayer, ctNemico, _posizioneAttuale))
                        {
                            VariabiliTemp.nemici.Remove(this);
                            VariabiliGioco.game.Jump();
                        }
                    } 
                }
                else
                    if (ctPlayer.Collides(VariabiliTemp.posizionePlayer, ctNemico, _posizioneAttuale))
                        VariabiliTemp.nemici.Remove(this);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna il nemico
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch</param>
        /// <param name="isInizialized">true se ha già il begin, false altrimenti</param>
        public void Draw(SpriteBatch spriteBatch, bool isInizialized, GameTime time)
        {
            try
            {
                if (isInizialized)
                    spriteBatch.End();

                Draw(spriteBatch, time);

                if (isInizialized)
                    spriteBatch.Begin();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Il player spara in una direzione casuale
        /// </summary>
        /// <param name="playerPosition"></param>
        public static void NullFire(Vector2 playerPosition)
        {
            try
            {
                Vector2 _posizionePlayerCenter = new Vector2();
                _posizionePlayerCenter.X = playerPosition.X + (VariabiliGioco.tx_player.Width / 2);
                _posizionePlayerCenter.Y = playerPosition.Y + 20;
                Vector2 direction = new Vector2(Variabili.random.Next(240), 0);
                Proiettile currProiet = new Proiettile(_posizionePlayerCenter, direction, Costanti.VELOCITA_PROIETTILE);
                currProiet.Direction = direction - _posizionePlayerCenter;
                currProiet.Direction.Normalize();
                currProiet.CalcAngle();
                _nullProiettili.Add(currProiet);
                isNullFire = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Il player sapra
        /// </summary>
        /// <param name="playerPosition">Posizione del player</param>
        public void Fire(Vector2 playerPosition)
        {
            try
            {
                _posizioneNemicoCenter = new Vector2();
                _posizioneNemicoCenter.X = _posizioneAttuale.X + (_textureNemico.Height / 2);
                _posizioneNemicoCenter.Y = _posizioneAttuale.Y + (_textureNemico.Width / 2);

                _posizionePlayerCenter = new Vector2();
                _posizionePlayerCenter.X = playerPosition.X + (VariabiliGioco.tx_player.Width / 2);
                _posizionePlayerCenter.Y = playerPosition.Y + 20;

                Proiettile currProiet = new Proiettile(_posizionePlayerCenter, _posizioneNemicoCenter, Costanti.VELOCITA_PROIETTILE);
                currProiet.Direction = _posizioneNemicoCenter - _posizionePlayerCenter;
                currProiet.Direction.Normalize();
                currProiet.CalcAngle();
                _proiettili.Add(currProiet);
                isFire = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Effettua lo spostamento del proiettile sparato
        /// </summary>
        private void InFire(GameTime time)
        {
            try
            {
                if (isFire)
                {
                    #region OLD VERSION
                    //if (x < 0)
                    //{
                    //    _posizioneProiettileAttuale.X = _posizioneProiettileAttuale.X - deltaX;
                    //    _posizioneProiettileAttuale.Y = _posizioneProiettile.Y - (_posizioneProiettileAttuale.X * K);                    
                    //}
                    //if (x > 0)
                    //{
                    //    _posizioneProiettileAttuale.X = _posizioneProiettileAttuale.X + deltaX;
                    //    _posizioneProiettileAttuale.Y = _posizioneProiettile.Y - (_posizioneProiettileAttuale.X * K);// -(_posizioneProiettile.X * K) / 100;
                    //}
                    //if (_posizioneProiettileAttuale.X > 250 || _posizioneProiettileAttuale.X < -10)
                    //{
                    //    _posizioneProiettileAttuale = Vector2.Zero;
                    //    isFire = false;
                    //}
                    //if (_posizioneProiettileAttuale.Y < 0 || _posizioneProiettileAttuale.Y > 320)
                    //{
                    //    _posizioneProiettileAttuale = Vector2.Zero;
                    //    isFire = false;
                    //}

                    //_posizioneProiettileAttuale = quadricIntercept(_posizionePlayerCenter, 5f, _posizioneNemicoCenter, 5f, _posizioneProiettileAttuale); 
                    #endregion

                    foreach (Proiettile proiettile in _proiettili)
                    {
                        proiettile.UpdatePosition(time);
                    }

                    CheckCollisionProiettili();
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Se si sta sparando e non ci sono nemici, spara a caso
        /// </summary>
        /// <param name="time"></param>
        public static void UpdateNullPosition(GameTime time)
        {
            try
            {
                if (isNullFire)
                {
                    for (int i = 0; i < _nullProiettili.Count; i++)
                    {
                        _nullProiettili[i].UpdatePosition(time);
                        if (!Helper.IsInWindow(_nullProiettili[i].Location))
                            _nullProiettili.RemoveAt(i);
                        if (_nullProiettili.Count == 0)
                            isNullFire = false;
                    }
                    foreach (Proiettile proiettile in _nullProiettili)
                    {
                        Variabili.spriteBatch.Begin();
                        Variabili.spriteBatch.Draw(VariabiliGioco.tx_proiettile, proiettile.Location, null, Color.White, (float)proiettile.Angle, Vector2.Zero, 1f, SpriteEffects.None, 0);
                        Variabili.spriteBatch.End();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Controlla se avviene una collisione tra un nemico e il proiettile
        /// </summary>
        private void CheckCollisionProiettili()
        {
            try
            {

                for (int i = 0; i < _proiettili.Count; i++)
                {
                    ctNemico = new ColliderTexture(_textureNemico);
                    ctProiettile = new ColliderTexture(_textureProiettile);

                    if (!Helper.IsInWindow(_proiettili[i].Location))
                    {
                        Debug.WriteLine("Rimosso perchè fuori schermo");
                        _proiettili.RemoveAt(i);
                    }

                    if (_proiettili.Count > 0 && ctNemico.Collides(_posizioneAttuale, ctProiettile, _proiettili[i].Location))
                    {
                        _life--;
                        if (Life <= 0)
                        {
                            _nullProiettili.AddRange(_proiettili);
                            VariabiliTemp.nemici.Remove(this);
                        }
                        Debug.WriteLine("Rimosso perchè ha colpito");
                        _proiettili.RemoveAt(i);
                        _colore = Color.Red;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        // QUADRATIC INTERCEPT
        //public Vector2 quadricIntercept(Vector2 i_position, float i_speed, Vector2 t_position, float t_speed, Vector2 t_normal)
        //{
        //    float tvx = t_normal.X * t_speed;
        //    float tvy = t_normal.Y * t_speed;
        //    float pdx = t_position.X - i_position.X;
        //    float pdy = t_position.Y - i_position.Y;

        //    float pdlength = Vector2.Normalize(t_position - i_position).Length();
        //    float d = pdx * pdx + pdy * pdy;
        //    float s = (tvx * tvx + tvy * tvy) - i_speed * i_speed;
        //    float q = (tvx * pdx + tvy * pdy);
        //    float sd = ((tvx * tvx + tvy * tvy) - i_speed * i_speed) * (tvx * pdx + tvy * pdy);
        //    float disc = (q * q) - s * d; // get rid of the fluff 
        //    float disclen = (float)Math.Sqrt(disc);

        //    float t1 = (-q + disclen) / s;
        //    float t2 = (-q - disclen) / s;

        //    float t = t1;
        //    if (t1 < 0.0f) { t = t2; }

        //    Vector2 aimpoint = Vector2.Zero;
        //    if (t > 0.0f)
        //    {
        //        aimpoint.X = t * tvx + t_position.X;
        //        aimpoint.Y = t * tvy + t_position.Y;
        //    }
        //    return aimpoint; // returns Vector2.Zero if no positive time to fire exists 
        //} 
    }
}
