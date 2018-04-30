using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes.FiltroReportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte
{
    public class ReportePorPeticionesTipoOpinionRdn
    {
        ReportePorPeticionesTipoOpinion reporteTipoOpinion = new ReportePorPeticionesTipoOpinion();
        public List<pa_PeticionesWeb_Reportes_Generar_RptOrdenadoPorTipoOpinion_Result> solicitarReportePeticionesTipoOpinion(FiltroReportePorTiposOpinionCaptacion pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Generar_RptOrdenadoPorTipoOpinion_Result>();
            try
            {
                #region funconalidad del metodo
                respuestaWeb = reporteTipoOpinion.obtenerReportePeticionesTipoOpinion(pi, pError);
                #endregion
            }
            catch
            {
                #region se atrapa la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }
        public List<pa_PeticionesWeb_Reportes_Generar_RptServiciosHechosPorDelegacion_Result> solicitarReporteServiciosHechosPorDelegacion(FiltroReportePorTiposOpinionCaptacion pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Generar_RptServiciosHechosPorDelegacion_Result>();
            try
            {
                #region funconalidad del metodo
                respuestaWeb = reporteTipoOpinion.obtenerReporteServicioshechosDelegacion(pi, pError);
                #endregion
            }
            catch
            {
                #region se atrapa la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }
    }
}
