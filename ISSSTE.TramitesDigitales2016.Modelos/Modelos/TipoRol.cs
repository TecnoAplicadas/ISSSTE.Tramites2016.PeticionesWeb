using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class TipoRol : ACatalogo
   { 
      public TipoRol()
      {
         this.Rol = new HashSet<Rol>();
      }

      [Key]
      public virtual int IdTipoRol { get; set; }

      public virtual ICollection<Rol> Rol { get; set; }
   }
}
