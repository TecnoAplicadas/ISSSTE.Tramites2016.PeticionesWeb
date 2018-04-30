using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class TipoOpinion : ACatalogo
   {
      public TipoOpinion()
      {
         this.CausaAsunto = new HashSet<CausaAsunto>();
      }

      [Key]
      public virtual int IdTiposOpinion { get; set; }

      public virtual ICollection<CausaAsunto> CausaAsunto { get; set; }
   }
}
