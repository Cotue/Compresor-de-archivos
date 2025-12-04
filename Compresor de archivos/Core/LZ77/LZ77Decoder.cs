using System;
using System.Collections.Generic;

namespace Compresor_de_archivos.Core.LZ77
{
	public class LZ77Decoder
	{
		public byte[] Decode(List<LZ77Token> tokens)
		{
			var output = new List<byte>();

			foreach (var t in tokens)
			{
				if (t.Offset > 0 && t.Length > 0)
				{
					int start = output.Count - t.Offset;

					for (int i = 0; i < t.Length; i++)
						output.Add(output[start + i]);
				}

				if (t.Next != 0 || (t.Offset == 0 && t.Length == 0))
					output.Add(t.Next);
			}

			return output.ToArray();
		}
	}
}
