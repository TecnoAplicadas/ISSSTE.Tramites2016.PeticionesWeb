using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes.FiltroReportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes
{
    public class ReportePorPeticionesDelegacion
    {
        public List<pa_PeticionesWeb_Reportes_Generar_ReporteOrdenadosPorCaptacion_Result> obtenerReportePorPeticionesDelegacion(FiltroReportePorTiposOpinionCaptacion pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Generar_ReporteOrdenadosPorCaptacion_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Reportes_Generar_ReporteOrdenadosPorCaptacion(
                    pi_IdDelegacion: pi.Delegacion,
                    pdt_FechaInicio: pi.FechaInicio,
                    pdt_FechaFin: pi.FechaFin,
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
