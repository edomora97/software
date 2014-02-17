using Microsoft.Xna.Framework.Input;

namespace ComputersInvaders
{
    public class Input
    {
        
        public Input()
        {

        }
        public void input()
        {
            Variabili.stato_tastiera = Keyboard.GetState();
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Right) && (Variabili.posizione_pg_2.X < Variabili.fine_schermo.X + 15))
                Variabili.posizione_pg.X += Variabili.velocità;
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Left) && (Variabili.posizione_pg.X > 0))
                Variabili.posizione_pg.X -= Variabili.velocità;
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Left) && (Variabili.stato_tastiera.IsKeyDown(Keys.RightShift)))
                Variabili.posizione_pg.X -= Variabili.velocità;
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Down) && (Variabili.posizione_pg_2.Y < Variabili.fine_schermo.Y - 15))
                Variabili.posizione_pg.Y += Variabili.velocità;
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Up) && (Variabili.posizione_pg.Y > 300))
                Variabili.posizione_pg.Y -= Variabili.velocità;
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Enter))
                Variabili.game_over = false;
            if (Variabili.stato_tastiera.IsKeyDown(Keys.W) && Variabili.stato_tastiera.IsKeyDown(Keys.LeftAlt))
            {
                Variabili.incrementoY += 1;
                Variabili.truccata = true;
            }
            if (Variabili.stato_tastiera.IsKeyDown(Keys.S) && Variabili.stato_tastiera.IsKeyDown(Keys.LeftControl))
            {
                Variabili.incrementoY -= 1;
                Variabili.truccata = true;
            }
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Escape))
                Variabili.game.Exit();
            if (Variabili.stato_tastiera.IsKeyDown(Keys.LeftShift))
            {
                Variabili.velocità = 15f;
                Variabili.truccata = true;
            }
            if (Variabili.stato_tastiera.IsKeyUp(Keys.RightShift))
                Variabili.velocità = 7f;
            if (Variabili.stato_tastiera.IsKeyDown(Keys.Space))
            {
                Variabili.pause_temp = true;
            }
            if (Variabili.stato_tastiera.IsKeyUp(Keys.Space))
            {
                if (Variabili.pause_temp)
                {
                    if (Variabili.pause)
                        Variabili.pause = false;
                    else
                        Variabili.pause = true;
                    Variabili.pause_temp = false;
                }
            }

            if (Variabili.stato_tastiera.IsKeyDown(Keys.M))
            {
                Variabili.usa_mouse_temp = true;
            }
            if (Variabili.stato_tastiera.IsKeyUp(Keys.M))
            {
                if (Variabili.usa_mouse_temp)
                {
                    if (Variabili.usa_mouse)
                        Variabili.usa_mouse = false;
                    else
                        Variabili.usa_mouse = true;
                    Variabili.usa_mouse_temp = false;
                }
            }

#if DEBUG
            if (Variabili.stato_tastiera.IsKeyDown(Keys.F12))
            {
                Variabili.schermo_intero_temp = true;
            }
            if (Variabili.stato_tastiera.IsKeyUp(Keys.F12))
            {
                if (Variabili.schermo_intero_temp)
                {
                    if (Variabili.schermo_intero)
                    {
                        Variabili.schermo_intero = false;
                        Variabili.graphics.IsFullScreen = false;
                        Variabili.graphics.ApplyChanges();
                    }
                    else
                    {
                        Variabili.schermo_intero = true;
                        Variabili.graphics.IsFullScreen = true;
                        Variabili.graphics.ApplyChanges();
                    }
                    Variabili.schermo_intero_temp = false;
                }
            }   
#endif
            
        }
    }
}
