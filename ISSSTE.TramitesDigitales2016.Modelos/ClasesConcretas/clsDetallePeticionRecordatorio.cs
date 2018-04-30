using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsDetallePeticionRecordatorio : DetallePeticionRecordatorio
   {
      public new Nullable<int> IdPeticion { get; set; }
      public new Nullable<int> IdRecordatorio { get; set; }
      public override string Remitente { get; set; }
      public override string Destinatario { get; set; }
      public override string ConCopiaA { get; set; }
      public override string Asunto { get; set; }
      public new Nullable<int> IdEstatusInterno { get; set; }
      public new Nullable<DateTime> Fecha { get; set; }
   }
}
