using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core
{
    public interface GeneralCompressor
    {
        string Name { get; }

        byte[] Compress(byte[] input);

        byte[] Decompress(byte[] input);
    }
}
