using System;
using System.IO;
using System.Windows;

namespace PumaKatariConsola {
    public class ArchRuta {
        private string nomArch;
        public ArchRuta(string nomArch) { this.nomArch = nomArch; }
        public void CrearRegRuta(){ if (File.Exists(nomArch) ) { File.Delete(nomArch); } }

        public void AdiRuta(string nomRuta, string tarifa, string nroParadas, Parada[] parada){
            Stream file = File.Open(nomArch,FileMode.OpenOrCreate);
            BinaryWriter write = new BinaryWriter(file);
            Console.WriteLine("\n- REGISTRO DE RUTAS (Limite 7): ");
            try {         
                Ruta regRuta = new Ruta(nomRuta,int.Parse(nroParadas),Double.Parse(tarifa),parada);
                write.Seek(0,SeekOrigin.End);
                regRuta.WriteRuta(write);            
            }
            catch (Exception){ Console.WriteLine("\n--x-- Fin Registro Rutas --x--\n"); }
            finally { file.Close(); }
        }

        public double BuscarTarifaRuta(string nomRuta)
        {
            double tarifa = 0.0;
            Stream file = File.Open(nomArch,FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            try
            {
                while (true)
                {
                    Ruta ruta = new Ruta();
                    ruta.ReadRuta(read);
                    if(ruta.NomRuta == nomRuta)
                    {
                        return ruta.Tarifa.Tarifa;
                    }
                }
            }
            catch (Exception) { Console.WriteLine("--x-- Fin Buscar Tarifa Ruta --x--"); }
            finally { file.Close(); }
            return tarifa;
        }

        public string RutaMayPasajeros(ArchBus regBus)
        {
            int mayPasajeros = 0;
            string nomRuta = "";
            Stream file = File.Open(nomArch,FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            try
            {
                while (true)
                {
                    Ruta ruta = new Ruta(); 
                    ruta.ReadRuta(read);
                    

                    string nombreRuta = ruta.NomRuta;
                    int nroPasajeros = regBus.mayPasajeros(nombreRuta);
                    if(nroPasajeros > mayPasajeros)
                    {
                        mayPasajeros= nroPasajeros;
                        nomRuta = nombreRuta;
                    }
                    
                    
                }
            }
            catch (Exception) { Console.WriteLine("--x-- Fin Ruta con Mayor Cantidad de Pasajeros --x--"); }
            finally { file.Close(); }
            return nomRuta;
        }
      
    }
}
