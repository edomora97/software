using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Diagnostics;

namespace JumpingJump.Piattaforme
{
    public class SaveData
    {
        public SaveData() { }

        public void Salva(string nomeFile, int difficoltà)
        {
            nomeFile = nomeFile + Variabili.index.ToString();
            Variabili.posizioni = OrdinaElementi(Variabili.posizioni);
            Stream stream = new FileStream(nomeFile, FileMode.Create, FileAccess.ReadWrite);
            DataLivelli data = new DataLivelli();
            data.livello = new Livello(Variabili.posizioni, difficoltà);
            XmlSerializer serializer = new XmlSerializer(typeof(DataLivelli));
            serializer.Serialize(stream, data);
            stream.Close();
            Compression.Compress(new FileInfo(nomeFile), new FileInfo(nomeFile + ".pck"));
            File.Delete(nomeFile);
            Debug.WriteLine("FILE SALVATO, nome: " + nomeFile + ".pck, difficoltà: " + difficoltà);
            Variabili.index++;
        }
        public void Carica(string nomeFile)
        {
            Compression.DeCompress(new FileInfo(nomeFile + Variabili.index.ToString() + ".pck"));
            DataLivelli data = new DataLivelli();
            XmlSerializer deserializer = new XmlSerializer(typeof(DataLivelli));
            FileStream stream = new FileStream(nomeFile + ".liv", FileMode.Open, FileAccess.ReadWrite);
            data = (DataLivelli)deserializer.Deserialize(stream);
            Variabili.posizioni = data.livello.Posizioni;
            stream.Close();
            Debug.WriteLine("FILE CARICATO");
        }

        /// <summary>
        /// Ordina le posizioni della lista in base alla Y
        /// </summary>
        /// <param name="posizioni">Lista da ordinare</param>
        /// <returns></returns>
        public static List<Posizione> OrdinaElementi(List<Posizione> posizioni)
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
    }

    [Serializable]
    public class DataLivelli
    {
        public Livello livello;
    }
}
