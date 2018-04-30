using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class PersonalInvolucrado
    {
        public Nullable<int> IdPeticion { get; set; }
        public  Nullable<int> IdInvolucrado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Nullable<int> IdTipoPersonal { get; set; }
        public  Nullable<DateTime> FechaRegistro { get; set; }
        public Nullable<int> IdUsuarioRegistro { get; set; }
        public string Test { get; set; }
    }
}