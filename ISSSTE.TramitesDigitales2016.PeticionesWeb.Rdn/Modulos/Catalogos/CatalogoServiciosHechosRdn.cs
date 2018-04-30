using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos
{
    public class CatalogoServiciosHechosRdn
    {
        CatalogoServiciosHechos procesosCatServiciosHechos = new CatalogoServiciosHechos();
        public List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result> solicitarServiciosHecho
        (clsServicioHecho pEntrada,ErrorProcedimientoAlmacenado pError)
        {
            var respuestWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechos_Result>();
            try
            {
                respuestWeb = procesosCatServiciosHechos.ObtenerServiciosHechos(pEntrada, pError);
            }
            catch(Exception)
            {
                throw;
            }
            return respuestWeb;
        }

        public List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result> ObtenerServiciosHechosPorAreaRdn
        (clsServicioHecho pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_ServiciosHechosPorArea_Result>();
            try
            {
                respuestWeb = procesosCatServiciosHechos.ObtenerServiciosHechosPorArea(pEntrada, pError);
            }
            catch (Exception)
            {
                throw;
            }
            return respuestWeb;
        }

    }
}
