using ISSSTE.TramitesDigitales2016.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.Modelos.ClasesAbstractas
{
   /// <summary>
   /// Nombre: ACatalogo.cs
   /// Descripción: Contiene el esquema de todos los catálogos.
   /// Autor: Miguel Angel Pájaro Martínez.
   /// Fecha de creación: 20/Dic/2016.
   /// Fecha Ultima modificación: 27/Dic/2016.
   /// </summary>
   public abstract class ACatalogo : ICatalogo
   {
      #region   < < <   P r o p i e d a d e s   > > >
      [Required]
      public virtual string Clave { get; set; }
      [Required]
      public virtual string Nombre { get; set; }
      [Required]
      public virtual string EstatusRegistro { get; set; }
      [Required]
      public virtual DateTime FechaRegistro { get; set; }
      [Required]
      public virtual int IdUsuarioRegistro { get; set; }
      #endregion
   }
}
