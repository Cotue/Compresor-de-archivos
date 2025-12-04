using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core.Huffman
{
    public class HuffmanCompressor : GeneralCompressor
    {
        
        public string Name => "Huffman";
        // Implementación de compresión y descompresión 
        public byte[] Compress(byte[] input)
        {
            if (input == null || input.Length == 0)
                return Array.Empty<byte>();

            // Más adelante: implementación del árbol de Huffman
            throw new NotImplementedException("Huffman compression not implemented yet.");
        }

        public byte[] Decompress(byte[] input)
        {
            if (input == null || input.Length == 0)
                return Array.Empty<byte>();

            // Más adelante: reconstruir el árbol y decodificar
            throw new NotImplementedException("Huffman decompression not implemented yet.");
        }
    }
}