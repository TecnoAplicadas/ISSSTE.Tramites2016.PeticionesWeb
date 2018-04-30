using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Peticionario : APersona
   {
      public Peticionario()
      {
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdPeticionario { get; set; }
      [Required]
      public virtual string Curp { get; set; }
      public virtual string Calle { get; set; }
      public virtual string TipoCalle { get; set; }
      public virtual string NumeroExterior { get; set; }
      public virtual string NumeroInterior { get; set; }
      [Required]
      public virtual int IdPoblacionOColonia { get; set; }
      public virtual string Lada { get; set; }
      public virtual string TelefonoFijo { get; set; }
      public virtual string TelefonoMovil { get; set; }
      [Required]
      public virtual string CorreoElectronico { get; set; }
      [Required]
      public virtual int IdGenero { get; set; }
      [Required]
      public virtual string Rfc { get; set; }
      [Required]
      public virtual int IdTipoDerechohabiente { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }


      public virtual Genero Genero { get; set; }
      public virtual TipoDerechohabiente TipoDerechohabiente { get; set; }
      public virtual ICollection<Peticion> Peticion { get; set; }
   }
}
