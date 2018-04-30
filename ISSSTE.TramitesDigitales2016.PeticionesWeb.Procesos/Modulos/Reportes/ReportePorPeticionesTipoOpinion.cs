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
    public class ReportePorPeticionesTipoOpinion
    {
        public List<pa_PeticionesWeb_Reportes_Generar_RptOrdenadoPorTipoOpinion_Result> obtenerReportePeticionesTipoOpinion(FiltroReportePorTiposOpinionCaptacion pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Generar_RptOrdenadoPorTipoOpinion_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Reportes_Generar_RptOrdenadoPorTipoOpinion(
                    i_id_unidad_administrativa: pi.Delegacion,
                    dt_fecha_inicio: pi.FechaInicio,
                    dt_fecha_fin: pi.FechaFin,
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
        public List<pa_PeticionesWeb_Reportes_Generar_RptServiciosHechosPorDelegacion_Result> obtenerReporteServicioshechosDelegacion(FiltroReportePorTiposOpinionCaptacion pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Generar_RptServiciosHechosPorDelegacion_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Reportes_Generar_RptServiciosHechosPorDelegacion(
                    pi_id_unidad_administrativa: pi.Delegacion,
                    pdt_fecha_inicio: pi.FechaInicio,
                    pdt_fecha_fin: pi.FechaFin,
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
