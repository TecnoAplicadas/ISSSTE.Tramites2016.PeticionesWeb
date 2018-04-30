using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsPeticionario : Peticionario
   {
      public new Nullable<int> IdPeticionario { get; set; }
      public override string Curp { get; set; }
      public override string Nombre { get; set; }
      public override string ApellidoPaterno { get; set; }
      public override string ApellidoMaterno { get; set; }
      public new Nullable<int> IdTipoDerechohabiente { get; set; }
      public override string Lada { get; set; }
      public override string TelefonoFijo { get; set; }
      public override string TelefonoMovil { get; set; }
      public override string CorreoElectronico { get; set; }
      public new Nullable<int> IdGenero { get; set; }
      public override string Rfc { get; set; }
      public override string Calle { get; set; }
      public override string NumeroExterior { get; set; }
      public override string NumeroInterior { get; set; }
      public new Nullable<int> IdPoblacionOColonia { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}
