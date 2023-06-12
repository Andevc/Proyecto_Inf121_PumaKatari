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
    /// Lógica de interacción para Registro_Rutas.xaml
    /// </summary>
    public partial class Registro_Rutas : Window
    {
        public ArchRuta regRuta = new ArchRuta("RegistroRutas.dat");
        public Registro_Rutas()
        {
            InitializeComponent();
            ActualizarArchivo();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            regRuta.CrearRegRuta();
            MessageBox.Show("Nuevo Archivo de Rutas Creado");
            ActualizarArchivo();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            Screens.DataFill.Datos_Ruta datRuta = new DataFill.Datos_Ruta();
            datRuta.ShowDialog();
            ActualizarArchivo();
        }

        private void ActualizarArchivo()
        {
            Stream file = File.Open("RegistroRutas.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            List<Ruta> listRuta = new List<Ruta>();
            try
            {
                while (true)
                {
                    Ruta ruta = new Ruta();
                    ruta.ReadRuta(read);
                    listRuta.Add(ruta);
                }
            }
            catch (Exception) { Console.WriteLine("Fin Registro Rutas"); }

            finally { file.Close(); }

            dgRutas.ItemsSource = listRuta;
        }

        private void btnCLose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
