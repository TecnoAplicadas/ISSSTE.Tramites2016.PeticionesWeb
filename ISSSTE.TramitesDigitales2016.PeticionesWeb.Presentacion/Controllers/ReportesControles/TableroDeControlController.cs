using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Models;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Reportes.ServiciosReporte;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Reportes.ServiciosReportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes.FiltroReportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl;

using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Office;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.ReportesControles
{
    [Authorize]

    public class TableroDeControlController : Controller
    {
        //Region de Variables
        #region 
        List<SelectListItem> listaUps = new List<SelectListItem>();
        List<SelectListItem> listaCausa = new List<SelectListItem>();
        FechaServidorRdn feachaActual = new FechaServidorRdn();
        CatalogoTableroControlRdn rdnListaCatalogos = new CatalogoTableroControlRdn();
        ViewModelTableroControl vmtc = new ViewModelTableroControl();
        TableroDeControlRdn Tablero = new TableroDeControlRdn();

        ErrorProcedimientoAlmacenado ManejoErrores = new ErrorProcedimientoAlmacenado();
        ViewModelTableroControlGeneral PeticionesTablero = new ViewModelTableroControlGeneral();
        List<pa_PeticionesWeb_TableroDeControlConfiguracionDias_Result> DiasConfiguracionTablero = new
        List<pa_PeticionesWeb_TableroDeControlConfiguracionDias_Result>();
        List<pa_PeticionesWeb_TableroDeEncabazadosDetalle_Result> TitulosDetalleTablero = new
        List<pa_PeticionesWeb_TableroDeEncabazadosDetalle_Result>();
        FiltroTableroControl FiltroEntrdada = new FiltroTableroControl();
        #endregion

        public ActionResult Index()
        {
            TableroControlCatalogos vm = new TableroControlCatalogos();
            //int? idRol = 1;             //Convert.ToInt32(Session["IdUsuarioRolReportes"]);
            //int? idRolController = 1;  //Convert.ToInt32(Session["IdUsuarioController"]);
            //int UsusarioLog = 1;      //Convert.ToInt32(Session["UserLoggedId"]);

            int? idRol = Convert.ToInt32(Session["IdUsuarioRolReportes"]);
            int? idRolController = Convert.ToInt32(Session["IdUsuarioController"]);
            int UsusarioLog =Convert.ToInt32(Session["UserLoggedId"]);
            //vmtc.FiltrosTableroControl.psUserName = "adminsad";

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
            var viewModel = vm.cargaCatalogosTableroControl(UsusarioLog, idRol);
            vmtc = viewModel;
            if (viewModel.Delegacion.Count == 0 & viewModel.Status.Count == 0 & viewModel.TiposOpinion.Count == 0)
                ViewBag.ErrorMessage = "Error al cargar las delegaciones, estatus y opiniones.";


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ViewModelTableroControl vmtc)
        {
            //variables generales tablero
            #region
            PeticionesTablero.PeticionesTableroControl =
            ObtenerPeticionesTableroDeControl(vmtc.FiltrosTableroControl).PeticionesTableroControl;
            PeticionesTablero.EncabezadosTableroEstadisticas = ObtenerEncabezadosEstadisticas().EncabezadosTableroEstadisticas;
            #endregion

            //http://files.cnblogs.com/fan0136/Microsoft.Office.Interop.Excel.rar
            //Pagina de descarga para descarga de excel
            #region   
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            #endregion

            //Encabezados Excel Detalle 
            #region
            //xlWorkSheet.Cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //seccion de encabezado imagen
            //xlWorkSheet.Shapes.AddPicture
            //(@"J:\ProyectoTableroDEcontrol\issste-logo.JPG",
            //Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue,
            //DatosGenerales.ImagenIzquierda, DatosGenerales.ImagenArriba, DatosGenerales.ImagenAncho, DatosGenerales.ImagenAlto);
            xlWorkSheet.Shapes.AddPicture
           (@"C:\ReportesExcelTablero\issste-logo.JPG",
           Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue,
           DatosGenerales.ImagenIzquierda, DatosGenerales.ImagenArriba, DatosGenerales.ImagenAncho, DatosGenerales.ImagenAlto);

            xlWorkSheet.Cells[DatosGenerales.FilaDos, DatosGenerales.ColumnaCinco] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == DatosGenerales.FilaDiezsiceis).FirstOrDefault().Encabezado;
            xlWorkSheet.Cells[DatosGenerales.FilaTres, DatosGenerales.ColumnaCinco] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == DatosGenerales.FilaCatorce).FirstOrDefault().Encabezado;
            xlWorkSheet.Cells[DatosGenerales.FilaCuatro, DatosGenerales.ColumnaCinco] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == DatosGenerales.FilaQuince).FirstOrDefault().Encabezado;

            //Seccion de punto de control

            int FilaInicioencabezadoPuntoControl = DatosGenerales.FilaOcho;
            string FilaInicioencabezadoPuntoControlString = FilaInicioencabezadoPuntoControl.ToString();
            string LetraColumnaInicioPuntoControl = "B";
            string LetraColumnaFinPuntoControl = "F";

            xlWorkSheet.Cells[FilaInicioencabezadoPuntoControl, 1].ColumnWidth = 5; // primera columna vacia

            //Punto de control 
            xlWorkSheet.Range[xlWorkSheet.Cells[8, 2], xlWorkSheet.Cells[8, 3]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[9, 2], xlWorkSheet.Cells[9, 3]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[10, 2], xlWorkSheet.Cells[10, 3]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[11, 2], xlWorkSheet.Cells[11, 3]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[12, 2], xlWorkSheet.Cells[12, 3]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[13, 2], xlWorkSheet.Cells[13, 3]].Merge();

            xlWorkSheet.Range[LetraColumnaInicioPuntoControl + FilaInicioencabezadoPuntoControlString,
            LetraColumnaFinPuntoControl + FilaInicioencabezadoPuntoControlString].Font.Bold = true;
            xlWorkSheet.Range[LetraColumnaInicioPuntoControl + FilaInicioencabezadoPuntoControlString,
            LetraColumnaFinPuntoControl + FilaInicioencabezadoPuntoControlString].Borders.LineStyle = 1d;
            xlWorkSheet.Range[LetraColumnaInicioPuntoControl + FilaInicioencabezadoPuntoControlString,
            LetraColumnaFinPuntoControl + FilaInicioencabezadoPuntoControlString].Interior.Color =
            System.Drawing.ColorTranslator.FromHtml("#75C9F7");

            //Asignacion de encabezados estadisticas
            xlWorkSheet.Cells[FilaInicioencabezadoPuntoControl, 2] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 1).FirstOrDefault().Encabezado;
            xlWorkSheet.Cells[FilaInicioencabezadoPuntoControl, 4] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 2).FirstOrDefault().Encabezado;
            xlWorkSheet.Cells[FilaInicioencabezadoPuntoControl, 5] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 3).FirstOrDefault().Encabezado;
            xlWorkSheet.Cells[FilaInicioencabezadoPuntoControl, 6] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 4).FirstOrDefault().Encabezado;

            //asignacion de registros Punto de control
            xlWorkSheet.Cells[9, DatosGenerales.ColumnaDos] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 1).FirstOrDefault().Nombre;
            xlWorkSheet.Cells[10, DatosGenerales.ColumnaDos] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 2).FirstOrDefault().Nombre;
            xlWorkSheet.Cells[11, DatosGenerales.ColumnaDos] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 3).FirstOrDefault().Nombre;
            xlWorkSheet.Cells[12, DatosGenerales.ColumnaDos] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 4).FirstOrDefault().Nombre;
            xlWorkSheet.Cells[13, DatosGenerales.ColumnaDos] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 5).FirstOrDefault().Nombre;
            //asignacion de registros  Dias
            xlWorkSheet.Cells[9, DatosGenerales.ColumnaCuatro] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 1).FirstOrDefault().DiasAsignadosPeticion.ToString();
            xlWorkSheet.Cells[10, DatosGenerales.ColumnaCuatro] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 2).FirstOrDefault().DiasAsignadosPeticion.ToString();
            xlWorkSheet.Cells[11, DatosGenerales.ColumnaCuatro] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 3).FirstOrDefault().DiasAsignadosPeticion.ToString();
            xlWorkSheet.Cells[12, DatosGenerales.ColumnaCuatro] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 4).FirstOrDefault().DiasAsignadosPeticion.ToString();
            xlWorkSheet.Cells[13, DatosGenerales.ColumnaCuatro] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 5).FirstOrDefault().DiasAsignadosPeticion.ToString();

            //asignacion de registros  Dias Promedio
            decimal DiasAsignacion =
            PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_AsignacionOperador != null).Sum(p => p.DiasTotalesAsignacion).Value;
            decimal NumeroDePeticionesAsignadas = PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_AsignacionOperador != null).Count();
            decimal DiasPromedioAsignacion = (NumeroDePeticionesAsignadas == 0 ? 0 : (DiasAsignacion / NumeroDePeticionesAsignadas));

            decimal DiasConclusion =
            PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_ConclusionPeticion2 != null).Sum(p => p.DiasTotalesConclusion2).Value;
            decimal NumeroDePeticionesConcluidas = PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_ConclusionPeticion2 != null).Count();
            decimal DiasPromedioConclusion = (NumeroDePeticionesConcluidas == 0 ? 0 : (DiasConclusion / NumeroDePeticionesConcluidas));

            decimal DiasCierre =
            PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_CierrePeticion != null).Sum(p => p.DiasTotalesCierre).Value;
            decimal NumeroDePeticionesCerradas = PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_CierrePeticion != null).Count();
            decimal DiasPromedioCerradas = (NumeroDePeticionesCerradas == 0 ? 0 : (DiasCierre / NumeroDePeticionesCerradas));

            decimal TotalDiasPromedio = 1 + ((DiasPromedioAsignacion + DiasPromedioConclusion + DiasPromedioCerradas) / 3);

            xlWorkSheet.Cells[9, 5] =
            DiasConfiguracionTablero.Where(x => x.IdDiaAsignado == 1).FirstOrDefault().DiasAsignadosPeticion.ToString();
            xlWorkSheet.Cells[10, 5] = decimal.Round(DiasPromedioAsignacion);
            xlWorkSheet.Cells[11, 5] = decimal.Round(DiasPromedioConclusion);
            xlWorkSheet.Cells[12, 5] = decimal.Round(DiasPromedioCerradas);
            xlWorkSheet.Cells[13, 5] = decimal.Round(TotalDiasPromedio);
            //asignacion de registros  Cumplimiento

            decimal CumplimientoAsignacion =
            PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_AsignacionOperador != null && p.DiasTotalesAsignacion < 10).Count();
            decimal NoPeticionesCaduacdasEnAsignacion =
            PeticionesTablero.PeticionesTableroControl.Count();
            //PeticionesTablero.PeticionesTableroControl.Where(p => p.DiasTotalesTranscurridos > 10).Count();
            decimal PorcentajeCumplimientoAsignacion =
            (NoPeticionesCaduacdasEnAsignacion == 0 ? 0 : ((CumplimientoAsignacion / NoPeticionesCaduacdasEnAsignacion) * 100));

            decimal CumplimientoConclusion =
            PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_ConclusionPeticion2 != null && p.DiasTotalesConclusion2 < 21).Count();
            decimal NoPeticionesPorArribaEnConclusion =
            PeticionesTablero.PeticionesTableroControl.Count();
            //PeticionesTablero.PeticionesTableroControl.Where(p => p.DiasTotalesTranscurridos > 30).Count();
            decimal PorcentajeCumplimientoConclusion =
            (NoPeticionesPorArribaEnConclusion == 0 ? 0 : ((CumplimientoConclusion / NoPeticionesPorArribaEnConclusion) * 100));

            decimal CumplimientoCierre =
            PeticionesTablero.PeticionesTableroControl.Where(p => p.Fecha_CierrePeticion != null && p.DiasTotalesCierre < 11).Count();
            decimal NoPeticionesPorArribaEnCierre =
            PeticionesTablero.PeticionesTableroControl.Count();
            //PeticionesTablero.PeticionesTableroControl.Where(p => p.DiasTotalesTranscurridos > 40).Count();
            decimal PorcentajeCumplimientoCierre =
            (NoPeticionesPorArribaEnCierre == 0 ? 0 : ((CumplimientoCierre / NoPeticionesPorArribaEnCierre) * 100));

            xlWorkSheet.Cells[9, 6] = (100).ToString();
            xlWorkSheet.Cells[10, 6] = decimal.Round(PorcentajeCumplimientoAsignacion);
            xlWorkSheet.Cells[11, 6] = decimal.Round(PorcentajeCumplimientoConclusion);
            xlWorkSheet.Cells[12, 6] = decimal.Round(PorcentajeCumplimientoCierre);

            //asignacion de registros  Estadisticas Globales
            #region
            int FilaInicioencabezadoGlobal = DatosGenerales.ColumnaNueve;
            string FilaInicioencabezadoGlogalString = FilaInicioencabezadoGlobal.ToString();
            int FilaFinencabezadoGlobal = 16;
            string FilaFinEncabezadoGlogalString = FilaFinencabezadoGlobal.ToString();


            string LetraColumnaInicioGlobal = "H";
            string LetraColumnaFinGlobal = "H";

            xlWorkSheet.Range[LetraColumnaInicioGlobal + FilaInicioencabezadoGlogalString,
                              LetraColumnaFinGlobal + FilaFinEncabezadoGlogalString].Font.Bold = true;
            //xlWorkSheet.Range[LetraColumnaInicioGlobal + FilaInicioencabezadoGlogalString,
            //                  LetraColumnaFinGlobal + FilaFinEncabezadoGlogalString].Borders.LineStyle = 1d;
            //xlWorkSheet.Range[LetraColumnaInicioGlobal + FilaInicioencabezadoGlogalString,
            //                  LetraColumnaFinGlobal + FilaFinEncabezadoGlogalString].Interior.Color =
            //System.Drawing.ColorTranslator.FromHtml("#75C9F7");

            //"Asignadas";
            xlWorkSheet.Cells[9, DatosGenerales.ColumnaOcho] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 6).FirstOrDefault().Encabezado;
            //"Concluida";
            xlWorkSheet.Cells[10, DatosGenerales.ColumnaOcho] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 7).FirstOrDefault().Encabezado;
            //"Cerradas";
            xlWorkSheet.Cells[11, DatosGenerales.ColumnaOcho] =
            //"Sin seguimiento";
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 8).FirstOrDefault().Encabezado;
            //Vencidas
            xlWorkSheet.Cells[12, DatosGenerales.ColumnaOcho] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 9).FirstOrDefault().Encabezado;
            //Sin Seguimiento
            xlWorkSheet.Cells[12, DatosGenerales.ColumnaOcho] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 13).FirstOrDefault().Encabezado;
            //"Total";
            xlWorkSheet.Cells[13, DatosGenerales.ColumnaOcho] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 10).FirstOrDefault().Encabezado;

            //"Días Pormedio";
            xlWorkSheet.Cells[15, DatosGenerales.ColumnaOcho] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 11).FirstOrDefault().Encabezado;
            //"Nivel de servicio";
            xlWorkSheet.Cells[16, DatosGenerales.ColumnaOcho] =
            PeticionesTablero.EncabezadosTableroEstadisticas.Where(x => x.IdTitulo == 12).FirstOrDefault().Encabezado;

            xlWorkSheet.Cells[9, DatosGenerales.ColumnaNueve] = "s/n";
            xlWorkSheet.Cells[10, DatosGenerales.ColumnaNueve] = "s/n";
            xlWorkSheet.Cells[11, DatosGenerales.ColumnaNueve] = "s/n";
            xlWorkSheet.Cells[12, DatosGenerales.ColumnaNueve] = "s/n";
            xlWorkSheet.Cells[13, DatosGenerales.ColumnaNueve] = "s/n";
            xlWorkSheet.Cells[15, DatosGenerales.ColumnaNueve] = "s/n";
            xlWorkSheet.Cells[16, DatosGenerales.ColumnaNueve] = "s/n";

            #endregion

            //Seccion de encabezados detalle peticiones                 
            int FilaInicioencabezado = 19;
            string FilaInicioencabezadoString = FilaInicioencabezado.ToString();
            string LetraColumnaInicio = "B";
            string LetraColumnaFin = "L";

            ObtenerTableroTitulosDetalle().ToList().ForEach(p =>
            {
                xlWorkSheet.Cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                xlWorkSheet.Cells[FilaInicioencabezado, 1].ColumnWidth = 5; // primera columna vacia
                xlWorkSheet.Cells[FilaInicioencabezado, p.IdTitulo + 1] = p.Encabezado;
                xlWorkSheet.Cells[FilaInicioencabezado, 3].ColumnWidth = 25;
                xlWorkSheet.Cells[FilaInicioencabezado, 4].ColumnWidth = 25;
                xlWorkSheet.Cells[FilaInicioencabezado, 5].ColumnWidth = 25;
                xlWorkSheet.Cells[FilaInicioencabezado, 6].ColumnWidth = 30;
                xlWorkSheet.Cells[FilaInicioencabezado, 7].ColumnWidth = 20;
                xlWorkSheet.Cells[FilaInicioencabezado, 8].ColumnWidth = 20;
                xlWorkSheet.Cells[FilaInicioencabezado, 9].ColumnWidth = 20;
                xlWorkSheet.Cells[FilaInicioencabezado, 10].ColumnWidth = 20;

                //xlWorkSheet.Cells[13, 2].Font.Bold = true;
                xlWorkSheet.Range[LetraColumnaInicio + FilaInicioencabezadoString, LetraColumnaFin + FilaInicioencabezadoString].Font.Bold = true;
                xlWorkSheet.Range[LetraColumnaInicio + FilaInicioencabezadoString, LetraColumnaFin + FilaInicioencabezadoString].Borders.LineStyle = 1d;
                xlWorkSheet.Range[LetraColumnaInicio + FilaInicioencabezadoString, LetraColumnaFin + FilaInicioencabezadoString].Interior.Color =
                System.Drawing.ColorTranslator.FromHtml("#75C9F7");
            }
            );
            #endregion

            //Excel Detalle Peticiones Tablero De control
            #region
            int NumeroDEPeticionesEncontradas = 0;
            int ValorDeLaFila = 20;

            PeticionesTablero.PeticionesTableroControl.ToList().ForEach(p =>
            {
                xlWorkSheet.Cells[ValorDeLaFila, 2] = (NumeroDEPeticionesEncontradas).ToString();
                xlWorkSheet.Cells[ValorDeLaFila, 3] = p.Folio;
                xlWorkSheet.Cells[ValorDeLaFila, 4] = p.CurpPeticionario;
                xlWorkSheet.Cells[ValorDeLaFila, 5] = p.NombrePeticionario;
                xlWorkSheet.Cells[ValorDeLaFila, 6] = p.Delegacion;
                xlWorkSheet.Cells[ValorDeLaFila, 7] = p.FechaRegistro;
                xlWorkSheet.Cells[ValorDeLaFila, 8] = p.Fecha_AsignacionOperador;
                //(p.Fecha_AsignacionOperador != null ? p.Fecha_AsignacionOperador.Value.ToString("dd/MM/yyyy") : "");
                xlWorkSheet.Cells[ValorDeLaFila, 9] = p.Fecha_ConclusionPeticion2;
                //(p.Fecha_ConclusionPeticion2 != null ? p.Fecha_ConclusionPeticion2.Value.ToString("dd/MM/yyyy") : "");
                xlWorkSheet.Cells[ValorDeLaFila, 10] = p.Fecha_CierrePeticion;
                //(p.Fecha_CierrePeticion != null ? p.Fecha_CierrePeticion.Value.ToString("dd/MM/yyyy") : "");
                //xlWorkSheet.Cells[ValorDeLaFila, 11] = p.DiasTotales.ToString();
                xlWorkSheet.Cells[ValorDeLaFila, 11] = p.DiasTotalesTranscurridos.ToString();
                xlWorkSheet.Cells[ValorDeLaFila, 12] = p.EstatusPeticion;
                //System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                NumeroDEPeticionesEncontradas = NumeroDEPeticionesEncontradas + 1;
                ValorDeLaFila = ValorDeLaFila + 1;
            }
            );

            int NumeroDEPeticionesEncontradasc = 0;
            int ValorDeLaFilac = 20;
            PeticionesTablero.PeticionesTableroControl.ToList().ForEach(p =>
            {
                if (p.Fecha_AsignacionOperador != null)
                {
                    xlWorkSheet.Cells[ValorDeLaFilac, 8].Interior.ColorIndex = p.ColorAsignacion1;
                    //= System.Drawing.ColorTranslator.FromHtml(p.ColorAsignacion1);
                }
                if (p.Fecha_ConclusionPeticion2 != null)
                {
                    xlWorkSheet.Cells[ValorDeLaFilac, 9].Interior.ColorIndex = p.ColorConclusion1;
                    //System.Drawing.ColorTranslator.FromHtml(p.ColorConclusion1);
                }
                if (p.Fecha_CierrePeticion != null)
                {
                    xlWorkSheet.Cells[ValorDeLaFilac, 10].Interior.ColorIndex = p.ColorCierre1;
                    //System.Drawing.ColorTranslator.FromHtml(p.ColorCierre1);
                }

                NumeroDEPeticionesEncontradasc = NumeroDEPeticionesEncontradasc + 1;
                ValorDeLaFilac = ValorDeLaFilac + 1;
            }
            );

            #endregion

            //Gurdado de archivo
            #region

            //string handle = Guid.NewGuid().ToString();

            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    xlWorkBook.SaveAs(memoryStream);
            //    memoryStream.Position = 0;
            //    TempData[handle] = memoryStream.ToArray();
            //}

            //// Note we are returning a filename as well as the handle
            //return new JsonResult()
            //{
            //    Data = new { FileGuid = handle, FileName = "TestReportOutput.xlsx" }
            //};
            //#endregion

            string RutaAlmacenamiento = string.Empty;
            RutaAlmacenamiento = @"C:\ReportesExcelTablero\ReporteExcel1.xlsx";

            ////MemoryStream ms = new MemoryStream();
            ////xlWorkBook.Save(ms);
            ////byte[] bytes = ms.ToArray();
            #endregion

            return File(RutaAlmacenamiento, "attachment", "WidgetData.xlsx");            
        }

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

        public ViewModelTableroControlGeneral ObtenerPeticionesTableroDeControl(FiltroTableroControl FiltroEntrdada)
        {
            PeticionesTablero.PeticionesTableroControl = 
            Tablero.ListaPeticionesTableroControlRdn(FiltroEntrdada, ManejoErrores);
            DiasConfiguracionTablero = Tablero.ListaParanetrosDiasTableroControlRdn(FiltroEntrdada, ManejoErrores);

            // caculo para los semaforos
            #region 
            //Avoso de recepcion Satosfactoria 
            int AvisoRecepcion =
            DiasConfiguracionTablero.Where
            (p => p.IdDiaAsignado == Convert.ToInt16(DatosGenerales.IdTableroCDiasAsignados.Aviso_recepcion)).First().DiasAsignadosPeticion;

            //Parametros para Asignacion
            int DiasInicioAsignacion = AvisoRecepcion +
            DiasConfiguracionTablero.Where
            (p => p.IdDiaAsignado == Convert.ToInt16(DatosGenerales.IdTableroCDiasAsignados.Contestacion)).First().DiasAsignadosPeticion;

            int Semaforo_Contestacion_Amarillo =
            DiasConfiguracionTablero.Where
            (p => p.IdDiaAsignado == Convert.ToInt16(DatosGenerales.IdTableroCDiasAsignados.Paremtro_Semaforo_Contestacion_amarillo)).First
            ().DiasAsignadosPeticion;

            int DiasDiferenciaContestacion = (DiasInicioAsignacion - Semaforo_Contestacion_Amarillo);

            //Parametros para Conclusion
            int DiasInicioConclusion = DiasInicioAsignacion +
            (DiasConfiguracionTablero.Where
            (p => p.IdDiaAsignado == Convert.ToInt16(DatosGenerales.IdTableroCDiasAsignados.Turnado)).First().DiasAsignadosPeticion);
            int Semaforo_Conclusion_Amarillo =
            DiasConfiguracionTablero.Where
            (p => p.IdDiaAsignado == Convert.ToInt16(DatosGenerales.IdTableroCDiasAsignados.Paremtro_Semaforo_Turnado_amarillo)).First
            ().DiasAsignadosPeticion;
            int DiasDiferenciaConclusion = (DiasInicioConclusion - Semaforo_Contestacion_Amarillo);

            //Parametros para Cierre
            int DiasInicioCierre = DiasInicioConclusion +
            (DiasConfiguracionTablero.Where
            (p => p.IdDiaAsignado == Convert.ToInt16(DatosGenerales.IdTableroCDiasAsignados.Respuesta)).First().DiasAsignadosPeticion);
            int Semaforo_Cierre_Amarillo =
            DiasConfiguracionTablero.Where
            (p => p.IdDiaAsignado == Convert.ToInt16(DatosGenerales.IdTableroCDiasAsignados.Paremtro_Semaforo_Respuesta_amarillo)).First
            ().DiasAsignadosPeticion;
            int DiasDiferenciaCierre = (DiasInicioCierre - Semaforo_Cierre_Amarillo);

            //Asignacion del color para la Asignacion
            PeticionesTablero.PeticionesTableroControl.ToList().ForEach(i =>
            {
                if (i.Fecha_AsignacionOperador == null)
                {

                }
                else
                {
                    if (i.DiasTotalesAsignacion <= DiasDiferenciaContestacion)
                    { i.ColorAsignacion1 = DatosGenerales.ColorVerde; }

                    if (i.DiasTotalesAsignacion > DiasDiferenciaContestacion && i.DiasTotalesAsignacion <= DiasInicioAsignacion)
                    { i.ColorAsignacion1 = DatosGenerales.ColorAmarillo; }

                    if (i.DiasTotalesAsignacion > DiasInicioAsignacion)
                    { i.ColorAsignacion1 = DatosGenerales.ColorRojo; }
                }
            });

            //Asignacion del color para la conclusion
            PeticionesTablero.PeticionesTableroControl.ToList().ForEach(i =>
            {
                if (i.DiasTotalesConclusion2 <= DiasDiferenciaConclusion)
                { i.ColorConclusion1 = DatosGenerales.ColorVerde; }

                if (i.DiasTotalesConclusion2 > DiasDiferenciaConclusion && i.DiasTotalesConclusion2 <= DiasInicioConclusion)
                { i.ColorConclusion1 = DatosGenerales.ColorAmarillo; }

                if (i.DiasTotalesConclusion2 > DiasInicioConclusion)
                { i.ColorConclusion1 = DatosGenerales.ColorRojo; }
            });

            //Asignacion del color Para la cierre
            PeticionesTablero.PeticionesTableroControl.ToList().ForEach(i =>
            {
                if (i.DiasTotalesCierre <= DiasDiferenciaCierre)
                { i.ColorCierre1 = DatosGenerales.ColorVerde; }

                if (i.DiasTotalesCierre > DiasDiferenciaCierre && i.DiasTotalesCierre <= DiasInicioCierre)
                { i.ColorCierre1 = DatosGenerales.ColorAmarillo; }

                if (i.DiasTotalesCierre > DiasInicioCierre)
                { i.ColorCierre1 = DatosGenerales.ColorRojo; }
            });
            #endregion

            return PeticionesTablero;
        }

        public ViewModelTableroControlGeneral ObtenerEncabezadosEstadisticas()
        {
            PeticionesTablero.EncabezadosTableroEstadisticas = 
            Tablero.EncabezadosEstadisticasRdn(FiltroEntrdada, ManejoErrores);

            // caculo para los semaforos

            return PeticionesTablero;
        }

        public List<pa_PeticionesWeb_TableroDeEncabazadosDetalle_Result> ObtenerTableroTitulosDetalle()
        {
            TitulosDetalleTablero = Tablero.ListaTableroDeEncabazadosDetalleRdn(FiltroEntrdada, ManejoErrores);
            return TitulosDetalleTablero;
        }
    }
}