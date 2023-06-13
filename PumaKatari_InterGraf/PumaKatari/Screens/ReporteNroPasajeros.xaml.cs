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
    /// Lógica de interacción para ReporteNroPasajeros.xaml
    /// </summary>
    public partial class ReporteNroPasajeros : Window
    {
        public ReporteNroPasajeros()
        {
            InitializeComponent();
            RutaMayPasajeros();
        }

        private void RutaMayPasajeros()
        {
            ArchBus regBus = new ArchBus("RegistroBuses.dat");
            ArchRuta regRuta = new ArchRuta("RegistroRutas.dat");

            string nomRuta = regRuta.RutaMayPasajeros(regBus);
            int nroPasajeros = regBus.mayPasajeros(nomRuta);
            txtReporte.Text = "Reporte de La Ruta con Mayor Cantidad de Pasajeros\n" +
                "\nIntroducción:" +
                "\nEste reporte presenta información sobre la ruta con mayor cantidad de pasajeros." +
                "\n\nResultados:" +
                "\nUn total de "+nroPasajeros+" pasajeros utilizaron la ruta \"" + nomRuta +"\""+
                "\n\nConclusiones:" +
                "\r\nLa ruta \"" + nomRuta +"\" tuvo una cantidad significativa de pasajeros desde el inicio de operaciones de los Buses Puma Katari.";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

