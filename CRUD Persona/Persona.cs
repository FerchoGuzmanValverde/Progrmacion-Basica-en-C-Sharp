using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Persona
{
    public class Persona
    {
        #region Atributos
        //Atributos de Perona
        int id, edad;
        string nombre, apellidoPaterno, apellidoMaterno, ci;
        double peso, estatura, imc;
        #endregion

        #region Propiedades
        /// <summary>
        /// Prop: ID Persona
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Prop: Nombre de la persona
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /// <summary>
        /// Prop: Apellido Paterno de Persona
        /// </summary>
        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }
        /// <summary>
        /// Prop: Apellido Materno de Persona
        /// </summary>
        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }
        /// <summary>
        /// Prop: Edad de Persona
        /// </summary>
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        /// <summary>
        /// Prop: Estatura de Persona
        /// </summary>
        public double Estatura
        {
            get { return estatura; }
            set { estatura = value; }
        }
        /// <summary>
        /// Prop: Peso de Persona
        /// </summary>
        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        /// <summary>
        /// Prop: IMC de Persona
        /// </summary>
        public double IMC
        {
            get { return imc; }
            set { imc = Math.Round(value,3); }
        }
        #endregion

        #region Metodos
        public double SacarIMC()
        {
            return peso / (Math.Pow((estatura/100), 2));
        }
        #endregion
    }
}
