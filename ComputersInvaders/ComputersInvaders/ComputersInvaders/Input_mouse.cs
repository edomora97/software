using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ComputersInvaders
{
    public class Input_mouse
    {

        public Input_mouse()
        {

        }
        public void input_mouse()
        {
            Variabili.stato_mouse = Mouse.GetState();
            if (Variabili.usa_mouse)
            {
                Variabili.posizione_mouse = new Vector2(Variabili.stato_mouse.X, Variabili.stato_mouse.Y);
                if (Variabili.posizione_mouse.Y > 300 && Variabili.posizione_mouse.X < Variabili.fine_schermo.X - 30 && Variabili.posizione_mouse.X > 0 && Variabili.posizione_mouse.Y < Variabili.fine_schermo.Y - 45)
                {
                    Variabili.posizione_pg = Variabili.posizione_mouse;
                }
            }
        }
    }
}
