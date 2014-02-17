using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
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
    /// Classe per il disegno e la gestione della classifica
    /// </summary>
    public class Classifica
    {
        /// <summary>
        /// Costruttore base per la classe
        /// </summary>
        public Classifica()
        {
            try
            {
                VariabiliTemp._classifica = new List<ElementoClassifica>();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore che copia la classifica da una lista
        /// </summary>
        /// <param name="classifica">Lista da cui copiare la classifica</param>
        public Classifica(List<ElementoClassifica> classifica)
        {
            try
            {
                VariabiliTemp._classifica = classifica;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        private int index = 0;
        /// <summary>
        /// Imposta o ottiene la classifica
        /// </summary>
        public List<ElementoClassifica> classifica
        {
            get { return VariabiliTemp._classifica; }
            set { VariabiliTemp._classifica = value; }
        }

        /// <summary>
        /// Cancella tutti i valori della classifica e sostituisce con: 
        /// "Nessuno" e 0
        /// </summary>
        public void Reset()
        {
            try
            {
                // Cancella tutti gli elementi della classifica
                VariabiliTemp._classifica.Clear();
                // Riempie la classifica con n copie di un elemento
                for (int i = 0; i < Costanti.CLASSIFICA_SAVED; i++)
                {
                    VariabiliTemp._classifica.Add(new ElementoClassifica("Nessuno", 0));
                }
                VariabiliTemp.totalGame = 0;
                VariabiliTemp.totalJump = 0;
                VariabiliTemp.totalScore = 0;
                VariabiliTemp.avarangeJump = 0;
                VariabiliTemp.avarangeScore = 0;
                VariabiliTemp.lastJump = 0;
                VariabiliTemp.lastScore = 0;
                VariabiliTemp.totalGameTime = new TimeSpan();
                Salva();
                Debug.WriteLine("Classifica resettata");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Cancella tutti i valori della classifica e sostituisce con: 
        /// Messaggio di errore e 0
        /// </summary>
        /// <param name="error">Messaggio di errore</param>
        public void Reset(string error)
        {
            try
            {
                // Cancella tutti gli elementi della classifca
                VariabiliTemp._classifica.Clear();
                // Riempie la classifica con n copie di un elemento
                for (int i = 0; i < Costanti.CLASSIFICA_SAVED; i++)
                {
                    VariabiliTemp._classifica.Add(new ElementoClassifica(error, 0));
                }
                VariabiliTemp.totalGame = 0;
                VariabiliTemp.totalJump = 0;
                VariabiliTemp.totalScore = 0;
                VariabiliTemp.avarangeJump = 0;
                VariabiliTemp.avarangeScore = 0;
                VariabiliTemp.lastJump = 0;
                VariabiliTemp.lastScore = 0;
                VariabiliTemp.totalGameTime = new TimeSpan();
                Salva();
                Debug.WriteLine("Classifica resettata");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Agguinge un valore alla classifica e mantiene la lunghezza al valore prefissato (Variabili.CLASSIFICA_SAVED)
        /// </summary>
        /// <param name="nome">Nome del giocatore</param>
        /// <param name="punteggio">Punteggio del giocatore</param>
        /// <param name="jumpNo">Numero di salti in quella partita</param>
        public void Add(string nome, int punteggio, int jumpNo)
        {
            try
            {
                // Aggiunge un nuovo elemento alla classifica
                VariabiliTemp._classifica.Add(new ElementoClassifica(nome, punteggio));
                // Ordina la classifica in base al punteggio
                VariabiliTemp._classifica = Helper.OrdinaElementi(VariabiliTemp._classifica);
                // Fino a quando la lunghezza della classifica è maggiore del limite, viene rimosso l'ultimo elemento
                while (VariabiliTemp._classifica.Count > Costanti.CLASSIFICA_SAVED)
                {
                    VariabiliTemp._classifica.RemoveAt(VariabiliTemp._classifica.Count - 1);
                }
                VariabiliTemp.totalJump += jumpNo;
                VariabiliTemp.totalGame++;
                VariabiliTemp.totalScore += punteggio;
                VariabiliTemp.avarangeJump = VariabiliTemp.totalJump / VariabiliTemp.totalGame;
                VariabiliTemp.avarangeScore = VariabiliTemp.totalScore / VariabiliTemp.totalGame;
                VariabiliTemp.lastJump = jumpNo;
                VariabiliTemp.lastScore = punteggio;
                Salva();
                Debug.WriteLine("Aggiunto a classifica: " + nome + ", " + punteggio.ToString());
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Disegna la classifica sullo schermo. 
        /// Deve essere richiamato ogni ciclo di clock
        /// </summary>
        public void Draw()
        {
            // Controlla l'input
            Input();            
            try
            {
                Variabili.spriteBatch.Begin();

                // Disegna lo sfondo e il titolo del menu
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_sfondo_main, Vector2.Zero, Color.White);
                Variabili.spriteBatch.Draw(VariabiliGioco.tx_hightScores, new Vector2(20, 20), Color.White);

                if (index == 0)
                {
                    // Disegna i pulsanti ed evidenzia quello con indice 0
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 200), Color.OrangeRed);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnReset, new Vector2(40, 240), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnStats, new Vector2(40, 280), Color.White);
                }
                if (index == 1)
                {
                    // Disegna i pulsanti ed evidenzia quello con indice 1
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 200), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnReset, new Vector2(40, 240), Color.OrangeRed);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnStats, new Vector2(40, 280), Color.White);
                }
                if (index == 2)
                {
                    // Disegna i pulsanti ed evidenzia quello con indice 2
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnMenu, new Vector2(40, 200), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnReset, new Vector2(40, 240), Color.White);
                    Variabili.spriteBatch.Draw(VariabiliGioco.tx_btnStats, new Vector2(40, 280), Color.OrangeRed);
                }
                // Disegna il nome delle colonne
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaL, "NOME", new Vector2(40, 70), Color.Blue);
                Variabili.spriteBatch.DrawString(Variabili.FontClassificaL, "PUNTI", new Vector2(140, 70), Color.Blue);

                try
                {
                    // Variabile temporanea che indica la posizione Y della riga
                    int y = 90;
                    foreach (ElementoClassifica elemento in VariabiliTemp._classifica)
                    {
                        // Disegna ogni elemento della classifica
                        elemento.Disegna(Variabili.spriteBatch, Variabili.FontClassificaS, new Vector2(40, y), new Vector2(140, y));
                        // Incrementa di 15 la riga successiva
                        y += 15;
                    }
                }
                catch
                {
                    // Cancella la classifica e restituisce un errore
                    Reset("ERROR");
                }

                Variabili.spriteBatch.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Controlla l'input dell'applicazione all'interno del menu classifica
        /// </summary>
        private void Input()
        {
            try
            {
                if (VariabiliTemp.classificaTemp)
                {
                    // Se viene premuto il tasto su decrementa l'indice
                    if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Up) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Up) && index > 0)
                    {
                        index--;
                    }
                    // Se viene premuto il tasto giù incrementa l'indice
                    if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Down) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Down) && index < Costanti.PULSANTI_CLASSIFICA - 1)
                    {
                        index++;
                    }
                    // Se viene premuto il tasto Enter esegue l'azione in base all'indice
                    if (VariabiliGioco.keyboardState.IsKeyDown(Keys.Enter) && VariabiliGioco.keyboardState_old.IsKeyUp(Keys.Enter))
                    {
                        // In base all'indice esegue l'azione specifica
                        switch (index)
                        {
                            case 2: BtnStats(); break;
                            case 1: BtnReset(); break;
                            case 0: BtnMenu(); break;
                            default: Helper.ShowFatalError(); break;
                        }
                    }

                    if (VariabiliGioco.mouseState.X >= 40 && VariabiliGioco.mouseState.X <= 40 + VariabiliGioco.tx_btnMenu.Width)
                        if (VariabiliGioco.mouseState.Y >= 200 && VariabiliGioco.mouseState.Y <= 200 + VariabiliGioco.tx_btnMenu.Height)
                            index = 0;
                    if (VariabiliGioco.mouseState.X >= 40 && VariabiliGioco.mouseState.X <= 40 + VariabiliGioco.tx_btnReset.Width)
                        if (VariabiliGioco.mouseState.Y >= 240 && VariabiliGioco.mouseState.Y <= 240 + VariabiliGioco.tx_btnReset.Height)
                            index = 1;
                    if (VariabiliGioco.mouseState.X >= 40 && VariabiliGioco.mouseState.X <= 40 + VariabiliGioco.tx_btnReset.Width)
                        if (VariabiliGioco.mouseState.Y >= 280 && VariabiliGioco.mouseState.Y <= 280 + VariabiliGioco.tx_btnReset.Height)
                            index = 2;
                    if (VariabiliGioco.mouseState.LeftButton == ButtonState.Pressed && VariabiliGioco.mouseState_old.LeftButton == ButtonState.Released)
                    {
                        if (Helper.IsMouseIn(new Rectangle(40, 200, VariabiliGioco.tx_btnMenu.Width, VariabiliGioco.tx_btnMenu.Height)))
                            BtnMenu();
                        if (Helper.IsMouseIn(new Rectangle(40, 240, VariabiliGioco.tx_btnReset.Width, VariabiliGioco.tx_btnReset.Height)))
                            BtnReset();
                        if (Helper.IsMouseIn(new Rectangle(40, 280, VariabiliGioco.tx_btnReset.Width, VariabiliGioco.tx_btnReset.Height)))
                            BtnStats();
                    }
                }
                VariabiliTemp.classificaTemp = true;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Entra nel menu statistiche. Utilizzo per il bottone "STATS"
        /// </summary>
        private void BtnStats()
        {
            VariabiliTemp.statisticheTemp = false;
            VariabiliGioco.isClassifica = false;
            VariabiliGioco.isStatistiche = true;
        }
        /// <summary>
        /// Resetta la classifica. Utilizzo per il bottone "RESET"
        /// </summary>
        private void BtnReset()
        {
            try
            {
                Reset();
                Debug.WriteLine("Premuto reset");
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore E21: " + ex.Message);
            }
        }
        /// <summary>
        /// Ritorna al menu. Utilizzo per il bottone "MENU"
        /// </summary>
        private void BtnMenu()
        {
            try
            {
                VariabiliGioco.isClassifica = false;
                VariabiliGioco.isGameOver = false;
                VariabiliGioco.isMenu = true;
                Debug.WriteLine("Premuto menu");
            }
            catch (Exception ex)
            {
                Helper.ShowFatalError("Errore E22: " + ex.Message);
            }
        }
        /// <summary>
        /// Salva la classifica
        /// </summary>
        public void Salva()
        {
            try
            {
                // Crea un stream al file non compresso
                Stream stream = new FileStream(@"Content\Data\Save\save.xml", FileMode.Create, FileAccess.ReadWrite);
                // Crea una classe con i dati da salvare
                Data data = new Data();
                // Riempie la classe con i dati
                data.classifica = VariabiliTemp._classifica;
                data.avarangeJump = VariabiliTemp.avarangeJump;
                data.avarangeScore = VariabiliTemp.avarangeScore;
                data.lastJump = VariabiliTemp.lastJump;
                data.lastScore = VariabiliTemp.lastScore;
                data.totalGame = VariabiliTemp.totalGame;
                data.totalJump = VariabiliTemp.totalJump;
                data.totalScore = VariabiliTemp.totalScore;
                data.ore = VariabiliTemp.totalGameTime.Hours;
                data.min = VariabiliTemp.totalGameTime.Minutes;
                data.sec = VariabiliTemp.totalGameTime.Seconds;

                // Crea un serializzatore di dati Xml
                XmlSerializer serializer = new XmlSerializer(typeof(Data));
                // Serializza in un fie Xml non compresso
                serializer.Serialize(stream, data);
                // Chiude lo stream di dati
                stream.Close();
                // Comprime il file
                using (FileStream inFile = File.OpenRead(@"Content\Data\Save\save.xml"))
                {
                    using(FileStream outFile = File.Create(@"Content\Data\Save\Data.dat"))
                    {
                        using(GZipStream compress = new GZipStream(outFile, CompressionMode.Compress))
	                    {
                            inFile.CopyTo(compress);
	                    }
                    }
                }
                // Cancella il file compresso
                File.Delete(@"Content\Data\Save\save.xml");
                Debug.WriteLine("Classifica salvata");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Carica la classifica
        /// </summary>
        public void Carica()
        {
            Stream stream = null;
            try
            {
                FileStream inFile = new FileStream(@"Content\Data\Save\Data.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                FileStream outFile = new FileStream(@"Content\Data\Save\save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                GZipStream dec = new GZipStream(inFile, CompressionMode.Decompress);
                dec.CopyTo(outFile);
                inFile.Close();
                outFile.Close();

                // Crea uno stream al file della classifica decompresso
                stream = new FileStream(@"Content\Data\Save\save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                // Crea una classe vuota
                Data data;
                // Crea un deserializzatore
                XmlSerializer deserializer = new XmlSerializer(typeof(Data));
                // Riempie la classe con i dati deserializzati
                data = (Data)deserializer.Deserialize(stream);
                // Chiude lo stream
                stream.Close();
                // Riempie i dati della classifica con quelli deserializzati
                VariabiliTemp._classifica = data.classifica;
                VariabiliTemp.avarangeJump = data.avarangeJump;
                VariabiliTemp.avarangeScore = data.avarangeScore;
                VariabiliTemp.lastJump = data.lastJump;
                VariabiliTemp.lastScore = data.lastScore;
                VariabiliTemp.totalGame = data.totalGame;
                VariabiliTemp.totalJump = data.totalJump;
                VariabiliTemp.totalScore = data.totalScore;
                VariabiliTemp.totalGameTime = new TimeSpan(data.ore, data.min, data.sec);

                // Cancella il fil edecompresso
                File.Delete(@"Content\Data\Save\save.xml");
                Debug.WriteLine("Classifica caricata");
            }
            catch
            {
                stream.Close();
                Helper.ShowMessage("Errore nel caricamento della classifica. Verrà resettata.", "Errore");
                Reset("ERROR");
            }
        }
        /// <summary>
        /// Ottiene il record all'interno della classifica
        /// </summary>
        /// <returns></returns>
        public ElementoClassifica GetRecord()
        {
            try
            {
                Salva();
                Carica();
                return classifica[0];
            }
            catch
            {
                Helper.ShowMessage("Errore nel file della classifica. Verrà resettata.", "Errore");
                Reset("ERROR");
                return GetRecord();
            }
        }
    }

    /// <summary>
    /// Classe che serve per contenere un elemento della classifica (nome e punteggio)
    /// </summary>
    public class ElementoClassifica
    {
        /// <summary>
        /// Costruttore vuoto
        /// </summary>
        public ElementoClassifica() { }
        /// <summary>
        /// Costruttore completo
        /// </summary>
        /// <param name="nome">Nome del player</param>
        /// <param name="punteggio">Punteggio del player</param>
        public ElementoClassifica(string nome, int punteggio)
        {
            try
            {
                _nome = nome;
                _punteggio = punteggio;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        private string _nome;
        private int _punteggio;

        /// <summary>
        /// Ottiene o imposta il nome del giocatore
        /// </summary>
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        /// <summary>
        /// Ottiene o imposta il punteggio
        /// </summary>
        public int Punteggio
        {
            get { return _punteggio; }
            set { _punteggio = value; }
        }

        /// <summary>
        /// Disegna in nome e il punteggio
        /// </summary>
        /// <param name="sb">SpriteBatch (deve essere già stata effettuata la chiamata Begin e dovrà essere effettuata la chiamata End</param>
        /// <param name="sf">SpriteFonte da tilizzare per scrivere</param>
        /// <param name="pos1">Posizione del nome</param>
        /// <param name="pos2">Posizione del punteggio</param>
        public void Disegna(SpriteBatch sb, SpriteFont sf, Vector2 pos1, Vector2 pos2)
        {
            try
            {
                sb.DrawString(sf, _nome, pos1, Color.Red);
                sb.DrawString(sf, _punteggio.ToString(), pos2, Color.Red);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }                    
        }
        /// <summary>
        /// Disegna in nome e il punteggio se isNotBeggined è true non deve essere già stata effettuata la chiamata Begin e non dovrà essere effettuata la chiamata End
        /// </summary>
        /// <param name="sb">SpriteBatch da utilizzare</param>
        /// <param name="sf">SpriteFonte da utilizzare per scrivere</param>
        /// <param name="pos1">Posizione del nome</param>
        /// <param name="pos2">Posizione del punteggio</param>
        /// <param name="isNotBeggined">Specifica se la chiamate begin non è già stata effettuata</param>
        public void Disegna(SpriteBatch sb, SpriteFont sf, Vector2 pos1, Vector2 pos2, bool isNotBeggined)
        {
            try
            {
                if (isNotBeggined)
                    sb.Begin();
                sb.DrawString(sf, _nome, pos1, Color.Red);
                sb.DrawString(sf, _punteggio.ToString(), pos2, Color.Red);
                if (isNotBeggined)
                    sb.End();
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }  
        }
    }

    /// <summary>
    /// Classe per il salvataggio/caricamento del file classifica
    /// </summary>
    [Serializable]
    public class Data
    {
        /// <summary>
        /// Lista degli elementi della classifica
        /// </summary>
        public List<ElementoClassifica> classifica;
        /// <summary>
        /// Numero totale dei salti fatti
        /// </summary>
        public int totalJump;
        /// <summary>
        /// Numero totale di partite fatte
        /// </summary>
        public int totalGame;
        /// <summary>
        /// Punteggio totale di tutte le partite
        /// </summary>
        public int totalScore;
        /// <summary>
        /// Numero di salti della partita precedente
        /// </summary>
        public int lastJump;
        /// <summary>
        /// Punteggio dell'ultima partita fatta
        /// </summary>
        public int lastScore;
        /// <summary>
        /// Numero medio di salti fatti
        /// </summary>
        public float avarangeJump;
        /// <summary>
        /// Punteggio medio delle partite
        /// </summary>
        public float avarangeScore;
        /// <summary>
        /// Tempo totale di gioco
        /// </summary>
        public int ore, min, sec;
    }
}
