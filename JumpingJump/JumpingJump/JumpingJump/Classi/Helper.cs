using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
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
    /// Classe statica con delle funzioni rapide
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Mostra un messaggio
        /// </summary>
        /// <param name="message">Testo del messaggio</param>
        /// <param name="title">Titolo della finestra</param>
        /// <param name="buttons">Bottoni della finestra</param>
        /// <param name="icon">Icona della finestra</param>
        public static void ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            try
            {
                MessageBox.Show(message, title, buttons, icon);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Mostra un messaggio
        /// </summary>
        /// <param name="message">Testo del messaggio</param>
        /// <param name="title">Titolo della finestra</param>
        public static void ShowMessage(string message, string title)
        {
            try
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Mostra un messaggio e poi chiude l'applicazione
        /// </summary>
        public static void ShowFatalError()
        {
            try
            {
                MessageBox.Show("Si è verificato un proble grave. \nL'applicazione deve essere chiusa", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Variabili.game.Exit();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Mostra un messaggio personalizzato e poi chiude l'applicazione
        /// </summary>
        /// <param name="text">Testo del messaggio</param>
        public static void ShowFatalError(string text)
        {
            try
            {
                MessageBox.Show(text, "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Variabili.game.Exit();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Ottiene una stringa contenente il tasto premuto (lettere) se viene prmuto il tasto Back viene restituito "-BACK-"
        /// </summary>
        /// <returns></returns>
        public static string GetChar()
        {
            try
            {
                KeyboardState keyboardState_old = VariabiliGioco.keyboardState_old, keyboardState_now = VariabiliGioco.keyboardState;
                if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.A) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.A))
                    return "A";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.B) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.B))
                    return "B";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.C) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.C))
                    return "C";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.D) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.D))
                    return "D";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.E) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.E))
                    return "E";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.F) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F))
                    return "F";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.G) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.G))
                    return "G";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.H) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.H))
                    return "H";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.I) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.I))
                    return "I";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.J) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.J))
                    return "J";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.K) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.K))
                    return "K";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.L) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.L))
                    return "L";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.M) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.M))
                    return "M";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.N) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.N))
                    return "N";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.O) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.O))
                    return "O";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.P) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.P))
                    return "P";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Q) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Q))
                    return "Q";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.R) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R))
                    return "R";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.S) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))
                    return "S";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.T) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.T))
                    return "T";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.U) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.U))
                    return "U";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.V) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.V))
                    return "V";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.W) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.W))
                    return "W";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.X) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.X))
                    return "X";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Y) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Y))
                    return "Y";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Z) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z))
                    return "Z";
                else if (keyboardState_old.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Back) && keyboardState_now.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Back))
                    return "-BACK-";
                else
                    return "";
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return "";
        }
        /// <summary>
        /// Conversione da gradi a radianti
        /// </summary>
        /// <param name="grad">Angolo in gradi</param>
        /// <returns></returns>
        public static double DegToRad(double grad)
        {
            try
            {
                return (Math.PI / 180) * grad;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return -1;
        }
        /// <summary>
        /// Conversione da radianti a gradi
        /// </summary>
        /// <param name="rad">Angolo in radianti</param>
        /// <returns></returns>
        public static double RadToDeg(double rad)
        {
            try
            {
                return rad * 180 / Math.PI;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return -1;
        }
        /// <summary>
        /// Restituisce la versione del programma
        /// </summary>
        /// <returns></returns>
        public static string Versione()
        {
            try
            {
                return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return "";
        }
        /// <summary>
        /// Apre una Texture2D dal file path. Path deve includere l'estensione ma non Content\
        /// </summary>
        /// <param name="path">Percorso dell'immagine da aprire (gif, jpg, png)</param>
        /// <returns></returns>
        public static Texture2D LoadTextureFromFile(string path)
        {
            try
            {
                //path = Variabili.game.Content.RootDirectory + "\\" + path;
                path = "Content\\" + path;
                Texture2D temp = null;
                try
                {
                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    temp = Texture2D.FromStream(Variabili.game.GraphicsDevice, stream);
                }
                catch
                {
                    ShowFatalError("Impossibile leggere: " + path);
                }
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Apre una Texture2D dal file path. Path deve includere l'estensione ma non Content\
        /// </summary>
        /// <param name="path">Percorso dell'immagine da aprire (gif, jpg, png)</param>
        /// <returns></returns>
        public static Texture2D LoadTextureFromFile(string path, Microsoft.Xna.Framework.Game game)
        {
            try
            {
                path = "Content\\" + path;
                Texture2D temp = null;
                try
                {
                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    temp = Texture2D.FromStream(game.GraphicsDevice, stream);
                }
                catch
                {
                    ShowFatalError("Impossibile leggere: " + path);
                }
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Ordina le posizioni della lista in base alla Y
        /// </summary>
        /// <param name="posizioni">Lista da ordinare</param>
        /// <returns></returns>
        public static List<Posizione> OrdinaElementi(List<Posizione> posizioni)
        {
            try
            {
                Posizione[] a = posizioni.ToArray();
                int x = a.Length;

                int i;
                int j;
                Posizione indice;

                for (i = 0; i < x; i++)
                {
                    indice = a[i];
                    j = i;

                    while ((j > 0) && (a[j - 1].Y > indice.Y))
                    {
                        a[j] = a[j - 1];
                        j--;
                    }
                    a[j] = indice;
                }

                List<Posizione> temp = new List<Posizione>();
                foreach (Posizione posizione in a)
                {
                    temp.Add(posizione);
                }
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Ordina la classifica in base al punteggio
        /// </summary>
        /// <param name="posizioni">Lista da ordinare</param>
        /// <returns></returns>
        public static List<ElementoClassifica> OrdinaElementi(List<ElementoClassifica> classifica)
        {
            try
            {
                ElementoClassifica[] a = classifica.ToArray();
                int x = a.Length;

                int i;
                int j;
                ElementoClassifica indice;

                for (i = 0; i < x; i++)
                {
                    indice = a[i];
                    j = i;

                    while ((j > 0) && (a[j - 1].Punteggio < indice.Punteggio))
                    {
                        a[j] = a[j - 1];
                        j--;
                    }
                    a[j] = indice;
                }

                List<ElementoClassifica> temp = new List<ElementoClassifica>();
                foreach (ElementoClassifica elemento in a)
                {
                    temp.Add(elemento);
                }
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return null;
        }        
        /// <summary>
        /// Restistuisce l'ipotenusa del cateto a e b
        /// </summary>
        /// <param name="a">Primo cateto</param>
        /// <param name="b">Secondo cateto</param>
        /// <returns></returns>
        public static double Pitagora(double a, double b)
        {
            try
            {
                double a2 = a * a;
                double b2 = a * a;
                return Math.Sqrt(a2 + b2);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return -1;
        }
        /// <summary>
        /// Restituisce l'ipotenusa tra il punto a e il punto b
        /// </summary>
        /// <param name="a">Posizione del primo vertice</param>
        /// <param name="b">Posizione del secondo vertice</param>
        /// <returns></returns>
        public static double Pitagora(Vector2 a, Vector2 b)
        {
            try
            {
                double a2 = Math.Pow(a.X - b.Y, 2);
                double b2 = Math.Pow(a.Y - b.Y, 2);
                return Math.Sqrt(a2 + b2);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return -1;
        }
        /// <summary>
        /// Indica se la posizione si trova all'interno dello schermo (margine 20px)
        /// </summary>
        /// <param name="pos">Posizione da controllare</param>
        /// <returns></returns>
        public static bool IsInWindow(Vector2 pos)
        {
            try
            {
                if (pos.X > 260 || pos.X < -20 || pos.Y > 340 || pos.Y < -20)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return false;
        }
        /// <summary>
        /// Indica se la posizione si trova all'interno del rettangolo
        /// </summary>
        /// <param name="pos">Posizione da controllare</param>
        /// <param name="rect">Rettangolo da controllare</param>
        /// <returns></returns>
        public static bool IsInWindow(Vector2 pos, Rectangle rect)
        {
            try
            {
                if (pos.X > rect.X + rect.Width || pos.X < rect.X || pos.Y > rect.Y + rect.Height || pos.Y < rect.Y)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return false;
        }
        /// <summary>
        /// Indica se il mouse si trova all'interno del rettangolo
        /// </summary>
        /// <param name="rectangle">Rettangolo da verificare se il mouse si strova all'interno</param>
        /// <returns></returns>
        public static bool IsMouseIn(Rectangle rectangle)
        {
            try
            {
                if (Mouse.GetState().X > rectangle.X && Mouse.GetState().Y > rectangle.Y)
                    if (Mouse.GetState().X < rectangle.X + rectangle.Width && Mouse.GetState().Y < rectangle.Y + rectangle.Height)
                        return true;
                return false;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return false;
        }
        /// <summary>
        /// Effettua la chiusura del gioco
        /// </summary>
        public static void Exit()
        {
            try
            {
                Variabili.game.Exit();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }        
        /// <summary>
        /// Restutuisce una stringa contenente il TimeSpan
        /// </summary>
        /// <param name="timeSpan">TimeSpan da convertire</param>
        /// <returns></returns>
        public static string TimeSpanToString(TimeSpan timeSpan)
        {
            try
            {
                string temp = "";
                if (timeSpan.Hours < 10)
                    temp += "0";
                temp += timeSpan.Hours.ToString() + "h:";
                if (timeSpan.Minutes < 10)
                    temp += "0";
                temp += timeSpan.Minutes.ToString() + "m:";
                if (timeSpan.Seconds < 10)
                    temp += "0";
                temp += timeSpan.Seconds.ToString() + "s";
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return "";
        }
        /// <summary>
        /// Restutuisce una stringa contenente il DateTime
        /// </summary>
        /// <param name="dateTime">DateTime da convertire</param>
        /// <returns></returns>
        public static string DateTimeToString(DateTime dateTime)
        {
            try
            {
                string temp = "";
                if (dateTime.Hour < 10)
                    temp += "0";
                temp += dateTime.Hour.ToString() + ":";
                if (dateTime.Minute < 10)
                    temp += "0";
                temp += dateTime.Minute.ToString() + ":";
                if (dateTime.Second < 10)
                    temp += "0";
                temp += dateTime.Second.ToString();
                return temp;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return "";
        }

        /// <summary>
        /// Disegna una linea sullo schermo
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch con già il Begin</param>
        /// <param name="v1">Primo vertice della linea</param>
        /// <param name="v2">Secondo vertice della linea</param>
        /// <param name="color">Colore della linea</param>
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 v1, Vector2 v2, Color color)
        {
            try
            {
                float lenght = 0.0f;
                lenght = Vector2.Distance(v1, v2);
                spriteBatch.Draw(VariabiliGioco.tx_dot, new Rectangle((int)v1.X, (int)v1.Y, (int)lenght, 3), color);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna una linea sullo schermo
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch con già il Begin</param>
        /// <param name="v1">Primo vertice della linea</param>
        /// <param name="v2">Secondo vertice della linea</param>
        /// <param name="color">Colore della linea</param>
        /// <param name="size">Spessore della linea</param>
        public static void DrawLine(SpriteBatch spriteBatch, Vector2 v1, Vector2 v2, Color color, int size)
        {
            try
            {
                float lenght = 0.0f;
                lenght = Vector2.Distance(v1, v2);
                spriteBatch.Draw(VariabiliGioco.tx_dot, new Rectangle((int)v1.X, (int)v1.Y, (int)lenght, size), color);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
