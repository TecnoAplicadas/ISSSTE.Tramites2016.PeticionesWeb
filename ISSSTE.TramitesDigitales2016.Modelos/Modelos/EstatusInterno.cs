using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class EstatusInterno : ACatalogo
   {
      public EstatusInterno()
      {
         this.ConfiguracionEstatusInternoEstatusExterno = new HashSet<ConfiguracionEstatusInternoEstatusExterno>();
         this.ConfiguracionFlujoEstatusEstatusInterno = new HashSet<ConfiguracionFlujoEstatusEstatusInterno>();
         this.ConfiguracionFlujoNotificacionNotificacion = new HashSet<ConfiguracionFlujoNotificacionNotificacion>();
         this.DetalleConfiguracionFlujoRecordatorioRecordatorio = new HashSet<DetalleConfiguracionFlujoRecordatorioRecordatorio>();
         this.DetallePeticionSeguimiento = new HashSet<DetallePeticionSeguimiento>();
      }

      [Key]
      public virtual int IdEstatusInterno { get; set; }

      public virtual ICollection<ConfiguracionEstatusInternoEstatusExterno> ConfiguracionEstatusInternoEstatusExterno { get; set; }
      public virtual ICollection<ConfiguracionFlujoEstatusEstatusInterno> ConfiguracionFlujoEstatusEstatusInterno { get; set; }
      public virtual ICollection<ConfiguracionFlujoNotificacionNotificacion> ConfiguracionFlujoNotificacionNotificacion { get; set; }
      public virtual ICollection<DetalleConfiguracionFlujoRecordatorioRecordatorio> DetalleConfiguracionFlujoRecordatorioRecordatorio { get; set; }
      public virtual ICollection<DetallePeticionSeguimiento> DetallePeticionSeguimiento { get; set; }
   }
}
