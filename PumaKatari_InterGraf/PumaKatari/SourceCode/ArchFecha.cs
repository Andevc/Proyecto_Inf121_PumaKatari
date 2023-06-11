﻿using System;
using System.IO;
namespace PumaKatariConsola {
   public class ArchFecha {
      private string nomArch;
      public ArchFecha(string nomArch) { this.nomArch = nomArch; }
      public void CrearRegFecha(){ if (File.Exists(nomArch)) { File.Delete(nomArch); } } 
      public void AdiFecha(string idBus, string fecha){
         
         Stream file = File.Open(nomArch, FileMode.OpenOrCreate);
         BinaryWriter write  = new BinaryWriter(file);
         
         try {    
               Fecha regFecha = new Fecha(idBus,fecha);          
               write.Seek(0,SeekOrigin.End);
               regFecha.WrFecha(write);
         }
         catch (Exception){ Console.WriteLine("\n--x-- Fin Registro Buses --x--"); }
         finally { file.Close(); }
      }
   }
}
