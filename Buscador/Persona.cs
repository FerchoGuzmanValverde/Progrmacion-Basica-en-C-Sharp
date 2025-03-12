using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscador
{
    internal class Persona
    {
        /// <summary>
        /// Declaracion de variables
        /// </summary>
        public double peso, estatura, imc;
        public string nombre, apellido, descripcion, codigo;

        /// <summary>
        /// 
        /// </summary>
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public double Peso 
        { 
            get { return peso; }
            set {  peso = value; } 
        }
        public double Estatura 
        { 
            get { return estatura; }
            set { estatura = value; } 
        }
        public double IMC
        {
            get { return imc; }
            set { imc = value; }
        }
        public string DescripcionIMC
        {
            get { return descripcion; }
            set { descripcion = value; }    
        }

        public string generarCodigoPersona()
        {
            return nombre[0].ToString() + apellido[0].ToString() + peso.ToString();
        }

        public double obtenerIMC()
        {
            return Math.Round(peso / Math.Pow(estatura / 100, 2), 5);
        }

        public string descripcionIMC()
        {
            if (imc < 18.5)
                return "Por debajo del peso";
            else if (imc >= 18.5 && imc < 25)
                return "Saludable";
            else if (imc >= 25 && imc < 30)
                return "Con sobrepeso";
            else if (imc >= 30 && imc < 40)
                return "Obeso";
            else if (imc >= 40)
                return "Obesidad Extrema";
            else return "";
        }
    }
}
