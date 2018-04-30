using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos
{
    public class CatalogoTiposPersonalRdn
    {
        public List<pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal_Result> Obtener_TiposPersonalRdn(ErrorProcedimientoAlmacenado ParametrosError)
        {
            Procesos.Modulos.Catalogos.CatalogoTiposPersonal objTiposPersonalP = new Procesos.Modulos.Catalogos.CatalogoTiposPersonal();

            List<pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal_Result> TiposPersonal = new List<pa_PeticionesWeb_Catalogos_Obtener_TiposPersonal_Result>();
            try
            {
                TiposPersonal = objTiposPersonalP.Obtener_TiposPersonalP(ParametrosError);
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return TiposPersonal;
        }

    }
}
