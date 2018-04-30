using System;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos
{
    public class CatalogoPoblacionColoniaRdn
    {
        CatalogoPoblacionColonia procesosCatPoblacionColonia= new CatalogoPoblacionColonia();
        public List<pa_PeticionesWeb_Catalogos_Obtener_PoblacionesColonias_Result> solicitarPoblacionColonia(clsPoblacionOColonia pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_PoblacionesColonias_Result>();
            try
            {
                respuestaWeb = procesosCatPoblacionColonia.ObtenerPoblacionColonia(pEntrada, pError);

            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
