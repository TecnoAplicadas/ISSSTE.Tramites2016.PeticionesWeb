using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetallePeticionNotificacion
   {
      [Key]
      public virtual int IdPeticion { get; set; }
      [Key]
      public virtual int IdNotificacion { get; set; }
      [Required]
      public virtual string Remitente { get; set; }
      [Required]
      public virtual string Destinatario { get; set; }
      public virtual string ConCopiaA { get; set; }
      [Required]
      public virtual string Asunto { get; set; }
      [Required]
      public virtual Boolean EstatusEnvio { get; set; }
      [Required]
      public virtual string ComentariosEnvio { get; set; }
      [Required]
      public virtual DateTime Fecha { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual Notificacion Notificacion { get; set; }
      public virtual Peticion Peticion { get; set; }
   }
}
