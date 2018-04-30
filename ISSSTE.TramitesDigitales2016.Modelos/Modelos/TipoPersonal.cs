using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class TipoPersonal : ACatalogo
   {
      public TipoPersonal()
      {
         //this.DetallePeticionInvolucrado = new HashSet<DetallePeticionInvolucrado>();
      }

      [Key]
      public virtual int IdTipoPersonal { get; set; }

      //public virtual ICollection<DetallePeticionInvolucrado> DetallePeticionInvolucrado { get; set; }
   }
}
