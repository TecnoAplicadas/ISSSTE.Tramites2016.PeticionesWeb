using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte
{
    public class ListaDelegaciones
    {
        #region Optiene Genero
        GeneraCatalagoReportesPdf ProcesosGeneraCatalogo = new GeneraCatalagoReportesPdf();
        #endregion

        public List<pa_PeticionesWeb_Catalogos_Obtener_DelegacionesReportesPDF_Result> solicitarDelegaciones(int pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_DelegacionesReportesPDF_Result>();
            try
            {
                #region Funcionalidad del Metodo
                respuestaWeb = ProcesosGeneraCatalogo.obtenerDelegaciones(pi, pError);
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
