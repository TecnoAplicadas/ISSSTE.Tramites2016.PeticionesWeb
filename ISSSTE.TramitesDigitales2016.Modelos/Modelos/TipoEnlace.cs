using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class TipoEnlace : ACatalogo
   {
      public TipoEnlace()
      {
         this.Enlace = new HashSet<Enlace>();
      }

      [Key]
      public virtual int IdTipoEnlace { get; set; }
      [Required]
      public virtual int IdCoberturaEnlace { get; set; }

      public virtual CoberturaEnlace CoberturaEnlace { get; set; }
      public virtual ICollection<Enlace> Enlace { get; set; }
   }
}
