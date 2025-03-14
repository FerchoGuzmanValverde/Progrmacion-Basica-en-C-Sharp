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

namespace CalculadoraSistemasNumericos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConversiones_Click(object sender, RoutedEventArgs e)
        {
            Conversiones nuevaVentana = new Conversiones();
            nuevaVentana.ShowDialog();
        }

        private void btnOperaciones_Click(object sender, RoutedEventArgs e)
        {
            Operaciones nuevaVentana = new Operaciones();
            nuevaVentana.ShowDialog();
        }
    }
}