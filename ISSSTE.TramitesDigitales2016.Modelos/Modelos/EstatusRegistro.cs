using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class EstatusRegistro
   {
      #region   --   < V a r i a b l e s >   --
      #endregion

      #region   --   < C o n s t r u c t o r e s >   --
      public EstatusRegistro()
      {

      }
      #endregion

      #region   --   < A t r i b u t o s >   --
      [Key]
      [MaxLength(1, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
      public virtual string Estatus { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      [StringLength(20, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener de {2} a {1} caracteres.")]
      public virtual string Nombre { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      public virtual DateTime FechaRegistro { get; set; }
      [Required(ErrorMessage = "{0} es un campo requerido.")]
      public virtual int IdUsuarioRegistro { get; set; }
      #endregion

      #region   --   < M é t o d o s >   --
      #endregion
   }
}
