using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsDetallePeticionInvolucrado : DetallePeticionInvolucrado
   {
      public new Nullable<int> IdPeticion { get; set; }
      public new Nullable<int> IdInvolucrado { get; set; }
      public override string Nombre { get; set; }
      public override string ApellidoPaterno { get; set; }
      public override string ApellidoMaterno { get; set; }
      public new Nullable<int> IdTipoPersonal { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
