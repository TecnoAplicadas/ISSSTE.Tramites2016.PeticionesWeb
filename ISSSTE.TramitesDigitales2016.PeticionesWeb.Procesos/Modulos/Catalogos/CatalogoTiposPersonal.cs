using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;


namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos
{
    public class CatalogoTiposPersonal
    {

        public List<pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal_Result> Obtener_TiposPersonalP(ErrorProcedimientoAlmacenado ParametrosError)
        {
            var TiposPersonal = new List<pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal_Result>();
            try
            {
                using (var Db = new TramitesDigitalesEntities())
                {
                    TiposPersonal = Db.pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal(
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
            return TiposPersonal;
        }


    }
}
