using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Interfaces
{
   public interface IPersona
   {
      string Nombre { get; set; }
      string ApellidoPaterno { get; set; }
      string ApellidoMaterno { get; set; }
   }
}
