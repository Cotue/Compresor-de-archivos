using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core.Huffman
{
    public class HuffmanTree
    {
        public HuffmanNode Root { get; private set; }

        // Construye el árbol a partir del array de bytes original
        public void Build(byte[] input)
        {
            if (input == null || input.Length == 0)
            {
                Root = null;
                return;
            }

            int[] frequencies = new int[256];

            foreach (var b in input)
            {
                frequencies[b]++;
            }

            BuildFromFrequencies(frequencies);
        }

        // Construye el árbol a partir de una tabla de frecuencias (para Decompress)
        public void BuildFromFrequencies(int[] frequencies)
        {
            if (frequencies == null || frequencies.Length != 256)
                throw new ArgumentException("La tabla de frecuencias debe tener 256 elementos.");

            List<HuffmanNode> nodes = new List<HuffmanNode>();

            for (int i = 0; i < 256; i++)
            {
                int freq = frequencies[i];
                if (freq > 0)
                {
                    nodes.Add(new HuffmanNode((byte)i, freq));
                }
            }

            if (nodes.Count == 0)
            {
                Root = null;
                return;
            }

            if (nodes.Count == 1)
            {
                Root = nodes[0];
                return;
            }

            while (nodes.Count > 1)
            {
                nodes = nodes.OrderBy(n => n.Frequency).ToList();

                HuffmanNode left = nodes[0];
                HuffmanNode right = nodes[1];

                HuffmanNode parent = new HuffmanNode(null, left.Frequency + right.Frequency);
                parent.Left = left;
                parent.Right = right;

                nodes.RemoveAt(0);
                nodes.RemoveAt(0);
                nodes.Add(parent);
            }

            Root = nodes[0];
        }
    }
}
