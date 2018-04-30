using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Bitacora
{
    public class Bitacora
    {
        public List<pa_PeticionesWeb_Bitacora_Obtener_BitacoraPeticion_Result> Obtener_BitacoraPeticionP(ParametrosBitacora ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {
            var bitacora = new List<pa_PeticionesWeb_Bitacora_Obtener_BitacoraPeticion_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    bitacora = Db.pa_PeticionesWeb_Bitacora_Obtener_BitacoraPeticion(
                        pnvc_Username: ParametrosEntrada.Username,
                        pnvc_Folio: ParametrosEntrada.Folio,
                        pnvc_FechaInicio: ParametrosEntrada.FechaInicio,
                        pnvc_FechaFin: ParametrosEntrada.FechaFin,
                        pi_errorNumero: ParametrosError.Numero,
                        pnvc_errorMensaje: ParametrosError.Mensaje,
                        pi_errorLinea: ParametrosError.Linea,
                        pnvc_errorProcAlm: ParametrosError.ProcedimientoAlmacenado,
                        pi_errorSeveridad: ParametrosError.Severidad,
                        pi_errorEstado: ParametrosError.Estado
                    ).ToList();
                }
            }
            catch
            {
                throw;
            }
            return bitacora;
        }

    }
}
