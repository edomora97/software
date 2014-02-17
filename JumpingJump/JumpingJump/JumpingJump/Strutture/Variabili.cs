using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump
{
    public struct Variabili
    {
        /// <summary>
        /// Contiene la variabile del gioco
        /// </summary>
        public static Main game;
        /// <summary>
        /// Contiene il GraphicsDeviceManager del gioco
        /// </summary>
        public static GraphicsDeviceManager graphics;
        /// <summary>
        /// Genera numeri casuali
        /// </summary>
        public static Random random;
        /// <summary>
        /// Disegna oggetti sullo schermo
        /// </summary>
        public static SpriteBatch spriteBatch;
        /// <summary>
        /// Font della classifica, caratteri grandi
        /// </summary>
        public static SpriteFont FontClassificaL;
        /// <summary>
        /// Font del menu dei credits
        /// </summary>
        public static SpriteFont FontCreditMenu;
        /// <summary>
        /// Font della classifica, caratteri piccoli
        /// </summary>
        public static SpriteFont FontClassificaS;
        /// <summary>
        /// Font del menu statistiche
        /// </summary>
        public static SpriteFont FontStatistiche;
        /// <summary>
        /// Texture dello sfondo
        /// </summary>
        public static Texture2D sfondo;
        /// <summary>
        /// Il gameTime corrente
        /// </summary>
        public static GameTime gameTime;
    }
}