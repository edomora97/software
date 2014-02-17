using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
 * 
*/

namespace JumpingJump.Classi
{
    public class LoadData
    {
        //OLD VERSION
        //
        // -------
        //
        ///// <summary>
        ///// Carica tutti i livelli (Content\Data\Posizioni\*.liv). Dento al file liv deve esserci un solo file chiamato conme il contentitore
        ///// </summary>
        //public static void CaricaLivelli()
        //{
        //    Directory.CreateDirectory(@"Content\Data\Posizioni\Temp");
        //    // Lista temporanea dei livelli
        //    List<Livello> livelli = new List<Livello>();
        //    // Ottiene le informazioni della cartella dove sono salvati i vivelli
        //    DirectoryInfo dir = new DirectoryInfo("Content\\Data\\Posizioni");
        //    // Lista dei file con estensione " *.liv "
        //    FileInfo[] listaFile = dir.GetFiles("*.liv");
        //    foreach (FileInfo file in listaFile)
        //    {
        //        // Crea un deserializzatore per XML
        //        XmlSerializer deserializer = new XmlSerializer(typeof(DataLivelli));
        //        // Decomprime il livello
        //        Helper.UnZip(file.FullName, "Content\\Data\\Posizioni\\Temp\\");
        //        // Ottiene le informazioni del file attuale decompresso
        //        FileInfo info = new FileInfo(file.FullName);
        //        // Crea uno stream al file decompresso
        //        FileStream stream = new FileStream("Content\\Data\\Posizioni\\Temp\\" + file.Name, FileMode.Open, FileAccess.Read);
        //        // Crea una classe vuota
        //        DataLivelli data = new DataLivelli();
        //        // Riempie la classe con i dati deserializzati
        //        data = (DataLivelli)deserializer.Deserialize(stream);
        //        // Chiude lo stream
        //        stream.Close();
        //        // Aggiunge i livelli che ci sono nel file decompresso
        //        livelli.AddRange(data.livelli);
        //        foreach (FileInfo _file in new DirectoryInfo("Content\\Data\\Posizioni\\Temp").GetFiles())
        //        {
        //            File.Delete(_file.FullName);
        //        }
        //        Directory.Delete("Content\\Data\\Posizioni\\Temp\\");
        //    }
        //    // Salva i livelli importati in un luovo accessibile
        //    VariabiliTemp.livelliTemp = livelli;
        //}

        ///// <summary>
        ///// Genera una lista di livelli, uno per ogni difficoltà. Richiama anche CaricaLivelli e CalcolaPosizioni
        ///// </summary>
        //public static void GeneraRandom()
        //{
        //    // Carica i livelli
        //    CaricaLivelli();
        //    // Lista temporanea dei livelli con il random già eseguito
        //    List<Livello> levelTemp = new List<Livello>();
        //    // Lista di liste di livelli, ogni lista (major) contiene liste (junior)
        //    // della stessa difficoltà.
        //    List<List<Livello>> livelli = new List<List<Livello>>();
        //    for (int i = 0; i < Costanti.MAX_LEVEL; i++)
        //    {
        //        // Aggiunge un elemento alla lista di liste che ha i come difficoltà
        //        livelli.Add(new List<Livello>());
        //        // Per ogni livello, se la difficoltà è uguale a i la aggiunge alla
        //        // lista i
        //        foreach (Livello livello in VariabiliTemp.livelliTemp)
        //        {
        //            if (livello.Difficoltà == i)
        //                livelli[i].Add(livello);                    
        //        }
        //    }
        //    // Applica la funzione di random per ogni difficoltà
        //    for (int i = 0; i < livelli.Count; i++)
        //    {
        //        try
        //        {
        //            int rnd = Variabili.random.Next(livelli[i].Count);
        //            levelTemp.Add(livelli[i][rnd]);
        //        }
        //        catch
        //        {
        //            levelTemp.Add(new Livello());
        //        }
        //    }
        //    // Salva in un luovo raggiungibile la lista di livelli
        //    VariabiliTemp.livelliTemp = levelTemp;
        //    // Calcola le posizioni a partire dai livelli
        //    CalcolaPosizioni();
        //}

        ///// <summary>
        ///// Ordina le posizioni e i livelli, aggiunge tutti i livelli a posizioni
        ///// </summary>
        //public static void CalcolaPosizioni()
        //{
        //    // Ordina ogni elemento di ogni livello
        //    foreach (Livello livello in VariabiliTemp.livelliTemp)
        //    {
        //        livello.Posizioni = Helper.OrdinaElementi(livello.Posizioni);
        //    }

        //    // Incremento verso l'alto dei blocchi di livello superiore
        //    float[] maxY = new float[VariabiliTemp.livelliTemp.Count];
        //    // Assegna il valore a maxY
        //    for (int i = 0; i < VariabiliTemp.livelliTemp.Count; i++)
        //    {
        //        maxY[i] = FindHightest(VariabiliTemp.livelliTemp[i].Posizioni).Y;
        //        if (i > 0)
        //            maxY[i] += maxY[i - 1];
        //    }

        //    //Applica lo spostamento a tutti i blocchi 
        //    for (int i = 1; i < VariabiliTemp.livelliTemp.Count; i++)
        //    {
        //        foreach (Posizione posizione in VariabiliTemp.livelliTemp[i-1].Posizioni)
        //        {
        //            //posizione.Y -= maxY[i-1];
        //            VariabiliTemp.posizioni.Add(posizione);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Ottiene la posizione dell'elemento che si trova più in alto in una lista ordinata
        ///// </summary>
        ///// <param name="posizioni">Posizioni da cui cercare l'elemento che si trova più in alto</param>
        ///// <returns></returns>
        //private static Posizione FindHightest(List<Posizione> posizioni)
        //{
        //    try
        //    {
        //        int count = posizioni.Count - 1;
        //        return posizioni[count];
        //    }
        //    catch
        //    {
        //        return new Posizione();
        //    }
        //}

        /// <summary>
        /// Costruttore della classe LoadData
        /// </summary>
        public LoadData()
        { }

        /// <summary>
        /// Lista dei livelli caricati dai file
        /// </summary>
        private List<Livello> livelli_loaded = new List<Livello>();

        /// <summary>
        /// Carica un file liv e aggiunge tutti i livelli in esso contenuti in VariabiliTemp.livelli
        /// </summary>
        /// <param name="path"></param>
        private void CaricaLiv(string path)
        {
            try
            {
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                XmlSerializer deserializer = new XmlSerializer(typeof(DataLivelli));
                DataLivelli data = new DataLivelli();
                data = (DataLivelli)deserializer.Deserialize(stream);
                stream.Close();
                livelli_loaded.Add(data.livello);
                File.Delete(path);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Azzera le informazioni noon necessarie in livelli loaded
        /// </summary>
        private void Standardize()
        {
            try
            {
                foreach (Livello liv in livelli_loaded)
                {
                    foreach (Posizione pos in liv.Posizioni)
                    {
                        Vector2 temp = pos.PosizioneAttuale;
                        temp.Y = pos.Coordinate.Y;
                        //temp.X = pos.Coordinate.X;
                        pos.PosizioneAttuale = temp;
                        pos.IsRight = true;
                        if (pos.Tipo != TipoPosizione.Nemico1 && pos.Tipo != TipoPosizione.Nemico2 && pos.Tipo != TipoPosizione.Nemico3 && pos.Tipo != TipoPosizione.Nemico4 &&
                            pos.Tipo != TipoPosizione.Nemico5 && pos.Tipo != TipoPosizione.Nemico6 && pos.Tipo != TipoPosizione.Nemico7)
                            pos.Jump = 0;
                        pos.Life = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Genera i livelli random e aggiunge le posizioni
        /// </summary>
        public void CaricaPosizioni()
        {
            try
            {
                VariabiliTemp.livelli.Clear();
                VariabiliTemp.posizioni.Clear();
                VariabiliTemp.nemici.Clear();
                Standardize();

                List<Livello> diff1 = new List<Livello>(),
                    diff2 = new List<Livello>(),
                    diff3 = new List<Livello>(),
                    diff4 = new List<Livello>(),
                    diff5 = new List<Livello>(),
                    diff6 = new List<Livello>(),
                    diff7 = new List<Livello>(),
                    diff8 = new List<Livello>(),
                    diff9 = new List<Livello>(),
                    diff10 = new List<Livello>();

                foreach (Livello livello in livelli_loaded)
                {
                    switch (livello.Difficoltà)
                    {
                        case 0: diff1.Add(livello); break;
                        case 1: diff2.Add(livello); break;
                        case 2: diff3.Add(livello); break;
                        case 3: diff4.Add(livello); break;
                        case 4: diff5.Add(livello); break;
                        case 5: diff6.Add(livello); break;
                        case 6: diff7.Add(livello); break;
                        case 7: diff8.Add(livello); break;
                        case 8: diff9.Add(livello); break;
                        case 9: diff10.Add(livello); break;
                        default: break;
                    }
                }

                if (diff1.Count > 0)
                    VariabiliTemp.livelli.Add(diff1[Variabili.random.Next(diff1.Count)]);
                if (diff2.Count > 0)
                    VariabiliTemp.livelli.Add(diff2[Variabili.random.Next(diff2.Count)]);
                if (diff3.Count > 0)
                    VariabiliTemp.livelli.Add(diff3[Variabili.random.Next(diff3.Count)]);
                if (diff4.Count > 0)
                    VariabiliTemp.livelli.Add(diff4[Variabili.random.Next(diff4.Count)]);
                if (diff5.Count > 0)
                    VariabiliTemp.livelli.Add(diff5[Variabili.random.Next(diff5.Count)]);
                if (diff6.Count > 0)
                    VariabiliTemp.livelli.Add(diff6[Variabili.random.Next(diff6.Count)]);
                if (diff7.Count > 0)
                    VariabiliTemp.livelli.Add(diff7[Variabili.random.Next(diff7.Count)]);
                if (diff8.Count > 0)
                    VariabiliTemp.livelli.Add(diff8[Variabili.random.Next(diff8.Count)]);
                if (diff9.Count > 0)
                    VariabiliTemp.livelli.Add(diff9[Variabili.random.Next(diff9.Count)]);
                if (diff10.Count > 0)
                    VariabiliTemp.livelli.Add(diff10[Variabili.random.Next(diff10.Count)]);

                #region METODO VECCHIO
                //List<List<Livello>> livelli = new List<List<Livello>>();
                //VariabiliTemp.livelliTemp.Clear();
                //VariabiliTemp.livelli.Clear();
                //livelli_loaded.Clear();
                //Carica();
                //VariabiliTemp.livelliTemp = livelli_loaded;
                //for (int difficoltà = 0; difficoltà < Costanti.MAX_LEVEL; difficoltà++)
                //{
                //    livelli.Add(new List<Livello>());
                //    foreach (Livello livello in livelli_loaded)
                //    {
                //        if (livello.Difficoltà == difficoltà)
                //        {
                //            livelli[difficoltà].Add(livello);
                //        }
                //    }
                //}

                //VariabiliTemp.livelliTemp.Clear();

                //foreach (List<Livello> livelli_sub in livelli)
                //{
                //    if (livelli_sub.Count > 0)
                //        VariabiliTemp.livelliTemp.Add(livelli_sub[Variabili.random.Next(livelli_sub.Count)]);
                //}

                #endregion


                for (int difficoltà = 1; difficoltà < VariabiliTemp.livelli.Count; difficoltà++)
                {
                    float Ymax = 0;
                    for (int i = VariabiliTemp.livelli[difficoltà - 1].Posizioni.Count - 1; i >= 0; i--)
                    {
                        if (VariabiliTemp.livelli[difficoltà - 1].Posizioni[i].Tipo == TipoPosizione.Normale ||
                            VariabiliTemp.livelli[difficoltà - 1].Posizioni[i].Tipo == TipoPosizione.Falso ||
                            VariabiliTemp.livelli[difficoltà - 1].Posizioni[i].Tipo == TipoPosizione.MovimOrriz ||
                            VariabiliTemp.livelli[difficoltà - 1].Posizioni[i].Tipo == TipoPosizione.Distruttibile ||
                            VariabiliTemp.livelli[difficoltà - 1].Posizioni[i].Tipo == TipoPosizione.SaltoSingolo)
                        {
                            Ymax = Vector2.Distance(VariabiliTemp.livelli[difficoltà - 1].Posizioni[i].Coordinate, new Vector2(VariabiliTemp.livelli[difficoltà - 1].Posizioni[i].Coordinate.X, 320));
                        }
                    }


                    for (int i = difficoltà; i < VariabiliTemp.livelli.Count; i++)
                    {
                        foreach (Posizione posizione in VariabiliTemp.livelli[i].Posizioni)
                        {
                            Vector2 temp = posizione.PosizioneAttuale;
                            temp.Y -= Ymax;
                            posizione.PosizioneAttuale = temp;
                        }
                    }
                }

                foreach (Livello livello in VariabiliTemp.livelli)
                {
                    foreach (Posizione posizione in livello.Posizioni)
                    {
                        if (posizione.Tipo != TipoPosizione.Nemico1 && posizione.Tipo != TipoPosizione.Nemico2 && posizione.Tipo != TipoPosizione.Nemico3 && posizione.Tipo != TipoPosizione.Nemico4 &&
                            posizione.Tipo != TipoPosizione.Nemico5 && posizione.Tipo != TipoPosizione.Nemico6 && posizione.Tipo != TipoPosizione.Nemico7)
                        {
                            VariabiliTemp.posizioni.Add(posizione);
                        }
                        else
                        {
                            Nemico currNemico = new Nemico(posizione.Jump, posizione.PosizioneAttuale, null, VariabiliGioco.tx_proiettile);
                            if (posizione.Tipo == TipoPosizione.Nemico1)
                                currNemico.TextureNemico = VariabiliGioco.tx_nemico1;
                            if (posizione.Tipo == TipoPosizione.Nemico2)
                                currNemico.TextureNemico = VariabiliGioco.tx_nemico2;
                            if (posizione.Tipo == TipoPosizione.Nemico3)
                                currNemico.TextureNemico = VariabiliGioco.tx_nemico3;
                            if (posizione.Tipo == TipoPosizione.Nemico4)
                                currNemico.TextureNemico = VariabiliGioco.tx_nemico4;
                            if (posizione.Tipo == TipoPosizione.Nemico5)
                                currNemico.TextureNemico = VariabiliGioco.tx_nemico5;
                            if (posizione.Tipo == TipoPosizione.Nemico6)
                                currNemico.TextureNemico = VariabiliGioco.tx_nemico6;
                            if (posizione.Tipo == TipoPosizione.Nemico7)
                                currNemico.TextureNemico = VariabiliGioco.tx_nemico7;

                            VariabiliTemp.nemici.Add(currNemico);
                        }
                    }
                }

                foreach (Posizione posizione in VariabiliTemp.posizioni)
                {
                    posizione.Jump = 0;
                    posizione.Life = 0;
                    if (posizione.Bonus != null)
                    {
                        switch (posizione.Bonus.Tipo)
                        {
                            case TipoBonus.Nessuno:
                                posizione.Bonus.Texture = new Microsoft.Xna.Framework.Graphics.Texture2D(Variabili.game.GraphicsDevice, 1, 1);
                                break;
                            case TipoBonus.Molla:
                                posizione.Bonus.Texture = VariabiliGioco.tx_molla;
                                break;
                            case TipoBonus.JetPack:
                                posizione.Bonus.Texture = VariabiliGioco.tx_jetpack;
                                break;
                            case TipoBonus.Capellino:
                                posizione.Bonus.Texture = VariabiliGioco.tx_cappello;
                                break;
                            case TipoBonus.Razzo:
                                posizione.Bonus.Texture = VariabiliGioco.tx_razzo;
                                break;
                            default:
                                break;
                        }
                    }
                    Debug.WriteLine(posizione.Details());
                }
                Debug.WriteLine("Livelli caricati: " + VariabiliTemp.livelli.Count);
                Debug.WriteLine("Posizioni caricate: " + VariabiliTemp.posizioni.Count);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Carica tutti i file pck in PATH_TEMP
        /// </summary>
        public void Carica()
        {
            try
            {
                VariabiliTemp.livelli = new List<Livello>();
                VariabiliTemp.posizioni = new List<Posizione>();

                livelli_loaded.Clear();

                foreach (FileInfo file in new DirectoryInfo(@"Content\Data\Posizioni").GetFiles("*.pck"))
                {
                    Compression.DeCompress(file);
                    Debug.WriteLine("File estratto: " + file.Name);
                }

                foreach (FileInfo file in new DirectoryInfo(@"Content\Data\Posizioni").GetFiles("*.liv"))
                {
                    CaricaLiv(file.FullName);
                    Debug.WriteLine("Livello caricato: " + file.Name);
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }

    /// <summary>
    /// Struttura per il salvataggio/caricamento dei livelli
    /// </summary>
    [Serializable]
    public class DataLivelli
    {
        public Livello livello;
    }
}
