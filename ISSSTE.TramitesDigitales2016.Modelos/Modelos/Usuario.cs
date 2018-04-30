using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
    public abstract class Usuario : APersona
    {
        public Usuario()
        {
            this.DetallePeticionSeguimiento = new HashSet<DetallePeticionSeguimiento>();
            this.ConfiguracionUsuarioRol = new HashSet<ConfiguracionUsuarioRol>();
        }
      [Key]
      public virtual int IdUsuario { get; set; }
      public virtual string Username { get; set; }
      public  virtual string Password { get; set; }
      public  virtual string Clave { get; set; }
      public  virtual int IdEnlace { get; set; }
      public  virtual int IdTipoUsuario { get; set; }

      public virtual ICollection<DetallePeticionSeguimiento> DetallePeticionSeguimiento { get; set; }
      public virtual ICollection<ConfiguracionUsuarioRol> ConfiguracionUsuarioRol { get; set; }
      public virtual Enlace Enlace { get; set; }
      public virtual TipoUsuario TipoUsuario { get; set; }
   }
}
