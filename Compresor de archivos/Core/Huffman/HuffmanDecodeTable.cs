using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core.Huffman
{
    public class HuffmanDecodeTable
    {
        // Diccionario final: código en bits → símbolo
        public Dictionary<string, byte> DecodeMap { get; private set; }
       
        public HuffmanDecodeTable()
        {
            DecodeMap = new Dictionary<string, byte>();
        }
        // Construir la tabla a partir del árbol de Huffman
        public void Build(HuffmanNode root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            DecodeMap.Clear();
            BuildRecursive(root, "");
        }
        //recorrer el árbol y asignar códigos
        private void BuildRecursive(HuffmanNode node, string path)
        {
            // Caso hoja → guardar el código
            if (node.IsLeaf)
            {
                if (node.Symbol == null)
                    throw new Exception("Nodo hoja sin símbolo en Huffman.");

                // Guardar: "0101" → 'A'
                DecodeMap[path] = node.Symbol.Value;
                return;
            }

            // Recorrer hijo izquierdo (0)
            if (node.Left != null)
                BuildRecursive(node.Left, path + "0");

            // Recorrer hijo derecho (1)
            if (node.Right != null)
                BuildRecursive(node.Right, path + "1");
        }
    }
}
