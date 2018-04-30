using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl
{
   public class FiltroTableroControl
   {
        public int? IdUsuario { get; set; }
        public int? Delegacion { get; set; }
        public int? Ups { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? TipoOpinion { get; set; }
        public int? CausaAsunto { get; set; }
        public int? Status { get; set; }
        public string psNombreDelegacion { get; set; }
        public string psUserName { get; set; }
    }
}