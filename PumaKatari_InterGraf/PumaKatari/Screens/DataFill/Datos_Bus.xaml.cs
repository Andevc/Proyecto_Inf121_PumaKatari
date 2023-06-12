using PumaKatariConsola;
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

namespace PumaKatari.Screens.DataFill
{
    /// <summary>
    /// Lógica de interacción para Datos_Bus.xaml
    /// </summary>
    public partial class Datos_Bus : Window
    {
        public Datos_Bus()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string placa = txtPlaca.Text;
            string idBus = txtIdBus.Text;
            string idConductor = txtIdConductor.Text;
            string idApoyo = txtIdApoyo.Text;
            string nomRuta = txtNomRuta.Text;
            string nroPj = txtNroPj.Text;
            Bus bus = new Bus();

            ArchBus regBus = new ArchBus("RegistroBuses.dat");
            regBus.AdiBus(placa,idBus,idConductor,idApoyo,nomRuta,nroPj);

            this.Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
