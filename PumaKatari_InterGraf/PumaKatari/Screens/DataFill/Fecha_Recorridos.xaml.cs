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
    /// Lógica de interacción para Fecha_Recorridos.xaml
    /// </summary>
    public partial class Fecha_Recorridos : Window
    {
        public Fecha_Recorridos()
        {
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string fecha = txtFechaRec.Text;
            string idBus = txtIdBus.Text;
            ArchFecha regFecha = new ArchFecha("RegistroFechas.dat");
            regFecha.AdiFecha(idBus, fecha);
            this.Close();
        }
        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
