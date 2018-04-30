using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl
{
   public class ParametrosEntradaTableroControl
   {
      public int? PiIdUnidadAdministrativa { get; set; }
      public int? PiIdUnidadPrestadoraServicio { get; set; }
      public DateTime? PsdtFechaInicio { get; set; }
      //public DateTime? PsdtFechaFin { get; set; }
      public int? PiIdEstatusInterno { get; set; }
      public int? PiIdTipoOpinion { get; set; }
      public int? PiIdCausaAsunto { get; set; }
   }
}