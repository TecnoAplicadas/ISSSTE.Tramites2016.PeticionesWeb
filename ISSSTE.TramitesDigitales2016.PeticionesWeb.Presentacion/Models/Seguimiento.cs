using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class Seguimiento
    {
        public Nullable<int> IdPeticion { get; set; }
        public Nullable<int> IdSeguimiento { get; set; }
        public Nullable<int> IdSeguimientoOperador { get; set; }
        public Nullable<int> IdOperador { get; set; }
        public string Comentarios { get; set; }
        public Nullable<int> IdEstatusInterno { get; set; }
        public Nullable<DateTime> FechaRegistro { get; set; }
        public string UserName { get; set; }
        public Nullable<int> IdRol { get; set; }
        public bool AsigPeticion { get; set; }
    }
}