using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class TipoAccionOperador : ACatalogo
   {
      public TipoAccionOperador()
      {
         this.BitacoraAccionOperador = new HashSet<BitacoraAccionOperador>();
      }

      [Key]
      public virtual int IdTipoAccionOperador { get; set; }

      public virtual ICollection<BitacoraAccionOperador> BitacoraAccionOperador { get; set; }
   }
}
