using Compresor_de_archivos.Interfaz;
using Compresor_de_archivos.Core;
using System;
using System.Windows.Forms;
using Compresor_de_archivos.Core.Huffman;
using Compresor_de_archivos.Core.LZ78;

namespace Compresor_de_archivos.Interfaz

{
    public partial class MainForm : Form
    {
        private readonly FileManager fileManager = new FileManager();
        private readonly DragDropComponent drag = new DragDropComponent(); // Fixed CS1002: Added missing semicolon

        public MainForm()
        {
            InitializeComponent();

            cmbAlgorithm.Items.Add("Huffman");
            cmbAlgorithm.Items.Add("LZ77");
            cmbAlgorithm.Items.Add("LZ78");
            cmbAlgorithm.SelectedIndex = 0;

            //----------------------------------------------------------------
            //Logica para arrastar y soltar archivos

            // Adjuntar el drag & drop al GroupBox de archivos, por ejemplo:
            drag.Attach(grpInputFiles);

            // Qué hacer cuando se sueltan archivos
            drag.FilesDropped += (files) =>
            {
                if (fileManager.AddFiles(files))
                {
                    foreach (var file in files)
                        if (!listInputFiles.Items.Contains(file))
                            listInputFiles.Items.Add(file);
                }
            };
            // ----------------------------------------------------------------

            //----------------------------------------------------------------


        }
        private AlgorithmSelector SelectedAlgorithm
        {
            get
            {
                string text = cmbAlgorithm.SelectedItem?.ToString() ?? "";

                return text switch
                {
                    "Huffman" => AlgorithmSelector.Huffman,
                    "LZ77" => AlgorithmSelector.LZ77,
                    "LZ78" => AlgorithmSelector.LZ78,
                    _ => AlgorithmSelector.Huffman
                };
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (listInputFiles.Items.Count == 0)
            {
                MessageBox.Show("No hay archivos para comprimir.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Obtener lista de archivos
            List<string> files = new List<string>();
            foreach (string file in listInputFiles.Items)
                files.Add(file);

            // 2. Elegir carpeta de salida
            string outputFolder = @"C:\CompresorOutput";  // temporal para pruebas
            Directory.CreateDirectory(outputFolder);

            // 3. Obtener algoritmo seleccionado
            AlgorithmSelector algorithm = SelectedAlgorithm;

            // 4. Llamar al servicio
            CompressionService service = new CompressionService();

            CompressionStats stats = service.CompressFiles(
                files,
                outputFolder,
                algorithm
            );

            // 5. Mostrar estadísticas
            MessageBox.Show(
                $"Compresión completada.\n" +
                $"Tiempo: {stats.ElapsedMilliseconds} ms\n" +
                $"Memoria usada: {stats.MemoryBytes} bytes\n" +
                $"Ratio: {Math.Round(stats.CompressionRatio, 3)}",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private AlgorithmSelector GetSelectedAlgorithm()
        {
            string text = cmbAlgorithm.SelectedItem?.ToString() ?? "";

            return text switch
            {
                "Huffman" => AlgorithmSelector.Huffman,
                "LZ77" => AlgorithmSelector.LZ77,
                "LZ78" => AlgorithmSelector.LZ78,
                _ => AlgorithmSelector.Huffman
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
