using System;
using System.Collections.Generic;
using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.DiasNoLaborales;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.Catalogos
{
   public class CrudDiasNoLaboralesRdn
   {
      CrudDiasNoLaborales procesoCrudDiasNoLaborales = new CrudDiasNoLaborales();
      public List<pa_PeticionesWeb_Catalogos_Obtener_DiasNoLaborables_Result> solicitarDiasNoLaborables(ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_Catalogos_Obtener_DiasNoLaborables_Result>();
         try
         {
            #region Funcionalidad del Metodo
            respuestaWeb = procesoCrudDiasNoLaborales.obtenerDiasNoLaborales(pError);
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
      public List<DateTime?> existeDiaNoLaborable(DateTime? pi, ErrorProcedimientoAlmacenado pError) {
         var respuestaweb = new List<DateTime?>();
         try {
            #region Funcionalidad
            respuestaweb = procesoCrudDiasNoLaborales.obtenDiaNoLaborable(pi,pError);
            #endregion
         }
         catch (Exception){
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return respuestaweb;
      }
      public String procesoInsertarDiasNoLaborables(DiaNoLaborable pEntrada, ErrorProcedimientoAlmacenado pError)
      {
         try
         {
            #region Funcionalidad del Metodo
            procesoCrudDiasNoLaborales.insertarDiasNoLaborales(pEntrada, pError);
            #endregion
         }
         catch (Exception)
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return pError.ToString();
      }
      public String procesoEliminarDiasNoLaborables(int pEntrada, ErrorProcedimientoAlmacenado pError)
      {
         try
         {
            #region Funcionalidad del Metodo
            procesoCrudDiasNoLaborales.eliminarDiasNoLaborales(pEntrada, pError);
            #endregion
         }
         catch (Exception)
         {
            #region Manejo de la excepcion
            throw;
            #endregion
         }
         return pError.ToString();
      }

   }
}
