using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe statica per il disegno dei blocchi dei vari tipi. Se viene restituito false il bloccl deve essere cancellato
    /// </summary>
    public static class Blocco
    {
        /// <summary>
        /// Disegna un blocco normale indistruttibile
        /// </summary>
        /// <param name="texture">Texture del blocco da disegnare</param>
        /// <param name="posizione">Posizione del blocco da disegnare</param>
        public static bool DisegnaNormale(SpriteBatch spriteBatch, Texture2D texture, Vector2 posizione)
        {
            try
            {
                // Disegna semplicemente il blocco
                spriteBatch.Draw(texture, posizione, Color.White);
                return true;
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore C01: " + ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Disegna un blocco falso (dove non è possibile saltarci sopra). E' identico a DisegnaNormale
        /// </summary>
        /// <param name="texture">Texture del blocco da disegnare</param>
        /// <param name="posizione">POsizione del blocco da disegnare</param>
        public static bool DisegnaFalso(SpriteBatch spriteBatch, Texture2D texture, Vector2 posizione)
        {
            try
            {
                // Disegna semplicemente il blocco         
                spriteBatch.Draw(texture, posizione, Color.White);
                return true;
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore C02: " + ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Disegna un blocco che si muove orrizontalmente dalla posizione a posizione + delta
        /// </summary>
        /// <param name="texture">Texture del blocco da disegnare</param>
        /// <param name="posizione">Posizione di partenza del bloco da disegnare</param>
        /// <param name="posizione_new">Posizione attuale del blocco da disegnare</param>
        /// <param name="delta">Corsa (in px) del blocco</param>
        public static bool DisegnaMovimOrriz(SpriteBatch spriteBatch, Texture2D texture, Vector2 posizione, Vector2 posizione_new, float delta)
        {
            try
            {
                // Muove il blocco all'inteno dell'intervallo
                if (posizione_new.X <= posizione.X)
                    posizione_new.X += Costanti.VELOCITA_BLOCCHI_X;
                if (posizione_new.X >= posizione.X + delta)
                    posizione_new.X -= Costanti.VELOCITA_BLOCCHI_X;

                // Disegna il blocco nella nuova posizione
                spriteBatch.Draw(texture, posizione_new, Color.White);
                return true;
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore C03: " + ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Disegna un blocco che si muove verticalmente dalla posizione a posizione + delta
        /// </summary>
        /// <param name="texture">Texture del blocco da disegnare</param>
        /// <param name="posizione">Posizione di partenza del bloco da disegnare</param>
        /// <param name="posizione_new">Posizione attuale del blocco da disegnare</param>
        /// <param name="delta">Corsa (in px) del blocco</param>
        public static bool DisegnaMovimVert(SpriteBatch spriteBatch, Texture2D texture, Vector2 posizione, Vector2 posizione_new, float delta)
        {
            try
            {
                // Muove il blocco all'inteno dell'intervallo
                if (posizione_new.Y <= posizione.Y)
                    posizione_new.Y += Costanti.VELOCITA_BLOCCHI_Y;
                if (posizione_new.Y >= posizione.Y + delta)
                    posizione_new.Y -= Costanti.VELOCITA_BLOCCHI_Y;

                // Disegna il blocco nella nuova posizione
                spriteBatch.Draw(texture, posizione_new, Color.White);
                return true;
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore C04: " + ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Disegna un blocco distruttibile. Dopo 5 salti il blocco viene distrutto.
        /// </summary>
        /// <param name="textures">Array di texture da utilizzare del disegno: [0] blocco originale, [...], [4] blocco distrutto</param>
        /// <param name="posizione">Posizione del blocco da disegnare</param>
        /// <param name="jumped">Numero attuale di salti effettuati</param>
        public static bool DisegnaDistruttibile(SpriteBatch spriteBatch, Texture2D[] textures, Vector2 posizione, int jumped)
        {
            try
            {
                if (textures.Length != 5)
                    Helper.ShowFatalError();
                Texture2D text = textures[0];
                if (jumped == 0)
                    text = textures[0];
                if (jumped == 1)
                    text = textures[1];
                if (jumped == 2)
                    text = textures[2];
                if (jumped == 3)
                    text = textures[3];
                if (jumped == 4)
                    text = textures[4];
                else
                    return false;
                spriteBatch.Draw(text, posizione, Color.White);
                return true;
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore C05: " + ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Disegna un blocco dove è possibile saltarci sopra una sola volta. Restutuisce false se il blocco è da cancellare
        /// </summary>
        /// <param name="texture">Texture del blocco</param>
        /// <param name="posizione">Posizione del blocco</param>
        /// <param name="jumped">Numero di salti effettuati su quella piattaforma (se maggiore di 0 restituisce false)</param>
        public static bool DisegnaSaltoSingolo(SpriteBatch spriteBatch, Texture2D texture, Vector2 posizione, int jumped)
        {
            try
            {
                // Se si è già saltato sopra questo blocco, restituisce false e il blocco verrà cancellato
                if (jumped > 0)
                    return false;
                // Altrimenti disegna il blocco
                else
                {
                    spriteBatch.Draw(texture, posizione, Color.White);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore C06: " + ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Disegna automaticamente un blocco in base alle informazioni in posizione
        /// </summary>
        /// <param name="posizione">Posizione del blocco (contiene anche il tipo e il numero di rimbalzi)</param>
        /// <param name="posizione_new">Posizione attuale del blocco, da utilizzare se il blocco è in movimento</param>
        /// <param name="texture">Array di texture da utilizzare per il disegno del blocco (se non serve array verrà usata texture[0])</param>
        /// <param name="delta">Corsa del blocco in movimento</param>
        /// <returns></returns>
        public static bool DisegnaAuto(SpriteBatch spriteBatch, Posizione posizione, Vector2 posizione_new, Texture2D[] texture, int delta)
        {
            try
            {
                // Seleziona quale metodo utilizzare in base al tipo di blocco
                if (posizione.Tipo == Tipo.Normale)
                    return DisegnaNormale(Variabili.spriteBatch, texture[0], posizione.Coordinate);
                if (posizione.Tipo == Tipo.Falso)
                    return DisegnaFalso(spriteBatch, texture[0], posizione.Coordinate);
                if (posizione.Tipo == Tipo.MovimOrriz)
                    return DisegnaMovimOrriz(spriteBatch, texture[0], posizione.Coordinate, posizione_new, delta);
                if (posizione.Tipo == Tipo.MovimVert)
                    return DisegnaMovimVert(spriteBatch, texture[0], posizione.Coordinate, posizione_new, delta);
                if (posizione.Tipo == Tipo.Distruttibile)
                    return DisegnaDistruttibile(spriteBatch, texture, posizione.Coordinate, posizione.Jump);
                if (posizione.Tipo == Tipo.SaltoSingolo)
                    return DisegnaSaltoSingolo(spriteBatch, texture[0], posizione.Coordinate, posizione.Jump);
                return false;
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore C11: " + ex.Message);
                return true;
            }
        }
    }
}
