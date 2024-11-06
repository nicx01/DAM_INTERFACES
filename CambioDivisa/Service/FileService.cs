using System;
using System.Collections.Generic;
using System.IO;

namespace CambioDivisa.Service
{
    public class FileService
    {
        public readonly string _filesDirectory = "FILES";

        public FileService()
        {
            EnsureFilesDirectory();
        }

        private void EnsureFilesDirectory()
        {
            if (!Directory.Exists(_filesDirectory))
            {
                Directory.CreateDirectory(_filesDirectory);

                File.WriteAllText(Path.Combine(_filesDirectory, $"{Guid.NewGuid()}.txt"), "Contenido de archivo aleatorio 1");
                File.WriteAllText(Path.Combine(_filesDirectory, $"{Guid.NewGuid()}.txt"), "Contenido de archivo aleatorio 2");

                string subDirectory = Path.Combine(_filesDirectory, $"Dir_{Guid.NewGuid()}");
                Directory.CreateDirectory(subDirectory);
            }
        }

        public IEnumerable<FileSystemInfo> GetFilesAndDirectories()
        {
            var directoryInfo = new DirectoryInfo(_filesDirectory);
            return directoryInfo.Exists ? directoryInfo.GetFileSystemInfos() : Array.Empty<FileSystemInfo>();
        }

        public void CreateFile(string fileName)
        {
            string filePath = Path.Combine(_filesDirectory, fileName);

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) { }
            }
        }

        public void CreateDirectory(string directoryName)
        {
            string directoryPath = Path.Combine(_filesDirectory, directoryName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
