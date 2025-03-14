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
using System.Windows.Shapes;

namespace CalculadoraSistemasNumericos
{
    /// <summary>
    /// Interaction logic for Operaciones.xaml
    /// </summary>
    public partial class Operaciones : Window
    {
        string[] res = new string[4];
        Numero num_1; Numero num_2;
        SistemaNumerico operador;

        public Operaciones()
        {
            InitializeComponent();
        }

        private void btnSumar_Click(object sender, RoutedEventArgs e)
        {
            num_1 = new Numero(); num_2 = new Numero();
            num_1.Valor = txtPrimerValor.Text; num_2.Valor = txtSegundoValor.Text;
            num_1.Sistema = IdentificarSistema(new List<RadioButton> { rbtDecimalPV, rbtBinarioPV, rbtOctalPV, rbtHexadecimalPV });
            num_2.Sistema = IdentificarSistema(new List<RadioButton> { rbtDecimalSV, rbtBinarioSV, rbtOctalSV, rbtHexadecimalSV });

            operador = new SistemaNumerico();
            res = operador.Sumar(num_1.Valor, num_1.Sistema, num_2.Valor, num_2.Sistema);

            ActualizarLabels(res);
        }

        private void btnRestar_Click(object sender, RoutedEventArgs e)
        {
            num_1 = new Numero(); num_2 = new Numero();
            num_1.Valor = txtPrimerValor.Text; num_2.Valor = txtSegundoValor.Text;
            num_1.Sistema = IdentificarSistema(new List<RadioButton> { rbtDecimalPV, rbtBinarioPV, rbtOctalPV, rbtHexadecimalPV });
            num_2.Sistema = IdentificarSistema(new List<RadioButton> { rbtDecimalSV, rbtBinarioSV, rbtOctalSV, rbtHexadecimalSV });

            operador = new SistemaNumerico();
            res = operador.Restar(num_1.Valor, num_1.Sistema, num_2.Valor, num_2.Sistema);

            ActualizarLabels(res);
        }

        private string IdentificarSistema(List<RadioButton> radios)
        {
            foreach (RadioButton rad in radios)
            {
                if (rad.IsChecked == true)
                    return rad.Name.Substring(3, rad.Name.Length - 3 - 2);
            }
            return "";
        }

        private void ActualizarLabels(string[] results)
        {
            lblResultadoDecimal.Content = results[0];
            lblResultadoBinario.Content = results[1];
            lblResultadoOctal.Content = results[2];
            lblResultadoHexadecimal.Content = results[3];
        }
    }
}
