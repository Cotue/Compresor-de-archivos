using System;
using System.Collections.Generic;
using System.Linq;

namespace Compresor_de_archivos.Core.LZ78
{
    public class LZ78Encoder
    {
        public List<LZ78Pair> Encode(byte[] input)
        {
            var output = new List<LZ78Pair>();
            if (input == null || input.Length == 0)
                return output;

            var dict = new LZ78Dictionary();
            var buffer = new List<byte>();

            foreach (byte b in input)
            {
                buffer.Add(b);
                int idx = dict.FindIndex(buffer.ToArray());

                if (idx == -1)
                {
                    buffer.RemoveAt(buffer.Count - 1);
                    int prefixIndex = dict.FindIndex(buffer.ToArray());

                    output.Add(new LZ78Pair(prefixIndex, b));

                    var newEntry = buffer.Concat(new byte[] { b }).ToArray();
                    dict.Add(newEntry);

                    buffer.Clear();
                }
            }

            if (buffer.Count > 0)
            {
                int remainingIndex = dict.FindIndex(buffer.ToArray());
                output.Add(new LZ78Pair(remainingIndex, 0)); // símbolo nulo
            }

            return output;
        }
    }
}
