using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes.FiltroReportes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes
{
    public class ReporteTipoOpinionMasEjercida
    {
        public List<pa_PeticionesWeb_Reportes_Generar_ReporteTipoOpinionesMasEjercidasB_Result> obtenerReporteTipoOpinionMasEjercida(FiltroReportePorTiposOpinionCaptacion pi, ErrorProcedimientoAlmacenado pError)
        {
            var pFechaInicio = Convert.ToDateTime(pi.FechaInicio).ToString("yyyyMMdd H:mm:ss.fff", CultureInfo.InvariantCulture);
            var pFechaFin = Convert.ToDateTime(pi.FechaFin).ToString("yyyyMMdd H:mm:ss.fff", CultureInfo.InvariantCulture);
            var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Generar_ReporteTipoOpinionesMasEjercidasB_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Reportes_Generar_ReporteTipoOpinionesMasEjercidasB(

                    pi_id_unidad_administrativa: pi.Delegacion,
                    pnvc_FechaInicio: pFechaInicio,
                    pnvc_FechaFin: pFechaFin,
                    pnvc_clave_ups: "TWOP",
                    pi_errorNumero: pError.Numero,
                    pnvc_errorMensaje: pError.Mensaje,
                    pi_errorLinea: pError.Linea,
                    pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
                    pi_errorSeveridad: pError.Severidad,
                    pi_errorEstado: pError.Estado
                    ).ToList();
                }
            }
            catch
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
