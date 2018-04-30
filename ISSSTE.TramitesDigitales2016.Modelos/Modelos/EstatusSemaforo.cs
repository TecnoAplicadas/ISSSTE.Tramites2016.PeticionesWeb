using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class EstatusSemaforo : ACatalogo
   {
      public EstatusSemaforo()
      {
         this.ConfiguracionFlujoSemaforoSemaforo = new HashSet<ConfiguracionFlujoSemaforoSemaforo>();
      }

      [Key]
      public virtual int IdEstatusSemaforo { get; set; }

      public virtual ICollection<ConfiguracionFlujoSemaforoSemaforo> ConfiguracionFlujoSemaforoSemaforo { get; set; }
   }
}
