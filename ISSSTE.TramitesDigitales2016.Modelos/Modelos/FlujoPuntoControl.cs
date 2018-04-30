using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class FlujoPuntoControl : ACatalogo
   {
      public FlujoPuntoControl() 
      {
         this.ConfiguracionFlujoPuntoControlPuntoControl = new HashSet<ConfiguracionFlujoPuntoControlPuntoControl>();
      }

      [Key]
      public virtual int IdFlujoPuntoControl { get; set; }
      

      public virtual ICollection<ConfiguracionFlujoPuntoControlPuntoControl> ConfiguracionFlujoPuntoControlPuntoControl { get; set; }
   }
}
