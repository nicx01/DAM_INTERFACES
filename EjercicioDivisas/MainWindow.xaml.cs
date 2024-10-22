using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public float euroDolar = 1.05f;
        public float libraDolar = 1.30f;
        public char[] currencySymbols = { '€', '$', '£' };
        private void ConvertirImporte(object sender, RoutedEventArgs e)
        {
            float value = float.Parse(textImporte.Text);
            int divisaDe = selectDe.SelectedIndex;
            int divisaA = selectA.SelectedIndex;
            float result = 0.00f;
            //0 Euro, 1 Dolar, 2 Libra
            float[,] conversionRates = {
                { 1, euroDolar, euroDolar / libraDolar },      
                { 1 / euroDolar, 1, 1 / libraDolar },          
                { libraDolar / euroDolar, libraDolar, 1 }      
            };
            result = value * conversionRates[divisaDe, divisaA];

            resultBox.Text = result.ToString("F2");
            var divisaDeSeleccionada = currencySymbols[divisaDe];
            var divisaASeleccionada = currencySymbols[divisaA];
            var fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var resultadoFormateado = result.ToString("F2");
            var origenFormateado = value.ToString("F2");

            var nuevaEntrada = $"{fechaHora} - {origenFormateado} {divisaDeSeleccionada} → {resultadoFormateado} {divisaASeleccionada}";
            var historico = history.Text;

            var lineas = historico.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lineas.Length >= 5)
            {
                historico = string.Join("\n", lineas, 1, lineas.Length - 1);
            }

            history.Text = historico + "\n" + nuevaEntrada;

        }

        private void SwapCurrencies_Click(object sender, RoutedEventArgs e)
        {
            var tempCurrency = selectDe.SelectedIndex;
            selectDe.SelectedIndex = selectA.SelectedIndex;
            selectA.SelectedIndex = tempCurrency;
        }

    }
}
