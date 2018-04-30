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
    public class CatalogoUnidadesPrestadoraServicioRdn
    {
        //CatalogoUnidadesPrestadoraServicio procesosCatUndsPresServ = new CatalogoUnidadesPrestadoraServicio();
        //public List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result> solicitarUnidadPrestServ(clsUnidadPrestadoraServicio pEntrada, ErrorProcedimientoAlmacenado pError)
        //{
        //    var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result>();
        //    try
        //    {
        //        respuestaWeb = procesosCatUndsPresServ.ObtenerUndsPrestadoraServicio(pEntrada, pError);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return respuestaWeb;
        //}

        CatalogoUnidadesPrestadoraServicio procesosCatUndsPresServ = new CatalogoUnidadesPrestadoraServicio();
        public List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result> solicitarUnidadPrestServ(clsUnidadPrestadoraServicio pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_UndsPrestadoraServicios_Result>();
            try
            {
                respuestaWeb = procesosCatUndsPresServ.ObtenerUndsPrestadoraServicio(pEntrada, pError);

            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
