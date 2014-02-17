using System.IO;
using System.IO.Compression;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Piattaforme
{

    public class Compression
    {
        /// <summary>
        /// Comprime un file liv in un pck
        /// </summary>
        /// <param name="file">File da comprimere</param>
        /// <param name="outFile">File di destinazione</param>
        public static void Compress(FileInfo file, FileInfo outFile)
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
            
        }

        /// <summary>
        /// Decomprime un file pck
        /// </summary>
        /// <param name="file">File da decomprimere</param>
        public static void DeCompress(FileInfo file)
        {
            FileStream inFile = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite);
            FileStream outFile = new FileStream(file.FullName.Remove(file.FullName.Length - file.Extension.Length) + ".liv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            GZipStream dec = new GZipStream(inFile, CompressionMode.Decompress);
            dec.CopyTo(outFile);
            inFile.Close();
            outFile.Close();
        }        
    }
}
