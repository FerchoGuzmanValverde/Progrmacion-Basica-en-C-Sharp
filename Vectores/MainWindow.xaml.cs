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

namespace Vectores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] vector_1, vector_2;
        int longitud;
        Operaciones vectorOp = new Operaciones();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAleatorio_Click(object sender, RoutedEventArgs e)
        {
            if (txtLongitudVectores.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor numérico en longitud de vectores!");
            } else
            {
                longitud = int.Parse(txtLongitudVectores.Text);
                vector_1 = vectorOp.vectorAleatorio(longitud, 10);
                vector_2 = vectorOp.vectorAleatorio(longitud, 10);

                llenarVentana();
            }
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (txtLongitudVectores.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor numérico en longitud de vectores!");
            }
            else
            {
                longitud = int.Parse(txtLongitudVectores.Text);
                vector_1 = llenarVector(longitud);
                vector_2 = llenarVector(longitud);

                llenarVentana();
            }
        }

        private int[] llenarVector(int longitud)
        {
            int[] vectorLleno = new int[longitud];
            for (int i = 0; i < vectorLleno.Length; i++)
            {
                vectorLleno[i] = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Ingrese valor:"));
            }
            return vectorLleno;
        }

        private void llenarVentana()
        {
            //Desplegar vectores
            lstMostrarVectorUno.Items.Clear();
            desplegarVector(vector_1, lstMostrarVectorUno);
            lstMostrarVectorDos.Items.Clear();
            desplegarVector(vector_2, lstMostrarVectorDos);

            //Promedio
            lblPromedioVectorUno.Content = vectorOp.promedioVector(vector_1);
            lblPromedioVectorDos.Content = vectorOp.promedioVector(vector_2);
            //Máximo
            lblMaximoVectorUno.Content = vectorOp.maximoValorVector(vector_1);
            lblMaximoVectorDos.Content = vectorOp.maximoValorVector(vector_2);
            //Mínimo
            lblMinimoVectorUno.Content = vectorOp.minimoValorVector(vector_1);
            lblMinimoVectorDos.Content = vectorOp.minimoValorVector(vector_2);
            //Repetidos
            lblParesVectorUno.Content = vectorOp.cantValoresPares(vector_1);
            lblParesVectorDos.Content = vectorOp.cantValoresPares(vector_2);
            //Suma de Vectores
            lstSumaVectores.Items.Clear();
            desplegarVector(vectorOp.sumaDeVectores(vector_1, vector_2), lstSumaVectores);
            //Union de Vectores
            lstUnionVectores.Items.Clear();
            desplegarVector(vectorOp.unionDeVectores(vector_1, vector_2), lstUnionVectores);
            //Interseccion de Vectores
            lstInterseccionVectores.Items.Clear();
            desplegarVector(vectorOp.interseccionDeVectores(vector_1, vector_2), lstInterseccionVectores);
            //Diferencia de Vectores
            lstDiferenciaVectores.Items.Clear();
            desplegarVector(vectorOp.diferenciaDeVectores(vector_1, vector_2), lstDiferenciaVectores);

            //Graficar vector 1
            lstGraficaVectorUno.Items.Clear();
            graficarVector(vector_1, lstGraficaVectorUno);
            //Graficar vector 2
            lstGraficaVectorDos.Items.Clear();
            graficarVector(vector_2, lstGraficaVectorDos);
        }

        private void desplegarVector(int[] vector, ListBox listBox)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                listBox.Items.Add(vector[i]);
            }
        }

        private void graficarVector(int[] vector, ListBox listBox)
        {
            string aux;
            for(int i = 0; i < vector.Length; i++)
            {
                aux = "";
                for (int j = 0; j < vector[i]; j++)
                {
                    aux = aux + "X";
                }
                listBox.Items.Add(aux);
            }
        }

        private void crearVectores(int cant)
        {
            
        }
    }
}