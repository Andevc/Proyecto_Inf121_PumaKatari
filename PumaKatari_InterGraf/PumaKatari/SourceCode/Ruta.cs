﻿using System;
using System.IO;
namespace PumaKatariConsola {  
   [Serializable]
   public class Ruta {
      private string nomRuta;
      private int nroParadas; 
      private Pasaje tarifa;
      private Parada[] paradas = new Parada[40];
      public Ruta(){  tarifa = new Pasaje(); } 
      public int NroParadas { get {return this.nroParadas; }  set {this.nroParadas = value; } }
      public string NomRuta { get {return this.nomRuta; }  set {this.nomRuta = value; } }
      public Pasaje Tarifa { get {return this.tarifa;}  set {this.tarifa = value; } }
      public Parada[] Paradas { get {return this.paradas; }  set {this.paradas = value; } }
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
      }
      public void ReadRuta(BinaryReader j){
         this.nomRuta = j.ReadString();
         this.nroParadas = j.ReadInt32();
         this.tarifa.RdPasaje(j);
         for (int i = 0; i < this.nroParadas; i++) { this.paradas[i] = new Parada(); this.paradas[i].RdParada(j);}
      }
      public void WriteRuta(BinaryWriter j){
         j.Write(this.nomRuta);
         j.Write(this.nroParadas);
         this.tarifa.WrPasaje(j);
         for (int i = 0; i < this.nroParadas; i++) { this.paradas[i].WrParada(j); }
      }      
      /* 
      public void pasajeroRandom(Bus x){
         string[] tipoPersona = new string[]{"estandar","estudiante","discapacidad","adulto mayor","estandar"};
         string[] nombres = new string[]{"Sofia","Lucas","Diego","Max","Zoe","Leo","Rex","Ben","Mia","Ana"};
         Random rnd = new Random();
         for (int i = 0; i < x.NroPasajeros; i++) { 
            int iNom = rnd.Next(nombres.Length);
            int iTipopj = rnd.Next(tipoPersona.Length);
            int edad = rnd.Next(18,60); 
            if( tipoPersona[iTipopj] == "estudiante"){ edad = rnd.Next(5,18); }
            else if(tipoPersona[iTipopj] == "adulto mayor"){ edad = rnd.Next(60,80); } 
            Pasajero pj = new Pasajero(nombres[iNom],edad,tipoPersona[iTipopj]);
         }
      } */
   }
}