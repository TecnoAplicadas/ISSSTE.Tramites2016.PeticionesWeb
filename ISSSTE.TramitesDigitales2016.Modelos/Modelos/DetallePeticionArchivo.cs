using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class DetallePeticionArchivo
   {
      [Key]
      public virtual int IdPeticion { get; set; }
      [Key]
      public virtual int IdRenglon { get; set; }
      [Required]
      public virtual byte[] Archivo { get; set; }
      [Required]
      public virtual string RutaArchivo { get; set; }
      [Required]
      public virtual string NombreArchivo { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }

      public virtual Peticion Peticion { get; set; }
   }
}
