using System;
using Compresor_de_archivos.Core.LZ78;

namespace Compresor_de_archivos.Core
{
    public class LZ78Compressor : GeneralCompressor
    {
        public string Name => "LZ78";

        private readonly LZ78Encoder encoder = new LZ78Encoder();
        private readonly LZ78Decoder decoder = new LZ78Decoder();

        public byte[] Compress(byte[] input)
        {
            var pairs = encoder.Encode(input);
            return LZ78Serializer.Serialize(pairs);
        }

        public byte[] Decompress(byte[] input)
        {
            var pairs = LZ78Serializer.Deserialize(input);
            return decoder.Decode(pairs);
        }
    }
}
