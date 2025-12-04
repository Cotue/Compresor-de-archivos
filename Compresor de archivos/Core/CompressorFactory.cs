using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compresor_de_archivos.Core.Huffman;

namespace Compresor_de_archivos.Core
{
    public static class CompressorFactory
    {
        public static GeneralCompressor Create(AlgorithmSelector algorithm)
        {
            switch (algorithm)
            {
                case AlgorithmSelector.Huffman:
                    return new HuffmanCompressor();

                //case AlgorithmSelector.LZ77:
                    //return new Lz77Compressor();

                //case AlgorithmSelector.LZ78:
                    //return new Lz78Compressor();

                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithm));
            }
        }
    }
}
