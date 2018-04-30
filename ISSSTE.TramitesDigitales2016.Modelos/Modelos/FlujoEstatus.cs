using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class FlujoEstatus : ACatalogo
   {
      public FlujoEstatus()
      {
         this.ConfiguracionFlujoEstatusEstatusInterno = new HashSet<ConfiguracionFlujoEstatusEstatusInterno>();
      }

      [Key]
      public virtual int IdFlujoEstatus { get; set; }

      public virtual ICollection<ConfiguracionFlujoEstatusEstatusInterno> ConfiguracionFlujoEstatusEstatusInterno { get; set; }
   }
}
