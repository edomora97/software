using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ComputersInvaders
{
    class CreaNemici : DrawableGameComponent
    {
        Random random = new Random();
        public CreaNemici(Game par_game)
            : base(par_game)
        {

        }
        bool a = false;
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            
            Variabili.nemico = Variabili.game.Content.Load<Texture2D>("nemico");
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {           
            base.Draw(gameTime);
        }
        public void crea()
        {
            Variabili.nemico_sb = new SpriteBatch(GraphicsDevice);
            Variabili.posizione_nemico_X = random.Next((int)Variabili.fine_schermo.X);
            Variabili.posizione_nemico = new Vector2(Variabili.posizione_nemico_X, 0);
            Variabili.nemico_sb.Begin();
            if (!a)
            {
                Variabili.nemico_sb.Draw(Variabili.nemico, Variabili.posizione_nemico, null, Color.Red);
                a = true;
            }
            Variabili.nemico_sb.End();
        }
    }
}
