using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class Municipio : ACatalogo
   {
      public Municipio()
      {
         //this.CodigoPostal = new HashSet<CodigoPostal>();
      }

      [Key]
      public virtual int IdMunicipio { get; set; }
      [Required]
      public virtual int IdEstado { get; set; }

      //public virtual ICollection<CodigoPostal> CodigoPostal { get; set; }
      public virtual Estado Estado { get; set; }
   }
}
