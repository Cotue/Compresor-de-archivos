using System;

namespace Compresor_de_archivos.Core.LZ77

{
    public struct LZ77Token
    {
        public int Offset;      // Cuánto retroceder en la ventana
        public int Length;      // Longitud de coincidencia
        public byte Next;       // Símbolo siguiente

        public LZ77Token(int offset, int length, byte next)
        {
            Offset = offset;
            Length = length;
            Next = next;
        }
    }
}
