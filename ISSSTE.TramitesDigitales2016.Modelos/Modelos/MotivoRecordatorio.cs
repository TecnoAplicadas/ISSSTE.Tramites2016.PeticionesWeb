using ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class MotivoRecordatorio : ACatalogo
   {
      public MotivoRecordatorio()
      {
         this.ConfiguracionFlujoRecordatorioRecordatorio = new HashSet<ConfiguracionFlujoRecordatorioRecordatorio>();
         this.DetallePeticionRecordatorio = new HashSet<DetallePeticionRecordatorio>();
      }

      [Key]
      public virtual int IdMotivoRecordatorio { get; set; }

      public virtual ICollection<ConfiguracionFlujoRecordatorioRecordatorio> ConfiguracionFlujoRecordatorioRecordatorio { get; set; }
      public virtual ICollection<DetallePeticionRecordatorio> DetallePeticionRecordatorio { get; set; }
   }
}
