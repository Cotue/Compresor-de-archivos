using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Compresor_de_archivos.Core.WriteAndRead
{
    public class BitWriter : IDisposable
    {
        private List<byte> buffer;
        private byte currentByte;
        private int bitCount;

        public BitWriter()
        {
            buffer = new List<byte>();
            currentByte = 0;
            bitCount = 0;
        }

        // Escribe un solo bit: 0 o 1
        public void WriteBit(int bit)
        {
            if (bit != 0 && bit != 1)
                throw new ArgumentException("El bit debe ser 0 o 1.");

            // Desplazar y agregar el bit
            currentByte = (byte)((currentByte << 1) | bit);
            bitCount++;

            // Si ya tenemos 8 bits, guardarlo en el buffer
            if (bitCount == 8)
            {
                buffer.Add(currentByte);
                currentByte = 0;
                bitCount = 0;
            }
        }

        // Escribir un string tipo "01101"
        public void WriteBits(string bits)
        {
            foreach (char c in bits)
            {
                if (c == '0')
                    WriteBit(0);
                else if (c == '1')
                    WriteBit(1);
                else
                    throw new Exception("Secuencia de bits inválida: " + c);
            }
        }

        // Devuelve el contenido final como array
        public byte[] ToArray()
        {
            // Si quedaron bits sin completar el byte final, rellenar con ceros
            if (bitCount > 0)
            {
                currentByte = (byte)(currentByte << (8 - bitCount));
                buffer.Add(currentByte);
            }

            return buffer.ToArray();
        }

        public void Dispose()
        {
            // No hace nada, pero permite usar "using"
        }
    }
}
