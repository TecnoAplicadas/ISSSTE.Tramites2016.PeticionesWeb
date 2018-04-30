using ISSSTE.TramitesDigitales2016.Modelos.Contextos;
using ISSSTE.TramitesDigitales2016.Modelos.Modelos.ManejoErrores;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.Reportes;
using ISSSTE.TramitesDigitales2016.PeticionesWeb.Procesos.Modulos.TableroControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSSTE.TramitesDigitales2016.PeticionesWeb.Rdn.Modulos.ListarReporte
{
   public class TableroDeControlRdn
   {
      TableroDeControl tc = new TableroDeControl();

        //Metodo nuevo para peticiones

        public List<pa_PeticionesWeb_TableroControl_Obtener_Peticiones_Result1> solicitarPeticionesTableroDeControl
        (FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
        {
            var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_Peticiones_Result1>();
            try
            {
                #region funconalidad del metodo
                respuestaWeb = tc.obtenerPeticionesTableroDeControl(pi, pError);
                #endregion
            }
            catch
            {
                #region se atrapa la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        //Fin metodo nuevo peticiones

        public List<pa_PeticionesWeb_TableroControl_Obtener_IndicadoresPanelControl_Result> solicitarTableroDeControl
      (FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_IndicadoresPanelControl_Result>();
         try
         {
            #region funconalidad del metodo
            respuestaWeb = tc.obtenerTableroDeControl(pi, pError);
            #endregion
         }
         catch
         {
            #region se atrapa la excepcion
            throw;
            #endregion
         }
         return respuestaWeb;
      }
      public List<pa_PeticionesWeb_TableroControl_Obtener_PuntosControl_Result> solicitarPuntoDeControl
      (FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
      {
         var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_PuntosControl_Result>();
         try
         {
            #region funconalidad del metodo
            respuestaWeb = tc.obtenerPuntoDeControl(pi, pError);
            #endregion
         }
         catch
         {
            #region se atrapa la excepcion
            throw;
            #endregion
         }
         return respuestaWeb;
      }
      public List<pa_PeticionesWeb_TableroControl_Obtener_TotalPeticionesPorEstatus_Result> solicitarEstatus
      (FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
      {
         //obtenerTotalPetciionesPorEstatus
         var respuestaWeb = new List<pa_PeticionesWeb_TableroControl_Obtener_TotalPeticionesPorEstatus_Result>();
         try
         {
            #region funconalidad del metodo
            respuestaWeb = tc.obtenerTotalPetcionesPorEstatus(pi, pError);
            #endregion
         }
         catch
         {
            #region se atrapa la excepcion
            throw;
            #endregion
         }
         return respuestaWeb;
      }


        public List<pa_PeticionesWeb_TableroDeControlGeneral_Result> ListaPeticionesTableroControlRdn
        (FiltroTableroControl Parametros, ErrorProcedimientoAlmacenado pError)
        {
            //obtenerTotalPetciionesPorEstatus
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeControlGeneral_Result>();
            try
            {
                #region funconalidad del metodo
                respuestaWeb = tc.ListaPeticionesTableroControl(Parametros ,pError);
                #endregion
            }
            catch
            {
                #region se atrapa la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        public List<pa_PeticionesWeb_TableroDeControlConfiguracionDias_Result> ListaParanetrosDiasTableroControlRdn
        (FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
        {
            //obtenerTotalPetciionesPorEstatus
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeControlConfiguracionDias_Result>();
            try
            {
                #region funconalidad del metodo
                respuestaWeb = tc.ListaParanetrosDiasTableroControl(pError);
                #endregion
            }
            catch
            {
                #region se atrapa la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }


        public List<pa_PeticionesWeb_TableroDeEncabazadosDetalle_Result> ListaTableroDeEncabazadosDetalleRdn
        (FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
        {
            //obtenerTotalPetciionesPorEstatus
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeEncabazadosDetalle_Result>();
            try
            {
                #region funconalidad del metodo
                respuestaWeb = tc.ListaTableroDeEncabazadosDetalle(pError);
                #endregion
            }
            catch
            {
                #region se atrapa la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

        public List<pa_PeticionesWeb_TableroDeEncabazadosEstadisticas_Result> EncabezadosEstadisticasRdn
        (FiltroTableroControl pi, ErrorProcedimientoAlmacenado pError)
        {
            //obtenerTotalPetciionesPorEstatus
            var respuestaWeb = new List<pa_PeticionesWeb_TableroDeEncabazadosEstadisticas_Result>();
            try
            {
                #region funconalidad del metodo
                respuestaWeb = tc.EncabezadosEstadisticas(pError);
                #endregion
            }
            catch
            {
                #region se atrapa la excepcion
                throw;
                #endregion
            }
            return respuestaWeb;
        }

    }
}
