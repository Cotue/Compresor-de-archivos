using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace Compresor_de_archivos.Interfaz
{
    public class DragDropComponent : Component
    {
        private Control target;

        public event Action<string[]> FilesDropped;

        public void Attach(Control control)
        {
            target = control;
            target.AllowDrop = true;

            target.DragEnter += Target_DragEnter;
            target.DragDrop += Target_DragDrop;
        }

        private void Target_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Target_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            FilesDropped?.Invoke(files);
        }
    }
}