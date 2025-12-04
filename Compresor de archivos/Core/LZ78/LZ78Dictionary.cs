using System;
using System.Collections.Generic;
using System.Linq;

namespace Compresor_de_archivos.Core.LZ78
{
    // Este diccionario sirve para almacenar secuencias y realizar busquedas secuenciales
    public class LZ78Dictionary
    {
        private readonly List<byte[]> entries;

        public LZ78Dictionary()
        {
            entries = new List<byte[]>();
            entries.Add(Array.Empty<byte>()); // Índice 0 = cadena vacía
        }

        public int Count => entries.Count;

        public byte[] this[int index] => entries[index];

        public int Add(byte[] entry)
        {
            entries.Add(entry);
            return entries.Count - 1;
        }

        public int FindIndex(byte[] sequence)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].SequenceEqual(sequence))
                    return i;
            }

            return -1;
        }
    }
}
