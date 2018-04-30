using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ConfiguracionEstatusInternoEstatusExterno
   {
      [Key]
      public virtual int IdEstatusExterno { get; set; }
      [Key]
      public virtual int IdEstatusInterno { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }



      public virtual EstatusExterno EstatusExterno { get; set; }
      public virtual EstatusInterno EstatusInterno { get; set; }
   }
}
