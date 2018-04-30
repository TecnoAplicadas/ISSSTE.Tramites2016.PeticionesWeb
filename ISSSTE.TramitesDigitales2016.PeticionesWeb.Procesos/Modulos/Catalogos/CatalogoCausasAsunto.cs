using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos
{
    public class CatalogoCausasAsunto
    {
        public List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result> ObtenerCausasAsunto
        (clsCausaAsunto pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto(
                        idTipoOpinion: pEntrada.IdTipoOpinion,
                        estatusRegistro: pEntrada.EstatusRegistro,
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


        public List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result> ObtenerCausasAsuntoPorTipoOpinionYArea
        (clsCausaAsunto pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    respuestaWeb = Db.pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea(
                        idTipoOpinion: pEntrada.IdTipoOpinion,
                        idArea: pEntrada.IdArea,
                        estatusRegistro: pEntrada.EstatusRegistro,
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
