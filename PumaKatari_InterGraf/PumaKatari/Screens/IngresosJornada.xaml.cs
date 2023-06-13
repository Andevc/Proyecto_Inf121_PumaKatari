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
    /// Lógica de interacción para IngresosJornada.xaml
    /// </summary>
    public partial class IngresosJornada : Window
    {
        public IngresosJornada()
        {
            InitializeComponent();
        }

        private void btnIngresoJornada_Click(object sender, RoutedEventArgs e)
        {
            
            ArchBus archBus = new ArchBus("RegistroBuses.dat");
            ArchRuta archRuta = new ArchRuta("RegistroRutas.dat");
            ArchFecha archFecha = new ArchFecha("RegistroFechas.dat");
            ActualizarRegistro(txtFechaJornada.Text, archBus);
            double ingreso = archFecha.IngresoJornada(txtFechaJornada.Text,archBus,archRuta);
            
            txtIngresoJornada.Text = "Los ingresos que ocurrieron durante la jornada del "+txtFechaJornada.Text+
                " tiene un monto total de: "+ingreso.ToString("0.00");
        }

        private void ActualizarRegistro(string jornada, ArchBus archBus)
        {
            Stream file = File.Open("RegistroFechas.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            List<Bus> busList = new List<Bus>();
            try
            {
                while (true)
                {
                    Fecha fecha = new Fecha();
                    fecha.RdFecha(read);
                    if( fecha.FechaReg == jornada)
                    {
                        busList.Add(archBus.BuscBus(fecha.IdBus));
                    }
                }
            }
            catch (Exception) { Console.WriteLine("--x-- Fin Actualizar --x--"); }
            finally { file.Close(); }

            dgBuses.ItemsSource = busList;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
