using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class BitacoraAccionOperador
   {
      public virtual int IdPeticion { get; set; }
      public virtual int IdSeguimiento { get; set; }
      public virtual int IdTipoAccionOperador { get; set; }
      public virtual int IdOperador { get; set; }
      public virtual int IdAccionOperador { get; set; }
      public virtual DateTime FechaRegistro { get; set; }

      public virtual DetallePeticionSeguimiento DetallePeticionSeguimiento { get; set; }
      public virtual TipoAccionOperador TipoAccionOperador { get; set; }
   }
}
