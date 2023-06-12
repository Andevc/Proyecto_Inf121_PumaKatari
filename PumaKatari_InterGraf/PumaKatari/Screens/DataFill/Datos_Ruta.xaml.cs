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
    /// Lógica de interacción para Datos_Ruta.xaml
    /// </summary>
    public partial class Datos_Ruta : Window
    {
        public Datos_Ruta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {            
            for (int i = 0; i < int.Parse(txtNroParadas.Text); i++)
            {
                Screens.DataFill.Paradas regParadas = new Screens.DataFill.Paradas();
                regParadas.NroParada = i + 1;
                regParadas.ShowDialog();
            }

            string nomRuta = txtNombreRuta.Text;
            string tarifa = txtTarifa.Text;
            string nroParadas = txtNroParadas.Text;
            ArchRuta regRuta = new ArchRuta("RegistroRutas.dat");
            regRuta.AdiRuta(nomRuta,tarifa,nroParadas);

            this.Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
