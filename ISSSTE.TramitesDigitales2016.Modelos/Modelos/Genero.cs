using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Genero : ACatalogo
   {
      public Genero()
      {
         this.Peticionario = new HashSet<Peticionario>();
      }

      [Key]
      public virtual int IdGenero { get; set; }

      public virtual ICollection<Peticionario> Peticionario { get; set; }
   }
}
