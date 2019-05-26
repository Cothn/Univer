using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompressPluginInterface;
using System.IO;
using System.IO.Compression;

namespace GZipPlugin
{
    public class GZipPlugin : IPlugin
    {
        public string FileExtens { get { return ".gz"; } }
        public override string ToString()
        {
            return "GZip";
        }
        public void Shifr(Stream ReadStream, Stream WriteStream)
        {
            using (GZipStream compressionStream = new GZipStream(WriteStream,
                CompressionMode.Compress))
            {
                ReadStream.CopyTo(compressionStream);

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
