using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ConfiguracionFlujoPuntoControlPuntoControl
   {
      [Key]
      public virtual int IdFlujoPuntoControl { get; set; }
      [Key]
      public virtual int IdPuntoControl { get; set; }
      public virtual byte Orden { get; set; }
      public virtual byte Dias { get; set; }
      public virtual string EstatusRegistro { get; set; }
      public virtual DateTime FechaRegistro { get; set; }
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual FlujoPuntoControl FlujoPuntoControl { get; set; }
      public virtual PuntoControl PuntoControl { get; set; }
   }
}
