using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes.FiltroReportes;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models
{
    public class ViewModelReporteTipoOpinionCaptacion
    {
        public List<SelectListItem> Delegacion { get; set; }
        public FiltroReportePorTiposOpinionCaptacion FiltroPdf { get; set; }
        public int ReporteNumero { get; set; }
        public List<SelectListItem> ReportesList { get; set; }
    }
}