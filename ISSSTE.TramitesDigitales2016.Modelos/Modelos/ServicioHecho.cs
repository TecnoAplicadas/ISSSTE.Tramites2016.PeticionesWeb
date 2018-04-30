using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ServicioHecho : ACatalogo
   {
      public ServicioHecho()
      {
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdServicioHecho { get; set; }

      public virtual ICollection<Peticion> Peticion { get; set; }
   }
}
