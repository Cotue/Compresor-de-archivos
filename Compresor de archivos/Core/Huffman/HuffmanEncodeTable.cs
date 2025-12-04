using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core.Huffman
{
    public class HuffmanEncodeTable
    {
        // Diccionario final: símbolo → código en bits
        public Dictionary<byte, string> EncodeMap { get; private set; }

        public HuffmanEncodeTable()
        {
            EncodeMap = new Dictionary<byte, string>();
        }
        // Construir la tabla a partir del árbol de Huffman
        public void Build(HuffmanNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            EncodeMap.Clear();
            BuildRecursive(root, "");
        }
        // Recursivo: recorrer el árbol y asignar códigos
        private void BuildRecursive(HuffmanNode node, string path)
        {
            // Caso hoja: asignar código
            if (node.IsLeaf)
            {
                if (node.Symbol == null)
                    throw new Exception("Nodo hoja sin símbolo en Huffman.");

                EncodeMap[node.Symbol.Value] = path;
                return;
            }

            // Hijo izquierdo → 0
            if (node.Left != null)
                BuildRecursive(node.Left, path + "0");

            // Hijo derecho → 1
            if (node.Right != null)
                BuildRecursive(node.Right, path + "1");
        }
    }
}
