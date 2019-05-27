using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompressPluginInterface;
using System.IO;
using System.IO.Compression;

namespace ZipPlugin
{
    public class ZipPlugin : IPlugin
    {
        public string FileExtens { get { return ".zip"; } }
        public override string ToString()
        {
            return "Zip";
        }
        public void Shifr(Stream ReadStream, Stream WriteStream)
        {
            using (GZipStream compressionStream = new GZipStream(WriteStream,
                CompressionMode.Compress))
            {
                ReadStream.CopyTo(compressionStream);

            }
            using (test2.ZipOutputStream s = new test2.ZipOutputStream(File.Create(Application.StartupPath + @"\test2.zip")))
            {
                byte[] buffer = new byte[4096];
                test2.ZipEntry entry = new test2.ZipEntry(Path.GetFileName(file));
                s.PutNextEntry(entry);
                using (FileStream fs = File.OpenRead(file))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);
                        s.Write(buffer, 0, sourceBytes);
                    } while (sourceBytes > 0);
                }
                s.Finish();
                s.Close();
            }
        }
        public void DeShifr(Stream ReadStream, Stream WriteStream)
        {
            using (GZipStream decompressionStream = new GZipStream(ReadStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(WriteStream);
            }
        }

    

    }
}
