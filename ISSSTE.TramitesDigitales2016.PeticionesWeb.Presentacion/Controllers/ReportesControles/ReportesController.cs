using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Reportes.ServiciosReporte;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Reportes.ServiciosReportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes.FiltroReportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.ReportesControles
{
    [Authorize]
    public class ReportesController : Controller
    {
        List<SelectListItem> listaUps = new List<SelectListItem>();
        List<SelectListItem> listaCausa = new List<SelectListItem>();
        FechaServidorRdn feachaActual = new FechaServidorRdn();
        CatalogoTableroControlRdn rdnListaCatalogos = new CatalogoTableroControlRdn();


        [HttpGet]
        public ActionResult Reportes()
        {

            int? idRol = Convert.ToInt32(Session["IdUsuarioRolReportes"]);
            int? idRolController = Convert.ToInt32(Session["IdUsuarioController"]);
            if (idRol == 2)
            {
                string OcultarControlDeMenu = "hidden";
                Session["OcultarControlDeMenuVar"] = OcultarControlDeMenu;
                @ViewBag.OcultaOpcionMenuDias = OcultarControlDeMenu;
            }
            if (idRolController == 3)
            {
                return RedirectToAction("BandejaIndex", "BandejaDepeticiones");
            }
            CargaCatalogoReportesPdf vmr = new CargaCatalogoReportesPdf();
            var viewModel = vmr.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol);
            if (viewModel.Delegacion.Count == 0)
                ViewBag.ErrorMessage = "Error al cargar las delegaciones";
            //System.Threading.Thread.Sleep(5000);

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Reportes(ViewModelReporteTipoOpinionCaptacion vmr, int ReporteNumero)
        {
            //System.Threading.Thread.Sleep(5000);

            //System.Threading.Thread.Sleep(10000);


            int? idRol = Convert.ToInt32(Session["IdUsuarioRolReportes"]);
            CargaCatalogoReportesPdf vmrFI = new CargaCatalogoReportesPdf();

            vmr.ReporteNumero = ReporteNumero;
            //List<string>  MI =  FormularioReportes.AllKeys.ToList();
            ////string CatTipOp = (Request["datepickerStart"]).ToString();

            if (vmr.FiltroPdf.FechaInicio == null || vmr.FiltroPdf.FechaFin == null)
            {
                ViewBag.ErrorMessage = "Se necesita una fecha inicio y fecha fin.";
                return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol));
            }
            if (vmr.ReporteNumero == 0)
            {
                ViewBag.ErrorMessage = "Selecciona algún reporte, en la lista Reportes.";
                return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol));
            }
            if (vmr.ReporteNumero == 3)
            {
                if ((vmr.FiltroPdf.FechaInicio != null && vmr.FiltroPdf.FechaFin != null))
                {
                    if ((vmr.FiltroPdf.FechaInicio <= vmr.FiltroPdf.FechaFin) && (vmr.FiltroPdf.FechaFin >= vmr.FiltroPdf.FechaInicio))
                    {
                        try
                        {
                            return generarReportePorPeticionesDelegacion(vmr.FiltroPdf);
                        }
                        catch (Exception e)
                        {
                            if (e.Source == "Peticiones por delegación, vacío.")
                            {
                                ViewBag.InfoMessage = "Sin información en el rango de fechas: reporte por peticiones por delegación, vacío..";
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "Al descargar el reporte por peticiones por delegación." + e.ToString();
                            }
                            return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol)); ;

                        }
                    }
                    else
                    {
                        ViewBag.WarningMessage = "La fecha inicio no puede ser mayor a la fecha fin o la fecha fin no puede ser menor a la fecha inicio.";
                        return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol));
                    }
                }
            }
            else if (vmr.ReporteNumero == 2)
            {
                if ((vmr.FiltroPdf.FechaInicio != null && vmr.FiltroPdf.FechaFin != null))
                {
                    if ((vmr.FiltroPdf.FechaInicio <= vmr.FiltroPdf.FechaFin) && (vmr.FiltroPdf.FechaFin >= vmr.FiltroPdf.FechaInicio))
                    {

                        try
                        {
                            return generarReportePorPeticionesTipoOpinion(vmr.FiltroPdf);
                        }
                        catch (Exception e)
                        {
                            if (e.Source == "Reporte por peticiones por tipo opinión, vacío.")
                            {
                                ViewBag.InfoMessage = "Sin información en el rango de fechas: reporte por peticiones por tipo de opinión.";
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "Al descargar el reporte por peticiones por tipo de opinión: " + e.ToString();
                            }
                            return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol));
                        }

                    }
                    else
                    {
                        ViewBag.WarningMessage = "La fecha inicio no puede ser mayor a la fecha fin o la fecha fin no puede ser menor a la fecha inicio.";
                        return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol));
                    }
                }
            }
            else if (vmr.ReporteNumero == 4)
            {
                if ((vmr.FiltroPdf.FechaInicio != null && vmr.FiltroPdf.FechaFin != null))
                {
                    if ((vmr.FiltroPdf.FechaInicio <= vmr.FiltroPdf.FechaFin) && (vmr.FiltroPdf.FechaFin >= vmr.FiltroPdf.FechaInicio))
                    {
                        try
                        {
                            return generarReporteTipoOpinionMasEjercida(vmr.FiltroPdf);
                        }
                        catch (Exception e)
                        {
                            if (e.Source == "Reporte tipo opinión más ejercida, vacío.")
                            {
                                ViewBag.InfoMessage = "Sin información en el rango de fechas: reporte por tipo opinión más ejercida.";
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "Al descargar el reporte por tipo opinión más ejercida: " + e.ToString();
                            }
                            return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol));
                        }
                    }
                    else
                    {
                        ViewBag.WarningMessage = "La fecha inicio no puede ser mayor a la fecha fin o la fecha fin no puede ser menor a la fecha inicio.";
                        return View(vmrFI.CragarCatalogosPdf(Convert.ToInt32(Session["UserLoggedId"]), idRol));
                    }
                }
            }

            return RedirectToAction("Reportes");
        }
        public ActionResult TableroDeControl()
        {
            TableroControlCatalogos vm = new TableroControlCatalogos();
            int? idRol = Convert.ToInt32(Session["IdUsuarioRolReportes"]);
            int? idRolController = Convert.ToInt32(Session["IdUsuarioController"]);
            if (idRol == 2)
            {
                string OcultarControlDeMenu = "hidden";
                Session["OcultarControlDeMenuVar"] = OcultarControlDeMenu;
                @ViewBag.OcultaOpcionMenuDias = OcultarControlDeMenu;
            }
            if (idRolController == 3)
            {
                return RedirectToAction("BandejaIndex", "BandejaDepeticiones");
            }
            var viewModel = vm.cargaCatalogosTableroControl(Convert.ToInt32(Session["UserLoggedId"]), idRol);
            if (viewModel.Delegacion.Count == 0 & viewModel.Status.Count == 0 & viewModel.TiposOpinion.Count == 0)
                ViewBag.ErrorMessage = "Error al cargar las delegaciones, estatus y opiniones.";
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult TableroDeControl(ViewModelTableroControl vmtc)
        {
            TableroDeControlServicio tc = new TableroDeControlServicio();
            TableroControlCatalogos newvm = new TableroControlCatalogos();
            ViewModelTableroControl viewModel = new ViewModelTableroControl();
            ErrorProcedimientoAlmacenado pError = new ErrorProcedimientoAlmacenado();
            ErrorProcedimientoAlmacenado pErrorF = new ErrorProcedimientoAlmacenado();
            int? idRol = Convert.ToInt32(Session["IdUsuarioRolReportes"]);
            vmtc.FiltrosTableroControl.IdUsuario = Convert.ToInt32(Session["UserLoggedId"]);
            vmtc.FiltrosTableroControl.psUserName = (Session["UserName"]).ToString();
            if (vmtc.FiltrosTableroControl.FechaInicio == null)
            {
                ViewBag.ErrorMessage = "Selecciona una fecha inicio.";
                return View(newvm.cargaCatalogosTableroControl(Convert.ToInt32(Session["UserLoggedId"]), idRol));
            }
            try
            {
                var fa = feachaActual.obtenerFechaServidor(pErrorF).First();
                vmtc.FiltrosTableroControl.FechaFin = fa;

            }
            catch
            {
                throw;
            }
            try
            {
                var fechaFin = feachaActual.obtenerFechaServidor(pError).First();
                if (vmtc.FiltrosTableroControl.FechaInicio > fechaFin)
                {
                    ViewBag.ErrorMessageFecha = "La fecha inicio, no puede ser mayor a la fecha actual";
                    return View(newvm.cargaCatalogosTableroControl(Convert.ToInt32(Session["UserLoggedId"]), idRol));
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "No se puede consultar la fecha del servidor.";
                return View(newvm.cargaCatalogosTableroControl(Convert.ToInt32(Session["UserLoggedId"]), idRol));
            }
            try
            {
                if (vmtc.FiltrosTableroControl.FechaInicio != null)
                {
                    try
                    {
                        return tc.GenerarTablero(vmtc.FiltrosTableroControl);
                    }
                    catch
                    {
                        ViewBag.InfoMessage = "Sin información en el rango de fechas.";
                        return View(newvm.cargaCatalogosTableroControl(Convert.ToInt32(Session["UserLoggedId"]), idRol));
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Error al generar el Tablero de Control.";
                return View(newvm.cargaCatalogosTableroControl(Convert.ToInt32(Session["UserLoggedId"]), idRol));
            }
            return RedirectToAction("TableroDeControl");
        }

        #region métodos pdf
        //Reporte por captación.
        public FileContentResult generarReportePorPeticionesDelegacion(FiltroReportePorTiposOpinionCaptacion pi)
        {
            ErrorProcedimientoAlmacenado pErrorF = new ErrorProcedimientoAlmacenado();
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            ReportePorPeticionesDelegacionRdn reportePorPeticionesDelegacionRdn = new ReportePorPeticionesDelegacionRdn();
            try
            {
                var fa = feachaActual.obtenerFechaServidor(pErrorF).First();
                if (Convert.ToDateTime(pi.FechaFin).Day >= Convert.ToDateTime(fa).Day)
                {
                    pi.FechaFin = fa;
                }
                else
                {
                    pi.FechaFin = Convert.ToDateTime(pi.FechaFin).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
            }
            catch
            {
                throw;
            }
            var parametroFechaInicioFin = Convert.ToDateTime(pi.FechaInicio).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX")) +
            " - " + Convert.ToDateTime(pi.FechaFin).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
            parametroFechaInicioFin = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(parametroFechaInicioFin);
            var list = reportePorPeticionesDelegacionRdn.solicitarReportePorPeticionesDelegacionRdn(pi, errorProcedimientoAlmacenado);
            if (list.Count == 0)
            {
                Exception e = new Exception();
                e.Source = "Peticiones por delegación, vacío.";
                throw e;
            }
            string nReportePDF = "PeticionesPorDelegación.pdf";
            using (TramitesDigitalesEntities _entities = new TramitesDigitalesEntities())
            {
                Warning[] warnings;
                string mimeType;
                string[] streamids;
                string encoding;
                string filenameExtension;

                var viewer = new ReportViewer();
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("fechaInicioFin", parametroFechaInicioFin);
                //viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = @"Reportes\ServiciosReportes\PlantillasReportes\ReportePorPeticionesPorDelegación.rdlc";
                ReportDataSource RDS = new ReportDataSource("DataSetReportePeticionesPorDelegación", list);
                viewer.LocalReport.SetParameters(parametros);
                viewer.LocalReport.DataSources.Add(RDS);
                viewer.LocalReport.Refresh();
                var bytes = viewer.LocalReport.Render("pdf", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

                return File(bytes, mimeType, nReportePDF);
            }
        }

        //Reporte por Tipo Opninión.
        public FileContentResult generarReportePorPeticionesTipoOpinion(FiltroReportePorTiposOpinionCaptacion pi)
        {
            ErrorProcedimientoAlmacenado perror = new ErrorProcedimientoAlmacenado();
            ErrorProcedimientoAlmacenado perror2 = new ErrorProcedimientoAlmacenado();
            ErrorProcedimientoAlmacenado pErrorF = new ErrorProcedimientoAlmacenado();
            ReportePorPeticionesTipoOpinionRdn reporteTipoOpninion = new ReportePorPeticionesTipoOpinionRdn();
            try
            {
                var fa = feachaActual.obtenerFechaServidor(pErrorF).First();
                if (Convert.ToDateTime(pi.FechaFin).Day >= Convert.ToDateTime(fa).Day)
                {
                    pi.FechaFin = fa;
                }
                else
                {
                    pi.FechaFin = Convert.ToDateTime(pi.FechaFin).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
            }
            catch
            {
                throw;
            }
            var parametroNombreDelegacion = pi.psNombreDelegacion;
            var parametroFechaInicioFin = Convert.ToDateTime(pi.FechaInicio).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX")) +
            " - " + Convert.ToDateTime(pi.FechaFin).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
            parametroFechaInicioFin = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(parametroFechaInicioFin);
            if (parametroNombreDelegacion == null | parametroNombreDelegacion == "-Selecciona-")
                parametroNombreDelegacion = "Todas";
            var listR1 = new List<pa_PeticionesWeb_Reportes_Generar_RptOrdenadoPorTipoOpinion_Result>();
            var listR2 = new List<pa_PeticionesWeb_Reportes_Generar_RptServiciosHechosPorDelegacion_Result>();
            try
            {
                listR1 = reporteTipoOpninion.solicitarReportePeticionesTipoOpinion(pi, perror);
                listR2 = reporteTipoOpninion.solicitarReporteServiciosHechosPorDelegacion(pi, perror2);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (listR1.Count == 0 | listR2.Count == 0)
            {
                Exception e = new Exception();
                e.Source = "Reporte por peticiones por tipo opinión, vacío.";
                throw e;
            }

            using (TramitesDigitalesEntities _entities = new TramitesDigitalesEntities())
            {
                Warning[] warnings;
                string mimeType;
                string[] streamids;
                string encoding;
                string filenameExtension;
                string nReportePDF = "ReportePorPeticionesPorTipoOpinion.pdf";

                var viewer = new ReportViewer();
                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("delegacion", parametroNombreDelegacion);
                parametros[1] = new ReportParameter("fechaInicioFin", parametroFechaInicioFin);
                viewer.LocalReport.ReportPath = @"Reportes\ServiciosReportes\PlantillasReportes\ReportePeticionesPorTipoDeOpinion.rdlc";
                ReportDataSource RDS = new ReportDataSource("DSRep", listR1);
                ReportDataSource RDS2 = new ReportDataSource("DSRep2", listR2);
                viewer.LocalReport.SetParameters(parametros);
                viewer.LocalReport.DataSources.Add(RDS);
                viewer.LocalReport.DataSources.Add(RDS2);
                viewer.LocalReport.Refresh();
                var bytes = viewer.LocalReport.Render("pdf", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

                return File(bytes, mimeType, nReportePDF);
            }

        }
        //Reporte por Tipo opinión más ejercida.
        public FileContentResult generarReporteTipoOpinionMasEjercida(FiltroReportePorTiposOpinionCaptacion pi)
        {
            ErrorProcedimientoAlmacenado perror = new ErrorProcedimientoAlmacenado();
            ErrorProcedimientoAlmacenado pErrorF = new ErrorProcedimientoAlmacenado();
            ReporteTipoOpinionMasEjercidaRdn reporteTipoOpninion = new ReporteTipoOpinionMasEjercidaRdn();
            try
            {
                var fa = feachaActual.obtenerFechaServidor(pErrorF).First();
                if (Convert.ToDateTime(pi.FechaFin).Day >= Convert.ToDateTime(fa).Day)
                {
                    pi.FechaFin = fa;
                }
                else
                {
                    pi.FechaFin = Convert.ToDateTime(pi.FechaFin).AddHours(23).AddMinutes(59).AddSeconds(59);
                }
            }
            catch
            {
                throw;
            }
            if (pi.Delegacion == null)
                pi.Delegacion = -1;
            var parametroFechaInicioFin = Convert.ToDateTime(pi.FechaInicio).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX")) +
            " - " + Convert.ToDateTime(pi.FechaFin).ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("es-MX"));
            parametroFechaInicioFin = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(parametroFechaInicioFin);
            var listR = reporteTipoOpninion.solicitarReporteTipoOpinionMasEjercida(pi, perror);
            if (listR.Count == 0)
            {
                Exception e = new Exception();
                e.Source = "Reporte tipo opinión más ejercida, vacío.";
                throw e;
            }
            using (TramitesDigitalesEntities _entities = new TramitesDigitalesEntities())
            {
                Warning[] warnings;
                string mimeType;
                string[] streamids;
                string encoding;
                string filenameExtension;
                string nReportePDF = "ReporteTipoOpinionMasEjercida.pdf";

                var viewer = new ReportViewer();
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("fechaInicioFin", parametroFechaInicioFin);
                viewer.LocalReport.ReportPath = @"Reportes\ServiciosReportes\PlantillasReportes\ReporteTipoOpinionMasEjercida.rdlc";
                ReportDataSource RDS = new ReportDataSource("DSRepTipOpiMasEje", listR);
                viewer.LocalReport.DataSources.Add(RDS);
                viewer.LocalReport.SetParameters(parametros);
                viewer.LocalReport.Refresh();
                var bytes = viewer.LocalReport.Render("pdf", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                return File(bytes, mimeType, nReportePDF);
            }
        }
        #endregion

        #region Json
        public JsonResult GetUps(string id)
        {
            int? idUps;
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            if (id != "")
            {
                idUps = Convert.ToInt32(id);
            }
            else
            {
                idUps = null;
            }
            var llenarListaUps = rdnListaCatalogos.solicitarUps(idUps, errorProcedimientoAlmacenado);
            foreach (var item in llenarListaUps)
                listaUps.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre });
            return Json(new SelectList(listaUps, "Value", "Text"));
        }
        public JsonResult GetCausaAsunto(string id)
        {

            int? idTipo;
            ErrorProcedimientoAlmacenado errorProcedimientoAlmacenado = new ErrorProcedimientoAlmacenado();
            if (id != "")
            {
                idTipo = Convert.ToInt32(id);
            }
            else
            {
                idTipo = null;
            }
            var llenarListaCausa = rdnListaCatalogos.solicitarCausaAsunto(idTipo, errorProcedimientoAlmacenado);
            foreach (var item in llenarListaCausa)
                listaCausa.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nombre });
            return Json(new SelectList(listaCausa, "Value", "Text"));
        }
        #endregion


    }

}