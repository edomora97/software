using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;


namespace ComputersInvaders
{
    public class SaveGame
    {
        public SaveGame()
        {
        
        }
        public void AvviaSalvataggio()
        {
            if (true)
            {
                Variabili.device = null;
                Variabili.stateobj = (Object)" ";
                StorageDevice.BeginShowSelector(this.Salva, Variabili.stateobj);
            }
        }
        public void AvviaCaricamento()
        {
                Variabili.device = null;
                Variabili.stateobj = (Object)" ";
                StorageDevice.BeginShowSelector(this.Carica, Variabili.stateobj);
            
        }
        public void Salva(IAsyncResult result)
        {
            Variabili.device = StorageDevice.EndShowSelector(result);
            if (Variabili.device != null && Variabili.device.IsConnected)
            {
                SalvaGioco(Variabili.device);
            }
        }

        public void Carica(IAsyncResult result)
        {
            Variabili.device = StorageDevice.EndShowSelector(result);
            if (Variabili.device != null && Variabili.device.IsConnected)
            {
                CaricaGioco(Variabili.device);
            }
        }


        public void SalvaGioco(StorageDevice device)
        {
            Lista data = new Lista();
            data.p1 = Variabili.p1;
            data.p2 = Variabili.p2;
            data.p3 = Variabili.p3;
            data.p4 = Variabili.p4;
            data.p5 = Variabili.p5;
            data.s1 = Variabili.s1;
            data.s2 = Variabili.s2;
            data.s3 = Variabili.s3;
            data.s4 = Variabili.s4;
            data.s5 = Variabili.s5;
            IAsyncResult result = device.BeginOpenContainer("ComputersInvaders", null, null);
            result.AsyncWaitHandle.WaitOne();
            StorageContainer container = device.EndOpenContainer(result);
            result.AsyncWaitHandle.Close();
            string filename = "savegame.sav";
            if (container.FileExists(filename))
            {
                container.DeleteFile(filename);
            }
            Stream stream = container.CreateFile(filename);
            XmlSerializer serializer = new XmlSerializer(typeof(Lista));
            serializer.Serialize(stream, data);
            stream.Close();
            container.Dispose();
        }
        public void CaricaGioco(StorageDevice device)
        {
            IAsyncResult result = device.BeginOpenContainer("ComputersInvaders", null, null);
            result.AsyncWaitHandle.WaitOne();
            StorageContainer container = device.EndOpenContainer(result);
            result.AsyncWaitHandle.Close();
            string filename = "savegame.sav";
            if (!container.FileExists(filename))
            {
                container.Dispose();
                return;
            }
            Stream stream = container.OpenFile(filename, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(Lista));
            Lista data = (Lista)serializer.Deserialize(stream);
            stream.Close();
            container.Dispose();
            Variabili.s1 = data.s1;
            Variabili.s2 = data.s2;
            Variabili.s3 = data.s3;
            Variabili.s4 = data.s4;
            Variabili.s5 = data.s5;
            Variabili.p1 = data.p1;
            Variabili.p2 = data.p2;
            Variabili.p3 = data.p3;
            Variabili.p4 = data.p4;
            Variabili.p5 = data.p5;

            Debug.WriteLine("NOMI {0}, {1}, {2}, {3}, {4}, PUNTEGGI {5}, {6}, {7}, {8}, {9}", Variabili.s1, Variabili.s2, Variabili.s3, Variabili.s4, Variabili.s5, Variabili.p1, Variabili.p2, Variabili.p3, Variabili.p4, Variabili.p5);
        }

        [Serializable]
        public struct Lista
        {
            public string s1, s2, s3, s4, s5;
            public int p1, p2, p3, p4, p5;
        }
    }
}
