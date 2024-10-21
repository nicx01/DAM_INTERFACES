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
        private void ConvertirImporte(object sender, RoutedEventArgs e)
        {
            float value = float.Parse(textImporte.Text);
            int divisaDe = selectDe.SelectedIndex;
            int divisaA = selectA.SelectedIndex;
            float result=0.00f;
            //0 Euro, 1 Dolar, 2 Libra
            if (divisaDe == divisaA)
            {
                result = value;
            }
            else if (divisaDe == 0)
            {
                if (divisaA == 1)
                {
                    result = value * euroDolar;
                }
                else if (divisaA == 2)
                {
                    result = value * euroDolar / libraDolar;
                }
            }
            else if (divisaDe == 1)
            {
                if (divisaA == 0)
                {
                    result = value * 1 / euroDolar;
                }
                else if (divisaA == 2)
                {
                    result = value * 1 / libraDolar;
                }
            }
            else if (divisaDe == 2)
            {
                if (divisaA == 0)
                {
                    result = value * libraDolar / euroDolar;
                }
                else if (divisaA == 1)
                {
                    result = value * libraDolar;
                }
            }
            resultBox.Text = result.ToString("F2");
            var historico = history.Text;
            var fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
            var resultadoFormateado = result.ToString("F2");
            history.Text = historico + "\n" + $"{fechaHora} - {resultadoFormateado}";

        }

        private void SwapCurrencies_Click(object sender, RoutedEventArgs e)
        {
            var tempCurrency = selectDe.SelectedIndex;
            selectDe.SelectedIndex = selectA.SelectedIndex;
            selectA.SelectedIndex = tempCurrency;
        }

    }
}
