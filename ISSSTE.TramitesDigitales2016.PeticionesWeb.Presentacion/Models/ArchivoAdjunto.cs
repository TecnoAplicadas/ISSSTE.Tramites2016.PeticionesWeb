using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class ArchivoAdjunto
    {
        public Nullable<int> IdPeticion { get; set; }
        public Nullable<int> IdRenglon { get; set; }
        public string RutaArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public Nullable<DateTime> FechaRegistro { get; set; }
    }
}