using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Estado : ACatalogo
   {
      public Estado()
      {
         this.Municipio = new HashSet<Municipio>();
      }

      [Key]
      public virtual int IdEstado { get; set; }
      [Required]
      public virtual int IdPais { get; set; }

      public virtual Pais Paises { get; set; }
      public virtual ICollection<Municipio> Municipio { get; set; }
   }
}
