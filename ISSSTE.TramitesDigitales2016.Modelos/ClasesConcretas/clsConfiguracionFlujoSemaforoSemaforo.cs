using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsConfiguracionFlujoSemaforoSemaforo : ConfiguracionFlujoSemaforoSemaforo
   {
      public new Nullable<int> IdFlujoSemaforo { get; set; }
      public new Nullable<int> IdSemaforo { get; set; }
      public new Nullable<byte> DiasInicio { get; set; }
      public override Nullable<byte> DiasFin { get; set; }
      public new Nullable<byte> Orden { get; set; }
      public new Nullable<int> IdEstatusSemaforo { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
