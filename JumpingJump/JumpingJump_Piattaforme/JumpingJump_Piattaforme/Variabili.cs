using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

namespace JumpingJump.Piattaforme
{
    public struct Variabili
    {
        public static KeyboardState keyboard;
        public static KeyboardState keyboard_prev;
        public static MouseState mouse;
        public static MouseState mouse_prev;

        public static List<Posizione> posizioni;

        public static Texture2D blocco;
        public static Texture2D dot;

        public static Input input;

        public static int offset;

        public static SaveData saveData;

        public static int index = 0;
    }

    public enum Tipo
    {
        Normale, Falso, MovimOrriz, Distruttibile, SaltoSingolo
    }
}