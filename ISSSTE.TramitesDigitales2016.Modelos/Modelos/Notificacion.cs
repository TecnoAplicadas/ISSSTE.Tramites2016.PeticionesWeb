using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Notificacion : ACatalogo
   {
      public Notificacion()
      {
         this.ConfiguracionFlujoNotificacionNotificacion = new HashSet<ConfiguracionFlujoNotificacionNotificacion>();
         this.DetallePeticionNotificacion = new HashSet<DetallePeticionNotificacion>();
      }

      [Key]
      public virtual int IdNotificacion { get; set; }

      public virtual ICollection<ConfiguracionFlujoNotificacionNotificacion> ConfiguracionFlujoNotificacionNotificacion { get; set; }
      public virtual ICollection<DetallePeticionNotificacion> DetallePeticionNotificacion { get; set; }
   }
}
