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
    public class ReportePorPeticionesDelegacionRdn
    {
        #region Instancias de objetos
        ReportePorPeticionesDelegacion procesosGeneraReporte = new ReportePorPeticionesDelegacion();
        #endregion

        public List<pa_PeticionesWeb_Reportes_Generar_ReporteOrdenadosPorCaptacion_Result> solicitarReportePorPeticionesDelegacionRdn (FiltroReportePorTiposOpinionCaptacion pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Generar_ReporteOrdenadosPorCaptacion_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = procesosGeneraReporte.obtenerReportePorPeticionesDelegacion(pi, pError);
                #endregion
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }
    }
}
