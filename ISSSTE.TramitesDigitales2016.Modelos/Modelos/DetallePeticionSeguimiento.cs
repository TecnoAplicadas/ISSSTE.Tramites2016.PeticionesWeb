using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetallePeticionSeguimiento
   {
      public DetallePeticionSeguimiento()
      {
         this.BitacoraAccionOperador = new HashSet<BitacoraAccionOperador>();
         this.DetallePeticionSeguimientoOperador = new HashSet<DetallePeticionSeguimientoOperador>();
      }

      [Key]
      public virtual int IdPeticion { get; set; }
      [Key]
      public virtual int IdSeguimiento { get; set; }
      [Required]
      public virtual string Comentarios { get; set; }
      [Required]
      public virtual int IdUsuario { get; set; }
      [Required]
      public virtual int IdEstatusInterno { get; set; }
      [Required]
      public virtual DateTime Fecha { get; set; }

      public virtual ICollection<BitacoraAccionOperador> BitacoraAccionOperador { get; set; }
      public virtual EstatusInterno EstatusInterno { get; set; }
      public virtual Peticion Peticion { get; set; }
      public virtual Usuario Usuario { get; set; }
      public virtual ICollection<DetallePeticionSeguimientoOperador> DetallePeticionSeguimientoOperador { get; set; }

   }
}
