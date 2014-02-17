using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using JumpingJump.Classi;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Piattaforme
{
    public class SaveData
    {
        public SaveData() { }

        /// <summary>
        /// Ottiene l'indice dell'ultimo file creato
        /// </summary>
        public void GetIndex()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"Content\Data\Posizioni\");
                FileInfo[] files = dir.GetFiles("data?x*.pck");
                int maxIndex = 0;
                foreach (FileInfo file in files)
                {
                    string temp = file.Name;
                    temp = temp.Replace("data", "");
                    temp = temp.Remove(0, 2);
                    temp = temp.Replace(".pck", "");                    
                    if (maxIndex < int.Parse(temp))
                        maxIndex = int.Parse(temp);
                }
                Variabili.index = maxIndex + 1;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Salva il livello
        /// </summary>
        /// <param name="nomeFile">Nome del file senza estensione e indice</param>
        /// <param name="difficoltà">Difficoltà del livello</param>
        public void Salva(string nomeFile, int difficoltà)
        {
            try
            {
                nomeFile = @"Content\Data\Posizioni\" + nomeFile + difficoltà.ToString() + "x" + Variabili.index.ToString();
                Variabili.posizioni = OrdinaElementi(Variabili.posizioni);
                Stream stream = new FileStream(nomeFile, FileMode.Create, FileAccess.ReadWrite);
                DataLivelli data = new DataLivelli();
                data.livello = new Livello(Variabili.posizioni, difficoltà);
                XmlSerializer serializer = new XmlSerializer(typeof(DataLivelli));
                serializer.Serialize(stream, data);
                stream.Close();
                Compression.Compress(new FileInfo(nomeFile), new FileInfo(nomeFile + ".pck"));
                File.Delete(nomeFile);
                FileInfo info = new FileInfo(nomeFile + ".pck");
                Debug.WriteLine("FILE SALVATO, nome: " + info.FullName + ", difficoltà: " + difficoltà + ", Peso: " + (info.Length / 1024).ToString() + " KB");
                VariabiliCondivise.AddText("FILE SALVATO, nome: " + info.Name + ", difficoltà: " + difficoltà + ", NumPosizioni: " + VariabiliCondivise.NumPosizioni + " Peso: " + info.Length + " byte");
                Variabili.index++;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
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
    }

    [Serializable]
    public class DataLivelli
    {
        public Livello livello;
    }
}
