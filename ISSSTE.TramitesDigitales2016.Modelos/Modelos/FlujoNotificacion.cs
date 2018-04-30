using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class FlujoNotificacion : ACatalogo
   {
      public FlujoNotificacion()
      {
         this.ConfiguracionFlujoNotificacionNotificacion = new HashSet<ConfiguracionFlujoNotificacionNotificacion>();
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdFlujoNotificacion { get; set; }

      public virtual ICollection<ConfiguracionFlujoNotificacionNotificacion> ConfiguracionFlujoNotificacionNotificacion { get; set; }
      public virtual ICollection<Peticion> Peticion { get; set; }
   }
}
