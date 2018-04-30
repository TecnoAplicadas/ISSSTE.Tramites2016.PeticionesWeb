using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes
{
    public class FechaServidor
    {
        public List<DateTime?> obtenerFechaServidor(ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<DateTime?>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Obtener_FechaServidor(
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
