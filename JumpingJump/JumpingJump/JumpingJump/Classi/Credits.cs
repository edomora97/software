using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per la visualizzazione del menu credits
    /// </summary>
    public class Credits
    {
        /// <summary>
        /// Costruttore della classe Credits
        /// </summary>
        public Credits() { }
        
        /// <summary>
        /// Gestisce l'input da tastiera o da mouse
        /// </summary>
        private void Input()
        {
            try
            {
                if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Enter) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Enter))
                    btnMenu();
                if (Helper.IsMouseIn(new Rectangle(40, 275, VariabiliGioco.tx_btnMenu.Width, VariabiliGioco.tx_btnMenu.Height)) && VariabiliGioco.mouseState.LeftButton == ButtonState.Pressed)
                    btnMenu();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Azione associata al pulsante menu
        /// </summary>
        private void btnMenu()
        {
            try
            {
                VariabiliGioco.isCredits = false;
                VariabiliGioco.isMenu = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna il menu credits
        /// </summary>
        public void Draw()
        {
            try
            {
                Input();

                Variabili.spriteBatch.Begin();
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_sfondo_main, Vector2.Zero, Color.White);
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaL, "JUMPING JUMP", new Vector2(5, 10), Color.Red);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Copyright © 2012 Edoardo Morassutto", new Vector2(10, 30), Color.DarkGray, 0, Vector2.Zero, 0.9f, SpriteEffects.None, 0);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Creatore: Edoardo Morassutto", new Vector2(5, 50), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Programmatore: Edoardo Morassutto", new Vector2(5, 65), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Grafica:", new Vector2(5, 90), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Edoardo Morassutto", new Vector2(20, 105), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Anna Perin", new Vector2(20, 120), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Posizionatori:", new Vector2(5, 145), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Edoardo Morassutto", new Vector2(20, 160), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "------", new Vector2(20, 175), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "------", new Vector2(20, 190), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "Beta Tester:", new Vector2(5, 215), Color.Black);
                Variabili.spriteBatch.DrawString(Variabili.FontCreditMenu, "------", new Vector2(20, 230), Color.Black);
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 275), Color.OrangeRed);
                Variabili.spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
