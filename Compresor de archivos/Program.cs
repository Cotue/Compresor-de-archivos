using System;
using System.Windows.Forms;
using Compresor_de_archivos.Interfaz;

namespace Compresor_de_archivos
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}

