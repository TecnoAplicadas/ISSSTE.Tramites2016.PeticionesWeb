using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Rol : ACatalogo
   {
      public Rol()
      {
         //this.ConfiguracionUsuarioRol = new HashSet<ConfiguracionUsuarioRol>();
      }

      [Key]
      public virtual int IdRol { get; set; }
      [Required]
      public virtual int IdTipoRol { get; set; }

      //public virtual ICollection<ConfiguracionUsuarioRol> ConfiguracionUsuarioRol { get; set; }
      public virtual TipoRol TiposRol { get; set; }
   }
}
