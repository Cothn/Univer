using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompressPluginInterface;
using System.IO.Compression;
using System.IO;

namespace DeflatePlugin
{
    public class GZipPlugin : IPlugin
    {
        public string FileExtens { get { return ".cmp"; } }
        public override string ToString()
        {
            return "Deflate";
        }
        public void Shifr(Stream ReadStream, Stream WriteStream)
        {
            using (DeflateStream compressionStream = new DeflateStream(WriteStream,
                CompressionMode.Compress))
            {
                ReadStream.CopyTo(compressionStream);

            }
        }
        public void DeShifr(Stream ReadStream, Stream WriteStream)
        {
            using (DeflateStream decompressionStream = new DeflateStream(ReadStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(WriteStream);
            }
        }

    }
}
