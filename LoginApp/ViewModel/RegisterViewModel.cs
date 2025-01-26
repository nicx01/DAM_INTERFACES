using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;

namespace PokemonBackRules.ViewModel
{
   public class ErrorResponse
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
    }
    public partial class RegisterViewModel : ViewModelBase
    {
        private string _userName;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _errorMessage;

        // Instancia estática de HttpClient para realizar solicitudes HTTP
        private static readonly HttpClient httpClient = new HttpClient();

        // Propiedades de enlace de datos
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        // Comando de registro que llama a OnRegisterAsync
        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            // Asocia el comando RegisterCommand al método OnRegisterAsync
            RegisterCommand = new RelayCommand(async (parameter) => await OnRegisterAsync(), CanRegister);
        }

        // Método que valida si se pueden activar las acciones de registro (si los campos están completos)
        private bool CanRegister(object parameter)
        {
            return !string.IsNullOrEmpty(UserName) &&
                   !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(ConfirmPassword);
        }

        // Método que se ejecuta cuando el usuario hace clic en "Register"
        private async Task OnRegisterAsync()
        {
            // Validar si las contraseñas coinciden
            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return;
            }

            // Crear un objeto anónimo con los datos del usuario
            var user = new
            {
                name = UserName,          // "name" en vez de "userName"
                userName = UserName,      // "userName" como estaba
                email = Email,
                password = Password,
                role = "admin"            // Asignar "admin" a role
            };

            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("https://localhost:7777/api/users/register", content);

                if (response.IsSuccessStatusCode)
                {
                    ErrorMessage = "Registration successful!";
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var errorDetails = JsonSerializer.Deserialize<ErrorResponse>(errorResponse);

                        ErrorMessage = $"Registration failed: {errorDetails?.Detail ?? errorDetails?.Title ?? "Unknown error"}";
                    }
                    catch (JsonException)
                    {
                        ErrorMessage = $"Registration failed. Response: {errorResponse}";
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones (por ejemplo, problemas de red, servidor no disponible, etc.)
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
        }

        // Método que notifica cuando una propiedad cambia (para que la vista se actualice)
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Implementación simple de ICommand
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
