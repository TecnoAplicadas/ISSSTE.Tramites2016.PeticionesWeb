using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos
{
    public class CatalogoTipoDerechoHabienteRdn
    {
        CatalogoTipoDerechoHabiente procesosCatTipoDerechoHabiente = new CatalogoTipoDerechoHabiente();
        public List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result> solicitarTipoDerechohabiente(clsTipoDerechoHabiente pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_TiposDerhabiente_Result>();
            try
            {
                respuestaWeb = procesosCatTipoDerechoHabiente.ObtenerTipoDerechoHabiente(pEntrada, pError);

            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
