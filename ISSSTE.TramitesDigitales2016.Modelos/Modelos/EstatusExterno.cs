using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class EstatusExterno : ACatalogo
   {
      public EstatusExterno()
      {
         this.ConfiguracionEstatusInternoEstatusExterno = new HashSet<ConfiguracionEstatusInternoEstatusExterno>();
      }

      [Key]
      public virtual int IdEstatusExterno { get; set; }

      public virtual ICollection<ConfiguracionEstatusInternoEstatusExterno> ConfiguracionEstatusInternoEstatusExterno { get; set; }
   }
}
