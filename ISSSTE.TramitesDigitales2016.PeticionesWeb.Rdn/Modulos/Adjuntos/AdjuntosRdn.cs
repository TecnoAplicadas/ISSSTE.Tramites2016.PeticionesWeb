using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.Modelos.ClasesConcretas;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Adjuntos
{
    public class AdjuntosRdn
    {

        /// <summary>
        /// Obtiene los archivos adjuntos de una petición
        /// </summary>
        /// <param name="ParametrosEntrada"></param>
        /// <param name="ParametrosError"></param>
        /// <returns></returns>
        public List<pa_PeticionesWeb_Adjuntos_Obtener_Adjuntos_Result> Obtener_AdjuntosRdn(clsDetallePeticionArchivo ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
        {

            Procesos.Modulos.Adjuntos.Adjuntos objAdjuntosP = new Procesos.Modulos.Adjuntos.Adjuntos();

            List<pa_PeticionesWeb_Adjuntos_Obtener_Adjuntos_Result> Adjuntos = new List<pa_PeticionesWeb_Adjuntos_Obtener_Adjuntos_Result>();
            try
            {
                Adjuntos = objAdjuntosP.Obtener_AdjuntosP(ParametrosEntrada, ParametrosError);
            }
            catch (Exception)
            {
                #region Manejo de la excepcion
                throw;
                #endregion
            }
            return Adjuntos;
        }

      /// <summary>
      /// Registra el alta de un archivo adjunto de una petición
      /// </summary>
      /// <param name="ParametrosEntrada"></param>
      /// <param name="ParametrosError"></param>
      /// <returns></returns>
      public int Insertar_AdjuntoRdn(int IdUsuario, clsDetallePeticionArchivo ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
      {
         Procesos.Modulos.Adjuntos.Adjuntos objAdjuntosP = new Procesos.Modulos.Adjuntos.Adjuntos();
         int resp = 0;
         try
         {
            resp = objAdjuntosP.Insertar_AdjuntoP(IdUsuario, ParametrosEntrada, ParametrosError);
         }
         catch
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return resp;
      }

      /// <summary>
      /// Elinia el registro de un archivo adjunto de una petición
      /// </summary>
      /// <param name="ParametrosEntrada"></param>
      /// <param name="ParametrosError"></param>
      /// <returns></returns>
      public int Eliminar_AdjuntoRdn(int IdUsuario, clsDetallePeticionArchivo ParametrosEntrada, ErrorProcedimientoAlmacenado ParametrosError)
      {
         Procesos.Modulos.Adjuntos.Adjuntos objAdjuntosP = new Procesos.Modulos.Adjuntos.Adjuntos();
         int resp = 0;
         try
         {
            resp = objAdjuntosP.Eliminar_AdjuntoP(IdUsuario, ParametrosEntrada, ParametrosError);
         }
         catch
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return resp;
      }


   }
}
