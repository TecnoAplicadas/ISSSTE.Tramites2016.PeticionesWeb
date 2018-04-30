using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class UnidadPrestadoraServicio : ACatalogo
   {
      public UnidadPrestadoraServicio()
      {
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdUnidadPrestadoraServicio { get; set; }
      public virtual string ClavePresupuestal { get; set; }
      [Required]
      public virtual int IdClasificacionUps { get; set; }
      [Required]
      public virtual int IdUnidadAdministrativa { get; set; }
      [Required]
      public virtual int IdNivelUps { get; set; }


      public virtual ClasificacionUps ClasificacionUps { get; set; }
      public virtual NivelUps NivelUps { get; set; }
      public virtual ICollection<Peticion> Peticion { get; set; }
      public virtual UnidadAdministrativa UnidadAdministrativa { get; set; }
   }
}
