using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace CompressPluginInterface
{
    public interface IPlugin
    {
        string FileExtens { get; }
        void Shifr(Stream ReadStream, Stream WriteStream);
        void DeShifr(Stream ReadStream, Stream WriteStream);
    }

    public class NonePlugin : IPlugin
    {
        public string FileExtens { get { return ""; } }
        public override string ToString()
        {
            return "none plugin";
        }
        public void Shifr(Stream ReadStream, Stream WriteStream)
        { ReadStream.CopyTo(WriteStream); }
        public void DeShifr(Stream ReadStream, Stream WriteStream)
        { ReadStream.CopyTo(WriteStream); }
    
    }

}
