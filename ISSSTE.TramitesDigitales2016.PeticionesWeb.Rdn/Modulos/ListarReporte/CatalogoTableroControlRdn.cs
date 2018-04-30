using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte
{
    public class CatalogoTableroControlRdn
    {
      #region GeneraListaUps
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Ups_TableroControl_Result> solicitarUps(int? piDelegacion, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Ups_TableroControl_Result>();
         try
         {
            #region Funcionalidad del Metodo
            respuestaWeb = procesosGeneraCatalogo.obtenerUps(piDelegacion, pError);
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
      #endregion

      #region GeneraListaTipoOpinion
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_TiposOpinion_TableroControl_Result> solicitarTipoOpinion(ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_TiposOpinion_TableroControl_Result>();
         try
         {
            #region Funcionalidad del Metodo
            respuestaWeb = procesosGeneraCatalogo.obtenerTiposOpinion(pError);
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
      #endregion

      #region GeneraInstanciaCatalogosTablero
      CatalogoTableroControl procesosGeneraCatalogo = new CatalogoTableroControl();
      #endregion

      #region GeneraListaDelegaciones
      public List<pa_PeticionesWeb_Catalogos_Obtener_DelegacionesReportesPDF_Result> solicitarDelegaciones(int pi,ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_DelegacionesReportesPDF_Result>();
         try
         {
            #region Funcionalidad del Metodo
            respuestaWeb = procesosGeneraCatalogo.obtenerDelegaciones(pi,pError);
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
      #endregion

      #region GeneraListaCausaAsunto
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_CausaAsunto_TableroControl_Result> solicitarCausaAsunto(int? piTipoOpinion, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_CausaAsunto_TableroControl_Result>();
         try
         {
            #region Funcionalidad del Metodo
            respuestaWeb = procesosGeneraCatalogo.obtenerCausasAsunto(piTipoOpinion, pError);
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
      #endregion

      #region GeneraListaStatus
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Status_TableroControl_Result> solicitarStatus(ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Status_TableroControl_Result>();
         try
         {
            #region Funcionalidad del Metodo
            respuestaWeb = procesosGeneraCatalogo.obtenerStatus(pError);
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
      #endregion
   }
}
