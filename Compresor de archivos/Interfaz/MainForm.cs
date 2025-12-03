using Compresor_de_archivos.Interfaz;
using Compresor_de_archivos.Core;
using System;
using System.Windows.Forms;
namespace Compresor_de_archivos.Interfaz
{
    public partial class MainForm : Form
    {
        private readonly FileManager fileManager = new FileManager();
        private readonly DragDropComponent drag = new DragDropComponent(); // Fixed CS1002: Added missing semicolon

        public MainForm()
        {
            InitializeComponent();

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
