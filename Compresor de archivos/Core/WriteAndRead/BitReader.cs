using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core.WriteAndRead
{
    public class BitReader
    {
        private byte[] data;
        private int byteIndex;
        private int bitIndex;
        
        public BitReader(byte[] input)
        {
            data = input ?? throw new ArgumentNullException(nameof(input));
            byteIndex = 0;
            bitIndex = 0;
        }

        // Devuelve el siguiente bit: 0 o 1
        public int ReadBit()
        {
            // Verificar si hay más bits
            if (!HasMoreBits())
                throw new EndOfStreamException("No hay más bits para leer.");
            // Obtener el byte actual
            byte current = data[byteIndex];

            // Extraer bit (del más significativo al menos significativo)
            int bit = (current >> (7 - bitIndex)) & 1;
            // Incrementar índices
            bitIndex++;
            if (bitIndex == 8)
            {
                bitIndex = 0;
                byteIndex++;
            }

            return bit;
        }

        // Para saber si todavía quedan bits
        public bool HasMoreBits()
        {
            return byteIndex < data.Length;
        }
    }
}
