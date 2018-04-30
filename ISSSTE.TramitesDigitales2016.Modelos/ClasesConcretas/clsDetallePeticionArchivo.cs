using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsDetallePeticionArchivo : DetallePeticionArchivo
   {
      public new Nullable<int> IdPeticion { get; set; }
      public new Nullable<int> IdRenglon { get; set; }
      public override byte[] Archivo { get; set; }
      public override string RutaArchivo { get; set; }
      public override string NombreArchivo { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
   }
}
