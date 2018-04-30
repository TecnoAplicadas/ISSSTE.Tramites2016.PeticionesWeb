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
   public class CrudGeneroRdn
   {
      #region Optiene Genero
      CrudGenero ProcesosCrudGenero = new CrudGenero();
      #endregion

      public List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result> solicitarGeneros(Genero pEntrada, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_Generos_Result>();
         try
         {
            #region Funcionalidad del Metodo
            respuestaWeb = ProcesosCrudGenero.obtenerGeneros(pEntrada, pError);
            #endregion
         }
         catch (Exception)
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return respuestaWeb;
      }
   }
}
