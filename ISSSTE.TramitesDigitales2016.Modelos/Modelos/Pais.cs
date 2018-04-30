using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Pais : ACatalogo
   {
      public Pais()
      {
         this.Estado = new HashSet<Estado>();
      }

      [Key]
      public virtual int IdPais { get; set; }


      public virtual ICollection<Estado> Estado { get; set; }
   }
}
