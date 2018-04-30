using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Interfaces
{
   public interface IPeticion
   {
      int IdPeticion { get; set; }
      string Folio { get; set; }
      int IdPeticionario { get; set; }
      int IdAfectado { get; set; }
      int IdCausaAsunto { get; set; }
      int IdServicioHecho { get; set; }
      int IdUnidadPrestadoraServicio { get; set; }
      DateTime FechaHechos { get; set; }
      string Descripcion { get; set; }
   }
}
