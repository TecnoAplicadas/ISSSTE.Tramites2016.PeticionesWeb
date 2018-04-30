using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class FlujoRecordatorio : ACatalogo
   {
      public FlujoRecordatorio()
      {
         this.ConfiguracionFlujoRecordatorioRecordatorio = new HashSet<ConfiguracionFlujoRecordatorioRecordatorio>();
         this.Peticion = new HashSet<Peticion>();
      }

      [Key]
      public virtual int IdFlujoRecordatorio { get; set; }

      public virtual ICollection<ConfiguracionFlujoRecordatorioRecordatorio> ConfiguracionFlujoRecordatorioRecordatorio { get; set; }
      public virtual ICollection<Peticion> Peticion { get; set; }
   }
}
