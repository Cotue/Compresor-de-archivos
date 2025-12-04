using System;
using System.Collections.Generic;

namespace Compresor_de_archivos.Core.LZ78
{
    // Implementación para que vaya de byte[] a caracter o entero y viciversa.
    // Es decir los métodos Serialize y Deserealize
    public static class LZ78Serializer
    {
        public static byte[] Serialize(List<LZ78Pair> pairs)
        {
            var bytes = new List<byte>(pairs.Count * 5);

            foreach (var p in pairs)
            {
                bytes.AddRange(BitConverter.GetBytes(p.Index));
                bytes.Add(p.Symbol);
            }

            return bytes.ToArray();
        }
    public static List<LZ78Pair> Deserialize(byte[] input)
        {
            var list = new List<LZ78Pair>();

            for (int i = 0; i < input.Length; i += 5)
            {
                int index = BitConverter.ToInt32(input, i);
                byte symbol = input[i + 4];

                list.Add(new LZ78Pair(index, symbol));
            }

            return list;
        }
    }
}
