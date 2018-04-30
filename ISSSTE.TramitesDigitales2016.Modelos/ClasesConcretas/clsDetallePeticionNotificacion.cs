using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsDetallePeticionNotificacion : DetallePeticionNotificacion
   {
      public new Nullable<int> IdPeticion { get; set; }
      public new Nullable<int> IdNotificacion { get; set; }
      public override string Remitente { get; set; }
      public override string Destinatario { get; set; }
      public override string ConCopiaA { get; set; }
      public override string Asunto { get; set; }
      public new Nullable<Boolean> EstatusEnvio { get; set; }
      public override string ComentariosEnvio { get; set; }
      public new Nullable<DateTime> Fecha { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
