using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetallePeticionRecordatorioDestinatario
   {
      [Key]
      public virtual int IdPeticion { get; set; }
      [Key]
      public virtual int IdRecordatorio { get; set; }
      [Key]
      public virtual int IdRenglon { get; set; }
      [Required]
      public virtual string Destinatario { get; set; }
      public virtual string ConCopiaA { get; set; }
      [Required]
      public virtual bool EstatusEnvio { get; set; }
      public virtual string ComentariosEnvio { get; set; }

      public virtual DetallePeticionRecordatorio DetallePeticionRecordatorio { get; set; }
   }
}
