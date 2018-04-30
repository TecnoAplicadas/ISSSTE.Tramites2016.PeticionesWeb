using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos
{
    public class CatalogoServiciosHechos
    {
        public List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result> ObtenerServiciosHechos
        (clsServicioHecho pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var repuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    repuestaWeb = Db.pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos(
                        pEntrada.IdServicioHecho,
                        pEntrada.EstatusRegistro,
                        pError.Numero,
                        pError.Mensaje,
                        pError.Linea,
                        pError.ProcedimientoAlmacenado,
                        pError.Severidad,
                        pError.Estado
                        ).ToList();
                }

            }
            catch(Exception)
            {
                throw;
            }
            return repuestaWeb;
        }

        public List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result> ObtenerServiciosHechosPorArea
        (clsServicioHecho pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var repuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    repuestaWeb = Db.pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea(
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
            catch (Exception)
            {
                throw;
            }
            return repuestaWeb;
        }
    }
}
