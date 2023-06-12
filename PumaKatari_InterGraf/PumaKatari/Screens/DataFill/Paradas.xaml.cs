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

namespace PumaKatari.Screens.DataFill
{
    /// <summary>
    /// Lógica de interacción para Paradas.xaml
    /// </summary>
    public partial class Paradas : Window
    {
        private int nroParada;
        public int NroParada
        {
            get { return this.nroParada; }
            set { this.nroParada = value; 
                   txtNroParada.Text = txtNroParada.Text+" Nro. "+nroParada.ToString();
            }
        }
        public Paradas()
        {
            InitializeComponent();
            nroParada = 0;
        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            Ruta ruta = new Ruta();
            string ubicacion = txtUbicaconParada.Text;
            ruta.AdiParada(ubicacion);
            this.Close();
        }
    }
}
