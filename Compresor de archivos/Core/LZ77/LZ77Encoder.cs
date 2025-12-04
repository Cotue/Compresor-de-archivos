using System;
using System.Collections.Generic;

namespace Compresor_de_archivos.Core.LZ77
{
	public class LZ77Encoder
	{
		private readonly int windowSize;

		public LZ77Encoder(int windowSize = 4096)
		{
			this.windowSize = windowSize;
		}

		public List<LZ77Token> Encode(byte[] input)
		{
			var tokens = new List<LZ77Token>();
			int pos = 0;

			while (pos < input.Length)
			{
				int bestOffset = 0;
				int bestLength = 0;

				int startWindow = Math.Max(0, pos - windowSize);

				// BUSCAR LA MEJOR COINCIDENCIA HACIA ATRÁS
				for (int i = pos - 1; i >= startWindow; i--)
				{
					int length = 0;

					while (pos + length < input.Length &&
						   input[i + length] == input[pos + length])
					{
						length++;
						if (i + length >= pos) break; // No sobrepasar la posición actual
					}

					if (length > bestLength)
					{
						bestLength = length;
						bestOffset = pos - i;
					}
				}

				// Token final
				byte next = (pos + bestLength < input.Length)
					? input[pos + bestLength]
					: (byte)0;

				tokens.Add(new LZ77Token(bestOffset, bestLength, next));

				pos += bestLength + 1;
			}

			return tokens;
		}
	}
}
