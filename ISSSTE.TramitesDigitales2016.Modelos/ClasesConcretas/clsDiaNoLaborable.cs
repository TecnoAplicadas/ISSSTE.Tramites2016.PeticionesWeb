using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsDiaNoLaborable : DiaNoLaborable
   {
      public new Nullable<int> IdFechaNoLaborable { get; set; }
      public new Nullable<DateTime> Fecha { get; set; }
      public override string Dia { get; set; }
      public override string Descripcion { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
