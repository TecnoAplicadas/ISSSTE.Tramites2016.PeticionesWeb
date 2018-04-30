using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsCausaAsunto : CausaAsunto
   {
      public clsCausaAsunto()
      {

      }

      public Nullable<int> IdArea { get; set; }
      public new Nullable<int> IdCausaAsunto { get; set; }
      public override string Clave { get; set; }
      public override string Nombre { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
