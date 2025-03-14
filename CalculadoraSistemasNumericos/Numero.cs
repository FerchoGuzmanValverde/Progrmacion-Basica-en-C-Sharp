using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalculadoraSistemasNumericos
{
    class Numero
    {
        string valor;
        string sistema = "Decimal";

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public string Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }

        public string IdentificarSistema()
        {
            if (valor.ToString().All(c => c == '0' || c == '1'))
                return "Binario";
            else if (valor.ToString().All(c => c >= '0' && c <= '7'))
                return "Octal";
            else if (valor.ToString().All(char.IsDigit))
                return "Decimal";
            else if (valor.ToString().All(c => char.IsDigit(c) || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                sistema = "Hexadecimal";
            else
                return "Decimal";
            return "";
        }

        public void ConvertirADecimal()
        {
            string resultado;
            int potencia, result;
            switch (sistema)
            {
                case "Octal":
                    string octal = valor.ToString();
                    result = 0; potencia = 1;

                    for (int i = octal.Length - 1; i >= 0; i--)
                    {
                        int digito = octal[i] - '0';
                        result += digito * potencia;
                        potencia *= 8;
                    }
                    valor = result.ToString();
                    break;
                case "Binario":
                    string binario = valor.ToString();
                    result = 0; potencia = 1;

                    for (int i = binario.Length - 1; i >= 0; i--)
                    {
                        int digito = binario[i] - '0';
                        result += digito * potencia;
                        potencia *= 2;
                    }
                    valor = result.ToString();
                    break;
                case "Hexadecimal":
                    string hexadecimal = valor;
                    result = 0; potencia = 1;

                    for (int i = hexadecimal.Length - 1; i >= 0; i--)
                    {
                        char c = hexadecimal[i];
                        int valor;

                        if (c >= '0' && c <= '9') valor = c - '0';
                        else if (c >= 'A' && c <= 'F') valor = c - 'A' + 10;
                        else if (c >= 'a' && c <= 'f') valor = c - 'a' + 10;
                        else throw new ArgumentException("Número hexadecimal inválido");

                        result += valor * potencia;
                        potencia *= 16;
                    }
                    valor = result.ToString();
                    break;
                default:
                    break;
            }
            sistema = "Decimal";
        }

        public void ConvertirABinario()
        {
            int numero;
            string binario;
            switch (sistema)
            {
                case "Decimal":
                    numero = int.Parse(valor);
                    if (valor == "0") valor = "0";

                    binario = "";
                    while (numero > 0)
                    {
                        binario = (numero % 2) + binario;
                        numero /= 2;
                    }
                    valor = binario;
                    break;
                case "Octal":
                    // Paso 1: Convertir octal a decimal
                    ConvertirADecimal();
                    numero = int.Parse(valor);

                    // Paso 2: Convertir decimal a binario
                    binario = "";
                    while (numero > 0)
                    {
                        binario = (numero % 2) + binario;
                        numero /= 2;
                    }

                    valor = binario == "" ? "0" : binario;
                    break;
                case "Hexadecimal":
                    string[] tablaBinaria = { 
                        "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111",
                        "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"
                    };

                    binario = "";
                    string hex = valor;
                    foreach (char c in hex)
                    {
                        int valor = (c >= '0' && c <= '9') ? c - '0' : c - 'A' + 10;
                        binario += tablaBinaria[valor];
                    }

                    valor = binario.TrimStart('0');
                    break;
                default:
                    break;
            }
            sistema = "Binario";
        }

        public void ConvertirAOctal()
        {
            long numero;
            string octal;
            switch (sistema)
            {
                case "Decimal":
                    numero = long.Parse(valor);
                    if (numero == 0) valor = "0";

                    octal = "";
                    while (numero > 0)
                    {
                        long residuo = numero % 8;
                        octal = residuo + octal;
                        numero /= 8;
                    }

                    valor = octal;
                    break;
                case "Binario":
                    numero = long.Parse (valor);
                    // Asegurar que la longitud sea múltiplo de 3 rellenando con ceros a la izquierda
                    while (valor.ToString().Length % 3 != 0)
                        valor = 0 + valor;

                    octal = "";

                    // Recorrer el binario en grupos de 3
                    for (int i = 0; i < valor.ToString().Length; i += 3)
                    {
                        string grupo = valor.ToString().Substring(i, 3);
                        int valorOctal = (grupo[0] - '0') * 4 + (grupo[1] - '0') * 2 + (grupo[2] - '0') * 1;
                        octal += valorOctal.ToString();
                    }

                    valor = octal;
                    break;
                case "Hexadecimal":
                    ConvertirABinario();
                    ConvertirAOctal();
                    break;
                default:
                    break;
            }
            sistema = "Octal";
        }

        public void ConvertirAHexadecimal()
        {
            int numero = int.Parse(valor);
            string hex;
            switch (sistema)
            {
                case "Decimal":
                    if (numero == 0) valor = "0";

                    hex = "";
                    char[] hexChars = "0123456789ABCDEF".ToCharArray();

                    while (numero > 0)
                    {
                        int residuo = numero % 16;
                        hex = hexChars[residuo] + hex;
                        numero /= 16;
                    }

                    valor = hex;
                    break;
                case "Binario":

                    // Asegurar que la longitud del binario sea múltiplo de 4
                    while (valor.ToString().Length % 4 != 0)
                        valor = 0 + valor;

                    hex = "";
                    Dictionary<string, char> binToHex = new Dictionary<string, char>()
                    {
                        {"0000", '0'}, {"0001", '1'}, {"0010", '2'}, {"0011", '3'},
                        {"0100", '4'}, {"0101", '5'}, {"0110", '6'}, {"0111", '7'},
                        {"1000", '8'}, {"1001", '9'}, {"1010", 'A'}, {"1011", 'B'},
                        {"1100", 'C'}, {"1101", 'D'}, {"1110", 'E'}, {"1111", 'F'}
                    };

                    for (int i = 0; i < valor.ToString().Length; i += 4)
                    {
                        string bloque = valor.ToString().Substring(i, 4);
                        hex += binToHex[bloque];
                    }

                    valor = hex;
                    break;
                case "Octal":
                    ConvertirADecimal();
                    ConvertirAHexadecimal();
                    break;
                default:
                    break;
            }
        }
    }
}
