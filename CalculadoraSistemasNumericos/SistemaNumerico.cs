using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraSistemasNumericos
{
    internal class SistemaNumerico
    {
        private Numero num_1, num_2;

        /// <summary>
        /// Metodo General de Sumas
        /// </summary>
        /// <param name="val_1"></param>
        /// <param name="sys_1"></param>
        /// <param name="val_2"></param>
        /// <param name="sys_2"></param>
        /// <returns></returns>
        public string[] Sumar(string val_1, string sys_1, string val_2, string sys_2)
        {
            string[] resultado = new string[4];

            //Asignacion de valores
            num_1 = new Numero(); num_2 = new Numero();
            num_1.Valor = val_1; num_2.Valor = val_2;
            num_1.Sistema = sys_1; num_2.Sistema = sys_2;

            //Suma Decimal
            num_1.ConvertirADecimal(); num_2.ConvertirADecimal();
            resultado[0] = SumaDecimal(int.Parse(num_1.Valor), int.Parse(num_2.Valor)).ToString();

            //Suma Binaria
            num_1.ConvertirABinario(); num_2.ConvertirABinario();
            resultado[1] = SumaBinaria(num_1.Valor, num_2.Valor);

            //Suma Octal
            num_1.ConvertirAOctal(); num_2.ConvertirAOctal();
            resultado[2] = SumaOctal(num_1.Valor, num_2.Valor);

            //Suma Hexadecimal
            num_1.ConvertirAHexadecimal(); num_2.ConvertirAHexadecimal();
            resultado[3] = SumaHexadecimal(num_1.Valor, num_2.Valor);


            return resultado;
        }
        /// <summary>
        /// Metodo General de Restas
        /// </summary>
        /// <param name="val_1"></param>
        /// <param name="sys_1"></param>
        /// <param name="val_2"></param>
        /// <param name="sys_2"></param>
        /// <returns></returns>
        public string[] Restar(string val_1, string sys_1, string val_2, string sys_2)
        {
            string[] resultado = new string[4];

            //Asignacion de valores
            num_1 = new Numero(); num_2 = new Numero();
            num_1.Valor = val_1; num_2.Valor = val_2;
            num_1.Sistema = sys_1; num_2.Sistema = sys_2;

            //Resta Decimal
            num_1.ConvertirADecimal(); num_2.ConvertirADecimal();
            resultado[0] = RestaDecimal(num_1.Valor, num_2.Valor);

            //Resta Binaria
            num_1.ConvertirABinario(); num_2.ConvertirABinario();
            resultado[1] = RestaBinaria(num_1.Valor, num_2.Valor);

            //Resta Octal
            num_1.ConvertirAOctal(); num_2.ConvertirAOctal();
            resultado[2] = RestaOctal(num_1.Valor, num_2.Valor);

            //Resta Hexadecimal
            num_1.ConvertirAHexadecimal(); num_2.ConvertirAHexadecimal();
            resultado[3] = RestaHexadecimal(num_1.Valor, num_2.Valor);

            return resultado;
        }

        //METODOS INDIVIDUALES DE SUMAS
        private string SumaBinaria(string bin1, string bin2)
        {
            int carry = 0;
            string resultado = "";

            int i = bin1.Length - 1, j = bin2.Length - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int bit1 = (i >= 0) ? bin1[i] - '0' : 0;
                int bit2 = (j >= 0) ? bin2[j] - '0' : 0;

                int suma = bit1 + bit2 + carry;
                resultado = (suma % 2) + resultado;
                carry = suma / 2;

                i--;
                j--;
            }

            return resultado;
        }
        private int SumaDecimal(int num1, int num2)
        {
            return num1 + num2;
        }
        private string SumaOctal(string octal1, string octal2)
        {
            // Convertir octales a decimales
            int decimal1 = Convert.ToInt32(octal1, 8);
            int decimal2 = Convert.ToInt32(octal2, 8);

            // Sumar los dos números decimales
            int sumaDecimal = decimal1 + decimal2;

            // Convertir el resultado de nuevo a octal
            string resultadoOctal = Convert.ToString(sumaDecimal, 8);

            return resultadoOctal;
        }
        private string SumaHexadecimal(string hex1, string hex2)
        {
            // Convertir hexadecimales a decimales
            int decimal1 = Convert.ToInt32(hex1, 16);
            int decimal2 = Convert.ToInt32(hex2, 16);

            // Sumar los dos números decimales
            int sumaDecimal = decimal1 + decimal2;

            // Convertir el resultado de nuevo a hexadecimal
            string resultadoHex = Convert.ToString(sumaDecimal, 16).ToUpper();

            return resultadoHex;
        }

        //METODOS INDIVIDUALES DE RESTAS
        private string RestaDecimal(string num1, string num2)
        {
            return Convert.ToString(Convert.ToInt32(num1) - Convert.ToInt32(num2));
        }
        private string RestaBinaria(string num1, string num2)
        {
            // Convertir los números binarios a decimales
            int decimal1 = Convert.ToInt32(num1, 2);
            int decimal2 = Convert.ToInt32(num2, 2);

            // Realizar la resta en decimal
            int restaDecimal = decimal1 - decimal2;

            // Convertir el resultado de vuelta a binario
            string resultadoBinario = Convert.ToString(restaDecimal, 2);

            return resultadoBinario;
        }
        private string RestaOctal(string num1, string num2)
        {
            // Convertir los números octales a decimales
            int decimal1 = Convert.ToInt32(num1, 8);
            int decimal2 = Convert.ToInt32(num2, 8);

            // Realizar la resta en decimal
            int restaDecimal = decimal1 - decimal2;

            // Convertir el resultado de vuelta a octal
            string resultadoOctal = Convert.ToString(restaDecimal, 8);

            return resultadoOctal;
        }
        private string RestaHexadecimal(string num1, string num2)
        {
            // Convertir los números hexadecimales a decimales
            int decimal1 = Convert.ToInt32(num1, 16);
            int decimal2 = Convert.ToInt32(num2, 16);

            // Realizar la resta en decimal
            int restaDecimal = decimal1 - decimal2;

            // Convertir el resultado de vuelta a hexadecimal
            string resultadoHexadecimal = Convert.ToString(restaDecimal, 16).ToUpper();

            return resultadoHexadecimal;
        }
    }
}
