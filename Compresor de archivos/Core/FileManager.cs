using System;
using System.Collections.Generic;
using System.IO;

namespace Compresor_de_archivos.Core
{
    public class FileManager
    {
        private readonly List<string> _files = new List<string>();

        public IReadOnlyList<string> Files => _files.AsReadOnly();
        //Función para agregar un archivo a la lista
        public bool AddFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            if (!File.Exists(path))
                return false;

            if (_files.Contains(path))
                return false;

            _files.Add(path);
            return true;
        }
        //Función para agregar múltiples archivos a la lista
        public bool AddFiles(IEnumerable<string> files)
        {
            bool addedAny = false;

            foreach (var file in files)
            {
                if (AddFile(file))
                    addedAny = true;
            }

            return addedAny;
        }

        public void Clear()
        {
            _files.Clear();
        }
    }
}
