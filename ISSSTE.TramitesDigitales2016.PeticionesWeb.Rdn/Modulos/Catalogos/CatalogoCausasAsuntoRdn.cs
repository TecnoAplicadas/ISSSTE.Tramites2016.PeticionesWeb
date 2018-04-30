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
    public class CatalogoCausasAsuntoRdn
    {
        CatalogoCausasAsunto procesosCatCausasAsunto = new CatalogoCausasAsunto();
        public List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result> solicitarCausasAsunto
        (clsCausaAsunto pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsunto_Result>();
            try
            {
                respuestaWeb = procesosCatCausasAsunto.ObtenerCausasAsunto(pEntrada, pError);

            }
            catch(Exception)
            {
                throw;
            }
            return respuestaWeb;
        }

        public List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result> obtenerCausasAsuntoPorTipoOpinionYArea
        (clsCausaAsunto pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_CausasAsuntoPorTipoOpinionYArea_Result>();
            try
            {
                respuestaWeb = procesosCatCausasAsunto.ObtenerCausasAsuntoPorTipoOpinionYArea(pEntrada, pError);

            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }
    }
}
