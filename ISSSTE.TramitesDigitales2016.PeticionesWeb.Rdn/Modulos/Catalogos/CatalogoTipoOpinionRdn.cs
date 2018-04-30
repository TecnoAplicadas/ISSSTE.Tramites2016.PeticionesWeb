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
    public class CatalogoTipoOpinionRdn
    {
        CatalogoTipoOpinion procesosCatTipoOpinion= new CatalogoTipoOpinion();
        public List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result> solicitarTipoOpinion(clsTipoOpinion pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_TiposOpinion_Result>();
            try
            {
                respuestaWeb = procesosCatTipoOpinion.ObtenerTipoOpinion(pEntrada, pError);

            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
