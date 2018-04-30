using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes.FiltroReportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Reportes.ServiciosReportes
{
    public class CargaCatalogoReportesPdf
    {
        ListaDelegaciones rdnListaDelegaciones = new ListaDelegaciones();
        public ViewModelReporteTipoOpinionCaptacion CragarCatalogosPdf(int pi,int? idRol)
        {
            ViewModelReporteTipoOpinionCaptacion vmr = new ViewModelReporteTipoOpinionCaptacion();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            vmr.Delegacion = new List<SelectListItem>();
            vmr.ReportesList = new List<SelectListItem>();
            vmr.FiltroPdf = new FiltroReportePorTiposOpinionCaptacion();
            vmr.ReportesList.Add(new SelectListItem { Value = "0", Text = "-Selecciona-" });
            vmr.ReportesList.Add(new SelectListItem { Value = "2", Text = "Peticiones por tipo de opinión." });
            vmr.ReportesList.Add(new SelectListItem { Value = "3", Text = "Peticiones por delegación." });
            vmr.ReportesList.Add(new SelectListItem { Value = "4", Text = "Tipo opinión más ejercida." });
            try
            {
                var lista = rdnListaDelegaciones.solicitarDelegaciones(pi, errorProcedimientoAlmacenado);
                if(idRol==1)
                    vmr.Delegacion.Add(new SelectListItem { Value = "", Text = "-Selecciona-", Selected = true });
                foreach (var item in lista)
                {
                    vmr.Delegacion.Add(new SelectListItem { Value = item.IdUnidadAdministrativa.ToString(), Text = item.Nombre });
                }
                return vmr;
            }
            catch
            {
                return vmr;
            }
        }
    }
}