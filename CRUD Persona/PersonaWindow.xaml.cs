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

namespace CRUD_Persona
{
    /// <summary>
    /// Interaction logic for PersonaWindow.xaml
    /// </summary>
    public partial class PersonaWindow : Window
    {
        int operacion = 0, idPersona;
        List<Persona> DB_Persona;
        Persona p_operador = new Persona();
        
        public PersonaWindow(int op, List<Persona> db, int id = -1)
        {
            operacion = op;
            DB_Persona = db;
            idPersona = id;

            InitializeComponent();

            Titulos();
        }

        private void Titulos()
        {
            if (operacion == 0)
            {
                lblTitulo.Content = "AGREGAR PERSONA";
                btnOperar.Content = "AGREGAR";
            }
            else
            {
                lblTitulo.Content = "MODIFICAR PERSONA";
                btnOperar.Content = "MODIFICAR";
                CargarDatos();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, RoutedEventArgs e)
        {
            if (operacion == 0)
            {
                //AGREGAR
                string[] nombreCompleto = txtNombreCompleto.Text.Split(' ');
                p_operador.Id = Enumerable.Range(1, DB_Persona.Count + 1).Except(DB_Persona.Select(p => p.Id)).FirstOrDefault();
                p_operador.Nombre = nombreCompleto[0];
                p_operador.ApellidoPaterno = nombreCompleto[1];
                p_operador.ApellidoMaterno = nombreCompleto[2];
                p_operador.Edad = int.Parse(txtEdad.Text);
                p_operador.Estatura = double.Parse(txtEstatura.Text);
                p_operador.Peso = double.Parse(txtPeso.Text);
                p_operador.IMC = p_operador.SacarIMC();

                DB_Persona.Add(p_operador);

                MessageBox.Show("Persona agregada correctamente!");
            } else
            {
                //MODIFICAR
                var persona = DB_Persona.FirstOrDefault(p => p.Id == idPersona);

                string[] nombreCompleto = txtNombreCompleto.Text.Split(' ');
                persona.Nombre = nombreCompleto[0];
                persona.ApellidoPaterno = nombreCompleto [1];
                persona.ApellidoMaterno = nombreCompleto[2];
                persona.Edad = int.Parse(txtEdad.Text);
                persona.Estatura = double.Parse(txtEstatura.Text);
                persona.Peso = double.Parse (txtPeso.Text);
                persona.IMC = persona.SacarIMC();

                MessageBox.Show("Persona actualizada correctamente!");
            }
            this.Close();
        }

        private void CargarDatos()
        {
            p_operador = DB_Persona.FirstOrDefault(p => p.Id == idPersona);
            txtNombreCompleto.Text = p_operador.Nombre + " " + p_operador.ApellidoPaterno + " " + p_operador.ApellidoMaterno;
            txtEdad.Text = p_operador.Edad.ToString();
            txtEstatura.Text = p_operador.Estatura.ToString();
            txtPeso.Text = p_operador.Peso.ToString();
            lblIMC.Content = "IMC: " + p_operador.SacarIMC();
        }

        private void txtPeso_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPeso.Text != "" && txtEstatura.Text != "")
                ActualizarIMC();
            else
                lblIMC.Content = "IMC: ";
        }

        private void txtEstatura_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPeso.Text != "" && txtEstatura.Text != "")
                ActualizarIMC();
            else
                lblIMC.Content = "IMC: ";
        }

        public void ActualizarIMC()
        {
            p_operador.Estatura = double.Parse(txtEstatura.Text);
            p_operador.Peso = double.Parse(txtPeso.Text);
            lblIMC.Content = "IMC: " + Math.Round(p_operador.SacarIMC(), 3).ToString();
        }
    }
}
