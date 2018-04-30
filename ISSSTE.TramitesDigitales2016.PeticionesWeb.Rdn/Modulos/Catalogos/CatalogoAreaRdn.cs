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
    public class CatalogoAreaRdn
    {
        CatalogoArea procesosArea = new CatalogoArea();
        public List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result> ObtenerAreas
        (clsArea pEntrada, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_Areas_Result>();
            try
            {
                respuestaWeb = procesosArea.ObtenerAreas(pEntrada, pError);
            }
            catch (Exception)
            {
                throw;
            }
            return respuestaWeb;
        }

    }
}
