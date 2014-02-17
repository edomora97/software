using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per la gestione dei file ini
    /// </summary>
    class ManagementINI
    {
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="PathFile">Percoso dove si trova l'INI</param>
        public ManagementINI(string PathFile)
        {
            try
            {
                if (!File.Exists(PathFile))
                    File.Create(PathFile);
                this.mPathFile = PathFile;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        /// <summary>
        /// API per la scrittura sui file INI
        /// </summary>
        /// <param name="Section">Sezione su cui scrivere</param>
        /// <param name="Key">Chiave da modificare</param>
        /// <param name="ValueToWrite">Valore da scrivere</param>
        /// <param name="FilePath">Percorso del file</param>
        /// <returns>Ritorna zero in caso di errore, altrimenti un altro valore</returns>
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string Section, string Key, string ValueToWrite, string FilePath);
        /// <summary>
        /// API per la lettura sui file INI
        /// </summary>
        /// <param name="Section">Seziona da cui leggere</param>
        /// <param name="Key">Chiave da leggere</param>
        /// <param name="DefaultKey">Chiave da leggere se non si trova il parametro precedente</param>
        /// <param name="BufferToWrite">Buffer su cui scrivere il valore letto</param>
        /// <param name="SizeOfBuffer">Grandezza del precedente buffer</param>
        /// <param name="FilePath">Percorso INI</param>
        /// <returns>Ritorna il numero di caratteri scritti sul buffer, se il buffer non basta torna dimensioneBuffer-1</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string DefaultKey, StringBuilder BufferToWrite, int SizeOfBuffer, string FilePath);
        /// <summary>
        /// Ritorna le chiavi e i valori di una sezione
        /// </summary>
        /// <param name="Section">Sezione da leggere</param>
        /// <param name="BufferToWrite">Buffer dove scrivere i valori</param>
        /// <param name="SizeOfBuffer">Grandezza del buffer</param>
        /// <param name="FilePath">File da leggere</param>
        /// <returns>Numero dei caratteri scritti nel buffer, se il buffer non basta torna la dimensione -2</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string Section, byte[] BufferToWrite, int SizeOfBuffer, string FilePath);
        /// <summary>
        /// Torna tutte le sezioni del file di inizializzazione
        /// </summary>
        /// <param name="BufferToWrite">Buffer su cui scrivere i dati</param>
        /// <param name="SizeOfBuffer">Dimensione del buffer</param>
        /// <param name="FilePath">Path del file INI da leggere</param>
        /// <returns>Torna il numero di caratteri letti, se non basta il buffer torna la dimensione -2</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSectionNames(byte[] BufferToWrite, int SizeOfBuffer, string FilePath);

        private string mPathFile;
        /// <summary>
        /// Ottiene o imposta la path del file INI
        /// </summary>
        public string Path
        {
            get { return mPathFile; }
            set { mPathFile = value; }
        }
        
        /// <summary>
        /// Legge dal file il valore della chiave specificiata
        /// </summary>
        /// <param name="Section">Sezione su cui leggere</param>
        /// <param name="Key">Chiave da leggere</param>
        /// <returns>Il buffer letto</returns>
        public string ReadKey(string Section, string Key)
        {
            try
            {
                if (mPathFile != "")
                {
                    long sizeRead = 0;
                    int sizeBuffer = 1024;
                    bool Do = true;
                    StringBuilder buff;

                    do
                    {
                        buff = new StringBuilder(sizeBuffer);
                        sizeRead = GetPrivateProfileString(Section, Key, "", buff, sizeBuffer, this.mPathFile);
                        if (sizeRead == (sizeBuffer - 1) || sizeRead == (sizeBuffer - 2))
                        {
                            sizeBuffer *= 2;
                            Do = true;
                        }
                        else
                        {
                            Do = false;
                        }
                        if (sizeRead == 0) break;
                    } while (Do);

                    if (sizeRead == 0) return "-Errore";
                    else return buff.ToString();
                }
                else return "-Errore";
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return "";
        }
        /// <summary>
        /// Scrive sul file INI
        /// </summary>
        /// <param name="Section">Sezione su cui scrivere (se non esiste viene creata)</param>
        /// <param name="Key">Chiave da scrivere (se non esiste viene creata (altrimenti sovrascritta))</param>
        /// <param name="Value">Valore da inserire</param>
        /// <returns>True in caso di successo, False altrimenti</returns>
        public bool WriteFile(string Section, string Key, string Value)
        {
            try
            {
                if (mPathFile != "")
                    return WritePrivateProfileString(Section, Key, Value, this.mPathFile);
                else return false;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return false;
        }
        /// <summary>
        /// Legge tutte le sezioni del file ini
        /// </summary>
        /// <returns>Ritorna un arraylist con tutte le sezioni contenute nel file</returns>
        public ArrayList ReadAllSection()
        {
            try
            {
                if (mPathFile != "")
                {
                    long sizeRead = 0;
                    int sizeBuffer = 32767;
                    try
                    {
                        byte[] buff = new byte[sizeBuffer];

                        sizeRead = GetPrivateProfileSectionNames(buff, sizeBuffer, mPathFile);

                        string[] bString = Encoding.ASCII.GetString(buff).Trim('\0').Split('\0');
                        if (sizeRead != 0) return new ArrayList(bString);
                        else return null;
                    }
                    catch
                    {
                        return null;
                    }
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Legge tutte le chiavi e i valori di una sezione del file
        /// </summary>
        /// <param name="Section">Sezione da leggere</param>
        /// <returns>Restituisce un arraylist contenente il tutto le chiavi e i valori della sezione</returns>
        public ArrayList ReadSection(string Section)
        {
            try
            {
                if (mPathFile != "")
                {
                    long sizeRead = 0;
                    int sizeBuffer = 32767;
                    try
                    {
                        byte[] buff = new byte[sizeBuffer];

                        sizeRead = GetPrivateProfileSection(Section, buff, sizeBuffer, mPathFile);

                        string[] bString = Encoding.ASCII.GetString(buff).Trim('\0').Split('\0');
                        if (sizeRead != 0) return new ArrayList(bString);
                        else return null;
                    }
                    catch
                    {
                        return null;
                    }
                }
                else return null;
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Estrapola il nome da una chiave key passata come parametro
        /// </summary>
        /// <param name="Key">Chiave da cui estrapolare il nome</param>
        /// <returns>Ritorna il nome della chiave passata come parametro (es. Nome=Valore) torna nome</returns>
        public string GetName(string Key)
        {
            try
            {
                string[] Value = Key.Split('=');
                return Value[0];
            }
            catch
            {
                return "-Errore";
            }
        }
    }
}
