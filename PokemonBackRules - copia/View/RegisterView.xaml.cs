using PokemonBackRules.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokemonBackRules.View
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }
        private void PasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                var password = passwordBox.Password;

                var viewModel = this.DataContext as PokemonBackRules.ViewModel.RegisterViewModel;
                if (viewModel != null)
                {
                    viewModel.Password = password;
                }
            }
        }
     private void ConfirmPasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                var confirmPassword = passwordBox.Password;
                var viewModel = this.DataContext as PokemonBackRules.ViewModel.RegisterViewModel;
                if (viewModel != null)
                {
                    viewModel.ConfirmPassword = confirmPassword;
                }
            }
        }
    }
}
