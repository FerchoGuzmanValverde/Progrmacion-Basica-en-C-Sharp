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

namespace CRUD_Persona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persona> personaList = new List<Persona>();
        int seleccionado = 0;

        public MainWindow()
        {
            InitializeComponent();
            ActualizarDatos();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dtgListaPersonas.ItemsSource = personaList.Where(p => p.Nombre == txtDato.Text || p.ApellidoPaterno == txtDato.Text || p.ApellidoMaterno == txtDato.Text);
            dtgListaPersonas.Items.Refresh();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            PersonaWindow opWindow = new PersonaWindow(0, personaList);
            opWindow.ShowDialog();
            ActualizarDatos();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            PersonaWindow opWindow = new PersonaWindow(1, personaList, dtgListaPersonas.SelectedIndex);
            opWindow.ShowDialog();
            ActualizarDatos();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            personaList.Remove(personaList[seleccionado]);
            ActualizarDatos();
        }

        private void dtgListaPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seleccionado = dtgListaPersonas.SelectedIndex;
        }

        private void ActualizarDatos()
        {
            dtgListaPersonas.ItemsSource = personaList;
            dtgListaPersonas.Items.Refresh();
        }

        private void btnMostarTodos_Click(object sender, RoutedEventArgs e)
        {
            ActualizarDatos();
        }
    }
}