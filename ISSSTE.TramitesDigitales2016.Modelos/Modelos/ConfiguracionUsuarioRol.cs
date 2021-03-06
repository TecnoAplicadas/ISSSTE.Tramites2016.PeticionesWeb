﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.Modelos
{
   public class ConfiguracionUsuarioRol
   {
      [Key]
      public virtual int IdUsuario { get; set; }
      [Key]
      public virtual int IdRol { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }

      public virtual Rol Rol { get; set; }
      public virtual Usuario Usuario { get; set; }
   }
}
