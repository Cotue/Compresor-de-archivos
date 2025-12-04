using System;
using System.Collections.Generic;

namespace Compresor_de_archivos.Core.LZ77
{
    public static class LZ77Serializer
    {
        public static byte[] Serialize(List<LZ77Token> tokens)
        {
            var bytes = new List<byte>(tokens.Count * 9);

            foreach (var t in tokens)
            {
                bytes.AddRange(BitConverter.GetBytes(t.Offset));
                bytes.AddRange(BitConverter.GetBytes(t.Length));
                bytes.Add(t.Next);
            }

            return bytes.ToArray();
        }

        public static List<LZ77Token> Deserialize(byte[] data)
        {
            var tokens = new List<LZ77Token>();

            for (int i = 0; i < data.Length; i += 9)
            {
                int offset = BitConverter.ToInt32(data, i);
                int length = BitConverter.ToInt32(data, i + 4);
                byte next = data[i + 8];

                tokens.Add(new LZ77Token(offset, length, next));
            }

            return tokens;
        }
    }
}
