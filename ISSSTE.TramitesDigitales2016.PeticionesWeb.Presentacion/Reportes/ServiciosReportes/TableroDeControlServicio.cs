using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl;
using System.Globalization;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Presentacion.Reportes.ServiciosReporte
{
   public class TableroDeControlServicio
   {
        //Alexo
      public FileContentResult GenerarTablero(FiltroTableroControl pi)
      {
         TableroDeControlRdn tc = new TableroDeControlRdn();
         ErrorProcedimientoAlmacenado pErrorPC = new ErrorProcedimientoAlmacenado();
         ErrorProcedimientoAlmacenado pErrorTablero = new ErrorProcedimientoAlmacenado();
         ErrorProcedimientoAlmacenado pErrorEstatus = new ErrorProcedimientoAlmacenado();
         DateTime pdtFechaInicio = Convert.ToDateTime(pi.FechaInicio);
         DateTime pdtFechaFin = Convert.ToDateTime(pi.FechaFin);
         var userName = pi.psUserName;
         var parametroFecha = (pdtFechaInicio.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + " - " + pdtFechaFin.ToString("dd/MM/yyyyy", CultureInfo.InvariantCulture));
         var parametroNombreD = pi.psNombreDelegacion;
         if (parametroNombreD == null | parametroNombreD == "-Selecciona-")
            parametroNombreD = "Todas";
         var puntoControl = new List<pa_PeticionesWeb_TableroControl_Obtener_PuntosControl_Result>();
         //version anterior
         var listTablero = new List<pa_PeticionesWeb_TableroControl_Obtener_IndicadoresPanelControl_Result>();
         //List<pa_PeticionesWeb_TableroControl_Obtener_Peticiones_Result1> listTablero = new List<pa_PeticionesWeb_TableroControl_Obtener_Peticiones_Result1>();
         var listEstatus = new List<pa_PeticionesWeb_TableroControl_Obtener_TotalPeticionesPorEstatus_Result>();
         try
         {
            puntoControl = tc.solicitarPuntoDeControl(pi, pErrorPC);
            //version anterior
            listTablero = tc.solicitarTableroDeControl(pi, pErrorTablero); 
            //listTablero = tc.solicitarPeticionesTableroDeControl(pi, pErrorTablero);
            listEstatus = tc.solicitarEstatus(pi, pErrorEstatus);
         }
         catch (Exception e)
         {
            throw e;
         }
         if (listTablero.Count == 0)
         {
            Exception e = new Exception();
            e.Source = "Tablero de control vacío.";
            throw e;
         }
         using (TramitesDigitalesEntities _entities = new TramitesDigitalesEntities())
         {
            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;

            var viewer = new ReportViewer();
            ReportParameter[] parametros = new ReportParameter[3];
            parametros[0] = new ReportParameter("OperadorParametro", userName);
            parametros[1] = new ReportParameter("FechaParametro", parametroFecha);
            parametros[2] = new ReportParameter("DelegacionParametro", parametroNombreD);
            viewer.LocalReport.ReportPath = @"Reportes\ServiciosReportes\PlantillasReportes\TableroDeControl.rdlc";
            ReportDataSource RDS = new ReportDataSource("DataSetPuntoDeControl", puntoControl);
            ReportDataSource RDST = new ReportDataSource("DataSetTablero", listTablero);
            ReportDataSource RDSE = new ReportDataSource("DataSetTotalEstatus", listEstatus);
            viewer.LocalReport.SetParameters(parametros);
            viewer.LocalReport.DataSources.Add(RDS);
            viewer.LocalReport.DataSources.Add(RDST);
            viewer.LocalReport.DataSources.Add(RDSE);
            viewer.LocalReport.Refresh();
            var bytes = viewer.LocalReport.Render("EXCELOPENXML", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return new FileContentResult(bytes, mimeType);
         }
      }
   }
}