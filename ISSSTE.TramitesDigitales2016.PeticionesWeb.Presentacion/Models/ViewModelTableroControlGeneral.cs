using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class ViewModelTableroControlGeneral
    {
        public List<pa_PeticionesWeb_TableroDeControlGeneral_Result> PeticionesTableroControl { get; set; }
        public List<pa_PeticionesWeb_TableroDeEncabazadosEstadisticas_Result> EncabezadosTableroEstadisticas { get; set; }
    }
}