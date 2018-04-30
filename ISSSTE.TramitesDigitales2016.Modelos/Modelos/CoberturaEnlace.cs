using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class CoberturaEnlace : ACatalogo
   {
      public CoberturaEnlace()
      {
         this.TipoEnlace = new HashSet<TipoEnlace>();
      }

      [Key]
      public virtual int IdCoberturaEnlace { get; set; }


      public virtual ICollection<TipoEnlace> TipoEnlace { get; set; }
   }
}
