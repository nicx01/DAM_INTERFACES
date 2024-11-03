using System;
using System.IO;

namespace CambioDivisa.Service
{
    public class FileService
    {
        private readonly string _filesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FILES");

        public FileService()
        {
            EnsureFilesDirectory();
        }

        // Verifica o crea el directorio FILES y sus contenidos
        private void EnsureFilesDirectory()
        {
            if (!Directory.Exists(_filesDirectory))
            {
                Directory.CreateDirectory(_filesDirectory);

                // Crea archivos de texto aleatorios
                File.WriteAllText(Path.Combine(_filesDirectory, $"{Guid.NewGuid()}.txt"), "Contenido de archivo aleatorio 1");
                File.WriteAllText(Path.Combine(_filesDirectory, $"{Guid.NewGuid()}.txt"), "Contenido de archivo aleatorio 2");

                // Crea un subdirectorio
                string subDirectory = Path.Combine(_filesDirectory, $"Dir_{Guid.NewGuid()}");
                Directory.CreateDirectory(subDirectory);
            }
        }

        // Método para obtener la lista de archivos y directorios
        public IEnumerable<FileSystemInfo> GetFilesAndDirectories()
        {
            var directoryInfo = new DirectoryInfo(_filesDirectory);
            return directoryInfo.Exists ? directoryInfo.GetFileSystemInfos() : Array.Empty<FileSystemInfo>();
        }
    }
}
