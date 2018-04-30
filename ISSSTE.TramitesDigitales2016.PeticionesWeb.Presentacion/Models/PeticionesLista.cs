using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class PeticionesLista
    {
        public int IdPeticion { get; set; }
        public string Folio { get; set; }
        public string UPSNombre { get; set; }
        public Nullable<System.DateTime> FechaHechos { get; set; }
        public string CausaAsunto { get; set; }
        public string NombreUsuario { get; set; }
        public int IdUPS { get; set; }
        public string SemaforoPeticion { get; set; }
        public Nullable<int> IdOperador { get; set; }
        public int IdEstatusInterno { get; set; }
    }
}