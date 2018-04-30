using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetallePeticionSeguimientoOperador
   {
      [Key]
      public virtual int IdPeticion { get; set; }
      [Key]
      public virtual int IdSeguimiento { get; set; }
      [Key]
      public virtual int IdSeguimientoOperador { get; set; }
      [Required]
      public virtual int IdOperador { get; set; }
      [Required]
      public virtual string Comentarios { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }

      public virtual DetallePeticionSeguimiento DetallePeticionSeguimiento { get; set; }
   }
}
