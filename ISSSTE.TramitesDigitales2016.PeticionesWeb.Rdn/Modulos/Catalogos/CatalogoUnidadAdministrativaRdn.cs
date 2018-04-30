using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos
{
    public class CatalogoUnidadAdministrativaRdn
    {
        CatalogoUnidadAdministrativa procesosUnidadAdm= new CatalogoUnidadAdministrativa();
        public List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result> solicitarUnidadAdministrativa(clsUnidadAdministrativa pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_UndadesAdministrativas_Result>();
            try
            {
                respuestaWeb = procesosUnidadAdm.ObtenerUnidadAdministrativa(pEntrada, pError);

            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
