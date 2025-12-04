using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core
{
    // Interfaz para compresores genéricos, asi la interfaz no tiene que depender de implementaciones específicas
    public interface GeneralCompressor
    {
        string Name { get; }

        byte[] Compress(byte[] input);

        byte[] Decompress(byte[] input);
    }
}
