using System;
using System.IO ;
using System.Numerics;
using System.Printing;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace PumaKatariConsola {
   public class ArchBus {
      private string nomArch; 
      public ArchBus(string nomArch) { this.nomArch = nomArch; }
      public void CrearRegBus(){ if (File.Exists(nomArch)) { File.Delete(nomArch); } }
        public void AdiBus( string placa,string idBus,string idConductor,string idApoyo,string nomRuta,string nroPj ) {
         
            Stream file = File.Open(nomArch, FileMode.OpenOrCreate);
            BinaryWriter write  = new BinaryWriter(file);
         
            try {
                Bus regBus = new Bus(placa,idBus,idConductor,idApoyo,nomRuta,int.Parse(nroPj));
                write.Seek(0,SeekOrigin.End);
                pasajeroRandom(regBus);
                regBus.WrBus(write);
                
            }
         
            catch (Exception){ Console.WriteLine("\n--x-- Fin Registro Buses --x--\n"); }
         
            finally { file.Close(); }
        }

        
        public void pasajeroRandom(Bus x){
            string[] tipoPersona = new string[]{"estandar","estudiante","discapacidad","adulto mayor","estandar"};
            string[] nombres = new string[]{"Sofia","Lucas","Diego","Max","Zoe","Leo","Rex","Ben","Mia","Ana"};
            Random rnd = new Random();
            for (int i = 0; i < x.NroPasajeros; i++) { 

                int iNom = rnd.Next(nombres.Length);
                int iTipopj = rnd.Next(tipoPersona.Length);
                int edad = rnd.Next(18,60); 

                if( tipoPersona[iTipopj] == "estudiante"){ edad = rnd.Next(6,18); }

                else if(tipoPersona[iTipopj] == "adulto mayor"){ edad = rnd.Next(60,80); } 

                Pasajero pasajeroRnd = new Pasajero(nombres[iNom],edad,tipoPersona[iTipopj]);

                x.AdiPasajero(pasajeroRnd, i);
            }
        }
        public double BuscarBus(string idBus, ArchRuta ruta, double insgresos)
        {
            
            Stream file = File.Open(nomArch,FileMode.Open);
            BinaryReader read = new BinaryReader(file);
            try
            {  
                while (true)
                {
                    Bus bus = new Bus();
                    bus.RdBus(read);
                    if(bus.Id == idBus)
                    {
                        for (int i = 0; i < bus.NroPasajeros; i++)
                        {                            
                            string tipoPj = bus.Pasajeros[i].TipoPasajero;
                            insgresos = insgresos + TarifaTipoPersona(tipoPj,ruta,bus.NomRuta);                            
                        }
                    }
                }
            }
            catch (Exception) { Console.WriteLine("--x-- Fin Buscar Bus --x--"); }
            finally { file.Close(); }

            return insgresos;
        }

        public double TarifaTipoPersona(string tipoPersona, ArchRuta ruta, string nomRuta)
        {
            if (tipoPersona != "estandar")
            {
                return 1;
            }
            return ruta.BuscarTarifaRuta(nomRuta);
        }

        public Bus BuscBus(string idBus)
        {
            Bus bus = new Bus();
            Stream file = File.Open(nomArch,FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            try {
                while (true) {
                    bus = new Bus();
                    bus.RdBus(read);
                    if(bus.Id == idBus)
                    {
                        return bus;
                    }
                }
            }
            catch (Exception) { Console.WriteLine("--x-- Fin Buscar Bus --x-- "); }
            finally { file.Close(); }
            
            return bus;
        }

        public int mayPasajeros(string nomRuta)
        {   int cantPasajeros = 0;
            Stream file = File.Open(nomArch, FileMode.OpenOrCreate);
            BinaryReader read = new BinaryReader(file);
            try
            {
                while (true)
                {
                    Bus bus = new Bus();
                    bus.RdBus(read);
                    if (bus.NomRuta == nomRuta)
                    {
                        cantPasajeros = cantPasajeros + bus.NroPasajeros;
                    }
                }
            }
            catch (Exception) { Console.WriteLine("--x-- Fin Buscar Bus --x-- "); }
            finally { file.Close(); }
            return cantPasajeros;
        }
    }
}

