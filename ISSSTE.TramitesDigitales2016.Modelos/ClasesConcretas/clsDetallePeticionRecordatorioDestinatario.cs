using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsDetallePeticionRecordatorioDestinatario : DetallePeticionRecordatorioDestinatario
   {
      public new Nullable<int> IdPeticion { get; set; }
      public new Nullable<int> IdRecordatorio { get; set; }
      public new Nullable<int> IdRenglon { get; set; }
      public override string Destinatario { get; set; }
      public override string ConCopiaA { get; set; }
      public new Nullable<bool> EstatusEnvio { get; set; }
      public override string ComentariosEnvio { get; set; }
   }
}
