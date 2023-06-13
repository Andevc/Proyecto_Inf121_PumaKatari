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

namespace PumaKatari.Screens {
    public partial class Fechas_Recorrido : Window {
        public ArchFecha fechaRecorrida = new ArchFecha("RegistroFechas.dat");
        public Fechas_Recorrido() {
            
            InitializeComponent();
            ActualizarArchivo();

        }
        private void btnCrear_Click(object sender, RoutedEventArgs e) {
            fechaRecorrida.CrearRegFecha();
            MessageBox.Show("Nuevo Archivo Fecha Recorrido Creada");
            ActualizarArchivo();
        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e) {
            DataFill.Fecha_Recorridos fechaRecorridos = new DataFill.Fecha_Recorridos();
            fechaRecorridos.ShowDialog();
            ActualizarArchivo();
        }

        // El Metodo ActualizarArchivo sustituye al metodo Listar en la Clase ArchFecha
        private void ActualizarArchivo() {
            Stream file = File.Open("RegistroFechas.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            
            List<Fecha> listRegFechas = new List<Fecha>();
            
            try {
                while (true) {
                    Fecha fecha = new Fecha();
                    fecha.RdFecha(read);
                    listRegFechas.Add(fecha);
                }
            }
            catch (Exception) { Console.WriteLine("--x-- Fin Actualizacion --x--"); }
            
            finally { file.Close(); }

            dgFechaRecorrido.ItemsSource = listRegFechas;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
