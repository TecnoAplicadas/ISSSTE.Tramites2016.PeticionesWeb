using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes
{
   public class CatalogoTableroControl
   {
      /*-----------------TABLERO DE CONTROL: CATALOGOS------------------------*/
      #region Catalogos
      //Catalogos del combo box: Por Delegaciones.
      public List<pa_PeticionesWeb_Catalogos_Obtener_DelegacionesReportesPDF_Result> obtenerDelegaciones(int pi,ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_DelegacionesReportesPDF_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Catalogos_Obtener_DelegacionesReportesPDF(
               pi_IdUsuario: pi,
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado
               ).ToList();
            }
         }
         catch
         {
            throw;
         }
         return respuestaWeb;
      }
      /*Catalogos del combo box: Por UPS.
      El catalogo por UPS, depende del elemento seleccionado en el catalogo DELEGACIONES,
      en caso contrario,el catalogo estara vacio.*/
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Ups_TableroControl_Result> obtenerUps(int? piDelegacion, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Ups_TableroControl_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Reportes_Catalogos_Obtener_Ups_TableroControl(
               pi_IdDelegacion: piDelegacion,
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado
               ).ToList();
            }
         }
         catch
         {
            throw;
         }
         return respuestaWeb;
      }
      //Catalogos del combo box: Por Causa Tipo Opinión
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_TiposOpinion_TableroControl_Result> obtenerTiposOpinion(ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_TiposOpinion_TableroControl_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Reportes_Catalogos_Obtener_TiposOpinion_TableroControl(
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado
               ).ToList();
            }
         }
         catch
         {
            throw;
         }
         return respuestaWeb;
      }
      /*Catalogos del combo box: Por Causa Asunto.
       El catalogo Causa Asunto, depende del elemento seleccionado en el catalogo TIPO OPINION,
       en caso contrario,el catalogo estara vacio.*/
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_CausaAsunto_TableroControl_Result> obtenerCausasAsunto(int? piTipoOpinion, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_CausaAsunto_TableroControl_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Reportes_Catalogos_Obtener_CausaAsunto_TableroControl(
               pi_IdCausaAsunto: piTipoOpinion,
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado
               ).ToList();
            }
         }
         catch
         {
            throw;
         }
         return respuestaWeb;
      }
      //Catalogos del combo box: Por Status
      public List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Status_TableroControl_Result> obtenerStatus(ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Reportes_Catalogos_Obtener_Status_TableroControl_Result>();
         try
         {
            using (var Db = new TramitesDigitalesEntities())
            {
               respuestaWeb = Db.pa_PeticionesWeb_Reportes_Catalogos_Obtener_Status_TableroControl(
               pi_errorNumero: pError.Numero,
               pnvc_errorMensaje: pError.Mensaje,
               pi_errorLinea: pError.Linea,
               pnvc_errorProcAlm: pError.ProcedimientoAlmacenado,
               pi_errorSeveridad: pError.Severidad,
               pi_errorEstado: pError.Estado
               ).ToList();
            }
         }
         catch
         {
            throw;
         }
         return respuestaWeb;
      }
      #endregion
   }
}
