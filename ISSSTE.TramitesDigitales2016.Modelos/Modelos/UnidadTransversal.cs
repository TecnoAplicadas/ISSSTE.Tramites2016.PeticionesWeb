using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class UnidadTransversal : ACatalogo
   {
      public UnidadTransversal()
      {
         this.UnidadAdministrativaUnidadTransversal = new HashSet<UnidadAdministrativaUnidadTransversal>();
      }

      [Key]
      public virtual int IdUnidadTransversal { get; set; }

      public virtual ICollection<UnidadAdministrativaUnidadTransversal> UnidadAdministrativaUnidadTransversal { get; set; }

   }
}
