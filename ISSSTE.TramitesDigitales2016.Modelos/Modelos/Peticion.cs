using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Peticion : APeticion
   {
      public Peticion()
      {
         this.DetallePeticionArchivo = new HashSet<DetallePeticionArchivo>();
         this.DetallePeticionInvolucrado = new HashSet<DetallePeticionInvolucrado>();
         this.DetallePeticionNotificacion = new HashSet<DetallePeticionNotificacion>();
         this.DetallePeticionRecordatorio = new HashSet<DetallePeticionRecordatorio>();
         this.DetallePeticionSeguimiento = new HashSet<DetallePeticionSeguimiento>();
      }

      public virtual string FolioPadre { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdFlujoRecordatorio { get; set; }
      [Required]
      public virtual int IdFlujoSemaforo { get; set; }
      [Required]
      public virtual int IdFlujoEstatus { get; set; }
      [Required]
      public virtual int IdEstatusInterno { get; set; }
      public virtual Nullable<int> IdOperador { get; set; }
      public virtual int IdFlujoNotificacion { get; set; }


      public virtual CausaAsunto CausaAsunto { get; set; }
      public virtual ConfiguracionFlujoEstatusEstatusInterno ConfiguracionFlujoEstatusEstatusInterno { get; set; }
      public virtual ICollection<DetallePeticionArchivo> DetallePeticionArchivo { get; set; }
      public virtual ICollection<DetallePeticionInvolucrado> DetallePeticionInvolucrado { get; set; }
      public virtual ICollection<DetallePeticionNotificacion> DetallePeticionNotificacion { get; set; }
      public virtual ICollection<DetallePeticionRecordatorio> DetallePeticionRecordatorio { get; set; }
      public virtual ICollection<DetallePeticionSeguimiento> DetallePeticionSeguimiento { get; set; }
      public virtual FlujoRecordatorio FlujoRecordatorio { get; set; }
      public virtual FlujoSemaforo FlujoSemaforo { get; set; }
      public virtual Peticionario Peticionario { get; set; }
      //public virtual Peticionario Peticionario1 { get; set; }
      public virtual Afectado Afectado { get; set; }
      public virtual ServicioHecho ServicioHecho { get; set; }
      public virtual UnidadPrestadoraServicio UnidadPrestadoraServicio { get; set; }
   }
}
