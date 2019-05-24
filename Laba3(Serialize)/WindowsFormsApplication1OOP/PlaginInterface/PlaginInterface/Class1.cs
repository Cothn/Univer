using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaginInterface
{
    public interface SerialPlagin
    {

        void Shifr(Stream stream);
        Stream DeShifr(Stream stream);
    }
}
