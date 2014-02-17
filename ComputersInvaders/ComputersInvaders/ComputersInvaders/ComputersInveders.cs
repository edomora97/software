using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace ComputersInvaders
{
    public class ComputersInveders : Microsoft.Xna.Framework.Game
    {
        public ComputersInveders()
        {
            Window.Title = "Computers Invader";
            Variabili.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Variabili.graphics.PreferredBackBufferWidth = 800;
            Variabili.graphics.PreferredBackBufferHeight = 600;
        }
        protected override void Initialize()
        {
            #region Variabili
            Variabili.probability = 0.005f;
            Variabili.timer_count = 3;
            Variabili.timer.Interval = 1000;
            Variabili.timer.Tick+=new EventHandler(timer_Tick);
            Variabili.drawerror = new DrawError(this);
            Variabili.sprite_batch = new SpriteBatch(GraphicsDevice);
            Variabili.player1 = new Personaggio(this);
            Variabili.game = this;
            Variabili.posizione_pg = new Vector2(Variabili.graphics.PreferredBackBufferWidth / 2, Variabili.graphics.PreferredBackBufferHeight - 70);
            Variabili.velocità = 5f;
            Variabili.background = Variabili.game.Content.Load<Texture2D>("background");
            Variabili.font1 = Variabili.game.Content.Load<SpriteFont>("font1");
            Variabili.font2 = Variabili.game.Content.Load<SpriteFont>("font2");
            Variabili.dot = Variabili.game.Content.Load<Texture2D>("dot");
            Variabili.player = Variabili.game.Content.Load<Texture2D>("player");
            Variabili.nemico = Variabili.game.Content.Load<Texture2D>("nemico");
            Variabili.sound = Content.Load<SoundEffect>("Sonoro");
            Variabili.player_ct = new ColliderTexture(Variabili.player);
            Variabili.block_ct = new ColliderTexture(Variabili.nemico);
            Variabili.game.Components.Add(new GamerServicesComponent(Variabili.game));
            #endregion
            Variabili.classifica.Inizialize();
            Variabili.classifica.GetClassifica();
            Components.Add(Variabili.player1);
            Variabili.sound.Play();
            base.LoadContent();
        }


        protected override void Update(GameTime gameTime)
        {
            Variabili.sprite_batch.Begin();
            Variabili.sprite_batch.Draw(Variabili.background, new Vector2(0, 0), Color.White);
            Variabili.sprite_batch.End();
            #region Non Pausa
            if (!Variabili.pause)
            {
                Variabili.posizione_nemico = Variabili.gravità.applica_grav(Variabili.posizione_nemico);
                if (Variabili.random.NextDouble() < Variabili.probability)
                {
                    float x = (float)Variabili.random.NextDouble() * GraphicsDevice.Viewport.Width;
                    Variabili.blockPosition.Add(new Variabili.BlockData()
                    {
                        posizione = new Vector2(x, -100)
                    });
                }
                #region Non gameover
                if (!Variabili.game_over)
                {
                    for (int i = 0; i < Variabili.blockPosition.Count; i++)
                    {
                        Variabili.blockPosition[i] = new Variabili.BlockData() { posizione = new Vector2(Variabili.blockPosition[i].posizione.X, Variabili.gravità.applica_grav(Variabili.blockPosition[i].posizione).Y) };

                        if (Variabili.player_ct.Collides(Variabili.posizione_pg, Variabili.block_ct, Variabili.blockPosition[i].posizione))
                        {
                            Variabili.game_over = true;
                        }



                        if (Variabili.blockPosition[i].posizione.Y - 25 > Variabili.graphics.PreferredBackBufferHeight)
                        {
                            Variabili.punteggio++;
                            Variabili.blockPosition.RemoveAt(i);
                            i--;
                            Variabili.probability += 0.001f;
                        }
                    }

                    foreach (var blockdata in Variabili.blockPosition)
                    {
                        Variabili.sprite_batch.Begin();
                        Variabili.sprite_batch.Draw(Variabili.nemico, blockdata.posizione, Color.WhiteSmoke);
                        Variabili.sprite_batch.End();
                    }
                }
                #endregion
                Variabili.fine_schermo.X = Variabili.graphics.PreferredBackBufferWidth;
                Variabili.fine_schermo.Y = Variabili.graphics.PreferredBackBufferHeight;
            }
            #endregion
            Variabili.input.input(); // -----------------
            Variabili.input_mouse.input_mouse();
            if (gameTime.IsRunningSlowly)
            {
                Variabili.sprite_batch.Begin();
                Variabili.sprite_batch.DrawString(Variabili.font1, "TILT", new Vector2(Variabili.graphics.PreferredBackBufferWidth - 70, 10), Color.PeachPuff);
                Variabili.sprite_batch.End();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (EnterPressed())
            {
                Variabili.punteggio = 0;
                Variabili.inc_velocità = 0;
                Variabili.incrementoY = 0;
                Variabili.probability = 0.005f;
                Variabili.game_over = false;
                Variabili.nome_temp = false;
                Variabili.truccata = false;
            }
            #region Pausa
            if (Variabili.pause)
            {
                Variabili.pausa = new PauseMenu(Variabili.game);
                Variabili.pausa.Draw(gameTime);
            }
            #endregion

            #region Non Pausa
            if (!Variabili.pause)
            {
                #region Gameover
                if (Variabili.game_over)
                {
                    Variabili.sprite_batch.Begin();
                    Variabili.sprite_batch.DrawString(Variabili.font2, "Game Over", new Vector2(Variabili.graphics.PreferredBackBufferWidth / 2 - 82, Variabili.graphics.PreferredBackBufferHeight / 2 - 10), colore());
                    Variabili.sprite_batch.DrawString(Variabili.font1, "Punteggio: " + Variabili.punteggio.ToString(), new Vector2(Variabili.graphics.PreferredBackBufferWidth / 2 - 70, Variabili.graphics.PreferredBackBufferHeight / 2 + 20), Color.Red);
                    Variabili.sprite_batch.End();
                    Variabili.inc_velocità = 0;
                    Variabili.incrementoY = 0;
                    Variabili.blockPosition.RemoveRange(0, Variabili.blockPosition.Count);
                    Variabili.classifica.DrawClassifica();
                    if (!Variabili.truccata)
                    {
                        Variabili.punteggio_temp = Variabili.punteggio;
                        if (!Variabili.nome_temp)
                        {
                            Variabili.nome_temp = true;
                            Variabili.nome = Variabili.classifica.ShowTextBoxDialog();
                            Variabili.classifica.GetClassifica();
                            if (!Variabili.isClassificated)
                            {
                                Variabili.isClassificated = true;
                                Variabili.classifica.CalcClassifica(Variabili.nome, Variabili.punteggio_temp);
                                Variabili.classifica.SetClassifica();
                            }
                        }
                    }
                    
                }
                #endregion
                #region Non gameover
                else
                {
                    Variabili.timer.Start();
                    if (Variabili.showError)
                    {
                        Variabili.drawerror.Drawerror(Variabili.errore);
                    }
                    string a = ((double)Variabili.inc_velocità).ToString("N3");
                    Variabili.nome_temp = false;
                    Variabili.sprite_batch.Begin();
                    Variabili.sprite_batch.DrawString(Variabili.font1, "Punteggio: " + Variabili.punteggio.ToString(), new Vector2(10, 10), Color.Red, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                    Variabili.sprite_batch.DrawString(Variabili.font1, "Velocita: " + a + " px/s", new Vector2(10, 30), Color.Red, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
                    if (Variabili.usa_mouse)
                        Variabili.sprite_batch.DrawString(Variabili.font1, "MOUSE! (beta)", new Vector2(10, 60), Color.Red, 0, new Vector2(0, 0), 1.2f, SpriteEffects.None, 0);
                    Variabili.sprite_batch.End();
                    draw_line(new Vector2(0, 300), new Vector2(Variabili.graphics.PreferredBackBufferWidth, 300), Color.Red);
                    base.Draw(gameTime);
                    Variabili.posizione_pg_2 = new Vector2((Variabili.posizione_pg.X + Variabili.player.Height), (Variabili.posizione_pg.Y + Variabili.player.Width));
                }
                #endregion
            }
            #endregion
        }
        void draw_line(Vector2 v1, Vector2 v2, Color color)
        {
            float angle = 0.0f;
            float lenght = 0.0f;
            Vector2 centerpoint;
            lenght = Vector2.Distance(v1, v2);
            centerpoint = new Vector2(lenght / 2, 1);
            angle = (float)Math.Atan2((float)(v2.Y - v1.Y), (float)(v2.X - v1.X));
            Variabili.sprite_batch.Begin();
            Variabili.sprite_batch.Draw(Variabili.dot, new Rectangle((int)v1.X, (int)v1.Y, (int)lenght, 1), null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
            Variabili.sprite_batch.End();
        }

        public bool EnterPressed()
        {
            if (Variabili.stato_tastiera.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                Variabili.nome_temp = false;
                Variabili.isClassificated = false;
                return true;
            }
            return false;
        }

        public Color colore()
        {
            int a;
            int b;
            int c;
            a = Variabili.random.Next(254);
            b = Variabili.random.Next(254);
            c = Variabili.random.Next(254);
            Color d = new Color(a, b, c, 255);
            return d;
        }
        public void timer_Tick(Object sender, EventArgs e)
        {
            if (Variabili.timer_count < 0)
            {
                Variabili.timer.Stop();
                Variabili.showError = false;
            }
            else
            {
                Variabili.timer_count--;
            }
        }
    }
}
