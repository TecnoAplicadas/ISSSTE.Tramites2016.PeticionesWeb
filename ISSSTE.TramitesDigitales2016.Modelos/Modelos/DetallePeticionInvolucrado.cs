using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetallePeticionInvolucrado : APersona
   {
      [Key]
      public virtual int IdPeticion { get; set; }
      [Key]
      public virtual int IdInvolucrado { get; set; }
      [Required]
      public virtual int IdTipoPersonal { get; set; }
      public virtual DateTime FechaRegistro { get; set; }
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual Peticion Peticion { get; set; }
      public virtual TipoPersonal TipoPersonal { get; set; }
   }
}
