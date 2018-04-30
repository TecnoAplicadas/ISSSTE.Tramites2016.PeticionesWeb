using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsUnidadAdministrativaUnidadTransversal : UnidadAdministrativaUnidadTransversal
   {
      public new Nullable<int> IdUnidadAdministrativa { get; set; }
      public new Nullable<int> IdUnidadTransversal { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
