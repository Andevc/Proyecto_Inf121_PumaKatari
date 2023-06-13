using PumaKatariConsola;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PumaKatari.Screens
{
    /// <summary>
    /// Lógica de interacción para Registro_Buses.xaml
    /// </summary>
    public partial class Registro_Buses : Window
    {
        public ArchBus regBus = new ArchBus("RegistroBuses.dat");
        public Registro_Buses()
        {
            InitializeComponent();
            ActualizarArchivo();
        }
        
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            regBus.CrearRegBus();
            MessageBox.Show("Nuevo registro de Buses Creado");
            ActualizarArchivo();

        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            Screens.DataFill.Datos_Bus datBus = new Screens.DataFill.Datos_Bus();
            datBus.ShowDialog();
            ActualizarArchivo();
        }

        // El Metodo ActualizarArchivo sustituye al metodo Listar en la Clase ArchBus
        private void ActualizarArchivo()
        {
            Stream file = File.Open("RegistroBuses.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            List<Bus> listBus = new List<Bus>();
            try
            {
                while (true)
                {
                    Bus buses = new Bus();
                    buses.RdBus(read);
                    listBus.Add(buses);
                }
            }
            catch (Exception) { Console.WriteLine("Fin Mostrar Lista Buses"); }

            finally { file.Close(); }

            dgBuses.ItemsSource = listBus;
        }


        private void btnCLose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

   
    }
}
