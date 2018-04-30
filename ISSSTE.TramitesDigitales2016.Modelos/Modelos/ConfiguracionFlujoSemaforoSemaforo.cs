using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ConfiguracionFlujoSemaforoSemaforo
   {
      [Key]
      public virtual int IdFlujoSemaforo { get; set; }
      [Key]
      public virtual int IdSemaforo { get; set; }
      [Required]
      public virtual byte DiasInicio { get; set; }
      public virtual Nullable<byte> DiasFin { get; set; }
      [Required]
      public virtual byte Orden { get; set; }
      [Required]
      public virtual int IdEstatusSemaforo { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual EstatusSemaforo EstatusSemaforo { get; set; }
      public virtual FlujoSemaforo FlujoSemaforo { get; set; }
      public virtual Semaforo Semaforo { get; set; }
   }
}
