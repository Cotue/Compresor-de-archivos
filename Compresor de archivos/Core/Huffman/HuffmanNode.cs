using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core.Huffman
{
    public class HuffmanNode
    {
        public byte? Symbol { get; set; }
        public int Frequency { get; set; }

        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }

        public bool IsLeaf => Left == null && Right == null;

        public HuffmanNode(byte? symbol, int frequency)
        {
            Symbol = symbol;
            Frequency = frequency;
        }
    }
}
