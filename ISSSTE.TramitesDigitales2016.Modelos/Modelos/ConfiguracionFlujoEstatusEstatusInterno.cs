using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ConfiguracionFlujoEstatusEstatusInterno
   {
      public ConfiguracionFlujoEstatusEstatusInterno()
      {
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdFlujoEstatus { get; set; }
      [Key]
      public virtual int IdEstatusInterno { get; set; }
      [Required]
      public virtual int Orden { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual EstatusInterno EstatusInterno { get; set; }
      public virtual FlujoEstatus FlujoEstatus { get; set; }
      public virtual ICollection<Peticion> Peticion { get; set; }
   }
}
