using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Enlace : ACatalogo
   {
      public Enlace()
      {
         //this.Usuario = new HashSet<Usuario>();
      }

      [Key]
      public virtual int IdEnlace { get; set; }
      [Required]
      public virtual int IdTipoEnlace { get; set; }

      public virtual TipoEnlace TipoEnlace { get; set; }
      //public virtual ICollection<Usuario> Usuario { get; set; }
   }
}
