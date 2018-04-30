using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class PuntoControl : ACatalogo
   {
      public PuntoControl()
      {
         this.ConfiguracionFlujoPuntoControlPuntoControl = new HashSet<ConfiguracionFlujoPuntoControlPuntoControl>();
      }

      [Key]
      public virtual int IdPuntoControl { get; set; }

      public virtual ICollection<ConfiguracionFlujoPuntoControlPuntoControl> ConfiguracionFlujoPuntoControlPuntoControl { get; set; }
   }
}
