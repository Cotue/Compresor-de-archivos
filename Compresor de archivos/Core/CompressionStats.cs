using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compresor_de_archivos.Core
{
    public class CompressionStats
    {
        public long ElapsedMilliseconds { get; set; }
        public long MemoryBytes { get; set; }
        public double CompressionRatio { get; set; }
    }
}
