using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ConfiguracionFlujoNotificacionNotificacion
   {
      [Key]
      public virtual int IdFlujoNotificacion { get; set; }
      [Key]
      public virtual int IdNotificacion { get; set; }
      [Required]
      public virtual int IdEstatusInterno { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }


      public virtual EstatusInterno EstatusInterno { get; set; }
      public virtual FlujoNotificacion FlujosNotificacion { get; set; }
   }
}
