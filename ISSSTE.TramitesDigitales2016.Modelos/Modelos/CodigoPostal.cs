using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class CodigoPostal : ACatalogo
   {
      public CodigoPostal()
      {
         this.PoblacionOColonia = new HashSet<PoblacionOColonia>();
      }

      [Key]
      public virtual int IdCodigoPostal { get; set; }
      [Required]
      public virtual int IdMunicipio { get; set; }

      public virtual Municipio Municipio { get; set; }
      public virtual ICollection<PoblacionOColonia> PoblacionOColonia { get; set; }
   }
}
