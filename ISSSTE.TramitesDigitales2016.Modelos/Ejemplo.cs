using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos
{
   public class Ejemplo
   {
      public Ejemplo()
      {
         clsPais pa = new clsPais();

         pa.IdPais = null;
         pa.Clave = null;
         pa.FechaRegistro = null;

         Peticion p = new Peticion();

         //p.Peticionario.Nombre = "";

         //p.Peticionario1.Nombre = "";

         //p.UnidadPrestadoraServicio.IdUnidadPrestadoraServicio = 23;


         //objeto.metodo(p, pManejoErrores);

         //... pa_insertar_peticionario
         //... pa_insertar_afectado
         //....pa_insertar_peticion
         //   ...


         //p.UnidadPrestadoraServicio.IdUnidadPrestadoraServicio = 23;
         //p.Peticionario.Nombre = 

         Peticionario pet = new Peticionario();
         pet.Nombre = "Miguel Angel";
         pet.ApellidoPaterno = "Pájaro";
         pet.ApellidoMaterno = "Martínez";
        
        //
         CausaAsunto cau = new CausaAsunto();
         cau.Clave = "";

         //Usuario usu = new Usuario();
         //usu.Nombre = "";

         DetallePeticionInvolucrado dpi = new DetallePeticionInvolucrado();
         dpi.Nombre = "";

         //Genero /*gen*/ = new Genero();
         //gen.
      }
   }
}
