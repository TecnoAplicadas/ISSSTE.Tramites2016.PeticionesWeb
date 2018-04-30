using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsPeticion : Peticion
   {
      public new Nullable<int> IdPeticion { get; set; }
      public override string Folio { get; set; }
      public override string FolioPadre { get; set; }
      public new Nullable<int> IdPeticionario { get; set; }
      public new Nullable<int> IdAfectado { get; set; }
      public new Nullable<int> IdCausaAsunto { get; set; }
      public new Nullable<int> IdServicioHecho { get; set; }
      public new Nullable<int> IdUnidadPrestadoraServicio { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<DateTime> FechaHechos { get; set; }
      public override string Descripcion { get; set; }
      public override Nullable<int> IdOperador { get; set; }
      public new Nullable<int> IdFlujoNotificacion { get; set; }
      public new Nullable<int> IdFlujoRecordatorio { get; set; }
      public new Nullable<int> IdFlujoSemaforo { get; set; }
      public new Nullable<int> IdFlujoEstatus { get; set; }
      public new Nullable<int> IdEstatusInterno { get; set; }
   }
}
