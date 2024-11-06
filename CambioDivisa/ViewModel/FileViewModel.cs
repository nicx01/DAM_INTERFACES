using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using CambioDivisa.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CambioDivisa.ViewModel
{
    public partial class FileViewModel : ViewModelBase
    {
        private readonly FileService _fileService;

        public ObservableCollection<FileSystemInfo> FilesAndDirectories { get; private set; }

        public FileViewModel(FileService fileService)
        {
            _fileService = fileService;
            FilesAndDirectories = new ObservableCollection<FileSystemInfo>(_fileService.GetFilesAndDirectories());
        }

        public override Task LoadAsync()
        {
            return base.LoadAsync();
        }

        [RelayCommand]
        private void CreateFile()
        {
            string newFileName = $"NuevoArchivo_{Guid.NewGuid()}.txt";

            _fileService.CreateFile(newFileName);

            FilesAndDirectories.Add(new FileInfo(Path.Combine(_fileService._filesDirectory, newFileName)));
        }

        [RelayCommand]
        private void CreateDirectory()
        {
            string newDirectoryName = $"NuevoDirectorio_{Guid.NewGuid()}";

            _fileService.CreateDirectory(newDirectoryName);

            FilesAndDirectories.Add(new DirectoryInfo(Path.Combine(_fileService._filesDirectory, newDirectoryName)));
        }
    }
}
