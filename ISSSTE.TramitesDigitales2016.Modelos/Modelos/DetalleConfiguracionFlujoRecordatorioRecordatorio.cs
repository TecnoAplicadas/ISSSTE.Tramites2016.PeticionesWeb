using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetalleConfiguracionFlujoRecordatorioRecordatorio
   {
      [Key]
      public virtual int IdFlujoRecordatorio { get; set; }
      [Key]
      public virtual int IdRecordatorio { get; set; }
      [Key]
      public virtual int IdEstatusInterno { get; set; }
      [Required]
      public virtual int IdRol { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual ConfiguracionFlujoRecordatorioRecordatorio ConfiguracionFlujoRecordatorioRecordatorio { get; set; }
      public virtual EstatusInterno EstatusInterno { get; set; }
      public virtual Rol Rol { get; set; }
   }
}
