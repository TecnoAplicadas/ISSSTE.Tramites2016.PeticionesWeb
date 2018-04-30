using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsDetallePeticionSeguimieto : DetallePeticionSeguimiento
   {
      public new Nullable<int> IdPeticion { get; set; }
      public new Nullable<int> IdSeguimiento { get; set; }
      public override string Comentarios { get; set; }
      public new Nullable<int> IdUsuario { get; set; }
      public new Nullable<int> IdEstatusInterno { get; set; }
      public new Nullable<DateTime> Fecha { get; set; }
   }
}
