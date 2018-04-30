using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DiaNoLaborable
   {
      public DiaNoLaborable()
      {

      }

      [Key]
      public virtual int IdFechaNoLaborable { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      public virtual DateTime Fecha { get; set; }
      [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      public virtual string Dia { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
      public virtual string Descripcion { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      [StringLength(1, MinimumLength = 1, ErrorMessage = "El campo {0} debe tener de {2} a {1} caracteres.")]
      public virtual string EstatusRegistro { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      public virtual DateTime FechaRegistro { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      public virtual int IdUsuarioRegistro { get; set; }
   }
}
