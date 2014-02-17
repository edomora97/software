using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per la compressione e la decompressione di file pck
    /// </summary>
    public class Compression
    {
        /// <summary>
        /// Comprime un file liv in un pck
        /// </summary>
        /// <param name="file">File da comprimere</param>
        /// <param name="outFile">File di destinazione</param>
        public static void Compress(FileInfo file, FileInfo outFile)
        {
            try
            {
                using (FileStream inFile = file.OpenRead())
                {
                    if ((File.GetAttributes(file.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden)
                    {
                        using (FileStream _outFile = File.Create(outFile.FullName.Remove(outFile.FullName.Length - outFile.Extension.Length) + ".pck"))
                        {
                            using (GZipStream Compress = new GZipStream(_outFile, CompressionMode.Compress, false))
                            {
                                inFile.CopyTo(Compress);
                            }
                        }
                    }
                }
                Debug.WriteLine("File compresso da: " + file.Name + " a: " + outFile.Name);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        /// <summary>
        /// Decomprime un file pck
        /// </summary>
        /// <param name="file">File da decomprimere</param>
        public static void DeCompress(FileInfo file)
        {
            try
            {
                FileStream inFile = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite);
                FileStream outFile = new FileStream(file.FullName.Remove(file.FullName.Length - file.Extension.Length) + ".liv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                GZipStream dec = new GZipStream(inFile, CompressionMode.Decompress);
                dec.CopyTo(outFile);
                inFile.Close();
                outFile.Close();
                Debug.WriteLine("File decompresso da: " + inFile.Name + " a: " + outFile.Name);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }        
    }
}
