using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class CausaAsunto : ACatalogo
   {
      public CausaAsunto()
      {
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdCausaAsunto { get; set; }
      [Required]
      public virtual int IdTipoOpinion { get; set; }

      public virtual TipoOpinion TipoOpinion { get; set; }
      public virtual ICollection<Peticion> Peticion { get; set; }
   }
}
