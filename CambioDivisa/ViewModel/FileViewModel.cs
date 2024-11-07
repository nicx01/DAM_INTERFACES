using CambioDivisa.View;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CambioDivisa.Service;

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
            string fileName = ShowCreateNameDialog(isCreatingFile: true);
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                _fileService.CreateFile(fileName+ ".txt");
                FilesAndDirectories.Add(new FileInfo(Path.Combine(_fileService._filesDirectory, fileName+ ".txt")));
            }
        }

        [RelayCommand]
        private void CreateDirectory()
        {
            string directoryName = ShowCreateNameDialog(isCreatingFile: false);
            if (!string.IsNullOrWhiteSpace(directoryName))
            {
                _fileService.CreateDirectory(directoryName);
                FilesAndDirectories.Add(new DirectoryInfo(Path.Combine(_fileService._filesDirectory, directoryName)));
            }
        }

        private string ShowCreateNameDialog(bool isCreatingFile)
        {
            var dialog = new CreateNameDialog(isCreatingFile);
            return dialog.ShowDialog() == true ? dialog.InputName : null;
        }
    }
}
