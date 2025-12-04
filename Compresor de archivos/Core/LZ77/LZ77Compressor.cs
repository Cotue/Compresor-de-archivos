using System;
using Compresor_de_archivos.Core.LZ77;

namespace Compresor_de_archivos.Core
{
	public class LZ77Compressor : GeneralCompressor
	{
		public string Name => "LZ77";

		private readonly LZ77Encoder encoder = new LZ77Encoder();
		private readonly LZ77Decoder decoder = new LZ77Decoder();

		public byte[] Compress(byte[] input)
		{
			var tokens = encoder.Encode(input);
			return LZ77Serializer.Serialize(tokens);
		}

		public byte[] Decompress(byte[] input)
		{
			var tokens = LZ77Serializer.Deserialize(input);
			return decoder.Decode(tokens);
		}
	}
}
