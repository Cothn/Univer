using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompressPluginInterface
{
    public interface IPlugin
    {
        string FileExtens { get; }
        void Shifr(Stream ReadStream, Stream WriteStream);
        Stream DeShifr(Stream ReadStream);
    }

    public class NonePlugin : IPlugin
    {
        public string FileExtens { get { return ""; } }
        public override string ToString()
        {
            return "none";
        }
        public void Shifr(Stream ReadStream, Stream WriteStream)
        { }
        public Stream DeShifr(Stream ReadStream)
        { return ReadStream; }
    
    }

}
