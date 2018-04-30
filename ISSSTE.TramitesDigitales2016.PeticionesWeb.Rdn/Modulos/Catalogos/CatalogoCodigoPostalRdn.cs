using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos
{
    public class CatalogoCodigoPostalRdn
    {
        CatalogoCodigoPostal procesosCatCodigoPostal = new CatalogoCodigoPostal();
        public List<pa_PeticionesWeb_Catalogos_Obtener_CodigosPostales_Result> solicitarCodigoPostal(CodigoPostal pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_CodigosPostales_Result>();
            try
            {
                respuestaWeb = procesosCatCodigoPostal.ObtenerCodigoPostal(pEntrada, pError);

            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }

        /// <summary>
        /// Obtiene el estado por medio del Codigo Postal
        /// </summary>
        CatalogoEstado ObtenerEstadoCP = new CatalogoEstado();
        public List<pa_PeticionesWeb_Catalogos_Obtener_EstadoByCodigoPostal_Result> solicitarEstadoCP(clsCodigoPostal pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_EstadoByCodigoPostal_Result>();
            try
            {
                respuestaWeb = ObtenerEstadoCP.ObtenerEstadoCP(pEntrada, pError);
            }
            catch (Exception)
            {

                throw;
            }
            return respuestaWeb;
        }

        /// <summary>
        /// Obtiene el Municipio por medio del Codigo Postal
        /// </summary>
        CatalogoMunicipio ObtenerMunicipioCP = new CatalogoMunicipio();

        public List<pa_PeticionesWeb_Catalogos_Obtener_MunicipioByCodigoPostal_Result> solicitarMunicipioCP(clsCodigoPostal pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_MunicipioByCodigoPostal_Result>();
            try
            {
                respuestaWeb = ObtenerMunicipioCP.ObtenerMunicipioCP(pEntrada, pError);
            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }

        /// <summary>
        /// Obtiene La poblacion o colonia por medio del Codigo Postal
        /// </summary>
        CatalogoPoblacionColonia obtenerPobColCP = new CatalogoPoblacionColonia();
        public List<pa_PeticionesWeb_Catalogos_Obtener_PoblacionesOColoniasByCodigoPostal_Result> solicitarPobColCP(clsCodigoPostal pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaweb = new List<pa_PeticionesWeb_Catalogos_Obtener_PoblacionesOColoniasByCodigoPostal_Result>();
            try
            {
                respuestaweb = obtenerPobColCP.ObtenerPoblacionColoniaCP(pEntrada, pError);
            }
            catch (Exception)
            {

                throw;
            }
            return respuestaweb;
        }
    }
}
