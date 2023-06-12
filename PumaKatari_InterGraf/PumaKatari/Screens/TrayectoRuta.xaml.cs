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
    /// Lógica de interacción para TrayectoRuta.xaml
    /// </summary>
    public partial class TrayectoRuta : Window
    {
        public TrayectoRuta()
        {
            InitializeComponent();
        }

        private void btnMostTrayectoria_Click(object sender, RoutedEventArgs e)
        {
            List<Parada> paradas= new List<Parada>();
            Stream file = File.Open("RegistroRutas.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            try
            {
                while (true)
                {
                    Ruta ruta = new Ruta();
                    ruta.ReadRuta(read);
                    if (ruta.NomRuta == txtBuscarRuta.Text)
                    {
                        for (int i = 0; i < ruta.NroParadas; i++)
                        {
                            paradas.Add(ruta.Paradas[i]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fin List Trayecto");
            }
            finally { file.Close(); }
            dgTrayecto.ItemsSource= paradas;
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
