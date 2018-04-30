using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class UnidadAdministrativaUnidadTransversal
   {
      [Key]
      public virtual int IdUnidadAdministrativa { get; set; }
      [Key]
      public virtual int IdUnidadTransversal { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual UnidadAdministrativa UnidadAdministrativa { get; set; }
      public virtual UnidadTransversal UnidadTransversal { get; set; }
   }
}
