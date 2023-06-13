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
    
    public partial class Registro_Empleados : Window {
        public ArchEmpleado regEmp = new ArchEmpleado("RegistroEmpleados.dat");
        public Registro_Empleados() {

            InitializeComponent();
            ActualizarArchivo();

        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            regEmp.CrearRegEmpl();
            MessageBox.Show("Nuevo Registro De Empleados Creado");
            ActualizarArchivo();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e) {
            DataFill.Datos_Empleado datEmp = new DataFill.Datos_Empleado();
            datEmp.ShowDialog();
            ActualizarArchivo();
        }

        // El Metodo ActualizarArchivo sustituye al metodo Listar en la Clase ArchEmpleado
        private void ActualizarArchivo() {
            List<Empleado> listEmpleados = new List<Empleado>();
            Stream file = File.Open("RegistroEmpleados.dat", FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);

            try {
                while (true) {
                    Empleado emp = new Empleado();
                    emp.RdEmpleado(read);
                    listEmpleados.Add(emp);
                }
            }

            catch (Exception) { Console.WriteLine("Fin Actualizacion Datos"); }

            finally { file.Close(); }

            dgEmpelados.ItemsSource = listEmpleados;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        
    }
}
