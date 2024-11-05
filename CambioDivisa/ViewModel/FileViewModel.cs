using System.Collections.ObjectModel;
using System.IO;
using CambioDivisa.Service;
using CommunityToolkit.Mvvm.ComponentModel;

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
    }
}
