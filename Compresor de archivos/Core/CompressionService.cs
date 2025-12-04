using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
namespace Compresor_de_archivos.Core
{
    public class CompressionService
    {
        // Método principal para comprimir archivos
        public CompressionStats CompressFiles(
            List<string> inputFiles,
            string outputFolder,
            AlgorithmSelector algorithm)
        {
            // Crear el compresor adecuado
            var compressor = CompressorFactory.Create(algorithm);

            // Para medir tiempo
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //Medir uso de memoria
            long initialMemory = GC.GetTotalMemory(true);

            // Acumulador para toda la salida comprimida
            using MemoryStream finalOutput = new MemoryStream();

            // Comprimir cada archivo individualmente
            foreach (var file in inputFiles)
            {
                byte[] originalBytes = File.ReadAllBytes(file);
                byte[] compressedBytes = compressor.Compress(originalBytes);

                // Guardar cada archivo comprimido dentro del output final
                finalOutput.Write(BitConverter.GetBytes(compressedBytes.Length));
                finalOutput.Write(compressedBytes);
            }
            // Finalizar mediciones
            stopwatch.Stop();
            long finalMemory = GC.GetTotalMemory(true);

            // Construir estadísticas
            CompressionStats stats = new CompressionStats
            {
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
                MemoryBytes = finalMemory - initialMemory,
                // Calcular la ratio de compresión
                CompressionRatio =
                    finalOutput.Length > 0
                    ? (double)finalOutput.Length /
                      TotalSizeOfFiles(inputFiles)
                    : 0
            };

            // Guardar el archivo final
            string outputFile = Path.Combine(outputFolder, "output.myzip");
            File.WriteAllBytes(outputFile, finalOutput.ToArray());

            return stats;
        }

        // Método auxiliar para calcular el tamaño total de una lista de archivos(Sumar tamanos
        private long TotalSizeOfFiles(List<string> files)
        {
            long total = 0;
            foreach (var f in files)
            {
                FileInfo info = new FileInfo(f);
                total += info.Length;
            }
            return total;
        }
    }
}
