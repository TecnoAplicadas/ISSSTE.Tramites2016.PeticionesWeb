using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class TipoUps : ACatalogo
   {
      public TipoUps()
      {
         this.NivelUps = new HashSet<NivelUps>();
      }

      [Key]
      public virtual int IdTipoUps { get; set; }

      public virtual ICollection<NivelUps> NivelUps { get; set; }
   }
}
