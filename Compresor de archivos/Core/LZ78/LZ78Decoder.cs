using System;
using System.Collections.Generic;
using System.Linq;

namespace Compresor_de_archivos.Core.LZ78
{

    public class LZ78Decoder
    {
        // Literalmente lo va haciendo por parejas
        public byte[] Decode(List<LZ78Pair> pairs)
        {
            var output = new List<byte>();
            if (pairs == null || pairs.Count == 0)
                return output.ToArray();

            var dict = new LZ78Dictionary();

            foreach (var p in pairs)
            {
                byte[] prefix = dict[p.Index];
                byte[] fullEntry;

                if (p.Symbol == 0)
                    fullEntry = prefix;
                else
                    fullEntry = prefix.Concat(new byte[] { p.Symbol }).ToArray();

                output.AddRange(fullEntry);
                dict.Add(fullEntry);
            }

            return output.ToArray();
        }
    }
}
