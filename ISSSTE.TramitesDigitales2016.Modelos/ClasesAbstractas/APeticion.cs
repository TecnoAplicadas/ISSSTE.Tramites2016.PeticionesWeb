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
    /// Nombre: APeticion.cs
    /// Descripción: Contiene el esquema de todas las peticiones.
    /// Autor: Miguel Angel Pájaro Martínez.
    /// Fecha de creación: 20/Dic/2016.
    /// Fecha Ultima modificación: 27/Dic/2016.
    /// </summary>
    public abstract class APeticion : IPeticion
    {
        #region   < < <   P r o p i e d a d e s   > > >
        [Key]
        public virtual int IdPeticion { get; set; }
        public virtual string Folio { get; set; }
        [Required]
        public virtual int IdPeticionario { get; set; }
        [Required]
        public virtual int IdAfectado { get; set; }
        [Required]
        public virtual int IdCausaAsunto { get; set; }
        [Required]
        public virtual int IdServicioHecho { get; set; }
        [Required]
        public virtual int IdUnidadPrestadoraServicio { get; set; }
        [Required]
        public virtual int IdArea { get; set; }
        [Required]
        public virtual DateTime FechaHechos { get; set; }
        [Required]
        public virtual string Descripcion { get; set; }
        #endregion
    }
}
