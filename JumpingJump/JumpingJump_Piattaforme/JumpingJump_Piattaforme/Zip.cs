sing System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;

namespace JumpingJump.Piattaforme
{
    /// <summary>
    /// Zip
    /// </summary>
    public class Zip
    {
        #region public methods

        /// <summary>
        /// Comprime il contenuto di un file in formato ZIP
        /// </summary>
        /// <param name="ZipFilePath">Path del file compresso da creare</param>
        /// <param name="OriginalFilePath">Path del file da comprimere</param>
        public static void ZipFile(string ZipFilePath, string OriginalFilePath)
        {
            try
            {
                FileInfo fi = new FileInfo(OriginalFilePath);
                ZipOutputStream zip = new ZipOutputStream(File.Create(ZipFilePath));
                zip.SetLevel(9);    // 0 - store only to 9 - means best compression
                AddFile2Zip(zip, fi, "");
                zip.Finish();
                zip.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Comprime il contenuto di una cartella in formato ZIP, ricorsivamente e preservandone la struttura
        /// </summary>
        /// <param name="ZipFilePath">Path del file compresso da creare</param>
        /// <param name="OriginalFolderPath">Path della cartella da comprimere</param>
        public static void ZipFolder(string ZipFilePath, string OriginalFolderPath)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(OriginalFolderPath);
                ZipOutputStream zip = new ZipOutputStream(File.Create(ZipFilePath));
                zip.SetLevel(6);    // 0 - store only to 9 - means best compression
                AddFolder2Zip(zip, di, "");
                zip.Finish();
                zip.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Decomprime un file compresso ZIP nella cartella di destinazione specificata
        /// </summary>
        /// <param name="ZipFilePath">Path del file ZIP da decomprimere</param>
        /// <param name="DestinationPath">Cartella di destinazione dell'archivio decompresso</param>
        public static void UnZip(string ZipFilePath, string DestinationPath)
        {
            string dp = (DestinationPath.EndsWith("\\")) ? DestinationPath : DestinationPath + @"\";
            ZipInputStream zip = new ZipInputStream(File.OpenRead(ZipFilePath));
            ZipEntry entry;
            while ((entry = zip.GetNextEntry()) != null)
            {
                if (entry.IsDirectory)
                    Directory.CreateDirectory(dp + entry.Name);
                else
                {
                    FileStream streamWriter = File.Create(dp + entry.Name);
                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = zip.Read(data, 0, data.Length);
                        if (size > 0)
                            streamWriter.Write(data, 0, size);
                        else
                            break;
                    }
                    streamWriter.Close();
                }
            }
            zip.Close();
        }

        #endregion

        #region private methods

        private static void AddFolder2Zip(ZipOutputStream zip, DirectoryInfo di, string internalzippath)
        {
            string izp = internalzippath + di.Name + "/";    // A directory is determined by an entry name with a trailing slash "/"
            Crc32 crc = new Crc32();
            ZipEntry entry = new ZipEntry(izp);
            entry.Crc = crc.Value;
            zip.PutNextEntry(entry);
            foreach (FileInfo fi in di.GetFiles())
                AddFile2Zip(zip, fi, izp);
            foreach (DirectoryInfo sdi in di.GetDirectories())
                AddFolder2Zip(zip, sdi, izp);
        }
        private static void AddFile2Zip(ZipOutputStream zip, FileInfo fi, string internalzippath)
        {
            Crc32 crc = new Crc32();
            FileStream fs = File.OpenRead(fi.FullName);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            ZipEntry entry = new ZipEntry(internalzippath + fi.Name);
            entry.DateTime = DateTime.Now;
            entry.Size = fs.Length;
            fs.Close();
            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;
            zip.PutNextEntry(entry);
            zip.Write(buffer, 0, buffer.Length);
        }

        #endregion
    }
}