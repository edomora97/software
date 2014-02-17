using Microsoft.Xna.Framework;

namespace ComputersInvaders
{
    public class Personaggio : DrawableGameComponent
    {
        public Personaggio(Game par_game)
            : base(par_game)
        {

        }
        public override void Draw(GameTime gameTime)
        {
            Variabili.sprite_batch.Begin();
            Variabili.sprite_batch.Draw(Variabili.player, Variabili.posizione_pg, Color.White);
            Variabili.sprite_batch.End();
            base.Draw(gameTime);
        }
    }
}
