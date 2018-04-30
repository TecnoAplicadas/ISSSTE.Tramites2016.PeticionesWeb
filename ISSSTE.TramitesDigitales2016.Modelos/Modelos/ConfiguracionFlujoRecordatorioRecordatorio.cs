using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ConfiguracionFlujoRecordatorioRecordatorio
   {
      public ConfiguracionFlujoRecordatorioRecordatorio()
      {
         this.DetalleConfiguracionFlujoRecordatorioRecordatorio = new HashSet<DetalleConfiguracionFlujoRecordatorioRecordatorio>();
      }

      [Key]
      public virtual int IdFlujoRecordatorio { get; set; }
      [Key]
      public virtual int IdRecordatorio { get; set; }
      [Required]
      public virtual byte Orden { get; set; }
      [Required]
      public virtual int IdMotivoRecordatorio { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual FlujoRecordatorio FlujoRecordatorio { get; set; }
      public virtual MotivoRecordatorio MotivoRecordatorio { get; set; }
      public virtual ICollection<DetalleConfiguracionFlujoRecordatorioRecordatorio> DetalleConfiguracionFlujoRecordatorioRecordatorio { get; set; }
   }
}
