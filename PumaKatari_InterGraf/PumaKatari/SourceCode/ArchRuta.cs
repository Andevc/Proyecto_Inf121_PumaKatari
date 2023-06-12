using System;
using System.IO;
namespace PumaKatariConsola {
   public class ArchRuta {
      private string nomArch;
      public ArchRuta(string nomArch) { this.nomArch = nomArch; }
      public void CrearRegRuta(){ if (File.Exists(nomArch) ) { File.Delete(nomArch); } }

      public void AdiRuta(string nomRuta, string tarifa, string nroParadas){
         Stream file = File.Open(nomArch,FileMode.OpenOrCreate);
         BinaryWriter write = new BinaryWriter(file);
         Console.WriteLine("\n- REGISTRO DE RUTAS (Limite 7): ");
         try {         
            Ruta regRuta = new Ruta(nomRuta,int.Parse(nroParadas),Double.Parse(tarifa));
            write.Seek(0,SeekOrigin.End);
            regRuta.WriteRuta(write);            
         }
         catch (Exception){ Console.WriteLine("\n--x-- Fin Registro Rutas --x--\n"); }
         finally { file.Close(); }
      }
      
   }
}
