using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetallePeticionRecordatorio
   {
      [Key]
      public virtual int IdPeticion { get; set; }
      [Key]
      public virtual int IdRecordatorio { get; set; }
      [Required]
      public virtual string Remitente { get; set; }
      [Required]
      public virtual string Destinatario { get; set; }
      public virtual string ConCopiaA { get; set; }
      [Required]
      public virtual string Asunto { get; set; }
      [Required]
      public virtual int IdEstatusInterno { get; set; }
      [Required]
      public virtual DateTime Fecha { get; set; }

      public virtual Peticion Peticion { get; set; }
      public virtual Recordatorio Recordatorio { get; set; }
   }
}
