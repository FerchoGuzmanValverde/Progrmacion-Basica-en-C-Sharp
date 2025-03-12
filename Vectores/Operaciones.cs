using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectores
{
    internal class Operaciones
    {
        Random opRandom = new Random();
        int contador;

        /// <summary>
        /// Retorna un vector generado aleatoriamente
        /// </summary>
        /// <param name="longitud"></param>
        /// <param name="rango"></param>
        /// <returns></returns>
        public int[] vectorAleatorio(int longitud, int rango = 50)
        {
            int[] vector = new int[longitud];
            for (int i = 0; i < longitud; i++)
            {
                vector[i] = opRandom.Next(1, rango);
            }
            return vector;
        }

        /// <summary>
        /// Retorna cuandos valores pares tiene un vector
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int cantValoresPares(int[] y)
        {
            contador = 0;
            for (int i = 0;i < y.Length;i++)
            {
                if (y[i] % 2 == 0)
                    contador++;
            }
            return contador;
        }

        /// <summary>
        /// Retorna cuanto valores impares tiene un vector.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int cantValoresImpares(int[] y)
        {
            contador = 0;
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] % 2 == 1)
                    contador++;
            }
            return contador;
        }

        /// <summary>
        /// Retorna el promedio de los valores de un vector.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int promedioVector(int[] y)
        {
            int promedio = 0;
            for(int i = 0; i < y.Length; i++)
            {
                promedio = promedio + y[i];
            }
            promedio = promedio / y.Length;
            return promedio;
        }

        /// <summary>
        /// Retorna verdadero si dos vectores son iguales.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool igualdadVectores(int[] x, int[] y)
        {
            if (x.Length != y.Length)
                return false;
            
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returna la cantidad de valores de un vector que son mayores al promedio
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int valMayoresAlPromedio(int[] y)
        {
            contador = 0;
            int promedio = promedioVector(y);

            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] > promedio)
                    contador++;
            }
            return contador;
        }

        /// <summary>
        /// Retorna el valor mas alto del vector.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int maximoValorVector(int[] y)
        {
            int max = y[0];
            for (int i = 0;i < y.Length; i++)
            {
                if (y[i] > max)
                    max = y[i];
            }
            return max;
        }

        /// <summary>
        /// Minimo valor del vector.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public int minimoValorVector(int[] y)
        {
            int min = y[0];
            for(int i = 0; i < y.Length; i++)
            {
                if (y[i] < min)
                    min = y[i];
            }
            return min;
        }

        /// <summary>
        /// Retorna la suma de dos vectores
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int[] sumaDeVectores(int[] x, int[] y)
        {
            if(x.Length != y.Length)
                return new int[0];

            int[] vectorResultado = new int[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                vectorResultado[i] = x[i] + y[i];
            }

            return vectorResultado;
        }

        /// <summary>
        /// Retorna la union de dos vectores
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int[] unionDeVectores(int[] x, int[] y)
        {
            int posicion = 0;
            int[] unionVector = new int[x.Length + y.Length];

            for(int i = 0; i < x.Length; i++)
            {
                unionVector[i] = x[i];
                posicion++;
            }
            for (int j = 0; j < y.Length; j++)
            {
                unionVector[posicion] = y[j];
                posicion++;
            }

            return unionVector;
        }

        /// <summary>
        /// Retorna la interseccion de dos vectores
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int[] interseccionDeVectores(int[] x, int[] y)
        {
            int[] vectorUnion = unionDeVectores(x, y);

            int n = vectorUnion.Length, index = 0;
            int[] temp = new int[n];

            for (int i = 0; i < n; i++)
            {
                bool encontrado = false;
                for (int j = 0; j < index; j++)
                    if (vectorUnion[i] == temp[j]) { encontrado = true; break; }

                if (!encontrado) temp[index++] = vectorUnion[i];
            }

            int[] resultado = new int[index];
            for (int i = 0; i < index; i++) resultado[i] = temp[i];
            return resultado;
        }

        /// <summary>
        /// Retorna la diferencia de dos vectores
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int[] diferenciaDeVectores(int[] x, int[] y)
        {
            if (x.Length != y.Length)
                return new int[0];

            int[] vectorResultado = new int[x.Length];

            for (int i = 0; i < x.Length; i++)
            {
                vectorResultado[i] = x[i] + (-y[i]);
            }

            return vectorResultado;
        }
    }
}
