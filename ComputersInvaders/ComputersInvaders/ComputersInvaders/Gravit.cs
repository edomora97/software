using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace ComputersInvaders
{
    public class Gravità
    {
        public Vector2 applica_grav(Vector2 posizione)
        {
            Variabili.forza_grav = 0.0002f;
            Variabili.incrementoY += Variabili.forza_grav;
            Variabili.inc_velocità = Variabili.incrementoY;
            posizione.Y += Variabili.inc_velocità;
            return posizione;
        }
    }
}
