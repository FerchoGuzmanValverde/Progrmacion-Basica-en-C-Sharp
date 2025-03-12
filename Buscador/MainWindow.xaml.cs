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
using System.Linq;

namespace Buscador
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persona persona;
        List<Persona> personaList = new List<Persona>();
        public MainWindow()
        {
            InitializeComponent();
            ActualizarTabla(personaList);
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampo(txtNombre) && ValidarCampo(txtApellido) && ValidarCampo(txtPeso) && ValidarCampo(txtEstatura))
            {
                persona = new Persona();

                try
                {
                    persona.Nombre = txtNombre.Text;
                    persona.Apellido = txtApellido.Text;
                    persona.Peso = double.Parse(txtPeso.Text);
                    persona.Estatura = double.Parse(txtEstatura.Text);
                    persona.IMC = persona.obtenerIMC();
                    persona.DescripcionIMC = persona.descripcionIMC();
                    persona.Codigo = persona.generarCodigoPersona();

                    personaList.Add(persona);
                    ActualizarTabla(personaList);
                    //Limpiar campos
                    LimpiarCampos(txtNombre); LimpiarCampos(txtApellido); LimpiarCampos(txtEstatura); LimpiarCampos(txtPeso);
                    //Actualizar Label de Registros
                    ActualizarLabelRegistros();
                }
                catch (Exception)
                {
                    MessageBox.Show("Porfavor asegurese que los datos ingresados esten en el formato correcto!", "ERROR DE DATOS");
                } 
            } else { MessageBox.Show("Porfavor llene todos los campos correctamente para registrar!"); }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampo(txtBuscar))
            {
                try
                {
                    var personasFiltradas = personaList.Where(p => p.Apellido == txtBuscar.Text || p.Nombre == txtBuscar.Text || p.Codigo == txtBuscar.Text).ToList();
                    ActualizarTabla(personasFiltradas);
                    LimpiarCampos(txtBuscar);
                    ActualizarLabelRegistros();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al realizar la busqueda!");
                }
            } else { MessageBox.Show("Porfavor coloque un código, nombre o apellido para buscar!"); }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCampo(txtBuscar))
            {
                try
                {
                    var personaAEliminar = personaList.FirstOrDefault(p => (p.Nombre + " " + p.Apellido) == txtBuscar.Text || p.Codigo == txtBuscar.Text);

                    if (personaAEliminar != null)
                    {
                        personaList.Remove(personaAEliminar);
                        ActualizarTabla(personaList);
                        LimpiarCampos(txtBuscar);
                        ActualizarLabelRegistros();
                    } else { MessageBox.Show("No se encontro a la persona!"); }
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al eliminar el registro!");
                }
            } else { MessageBox.Show("Porfavor coloque un código o nombre completo para eliminar!"); }
        }

        private bool ValidarCampo(TextBox texto)
        {
            if (texto.Text.Trim() == "")
            {
                return false;
            }

            return true;
        }

        private void ActualizarTabla(List<Persona> lista)
        {
            dtgDatos.ItemsSource = lista;
            dtgDatos.Items.Refresh();
        }

        private void ActualizarLabelRegistros()
        {
            lblTotalRegistros.Content = "El número total de registros es: " + dtgDatos.Items.Count.ToString();
        }

        private void LimpiarCampos(TextBox campo)
        {
            campo.Clear();
        }

        private void btnTodos_Click(object sender, RoutedEventArgs e)
        {
            ActualizarTabla(personaList);
            ActualizarLabelRegistros();
        }
    }
}