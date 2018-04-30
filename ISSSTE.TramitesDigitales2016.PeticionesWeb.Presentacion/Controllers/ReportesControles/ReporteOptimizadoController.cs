using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ExpertPdf.HtmlToPdf;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Controllers.ReportesControles
{
    public class ReporteOptimizadoController : Controller
    {

        #region Parámetros de PDF EXCEL y WORD
        /// <summary>
        /// ////////////////DATOS DE CONTENIDO HTML Y PDF
        /// </summary>
        public string TituloDocumento
        {
            get
            {
                //if (ViewState["TituloDocumento"] != null)
                //{
                //    return ViewState["TituloDocumento"].ToString();
                //}
                //else
                //{
                return "Exportación";
                //}
            }
            //set
            //{
            //    ViewState["TituloDocumento"] = value;
            //}
        }

        public string Titulo
        {
            get
            {
                //if (ViewState["Titulo"] != null)
                //{
                //    return ViewState["Titulo"].ToString();
                //}
                //else
                //{
                return "Exportación";
                //}
            }
            //set
            //{
            //    ViewState["Titulo"] = value;
            //}
        }

        public string Subtitulo
        {
            get
            {
                //if (ViewState["Subtitulo"] != null)
                //{
                //    return ViewState["Subtitulo"].ToString();
                //}
                //else
                //{
                return "Subtitulo";
                //}
            }
            //set
            //{
            //    ViewState["Subtitulo"] = value;
            //}
        }

        public string Cabecera
        {
            get
            {
                //if (ViewState["Cabecera"] != null)
                //{
                //    return ViewState["Cabecera"].ToString();
                //}
                //else
                //{
                return "C & A Systems";
                //}
            }
            //set
            //{
            //    ViewState["Cabecera"] = value;
            //}
        }

        public string FondoTitulo
        {
            get
            {
                //if (ViewState["FondoTitulo"] != null)
                //{
                //    return ViewState["FondoTitulo"].ToString();
                //}
                //else
                //{
                return "0000FF";
                //}
            }
            //set
            //{
            //    ViewState["FondoTitulo"] = value;
            //}
        }

        public string LetraTitulo
        {
            get
            {
                //if (ViewState["LetraTitulo"] != null)
                //{
                //    return ViewState["LetraTitulo"].ToString();
                //}
                //else
                //{
                return "FFFFFF";
                //}
            }
            //set
            //{
            //    ViewState["LetraTitulo"] = value;
            //}
        }

        public string ColorElemento
        {
            get
            {
                //if (ViewState["ColorElemento"] != null)
                //{
                //    return ViewState["ColorElemento"].ToString();
                //}
                //else
                //{
                return "EFF6F4";
                //}
            }
            //set
            //{
            //    ViewState["ColorElemento"] = value;
            //}
        }

        public string ColorAlternativo
        {
            get
            {
                //if (ViewState["ColorAlternativo"] != null)
                //{
                //    return ViewState["ColorAlternativo"].ToString();
                //}
                //else
                //{
                return "F2D0B3";
                //}
            }
            //set
            //{
            //    ViewState["ColorAlternativo"] = value;
            //}
        }

        public string NombreArchivo
        {
            get
            {
                //if (ViewState["NombreArchivo"] != null)
                //{
                //    return ViewState["NombreArchivo"].ToString();
                //}
                //else
                //{
                return "Exportacion.PDF";
                //}
            }
            //set
            //{
            //    ViewState["NombreArchivo"] = value;
            //}
        }

        #endregion

        #region Propiedades

        public string RutaImagenEncabezado { get; set; }

        public bool ShowHeader { get; set; }
        public bool ShowFooter { get; set; }
        public bool ShowPageNumber { get; set; }

        public bool DrawHeaderLine { get; set; }
        public bool DrawFooterLine { get; set; }

        public string HeaderText { get; set; }
        public int HeaderHeight { get; set; }

        //public HorizontalTextAlign HeaderTextAlign
        //{
        //    get
        //    {
        //        return HorizontalTextAlign.Center;
        //    }
        //}

        public string PageNumberingFormat { get; set; }

        public string FooterText { get; set; }
        public string FooterFontType { get; set; }
        public int FooterFontSize { get; set; }

        public bool CanPrint { get; set; }

        #endregion
        // GET: ReporteOptimizado


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection MiFormulario)
        {
            System.Threading.Thread.Sleep(2000);
            GeneraReporte();
            return View();
        }

        protected void GeneraReporte()
        {
            #region Cuerpo

            string Cuerpo =
            ("	<!DOCTYPE html>  "
            + "	<html xmlns='http://www.w3.org/1999/xhtml'>"
            + "	<head> "
            + "	<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/> "
            + "	<link href='../Css/Datosminimos.css' rel='stylesheet' type='text/css' /> "
            + "	<title></title> "
            + "	</head> "
            + "	<body> "
            + "	<div > "
            + "	<table style='text-align:left'> "
            + "	<tr>  "
            + "	<td>  "
            + "	<img src='../images/logo.jpg' />  "
            + "	</td>  "
            + "	<td>   "
            + "	<h3>Uniad Jurídica </h3> "
            + "	<h3>Dirección de Consultas, convenios y Contratos</h3> "
            + "	</td>  "
            + "	</tr>  "
            + "	</table>  "
            + "	<br />  "
            + "	<table> "
            + "	<tr>  "
            + "	<td><h4>NOMBRE O RAZÓN SOCIAL: </h4></td>  "
            + "	<td></td>  "
            + "	<td>@NOMBRE</td>  "
            + "	</tr>  "
            + "	<tr>  "
            + "	<td><h4>R.F.C: </h4></td>"
            + "	<td></td>"
            + "	<td>@RFC</td>"
            + "	</tr>"
            + "	<tr>"
            + "	<td><h4>CURP: </h4></td>"
            + "	<td></td>"
            + "	<td>@CURP</td>"
            + "	</tr>"
            + "	<tr>"
            + "	<td><h4>DOMICILIO LEGAL:</h4></td>"
            + "	<td>CALLE: </td>"
            + "	<td>@CALLE</td>"
            + "	</tr>"
            + "	<tr>"
            + "	<td><h4></h4></td>"
            + "	<td>NÚMERO: </td>"
            + "	<td>@NUMERO</td>"
            + "	</tr>"
            + "	</table>"
            + "	</div>"
            + "	</body>"
            + "	</html>");
            #endregion
            string rutaArchivo = @"J:\ArchivosDescargados\Reportes\convertido3" + ".pdf";

            PdfConverter pdfConverter = new PdfConverter();
            pdfConverter.LicenseKey = "f1ROX0dfTk9OTl9KUU9fTE5RTk1RRkZGRg==";
            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Letter;
            pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Best;
            pdfConverter.PdfDocumentOptions.PdfPageOrientation = ExpertPdf.HtmlToPdf.PDFPageOrientation.Portrait;
            pdfConverter.PdfDocumentOptions.ShowHeader = this.ShowHeader;
            //pdfConverter.PdfDocumentOptions.ShowFooter = this.ShowFooter;
            pdfConverter.PdfDocumentOptions.TopMargin = 0;
            pdfConverter.PdfDocumentOptions.RightMargin = 0;
            pdfConverter.PdfDocumentOptions.BottomMargin = 0;
            pdfConverter.PdfDocumentOptions.LeftMargin = 0;
            pdfConverter.SavePdfFromHtmlStringToFile(Cuerpo, rutaArchivo);
        }

    }
}