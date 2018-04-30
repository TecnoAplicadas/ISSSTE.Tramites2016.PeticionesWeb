using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsConfiguracionFlujoNotificacionNotificacion : ConfiguracionFlujoNotificacionNotificacion
   {
      public new Nullable<int> IdFlujoNotificacion { get; set; }
      public new Nullable<int> IdNotificacion { get; set; }
      public new Nullable<int> IdEstatusInterno { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable <DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
