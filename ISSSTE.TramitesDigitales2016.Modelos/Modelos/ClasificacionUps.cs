using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ClasificacionUps : ACatalogo
   {
      public ClasificacionUps()
      {
         this.UnidadPrestadoraServicio = new HashSet<UnidadPrestadoraServicio>();
      }

      [Key]
      public virtual int IdClasificacionUps { get; set; }

      public virtual ICollection<UnidadPrestadoraServicio> UnidadPrestadoraServicio { get; set; }
   }
}
