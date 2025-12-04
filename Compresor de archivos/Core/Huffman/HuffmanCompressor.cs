using Compresor_de_archivos.Core.WriteAndRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core.Huffman
{
    public class HuffmanCompressor : GeneralCompressor
    {
        public string Name => "Huffman";

        public byte[] Compress(byte[] input)
        {
            if (input == null || input.Length == 0)
                return Array.Empty<byte>();

            int originalLength = input.Length;

            // 1. Contar frecuencias
            int[] frequencies = new int[256];
            foreach (byte b in input)
            {
                frequencies[b]++;
            }

            // 2. Construir el árbol
            HuffmanTree tree = new HuffmanTree();
            tree.BuildFromFrequencies(frequencies);

            // 3. Construir tabla de códigos (encode)
            HuffmanEncodeTable encodeTable = new HuffmanEncodeTable();
            encodeTable.Build(tree.Root);

            // 4. Escribir los bits del archivo usando BitWriter
            byte[] compressedBits;
            using (BitWriter bitWriter = new BitWriter())
            {
                foreach (byte b in input)
                {
                    string code = encodeTable.EncodeMap[b]; // ej: "0101"
                    bitWriter.WriteBits(code);
                }

                compressedBits = bitWriter.ToArray();
            }

            // 5. Crear salida final: [tamaño][256 frecuencias][datos comprimidos]
            using MemoryStream ms = new MemoryStream();
            using (BinaryWriter writer = new BinaryWriter(ms))
            {
                // Tamaño original
                writer.Write(originalLength);

                // Tabla de frecuencias (256 ints)
                for (int i = 0; i < 256; i++)
                {
                    writer.Write(frequencies[i]);
                }

                // Datos comprimidos
                writer.Write(compressedBits);
            }

            return ms.ToArray();
        }

        public byte[] Decompress(byte[] input)
        {
            if (input == null || input.Length == 0)
                return Array.Empty<byte>();

            using MemoryStream ms = new MemoryStream(input);
            using BinaryReader reader = new BinaryReader(ms);

            // 1. Leer tamaño original
            int originalLength = reader.ReadInt32();

            // 2. Leer tabla de frecuencias
            int[] frequencies = new int[256];
            for (int i = 0; i < 256; i++)
            {
                frequencies[i] = reader.ReadInt32();
            }

            // 3. Reconstruir el árbol de Huffman
            HuffmanTree tree = new HuffmanTree();
            tree.BuildFromFrequencies(frequencies);

            if (tree.Root == null)
                return Array.Empty<byte>();

            // 4. Leer el resto de datos como bits comprimidos
            long remainingBytes = ms.Length - ms.Position;
            byte[] compressedData = reader.ReadBytes((int)remainingBytes);

            BitReader bitReader = new BitReader(compressedData);

            List<byte> output = new List<byte>(originalLength);

            // 5. Decodificar bit a bit
            while (output.Count < originalLength && bitReader.HasMoreBits())
            {
                HuffmanNode current = tree.Root;

                // bajar por el árbol hasta llegar a una hoja
                while (!current.IsLeaf)
                {
                    int bit = bitReader.ReadBit();
                    if (bit == 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }

                    if (current == null)
                    {
                        throw new Exception("Error al decodificar Huffman: nodo nulo.");
                    }
                }

                if (current.Symbol == null)
                    throw new Exception("Nodo hoja sin símbolo en la descompresión Huffman.");

                output.Add(current.Symbol.Value);
            }

            return output.ToArray();
        }
    }
}