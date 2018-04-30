using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsConfiguracionFlujoPuntoControlPuntoControl : ConfiguracionFlujoPuntoControlPuntoControl
   {
      public new Nullable<int> IdFlujoPuntoControl { get; set; }
      public new Nullable<int> IdPuntoControl { get; set; }
      public new Nullable<byte> Orden { get; set; }
      public new Nullable<byte> Dias { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
