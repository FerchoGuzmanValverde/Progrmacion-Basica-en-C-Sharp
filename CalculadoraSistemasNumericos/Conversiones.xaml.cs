using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for Conversiones.xaml
    /// </summary>
    public partial class Conversiones : Window
    {
        Numero sistemaNumerico;
        public Conversiones()
        {
            InitializeComponent();
        }

        private void btnConvertir_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarValor(txtValor))
            {
                sistemaNumerico = new Numero();
                sistemaNumerico.Valor = txtValor.Text;

                if (rbtDecimal_In.IsChecked == true)
                {
                    sistemaNumerico.Sistema = "Decimal";
                    if (rbtBinario_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirABinario();
                    } else if (rbtOctal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirAOctal();
                    } else if (rbtHexadecimal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirAHexadecimal();
                    }
                } else if (rbtBinario_In.IsChecked == true)
                {
                    sistemaNumerico.Sistema = "Binario";
                    if (rbtDecimal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirADecimal();
                    } else if (rbtOctal_Out.IsChecked== true)
                    {
                        sistemaNumerico.ConvertirAOctal();
                    } else if (rbtHexadecimal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirAHexadecimal();
                    }
                } else if (rbtOctal_In.IsChecked == true)
                {
                    sistemaNumerico.Sistema = "Octal";
                    if (rbtDecimal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirADecimal();
                    } else if (rbtBinario_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirABinario();
                    } else if (rbtHexadecimal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirAHexadecimal();
                    }
                } else if (rbtHexadecimal_In.IsChecked == true)
                {
                    sistemaNumerico.Sistema = "Hexadecimal";
                    if (rbtDecimal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirADecimal();
                    } else if (rbtBinario_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirABinario();
                    } else if (rbtOctal_Out.IsChecked == true)
                    {
                        sistemaNumerico.ConvertirAOctal();
                    }
                }
                ActualizarResultado(sistemaNumerico.Valor, sistemaNumerico.Sistema);
            } else { MessageBox.Show("Debe ingresar un valor!"); }
        }

        private void ActualizarResultado(string result, string system)
        {
            lblResultado.Content = system + ":  " + result;
        }

        private bool ValidarValor(TextBox texto)
        {
            if (texto.Text == "")
                return false;

            return true;
        }
    }
}
