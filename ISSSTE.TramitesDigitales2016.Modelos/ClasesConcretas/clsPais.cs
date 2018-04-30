﻿using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas
{
   public class clsPais : Pais
   {
      public new Nullable<int> IdPais { get; set; }
      public override string Clave { get; set; }
      public override string Nombre { get; set; }
      public override string EstatusRegistro { get; set; }
      public new Nullable<DateTime> FechaRegistro { get; set; }
      public new Nullable<int> IdUsuarioRegistro { get; set; }
   }
}