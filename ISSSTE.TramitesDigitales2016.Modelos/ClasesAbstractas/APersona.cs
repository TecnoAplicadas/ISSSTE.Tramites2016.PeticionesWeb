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
   /// Nombre: APersona.cs
   /// Descripción: Contiene el esquema de todos las personas.
   /// Autor: Miguel Angel Pájaro Martínez.
   /// Fecha de creación: 20/Dic/2016.
   /// Fecha Ultima modificación: 27/Dic/2016.
   /// </summary>
   public abstract class APersona : IPersona
   {
      #region   < < <   P r o p i e d a d e s   > > >
      [Required]
      public virtual string Nombre { get; set; }
      [Required]
      public virtual string ApellidoPaterno { get; set; }
      [Required]
      public virtual string ApellidoMaterno { get; set; }

      public virtual string NombreCompleto {
         get {
            StringBuilder sbNombreCompleto = new StringBuilder("");

            sbNombreCompleto.Append(Nombre);
            sbNombreCompleto.Append(" ");
            sbNombreCompleto.Append(ApellidoPaterno);
            sbNombreCompleto.Append(" ");
            sbNombreCompleto.Append(ApellidoMaterno);

            return sbNombreCompleto.ToString().Trim();
         }
      }
      #endregion
   }
}
