using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ComputersInvaders
{
    public class DrawError : DrawableGameComponent
    {
        public DrawError(Game game)
            : base(game)
        {           

        }
        public void Drawerror(string Text)
        {
            Variabili.sprite_batch.Begin();
            Variabili.sprite_batch.DrawString(Variabili.font1, Text, new Vector2(10, Variabili.fine_schermo.Y - 20), Color.Red);
            Variabili.sprite_batch.End();
        }
    }
}
