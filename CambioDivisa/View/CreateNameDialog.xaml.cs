using System.Windows;

namespace CambioDivisa.View
{
    public partial class CreateNameDialog : Window
    {
        public string InputName { get; private set; }
        private readonly bool _isCreatingFile;

        public CreateNameDialog(bool isCreatingFile)
        {
            InitializeComponent();
            _isCreatingFile = isCreatingFile;
            DialogTitle.Text = isCreatingFile ? "Introduce el nombre del archivo:" : "Introduce el nombre del directorio:";
        }

        private void OnCreateButtonClick(object sender, RoutedEventArgs e)
        {
            InputName = NameInput.Text;
            DialogResult = true;
            Close();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
