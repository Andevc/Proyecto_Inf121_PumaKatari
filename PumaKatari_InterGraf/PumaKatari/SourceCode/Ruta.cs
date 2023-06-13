using System;
using System.IO;
using System.Xml.Serialization;

namespace PumaKatariConsola {  
    [Serializable]
    public class Ruta {
        private string nomRuta;
        private int nroParadas; 
        private Pasaje tarifa;
        private Parada[] paradas = new Parada[40];
        public Ruta(){  tarifa = new Pasaje(); } // Constructor vacio para el Cast
        // Constuctor Parametrizado para Adicionar un Objeto Bus al Archivo
        public Ruta( string nomRuta, int nroParadas, double pasaje, Parada[] paradas){
            this.nomRuta = nomRuta;
            this.nroParadas = nroParadas;
            this.tarifa = new Pasaje(pasaje);
            this.paradas = paradas;
        }

        // Getters y Setters
        public int NroParadas { get {return this.nroParadas; }  set {this.nroParadas = value; } }
        public string NomRuta { get {return this.nomRuta; }  set {this.nomRuta = value; } }
        public Pasaje Tarifa { get {return this.tarifa;}  set {this.tarifa = value; } }
        public Parada[] Paradas { get {return this.paradas; }  set {this.paradas = value; } }

        // Adicionar Parada
        public void AdiParada(string ubiParada)
        {
            this.paradas[this.nroParadas] = new Parada(ubiParada);
            this.nroParadas++;
        }

        // Read Ruta      
        public void ReadRuta(BinaryReader j){
            this.nomRuta = j.ReadString();
            this.nroParadas = j.ReadInt32();
            this.tarifa.RdPasaje(j);
            for (int i = 0; i < this.nroParadas; i++) { this.paradas[i] = new Parada(); this.paradas[i].RdParada(j);}
        }

        public void RdRuta(BinaryReader j)
        {
            this.nomRuta = j.ReadString();
            this.nroParadas = j.ReadInt32();
            this.tarifa.RdPasaje(j);
        }

        // Write Ruta
        public void WriteRuta(BinaryWriter j){
            j.Write(this.nomRuta);
            j.Write(this.nroParadas);
            this.tarifa.WrPasaje(j);
            for (int i = 0; i < this.nroParadas; i++) {  this.paradas[i].WrParada(j); }
}     
      /* 
      public void MostRuta(){
         Console.WriteLine( "\n\tNombre Ruta: {0}\t| Nro Paradas: {1}\t| Tarifa: {2}",
            this.nomRuta,this.nroParadas,this.tarifa.Tarifa
         );
         Console.Write("\n\t\t\t ");
         for (int i = 0; i < this.nroParadas; i++) { Console.Write("{0}. \"{1}\"\t ",i+1,this.paradas[i].Ubicacion); }
         Console.WriteLine("");
      }
      public void LeerRuta(){
         Console.Write("\t- Nombre Ruta: "); this.nomRuta = Console.ReadLine();
         Console.Write("\t- Nro Paradas: "); this.nroParadas = int.Parse(Console.ReadLine());
         
         Console.WriteLine("\t- Agrega al Ubicacion de las Paradas: ");
         
         for (int i = 0; i < this.nroParadas; i++) { this.paradas[i] = new Parada(); this.paradas[i].LeeParada();  }
      } */

   }
}