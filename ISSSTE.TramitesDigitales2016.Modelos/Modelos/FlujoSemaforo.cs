using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class FlujoSemaforo : ACatalogo
   {
      public FlujoSemaforo()
      {
         this.ConfiguracionFlujoSemaforoSemaforo = new HashSet<ConfiguracionFlujoSemaforoSemaforo>();
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdFlujoSemaforo { get; set; }

      public virtual ICollection<ConfiguracionFlujoSemaforoSemaforo> ConfiguracionFlujoSemaforoSemaforo { get; set; }
      public virtual ICollection<Peticion> Peticion { get; set; }
   }
}
