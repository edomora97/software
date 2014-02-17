using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace JumpingJump.Piattaforme
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 320;
            graphics.PreferredBackBufferWidth = 240;
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            this.Window.Title = "JumpingJump_Piattaforme";

            Variabili.keyboard = Keyboard.GetState();
            Variabili.mouse = Mouse.GetState();
            Variabili.posizioni = new List<Posizione>();
            Variabili.input = new Input(this);
            Variabili.saveData = new SaveData();

            Components.Add(Variabili.input);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Variabili.blocco = Content.Load<Texture2D>("Block");
            Variabili.dot = Content.Load<Texture2D>("dot");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawLine(new Vector2(0, 320 + Variabili.offset), new Vector2(240, 320 + Variabili.offset), Color.Red);
            foreach (Posizione posizione in Variabili.posizioni)
            {
                if (posizione.Tipo == Tipo.Normale)
                    spriteBatch.Draw(Variabili.blocco, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.White);
                if (posizione.Tipo == Tipo.Falso)
                    spriteBatch.Draw(Variabili.blocco, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.Brown);
                if (posizione.Tipo == Tipo.MovimOrriz)
                    spriteBatch.Draw(Variabili.blocco, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.Orange);
                if (posizione.Tipo == Tipo.Distruttibile)
                    spriteBatch.Draw(Variabili.blocco, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.Gold);
                if (posizione.Tipo == Tipo.SaltoSingolo)
                    spriteBatch.Draw(Variabili.blocco, new Vector2(posizione.PosizioneAttuale.X, posizione.PosizioneAttuale.Y + Variabili.offset), Color.LightGray);
            }
            spriteBatch.Draw(Variabili.blocco, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        void DrawLine(Vector2 v1, Vector2 v2, Color color)
        {
            float lenght = 0.0f;
            lenght = Vector2.Distance(v1, v2);
            spriteBatch.Draw(Variabili.dot, new Rectangle((int)v1.X, (int)v1.Y, (int)lenght, 3), color);
        }
    }
}
