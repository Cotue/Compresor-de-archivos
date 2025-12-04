namespace Compresor_de_archivos.Core.LZ78
{
    public struct LZ78Pair // Representa cada salida o nodo del Trie (índice, caracter)
    {
        public int Index;
        public byte Symbol;

        public LZ78Pair(int index, byte symbol)
        {
            Index = index;
            Symbol = symbol;
        }
    }
}
