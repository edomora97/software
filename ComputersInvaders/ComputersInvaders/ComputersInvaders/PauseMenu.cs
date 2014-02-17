using Microsoft.Xna.Framework;


namespace ComputersInvaders
{
    public class PauseMenu : DrawableGameComponent
    {
        public PauseMenu(Game game)
            : base(game)
        {
            
        }
        public override void Draw(GameTime gameTime)
        {
            Variabili.sprite_batch.Begin();
            Variabili.sprite_batch.Draw(Variabili.background, new Vector2(0, 0), Color.White);
            Variabili.sprite_batch.DrawString(Variabili.font2, "PAUSA", new Vector2(Variabili.graphics.PreferredBackBufferWidth / 2 - 60, Variabili.graphics.PreferredBackBufferHeight / 2), colore());
            Variabili.sprite_batch.End();
            base.Draw(gameTime);
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
    }
}
