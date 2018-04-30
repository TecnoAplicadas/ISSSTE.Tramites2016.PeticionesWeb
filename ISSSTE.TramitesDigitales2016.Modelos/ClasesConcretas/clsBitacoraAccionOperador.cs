using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsBitacoraAccionOperador : BitacoraAccionOperador
   {
      public new Nullable<int> IdPeticion { get; set; }
      public new Nullable<int> IdSeguimiento { get; set; }
      public new Nullable<int> IdTipoAccionOperador { get; set; }
      public new Nullable<int> IdOperador { get; set; }
      public new Nullable<int> IdAccionOperador { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
   }
}
